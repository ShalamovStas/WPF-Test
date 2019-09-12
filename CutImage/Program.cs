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

        static void Main(string[] args)
        {
            List<string> names = GenerateFileNames();

            CutImages(names);
        }

        private static void CutImages(List<string> names)
        {
            if (!Directory.Exists("D:/Out/"))
                Directory.CreateDirectory("D:/Out/");

            var nameFile = 11;
            foreach (var item in names)
            {
                var img = Image.FromFile(@"D:/Wotchtower/Участки/" + item);
                var result = new Bitmap(1763, 1190);

                using (Graphics g = Graphics.FromImage(result))
                {
                    g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
                    result.Save("D:/Out/" + nameFile + ".png", ImageFormat.Png);
                    nameFile++;

                    g.DrawImage(img, new Rectangle(-1758, 0, img.Width, img.Height));
                    result.Save("D:/Out/" + nameFile + ".png", ImageFormat.Png);
                    nameFile++;

                    g.DrawImage(img, new Rectangle(-3, -1185, img.Width, img.Height));
                    result.Save("D:/Out/" + nameFile + ".png", ImageFormat.Png);
                    nameFile++;

                    g.DrawImage(img, new Rectangle(-1758, -1185, img.Width, img.Height));
                    result.Save("D:/Out/" + nameFile + ".png", ImageFormat.Png);
                    nameFile++;
                }
            }
        }

        private static List<string> GenerateFileNames()
        {
            int firstNumberName = 11;
            int SecondNumberName = 14;
            List<string> names = new List<string>();

            for (int i = 0; i < 60; i++)
            {
                //Console.WriteLine(firstNumberName + "-" + SecondNumberName + ".png");
                names.Add(firstNumberName + "-" + SecondNumberName + ".png");
                firstNumberName += 4;
                SecondNumberName += 4;
                if (firstNumberName == 243)
                {
                    SecondNumberName = 245;
                    Console.WriteLine(firstNumberName + "-" + SecondNumberName + ".png");
                    names.Add(firstNumberName + "-" + SecondNumberName + ".png");
                    break;
                }
            }
            return names;
        }
    }
}
