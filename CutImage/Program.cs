using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace CutImage
{
    class Program
    {
        static int cutSize = 7;
        static string ImageFolder = "../../../Images";
        static string ImageFolderOut = "../../../ImagesOut/";

        static void Main(string[] args)
        {
            if (!Directory.Exists(ImageFolder))
                Directory.CreateDirectory(ImageFolder);

            if (!Directory.Exists(ImageFolderOut))
                Directory.CreateDirectory(ImageFolderOut);

            string[] files = Directory.GetFiles(ImageFolder, "*.png");
            CutImages(files);
        }

        private static void CutImages(string[] files)
        {


            var nameFile = 11;
            foreach (var item in files)
            {
                var img = Image.FromFile(item);
                var result = new Bitmap(1761, 1188);

                using (Graphics g = Graphics.FromImage(result))
                {
                    g.DrawImage(img, new Rectangle(-3, -3, img.Width, img.Height));
                    result.Save(ImageFolderOut + nameFile + ".png", ImageFormat.Png);
                    nameFile++;

                    g.DrawImage(img, new Rectangle(-1757, -3, img.Width, img.Height));
                    result.Save(ImageFolderOut + nameFile + ".png", ImageFormat.Png);
                    nameFile++;

                    g.DrawImage(img, new Rectangle(-3, -1184, img.Width, img.Height));
                    result.Save(ImageFolderOut + nameFile + ".png", ImageFormat.Png);
                    nameFile++;

                    g.DrawImage(img, new Rectangle(-1757, -1184, img.Width, img.Height));
                    result.Save(ImageFolderOut + nameFile + ".png", ImageFormat.Png);
                    nameFile++;
                }
            }
        }
    }
}
