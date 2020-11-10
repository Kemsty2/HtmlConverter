using System;
using System.IO;
using System.Runtime.InteropServices;
using HtmlConverter.Configurations;

namespace HtmlConverter.Core
{
    public class HtmlConverter : CoreDriver
    {
        /// <summary>
        /// wkhtmltopdf only has a .exe extension in Windows.
        /// </summary>
        private static readonly string WkhtmlPdfExe =
            RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "wkhtmltopdf.exe" : "wkhtmltopdf";

        /// <summary>
        /// wkhtmltopdf only has a .exe extension in Windows.
        /// </summary>
        private static readonly string WkhtmlImageExe =
            RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "wkhtmltoimage.exe" : "wkhtmltoimage";

        /// <summary>
        /// Converts given HTML string to PDF.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns>PDF as byte array.</returns>
        public static byte[] ConvertHtmlToPdf(PdfConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            var bytes = ConvertByHtml(configuration.WkhtmlPath, configuration.GetConvertOptions(), configuration.Content, WkhtmlPdfExe);

            Store(configuration.OutputPath, bytes);
            return bytes;
            
        }

        /// <summary>
        /// Converts given HTML string to Image.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns>PDF as byte array.</returns>
        public static byte[] ConvertHtmlToImage(ImageConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            var bytes = ConvertByHtml(configuration.WkhtmlPath, configuration.GetConvertOptions(), configuration.Content, WkhtmlImageExe);

            Store(configuration.OutputPath, bytes);
            return bytes;

        }

        /// <summary>
        /// Converts given Url string to PDF.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns>PDF as byte array.</returns>
        public static byte[] ConvertUrlToPdf(PdfConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            
            var bytes = ConvertByUrl(configuration.WkhtmlPath, configuration.GetConvertOptions(), configuration.Url, WkhtmlPdfExe);

            Store(configuration.OutputPath, bytes);
            return bytes;
        }

        /// <summary>
        /// Converts given Url string to Image.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns>PDF as byte array.</returns>
        public static byte[] ConvertUrlToImage(ImageConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            var bytes = ConvertByUrl(configuration.WkhtmlPath, configuration.GetConvertOptions(), configuration.Url, WkhtmlImageExe);

            Store(configuration.OutputPath, bytes);
            return bytes;
        }

        private static void Store(string outputPath, byte[] bytes)
        {
            if (!string.IsNullOrEmpty(outputPath))
                File.WriteAllBytes(outputPath, bytes);
        }
    }
}