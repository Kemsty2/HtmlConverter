---
layout: page
title: Configuration
permalink: /configuration/
nav_order: 2
---

# Configuration
{: .no_toc }

## Table of contents
{: .no_toc .text-delta }

1. TOC
{:toc}

---

## Base Configuration

To convert Html content to Pdf or Image from HtmlConverter some options need to be configured. The basic options common to both types of coversion will be listed below.

To see this configuration github look at [BaseConfiguration.cs](https://github.com/Kemsty2/HtmlConverter/blob/master/HtmlConverter/Configurations/BaseConfiguration.cs).
{: .text-left .lh-0}

```c#
public abstract class BaseConfiguration
  {
    /// <summary>
    /// This will be send to the browser as a name of the generated PDF file.
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// Path to wkhtmltopdf\wkhtmltoimage binary.
    /// Default to Windows(C:\\Program Files\\wkhtmltopdf\\bin), Linux(/usr/bin)
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

    /// <summary>
    /// Html string to convert
    /// </summary>
    public string Content {get;set;}

    /// <summary>
    /// Website url to convert
    /// </summary>
    public string Url {get;set;}

    /// <summary>
    /// Path to save the generated file
    /// </summary>
    public string OutputPath {get;set;}
  }
```

## PDF Configuration

Specific options is available when generating a PDF from HTML. These options is use to configure the PDF you want to obtain.

To see this configuration github look at [PdfConfiguration.cs](https://github.com/Kemsty2/HtmlConverter/blob/master/HtmlConverter/Configurations/PdfConfiguration.cs).
{: .text-left .lh-0}

```c#
public class PdfConfiguration : BaseConfiguration
  {
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
  }
```

### Handle Margins

With HtmlConverter, you are able to configure the margin of the PDF to generate.
To see this configuration github look at [Margins.cs](https://github.com/Kemsty2/HtmlConverter/blob/master/HtmlConverter/Options/Margings.cs).
{: .text-left .lh-0}

```c#
public class Margins
  {
    /// <summary>
    /// Page bottom margin in mm.
    /// </summary>
    [OptionFlag("-B")] public int? Bottom;

    /// <summary>
    /// Page left margin in mm.
    /// </summary>
    [OptionFlag("-L")] public int? Left;

    /// <summary>
    /// Page right margin in mm.
    /// </summary>
    [OptionFlag("-R")] public int? Right;

    /// <summary>
    /// Page top margin in mm.
    /// </summary>
    [OptionFlag("-T")] public int? Top;

    public Margins()
    {
    }

    /// <summary>
    /// Sets the page margins.
    /// </summary>
    /// <param name="top">Page top margin in mm.</param>
    /// <param name="right">Page right margin in mm.</param>
    /// <param name="bottom">Page bottom margin in mm.</param>
    /// <param name="left">Page left margin in mm.</param>
    public Margins(int top, int right, int bottom, int left)
    {
        Top = top;
        Right = right;
        Bottom = bottom;
        Left = left;
    }
  }
```

### Handle Orientation

With HtmlConverter, you are able to configure the orientation of the PDF to generate.
To see this configuration github look at [Enums.cs](https://github.com/Kemsty2/HtmlConverter/blob/master/HtmlConverter/Options/Enums.cs).
{: .text-left .lh-0}

```c#
/// <summary>
/// Page orientation.
/// </summary>
public enum Orientation
{
    Landscape,
    Portrait
}
```

### Handle Size

With HtmlConverter, you are able to configure the size of the PDF to generate.
To see this configuration github look at [Enums.cs](https://github.com/Kemsty2/HtmlConverter/blob/master/HtmlConverter/Options/Enums.cs).
{: .text-left .lh-0}

```c#
/// <summary>
/// Page size.
/// </summary>
public enum Size
{
    /// <summary>
    /// 841 x 1189 mm
    /// </summary>
    A0,

    /// <summary>
    /// 594 x 841 mm
    /// </summary>
    A1,

    /// <summary>
    /// 420 x 594 mm
    /// </summary>
    A2,

    /// <summary>
    /// 297 x 420 mm
    /// </summary>
    A3,

    /// <summary>
    /// 210 x 297 mm
    /// </summary>
    A4,

    /// <summary>
    /// 148 x 210 mm
    /// </summary>
    A5,

    /// <summary>
    /// 105 x 148 mm
    /// </summary>
    A6,

    /// <summary>
    /// 74 x 105 mm
    /// </summary>
    A7,

    /// <summary>
    /// 52 x 74 mm
    /// </summary>
    A8,

    /// <summary>
    /// 37 x 52 mm
    /// </summary>
    A9,

    /// <summary>
    /// 1000 x 1414 mm
    /// </summary>
    B0,

    /// <summary>
    /// 707 x 1000 mm
    /// </summary>
    B1,

    /// <summary>
    /// 500 x 707 mm
    /// </summary>
    B2,

    /// <summary>
    /// 353 x 500 mm
    /// </summary>
    B3,

    /// <summary>
    /// 250 x 353 mm
    /// </summary>
    B4,

    /// <summary>
    /// 176 x 250 mm
    /// </summary>
    B5,

    /// <summary>
    /// 125 x 176 mm
    /// </summary>
    B6,

    /// <summary>
    /// 88 x 125 mm
    /// </summary>
    B7,

    /// <summary>
    /// 62 x 88 mm
    /// </summary>
    B8,

    /// <summary>
    /// 33 x 62 mm
    /// </summary>
    B9,

    /// <summary>
    /// 31 x 44 mm
    /// </summary>
    B10,

    /// <summary>
    /// 163 x 229 mm
    /// </summary>
    C5E,

    /// <summary>
    /// 105 x 241 mm - U.S. Common 10 Envelope
    /// </summary>
    Comm10E,

    /// <summary>
    /// 110 x 220 mm
    /// </summary>
    Dle,

    /// <summary>
    /// 190.5 x 254 mm
    /// </summary>
    Executive,

    /// <summary>
    /// 210 x 330 mm
    /// </summary>
    Folio,

    /// <summary>
    /// 431.8 x 279.4 mm
    /// </summary>
    Ledger,

    /// <summary>
    /// 215.9 x 355.6 mm
    /// </summary>
    Legal,

    /// <summary>
    /// 215.9 x 279.4 mm
    /// </summary>
    Letter,

    /// <summary>
    /// 279.4 x 431.8 mm
    /// </summary>
    Tabloid
}

```

## ImageConfiguration

Specific options is available when generating an Image from HTML. These options is use to configure the Image you want to obtain.

To see this configuration github look at [ImageConfiguration.cs](https://github.com/Kemsty2/HtmlConverter/blob/master/HtmlConverter/Configurations/ImageConfiguration.cs).
{: .text-left .lh-0}

```c#
public class ImageConfiguration : BaseConfiguration
  {
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
  }
```

### Handle Image Format

With HtmlConverter, you are able to configure the format of the Image to generate.
To see this configuration github look at [Enums.cs](https://github.com/Kemsty2/HtmlConverter/blob/master/HtmlConverter/Options/Enums.cs).
{: .text-left .lh-0}

```c#
/// <summary>
/// Image output format
/// </summary>
public enum ImageFormat
{
    Jpg,
    Jpeg,
    Png
}
```

### Handle Cropping

With HtmlConverter, you are able crop the Image you want to generate.
To see this configuration github look at [Cropping.cs](https://github.com/Kemsty2/HtmlConverter/blob/master/HtmlConverter/Options/Cropping.cs).
{: .text-left .lh-0}

```c#
public class Cropping
  {
    /// <summary>
    /// Set height for cropping
    /// </summary>
    [OptionFlag("--crop-h")] public int? Height;

    /// <summary>
    /// Set width for cropping
    /// </summary>
    [OptionFlag("--crop-w")] public int? Width;

    /// <summary>
    /// Set x for cropping
    /// </summary>
    [OptionFlag("--crop-x")] public int? CropX;

    /// <summary>
    /// Set y for cropping
    /// </summary>
    [OptionFlag("--crop-y")] public int? CropY;

    public Cropping(){}

    public Cropping(int height, int width, int cropX, int cropY)
    {
        Height = height;
        Width = width;
        CropX = cropX;
        CropY = cropY;
    }
  }
```
