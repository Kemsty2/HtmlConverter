---
layout: default
title: Pdf Examples
parent: Examples
---

# PDF Examples
{: .no_toc}

## Table of contents
{: .no_toc .text-delta }

1. TOC
{:toc}

## Render Static Html Content to PDF

```c#
var bytes = HtmlConverter.ConvertHtmlTo(new PdfConfiguration
{
    Content = @"<h1>Lorem ipsum dolor sit amet consectetuer adipiscing elit I SHOULD BE RED BY JAVASCRIPT</h1>
    <script>
        document.querySelector('h1').style.color = 'rgb(128,0,0)';
    </script>",
    OutputPath = @"C:\temp\temp.pdf"
});
```

## Render Url to PDF

```c#
HtmlConverter.ConvertUrlToPdf(new PdfConfiguration
{
    Url = "http://www.lipsum.com/",
    OutputPath = @"C:\temp\temp-url.pdf"
});
```

## Render a PDF and set others options like Quality, Page Size or Margins

```c#
HtmlConverter.ConvertHtmlTo(new PdfConfiguration
{
    IsLowQuality = false,
    PageMargins = new Margins() { Bottom = 10, Left = 10, Right = 10, Top = 10 },
    PageSize = Size.A3,
    Content = @"<h1>Lorem ipsum dolor sit amet consectetuer adipiscing elit I SHOULD BE RED BY JAVASCRIPT</h1><script>document.querySelector('h1').style.color = 'rgb(128,0,0)';</script>",
    OutputPath = @"C:\temp\sample3.pdf"
});
```
