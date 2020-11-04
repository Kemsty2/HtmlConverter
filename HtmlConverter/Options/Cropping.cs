using System.Globalization;
using System.Linq;
using System.Text;

namespace HtmlConverter.Options
{
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

        public override string ToString()
        {
            var result = new StringBuilder();

            var fields = GetType().GetFields();
            foreach (var fi in fields)
            {
                var of = fi.GetCustomAttributes(typeof(OptionFlag), true).FirstOrDefault() as OptionFlag;
                if (of == null)
                    continue;

                var value = fi.GetValue(this);
                if (value != null)
                    result.AppendFormat(CultureInfo.InvariantCulture, " {0} {1}", of.Name, value);
            }

            return result.ToString().Trim();
        }
    }
}