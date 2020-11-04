using System.Runtime.InteropServices;
using System.Text;
using HtmlConverter.Options;

namespace HtmlConverter.Configurations
{
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
        
        public ImageConfiguration()
        {
            WkhtmlPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "C:\\Program Files\\wkhtmltopdf\\bin" : "";

            Format = ImageFormat.Png;
            Quality = 100;
            Width = 1024;
        }

        public ImageConfiguration(string content = "", string url = "", string outputPath = "")
        {
            WkhtmlPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "C:\\Program Files\\wkhtmltopdf\\bin" : "";
            
            Url = url;
            Content = content;
            OutputPath = outputPath;
            Format = ImageFormat.Png;
            Quality = 100;
            Width = 1024;
        }

        public override string GetContentType()
        {
            throw new System.NotImplementedException();
        }

        public override string GetConvertOptions()
        {
            var result = new StringBuilder();

            if (Crop != null)
                result.Append(Crop);

            result.Append(" ");
            result.Append(base.GetConvertOptions());

            return result.ToString().Trim();
        }
    }
}