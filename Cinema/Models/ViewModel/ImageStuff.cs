using ImageMagick;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Cinema.Images
{
    public class ImageStuff
    {
        //
        //Summary
        //  Check the image, resize it decrease the quality
        //
        public static MagickImage HandleImage(IFormFile image)
        {
            try
            {
       
                MagickImage output;

                var memoryStream = new MemoryStream();
                image.CopyTo(memoryStream);

                var img = System.Drawing.Image.FromStream(memoryStream);
                byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(img, typeof(byte[]));

                var NewImage = new MagickImage(bytes);
                
                NewImage.Strip();
                output = NewImage;
                return output;


            }
            catch(Exception e)
            {
                throw e;
            }
        }

    }
}
