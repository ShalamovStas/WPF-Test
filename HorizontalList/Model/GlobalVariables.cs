using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizontalList
{
    static class GlobalVariables
    {
        static GlobalVariables()
        {
            PrintList = new List<string>();
        }

        public static string[] assets = { "11.png", "12.png", "13.png", "14.png", "15.png", "16.png", "17.png", "18.png", };
        public static string tempFolder = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + @"\Documents\Cards\";
        public static string tempFolderPrint = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + @"\Documents\Cards\Print\";

        public static List<string> PrintList { get; set; }

        public static int CalcPaperCount()
        {
            if (PrintList.Count == 0)
            {
                return 0;
            }
            int pageCount = 0;
            double temp = (PrintList.Count / 4.0);
            temp %= 1;

            pageCount = (PrintList.Count / 4);

            if (temp != 0)
                pageCount++;
            return pageCount;
        }

    }
}
