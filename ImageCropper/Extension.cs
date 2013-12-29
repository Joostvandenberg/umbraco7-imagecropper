using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Montagne.ImageCropperExtension
{
    public class ImageCrop
    {
        public string id { get; set; }
        public string x1 { get; set; }
        public string y1 { get; set; }
        public string x2 { get; set; }
        public string y2 { get; set; }
        public string widthoriginal { get; set; }
        public string heightoriginal { get; set; }
        public string widthdisplay { get; set; }
        public string heightdisplay { get; set; }
        public string compression { get; set; }
        public string processorurl { get; set; }
    }

    public static class Cropper
    {

        public static bool IsJson(this string input)
        {
            input = input.Trim();
            return input.StartsWith("{") && input.EndsWith("}") || input.StartsWith("[") && input.EndsWith("]");
        }

        public static ImageCrop GetImageCrop(this string json, string id)
        {
            ImageCrop IC = new ImageCrop();
            if (IsJson(json))
            {
                try
                {
                    List<ImageCrop> ImageCropperSettings = JsonConvert.DeserializeObject<List<ImageCrop>>(json);
                    IC = ImageCropperSettings.Where(p => p.id == id).First();
                }
                catch {  }
            }
            return IC;
        }

        public static List<ImageCrop> GetImageCrops(this string json)
        {
            List<ImageCrop> ImageCrops = new List<ImageCrop>();

            if (IsJson(json))
            {
                try
                {
                    ImageCrops = JsonConvert.DeserializeObject<List<ImageCrop>>(json);
                }
                catch
                {
                   
                }
            }
            return ImageCrops;
        }


    }
}
