using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Pipelines.HttpRequest;
using Sitecore.Resources.Media;

namespace Vitality.Website.SC.Pipelines.MediaStream
{
    public class LowResolutionImage
    {
        public void Process(GetMediaStreamPipelineArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Options.CustomOptions["lowres"]) && Convert.ToBoolean(args.Options.CustomOptions["lowres"]))
            {
                var bm = (Bitmap)Bitmap.FromStream(args.OutputStream.Stream);
                bm.SetResolution(10, 10);
                var stream = new MemoryStream();

                bm.Save(stream, ImageFormat.Png);
                args.OutputStream = new Sitecore.Resources.Media.MediaStream(stream, "png",
                  args.MediaData.MediaItem);
            }
        }
    }
}
