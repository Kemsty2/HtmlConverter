---
layout: default
title: Image Examples
parent: Examples
---

# Image Examples
{: .no_toc}

## Table of contents
{: .no_toc .text-delta }

1. TOC
{:toc}

## Render Static Html Content to Image

```c#
var bytes = HtmlConverter.ConvertHtmlTo(new ImageConfiguration
{
    Content = @"<h1>Lorem ipsum dolor sit amet consectetuer adipiscing elit I SHOULD BE RED BY JAVASCRIPT</h1>
    <script>
        document.querySelector('h1').style.color = 'rgb(128,0,0)';
    </script>",
    OutputPath = @"C:\temp\temp.png"
});
```

## Render Url to Image

```c#
HtmlConverter.ConvertUrlToImage(new ImageConfiguration
{
    Url = "http://www.lipsum.com/",
    OutputPath = @"C:\temp\temp-url.png",
    Quality = 100,
    Format = ImageFormat.Png
});
```

## Render an Image and set others options like Cropping, Quality or PageSize

```c#
HtmlConverter.ConvertHtmlToImage(new ImageConfiguration
{
    Crop = new Cropping() { Height = 10, Width = 10, CropX = 10, CropY = 10 },
    Content = @"<h1>Lorem ipsum dolor sit amet consectetuer adipiscing elit I SHOULD BE RED BY JAVASCRIPT</h1><script>document.querySelector('h1').style.color = 'rgb(128,0,0)';</script>",
    OutputPath = @"C:\temp\sample3.png",
    Quality = 100,
    Format = ImageFormat.Png,
    Width = 1024,
    Height = 800
});
```
