# HtmlConverter

## What is HtmlConvert

HtmlConvert is a simple .NET Core wrapper around the [WkHtmlToPdf](http://wkhtmltopdf.org) tool. Most options are exposed via a PdfConfiguration object for Pdf Conversion and ImageConfiguration object for Image Conversion , others can be specified by using Custom overrides for the configuration area you want.

Conversion setting assume you have the WkHTMLToPDF/WkHTMLToImage (x64) tool installed if not an error will be provided. You can override the Path to the tool by overridding **PdfConfiguration . WkhtmlPath** (PDF) | **ImageConfiguration . WkhtmlPath** (Image).

**You will need to install/download [WkHtmlToPdf](http://wkhtmltopdf.org), it is not embedded in the NuGet Package**

- [HtmlConverter](#htmlconverter)
  - [What is HtmlConvert](#what-is-htmlconvert)
  - [Convert HTML to PDF](#convert-html-to-pdf)
  - [Sample 1: Static HTML Content](#sample-1-static-html-content)
  - [Sample 2: Get Content from a URL](#sample-2-get-content-from-a-url)
  - [Sample 3: Quality and Page Size](#sample-3-quality-and-page-size)
  - [Convert HTML to Image](#convert-html-to-image)
  - [Sample 1: Static HTML Content (Image)](#sample-1-static-html-content-image)
  - [Sample 2: Get Content from a URL (Image)](#sample-2-get-content-from-a-url-image)
  - [Sample 3: Crop, Zoom and Page Size](#sample-3-crop-zoom-and-page-size)
  - [Configuration](#configuration)
    - [Basic Configuration (Image and Pdf)](#basic-configuration-image-and-pdf)
    - [Custom Configuration (Pdf)](#custom-configuration-pdf)
    - [Custom Configuration (Image)](#custom-configuration-image)
  - [Contributions](#contributions)
  - [Credits](#credits)

## Convert HTML to PDF

## Sample 1: Static HTML Content

```c#
    HtmlConverter.ConvertHtmlTo(new PdfConfiguration
    {
        Content = @"<h1>Lorem ipsum dolor sit amet consectetuer adipiscing elit I SHOULD BE RED BY JAVASCRIPT</h1>
        <script>
            document.querySelector('h1').style.color = 'rgb(128,0,0)';
        </script>",
        OutputPath = @"C:\temp\temp.pdf"
    });
```

## Sample 2: Get Content from a URL

```c#
    HtmlConverter.ConvertUrlToPdf(new PdfConfiguration
    {
        Url = "http://www.lipsum.com/",
        OutputPath = @"C:\temp\temp-url.pdf"
    });
```

## Sample 3: Quality and Page Size

```c#
    HtmlConverter.ConvertUrlToPdf(new PdfConfiguration
    {
        IsLowQuality = false,
        PageMargins = new Margins() { Bottom = 10, Left = 10, Right = 10, Top = 10 },
        PageSize = Size.A3,
        Content = @"<h1>Lorem ipsum dolor sit amet consectetuer adipiscing elit I SHOULD BE RED BY JAVASCRIPT</h1><script>document.querySelector('h1').style.color = 'rgb(128,0,0)';</script>",
        OutputPath = @"C:\temp\sample3.pdf"
    });
```

## Convert HTML to Image

## Sample 1: Static HTML Content (Image)
```c#
    HtmlConverter.ConvertHtmlToImage(new ImageConfiguration
    {
        Content = @"<h1>Lorem ipsum dolor sit amet consectetuer adipiscing elit I SHOULD BE RED BY JAVASCRIPT</h1>
        <script>
            document.querySelector('h1').style.color = 'rgb(128,0,0)';
        </script>",
        Quality = 100,
        Format = ImageFormat.Png,
        OutputPath = @"C:\temp\temp.pdf"
    });
```

## Sample 2: Get Content from a URL (Image)

```c#
    HtmlConverter.ConvertUrlToImage(new ImageConfiguration
    {
        Url = "http://www.lipsum.com/",
        OutputPath = @"C:\temp\temp-url.png",
        Quality = 100,
        Format = ImageFormat.Png
    });
```

## Sample 3: Crop, Zoom and Page Size

```c#
    HtmlConverter.ConvertHtmlToImage(new ImageConfiguration
    {
        Crop = new Cropping() { Height = 10, Width = 10, CropX = 10, CropY = 10 },
        Content = @"<h1>Lorem ipsum dolor sit amet consectetuer adipiscing elit I SHOULD BE RED BY JAVASCRIPT</h1><script>document.querySelector('h1').style.color = 'rgb(128,0,0)';</script>",
        OutputPath = @"C:\temp\sample3.pdf",
        Quality = 100,
        Format = ImageFormat.Png,
        Width = 1024,
        Height = 800
    });
```

## Configuration

### Basic Configuration (Image and Pdf)

```c#
        /// <summary>
        /// This will be send to the browser as a name of the generated PDF file.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Path to wkhtmltopdf\wkhtmltoimage binary.
        /// </summary>
        public string WkhtmlPath { get; set; }

        /// <summary>
        /// Sets custom headers.
        /// </summary>
        [OptionFlag("--custom-header")]
        public Dictionary<string, string> CustomHeaders { get; set; }

        /// <summary>
        /// Sets cookies.
        /// </summary>
        [OptionFlag("--cookie")]
        public Dictionary<string, string> Cookies { get; set; }

        /// <summary>
        /// Sets post values.
        /// </summary>
        [OptionFlag("--post")]
        public Dictionary<string, string> Post { get; set; }

        /// <summary>
        /// Indicates whether the page can run JavaScript.
        /// </summary>
        [OptionFlag("-n")]
        public bool IsJavaScriptDisabled { get; set; }

        /// <summary>
        /// Minimum font size.
        /// </summary>
        [OptionFlag("--minimum-font-size")]
        public int? MinimumFontSize { get; set; }

        /// <summary>
        /// Sets proxy server.
        /// </summary>
        [OptionFlag("-p")]
        public string Proxy { get; set; }

        /// <summary>
        /// HTTP Authentication username.
        /// </summary>
        [OptionFlag("--username")]
        public string UserName { get; set; }

        /// <summary>
        /// HTTP Authentication password.
        /// </summary>
        [OptionFlag("--password")]
        public string Password { get; set; }

        /// <summary>
        /// Set the default text encoding, for input
        /// </summary>
        [OptionFlag("--encoding")]
        public string Encoding { get; set; }

        /// <summary>
        /// Use this if you need another switches that are not currently supported by that module.
        /// </summary>
        [OptionFlag("")]
        public string CustomSwitches { get; set; }

        public string Content {get;set;}
        public string Url {get;set;}
        public string OutputPath {get;set;}
```

### Custom Configuration (Pdf)

```c#
        /// <summary>
        /// Sets the page size.
        /// </summary>
        [OptionFlag("-s")]
        public Size? PageSize { get; set; }

        /// <summary>
        /// Sets the page width in mm.
        /// </summary>
        /// <remarks>Has priority over <see cref="PageSize"/> but <see cref="PageHeight"/> has to be also specified.</remarks>
        [OptionFlag("--page-width")]
        public double? PageWidth { get; set; }

        /// <summary>
        /// Sets the page height in mm.
        /// </summary>
        /// <remarks>Has priority over <see cref="PageSize"/> but <see cref="PageWidth"/> has to be also specified.</remarks>
        [OptionFlag("--page-height")]
        public double? PageHeight { get; set; }

        /// <summary>
        /// Sets the page orientation.
        /// </summary>
        [OptionFlag("-O")]
        public Orientation? PageOrientation { get; set; }

        /// <summary>
        /// Sets the page margins.
        /// </summary>
        public Margins PageMargins { get; set; }

        /// <summary>
        /// Indicates whether the PDF should be generated in lower quality.
        /// </summary>
        [OptionFlag("-l")]
        public bool IsLowQuality { get; set; }

        /// <summary>
        /// Number of copies to print into the PDF file.
        /// </summary>
        [OptionFlag("--copies")]
        public int? Copies { get; set; }

        /// <summary>
        /// Indicates whether the PDF should be generated in grayscale.
        /// </summary>
        [OptionFlag("-g")]
        public bool IsGrayScale { get; set; }
```

### Custom Configuration (Image)

```c#
/// <summary>
        /// Sets the page margins.
        /// </summary>
        public Cropping Crop { get; set; }

        /// <summary>
        /// Output image quality (between 0 and 100)
        /// </summary>
        [OptionFlag("--quality")]
        public int? Quality { get; set; }

        /// <summary>
        /// Set screen width, note that this is used only as a guide line. Use --disable-smart-width to make it strict.
        /// </summary>
        [OptionFlag("--width")]
        public int? Width { get; set; }

        /// <summary>
        /// Set screen height (default is calculated from page content)
        /// </summary>
        [OptionFlag("--height")]
        public int? Height { get; set; }

        /// <summary>
        /// Output file format
        /// </summary>
        [OptionFlag("--format")]
        public ImageFormat Format { get; set; }

        /// <summary>
        /// Use this zoom factor
        /// </summary>
        [OptionFlag("--zoom")]
        public int? Zoom { get; set; }
```

## Contributions

- King Kemsty  [@kemsty2](https://twitter.com/kemsty2/)

## Credits

This project is base on

- Rotativa
- CoreHtmlToImage
