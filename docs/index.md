---
layout: home
title: Home
nav_order: 1
permalink: /
description: "HtmlConverter is a .Net Core wrapper of the popular C library [wkhtmltopdf](https://wkhtmltopdf.org/) which help you to convert Html to Image or PDF. HaveFun 🖖"
---

# HtmlConverter
{: .fs-9 }

HtmlConverter is a .Net Core wrapper of the popular open source library [wkhtmltopdf](https://wkhtmltopdf.org/) which help you to convert Html to Image or PDF. HaveFun 🖖
{: .fs-5 .fw-300 .text-left}

[Get started now](#getting-started){: .btn .btn-blue .fs-5 .mb-4 .mb-md-0 .mr-2 } [View it on GitHub](https://github.com/kemsty2/HtmlConverter){: .btn .fs-5 .mb-4 .mb-md-0 }

---

## Getting Started

### Dependencies

HtmlConverter is built for Asp.Net Core as a wrapper of [wkhtmltopdf](https://wkhtmltopdf.org/), an open source libray to render Html into PDF and various image formats.
For information about wkhtmltopdf you read the [docs](https://wkhtmltopdf.org/docs.html)

### Quick start : Render Html Content to Pdf

1. Install WkhtmlToPdf on your computer. To install wkhtmltopdf please follow this [link](https://wkhtmltopdf.org/downloads.html).

2. Install the nuget package

   - Package Manager

   ```powershell
   PM> Install-Package HtmlConverter
   ```

   - .Net CLI

   ```batch
   > dotnet add package HtmlConverter
   ```

3. Convert Html to PDF

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
