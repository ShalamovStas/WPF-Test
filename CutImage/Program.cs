using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

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

            //string[] filesFullPath = Directory.GetFiles(ImageFolder, "*.png");
            //
            //DirectoryInfo directoryInfo = new DirectoryInfo(ImageFolder);
            //FileInfo[] files = directoryInfo.GetFiles();
            //
            //var file = files.First();
            //CutImages(files);
            //ParseFileName(file.Name);

            var template = GenerateImageNames();
            Console.WriteLine(template);
            Console.ReadKey();
        }

        private static object GenerateImageNames()
        {
            int startIndex = 11;
            StringBuilder stringBuilder = new StringBuilder();
            //"11.png", "12.png",
            for (int i = 0; i < 246; i++)
            {
                stringBuilder.Append("\"" + startIndex + ".png\", ");
                startIndex++;
            }

            return stringBuilder.ToString();
        }

        private static void CutImages(FileInfo[] files)
        {
            foreach (var item in files)
            {
                int firstFileNameIndex = ParseFileName(item.Name);

                var img = Image.FromFile(item.FullName);
                var result = new Bitmap(1761, 1188);

                using (Graphics g = Graphics.FromImage(result))
                {
                    g.DrawImage(img, new Rectangle(-3, -3, img.Width, img.Height));
                    result.Save(ImageFolderOut + firstFileNameIndex + ".png", ImageFormat.Png);
                    firstFileNameIndex++;

                    g.DrawImage(img, new Rectangle(-1757, -3, img.Width, img.Height));
                    result.Save(ImageFolderOut + firstFileNameIndex + ".png", ImageFormat.Png);
                    firstFileNameIndex++;

                    g.DrawImage(img, new Rectangle(-3, -1184, img.Width, img.Height));
                    result.Save(ImageFolderOut + firstFileNameIndex + ".png", ImageFormat.Png);
                    firstFileNameIndex++;

                    g.DrawImage(img, new Rectangle(-1757, -1184, img.Width, img.Height));
                    result.Save(ImageFolderOut + firstFileNameIndex + ".png", ImageFormat.Png);
                    firstFileNameIndex++;
                }
            }
        }

        private static int ParseFileName(string item)
        {
            var parts = item.Split('-');
            return int.Parse(parts[0]);
        }
    }
}
