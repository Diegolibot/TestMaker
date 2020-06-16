using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media.Imaging;

namespace FirstApp.Models
{
    class ImageModel
    {
        //Main Functions
        static public byte[] BitmapToByte(BitmapImage imgBMI)
        {
            byte[] imgB;

            Image imgI;

            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(imgBMI));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);
                imgI = new Bitmap(bitmap);
            }

            imgB = ImageToByte(imgI);

            return imgB;
        }
        static public BitmapImage ByteToBitmapImage(byte[] imgB)
        {
            BitmapImage imgBMI;
            Image imgI;

            imgI = ByteToImage(imgB);
            imgBMI = ImageToBitmapImage(imgI);


            return imgBMI;
        }
        public static BitmapImage ImageFromSource(string src)
        {
            var imgI = new Bitmap(src);

            BitmapImage img = ImageToBitmapImage(imgI);

            return img;
        }


        //Passing functions
        static public byte[] ImageToByte(Image image)
        {
            // Convert Image to byte[]

            ImageConverter _imageConverter = new ImageConverter();
            byte[] imageByte = (byte[])_imageConverter.ConvertTo(image, typeof(byte[]));
         
            return imageByte;
        }
        static public Image ByteToImage(byte[] imageBytes)
        {
            // Convert byte[] to Image
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);
            return image;
        }
        static public BitmapImage ImageToBitmapImage(Image img)
        {
            BitmapImage bitmapImage = new BitmapImage();
            if (img != null)
            {
                using (var memory = new MemoryStream())
                {
                    img.Save(memory, ImageFormat.Png);
                    memory.Position = 0;

                    bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memory;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                }
            }

            return bitmapImage;
        }

    }
}
