using HtmlConverter.Configurations;
using System.IO;

namespace HtmlConverter.Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string html = "<div><strong>Hello</strong> World!</div>";
            const string url = "www.google.com";

            // Generate Pdf From HTML string

            var result = Core.HtmlConverter.ConvertHtmlToPdf(html, new PdfConfiguration());

            //  Store
            File.WriteAllBytes("C:\\Users\\kemsty\\Pictures\\html.pdf", result);

            // Generate Pdf From URL
            result = Core.HtmlConverter.ConvertUrlToPdf(url, new PdfConfiguration());

            //  Store
            File.WriteAllBytes("C:\\Users\\kemsty\\Pictures\\google.pdf", result);

            // Generate Pdf From HTML string
            result = Core.HtmlConverter.ConvertHtmlToImage(html, new ImageConfiguration());

            //  Store
            File.WriteAllBytes("C:\\Users\\kemsty\\Pictures\\html.png", result);

            // Generate Pdf From URL
            result = Core.HtmlConverter.ConvertUrlToImage(url, new ImageConfiguration());

            //  Store
            File.WriteAllBytes("C:\\Users\\kemsty\\Pictures\\google.png", result);
        }
    }
}