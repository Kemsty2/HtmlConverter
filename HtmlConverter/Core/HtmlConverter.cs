using System;
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
        /// <param name="html">String containing HTML code that should be converted to PDF.</param>
        /// <param name="configuration"></param>
        /// <returns>PDF as byte array.</returns>
        public static byte[] ConvertHtmlToPdf(string html, PdfConfiguration configuration)
        {
            if (configuration != null)
                return ConvertByHtml(configuration.WkhtmlPath, configuration.GetConvertOptions(), html, WkhtmlPdfExe);
            throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Converts given HTML string to Image.
        /// </summary>
        /// <param name="html">String containing HTML code that should be converted to Image.</param>
        /// <param name="configuration"></param>
        /// <returns>PDF as byte array.</returns>
        public static byte[] ConvertHtmlToImage(string html, ImageConfiguration configuration)
        {
            if (configuration != null)
                return ConvertByHtml(configuration.WkhtmlPath, configuration.GetConvertOptions(), html, WkhtmlImageExe);
            throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Converts given Url string to PDF.
        /// </summary>
        /// <param name="url">Url of website that should be converted to PDF.</param>
        /// <param name="configuration"></param>
        /// <returns>PDF as byte array.</returns>
#pragma warning disable CA1054 // Les paramètres de type URI ne doivent pas être des chaînes
        public static byte[] ConvertUrlToPdf(string url, PdfConfiguration configuration)
#pragma warning restore CA1054 // Les paramètres de type URI ne doivent pas être des chaînes
        {
            if (configuration != null)
                return ConvertByUrl(configuration.WkhtmlPath, configuration.GetConvertOptions(), url, WkhtmlPdfExe);
            throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Converts given Url string to Image.
        /// </summary>
        /// <param name="url">Url of website that should be converted to Image.</param>
        /// <param name="configuration"></param>
        /// <returns>PDF as byte array.</returns>
#pragma warning disable CA1054 // Les paramètres de type URI ne doivent pas être des chaînes
        public static byte[] ConvertUrlToImage(string url, ImageConfiguration configuration)
#pragma warning restore CA1054 // Les paramètres de type URI ne doivent pas être des chaînes
        {
            if (configuration != null)
                return ConvertByUrl(configuration.WkhtmlPath, configuration.GetConvertOptions(), url, WkhtmlImageExe);
            throw new ArgumentNullException(nameof(configuration));
        }
    }
}