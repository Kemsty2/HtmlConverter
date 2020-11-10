using HtmlConverter.Configurations;

namespace HtmlConverter.Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string html = "<div><strong>Hello</strong> World!</div>";
            const string url = "www.google.com";

            // Generate Pdf From HTML string

            Core.HtmlConverter.ConvertHtmlToPdf(new PdfConfiguration(html, "", "C:\\Users\\kemsty\\Pictures\\html.pdf"));

            // Generate Pdf From URL
            Core.HtmlConverter.ConvertUrlToPdf(new PdfConfiguration("", url, "C:\\Users\\kemsty\\Pictures\\google.pdf"));

            // Generate Pdf From HTML string
            Core.HtmlConverter.ConvertHtmlToImage(new ImageConfiguration(html, "", "C:\\Users\\kemsty\\Pictures\\html.png"));

            // Generate Pdf From URL
            Core.HtmlConverter.ConvertUrlToImage(new ImageConfiguration("", url, "C:\\Users\\kemsty\\Pictures\\html.png"));
        }
    }
}