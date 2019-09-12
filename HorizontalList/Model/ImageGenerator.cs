using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace HorizontalList
{
    class ImageGenerator
    {
        private int cutSize = 0;
        public List<string> GenerateImages(List<A4_Paper> paperList)
        {
            CreateOutputDirectory();
            RemoveFilesFromOutputFolder();

            List<string> pathFiles = new List<string>();

            foreach (var paper in paperList)
            {
                var bitmapResultPath = JoinBitmaps(paper);
                pathFiles.Add(bitmapResultPath);
            }
            return pathFiles;
        }

        private void CreateOutputDirectory()
        {
            if (!Directory.Exists(GlobalVariables.tempFolderPrint))
                Directory.CreateDirectory(GlobalVariables.tempFolderPrint);
        }

        private void RemoveFilesFromOutputFolder()
        {
            var files = Directory.GetFiles(GlobalVariables.tempFolderPrint);
            foreach (var file in files)
                File.Delete(file);
        }

        private string JoinBitmaps(A4_Paper paper)
        {
            //var fileName = GenerateFileName(paper.Cards);
            var fullPathfile = GlobalVariables.tempFolderPrint + paper.PaperName;
            var result = new Bitmap(3522, 2376);
            List<string> imgNames = new List<string>(4);
            List<Bitmap> bitmapList = new List<Bitmap>(4);

            for (int i = 0; i < 4; i++)
            {
                if (paper.Cards[i] == null)
                    break;
                imgNames.Add(paper.Cards[i].Image);
            }

            foreach (var imgName in imgNames)
            {
                bitmapList.Add(BitmapImage2Bitmap(new Uri("Assets/" + imgName, UriKind.Relative)));
            }

            int Height = bitmapList.First().Height;
            int Width = bitmapList.First().Width;

            if (File.Exists(fullPathfile))
                return fullPathfile;

            using (Graphics g = Graphics.FromImage(result))
            {

                int count = 0;
                foreach (var bitmap in bitmapList)
                {
                    if (count == 0)
                    {
                        g.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height), new Rectangle(cutSize, cutSize, bitmap.Width - 2 * cutSize, bitmap.Height - 2 * cutSize), GraphicsUnit.Pixel);
                        count++;
                        continue;
                    }
                    if (count == 1)
                    {
                        g.DrawImage(bitmap, new Rectangle(Width, 0, Width, Height), new Rectangle(cutSize, cutSize, bitmap.Width - 2 * cutSize, bitmap.Height - 2 * cutSize), GraphicsUnit.Pixel);
                        count++;
                        continue;

                    }
                    if (count == 2)
                    {
                        g.DrawImage(bitmap, new Rectangle(0, Height, Width, Height),
                    new Rectangle(cutSize, cutSize, Width - 2 * cutSize, Height - 2 * cutSize), GraphicsUnit.Pixel);
                        count++;
                        continue;

                    }
                    if (count == 3)
                    {
                        g.DrawImage(bitmap, new Rectangle(Width, Height, Width, Height),
                    new Rectangle(cutSize, cutSize, Width - 2 * cutSize, Height - 2 * cutSize), GraphicsUnit.Pixel);
                        count++;
                        continue;

                    }
                }



                result.Save(fullPathfile, ImageFormat.Png);
                g.Flush();
                g.Dispose();
                result.Dispose();
            };
            return fullPathfile;
        }

       // private object GenerateFileName(Card[] cards)
       // {
       //     var name = "";
       //     foreach (var card in cards)
       //     {
       //         if (card == null)
       //             break;
       //         name += card.Name;
       //     }
       //     return name + ".png";
       // }

        private Bitmap BitmapImage2Bitmap(Uri uri)
        {
            if (uri == null)
                return null;

            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(Application.GetResourceStream(uri).Stream));
                enc.Save(outStream);
                Bitmap bitmap = new Bitmap(outStream);
                return new Bitmap(bitmap);
            }
        }
    }
}
