#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Chiseled images have no shell or package manager, so wkhtmltopdf is installed
# here on the matching Ubuntu release and copied into the final image with its libraries and fonts.
FROM ubuntu:resolute AS wkhtmltopdf

ARG DEBIAN_FRONTEND=noninteractive

RUN apt-get update \
    && apt-get install -y --no-install-recommends wget ca-certificates fontconfig fonts-dejavu-core xfonts-75dpi xfonts-base \
    && cd /tmp/ \
    && wget -q https://github.com/wkhtmltopdf/packaging/releases/download/0.12.6.1-3/wkhtmltox_0.12.6.1-3.jammy_amd64.deb \
    && apt-get install -y --no-install-recommends ./wkhtmltox_0.12.6.1-3.jammy_amd64.deb \
    && rm -rf /tmp/* /var/lib/apt/lists/*

# Collect the binaries, every shared library they link against (except glibc, which the base image provides) and the font config
RUN mkdir -p /rootfs/usr/local/bin /rootfs/usr/lib/x86_64-linux-gnu \
    && cp /usr/local/bin/wkhtmltopdf /usr/local/bin/wkhtmltoimage /rootfs/usr/local/bin/ \
    && ldd /usr/local/bin/wkhtmltopdf /usr/local/bin/wkhtmltoimage \
        | awk '/=>/ {print $3}' | sort -u \
        | grep -vE '/(libc|libm|libdl|libpthread|librt)\.so' \
        | xargs -I{} sh -c 'cp -L "{}" "/rootfs/usr/lib/x86_64-linux-gnu/$(basename "{}")"' \
    && fc-cache -f \
    && cp -a --parents /etc/fonts /usr/share/fonts /usr/share/fontconfig /var/cache/fontconfig /rootfs


FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["HtmlConverter.WebApi/HtmlConverter.WebApi.csproj", "HtmlConverter.WebApi/"]
COPY ["Directory.Packages.props", "Directory.Packages.props"]
COPY ["Directory.Build.props", "Directory.Build.props"]
RUN dotnet restore "HtmlConverter.WebApi/HtmlConverter.WebApi.csproj"
COPY . .
WORKDIR "/src/HtmlConverter.WebApi"
RUN dotnet build "HtmlConverter.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HtmlConverter.WebApi.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0-resolute-chiseled-extra AS final
COPY --from=wkhtmltopdf /rootfs/ /
ENV PATH="/usr/local/bin:/usr/bin:/bin"
WORKDIR /app
EXPOSE 8080
EXPOSE 8443
COPY --from=publish /app/publish .
USER $APP_UID
ENTRYPOINT ["dotnet", "HtmlConverter.WebApi.dll"]
