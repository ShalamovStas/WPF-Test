﻿using System;
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

        public static string[] assets = { "11.png", "12.png", "13.png", "14.png", "15.png", "16.png", "17.png", "18.png", "19.png", "20.png", "21.png", "22.png", "23.png", "24.png", "25.png", "26.png", "27.png", "28.png", "29.png", "30.png", "31.png", "32.png", "33.png", "34.png", "35.png", "36.png", "37.png", "38.png", "39.png", "40.png", "41.png", "42.png", "43.png", "44.png", "45.png", "46.png", "47.png", "48.png", "49.png", "50.png", "51.png", "52.png", "53.png", "54.png", "55.png", "56.png", "57.png", "58.png", "59.png", "60.png", "61.png", "62.png", "63.png", "64.png", "65.png", "66.png", "67.png", "68.png", "69.png", "70.png", "71.png", "72.png", "73.png", "74.png", "75.png", "76.png", "77.png", "78.png", "79.png", "80.png", "81.png", "82.png", "83.png", "84.png", "85.png", "86.png", "87.png", "88.png", "89.png", "90.png", "91.png", "92.png", "93.png", "94.png", "95.png", "96.png", "97.png", "98.png", "99.png", "100.png", "101.png", "102.png", "103.png", "104.png", "105.png", "106.png", "107.png", "108.png", "109.png", "110.png", "111.png", "112.png", "113.png", "114.png", "115.png", "116.png", "117.png", "118.png", "119.png", "120.png", "121.png", "122.png", "123.png", "124.png", "125.png", "126.png", "127.png", "128.png", "129.png", "130.png", "131.png", "132.png", "133.png", "134.png", "135.png", "136.png", "137.png", "138.png", "139.png", "140.png", "141.png", "142.png", "143.png", "144.png", "145.png", "146.png", "147.png", "148.png", "149.png", "150.png", "151.png", "152.png", "153.png", "154.png", "155.png", "156.png", "157.png", "158.png", "159.png", "160.png", "161.png", "162.png", "163.png", "164.png", "165.png", "166.png", "167.png", "168.png", "169.png", "170.png", "171.png", "172.png", "173.png", "174.png", "175.png", "176.png", "177.png", "178.png", "179.png", "180.png", "181.png", "182.png", "183.png", "184.png", "185.png", "186.png", "187.png", "188.png", "189.png", "190.png", "191.png", "192.png", "193.png", "194.png", "195.png", "196.png", "197.png", "198.png", "199.png", "200.png", "201.png", "202.png", "203.png", "204.png", "205.png", "206.png", "207.png", "208.png", "209.png", "210.png", "211.png", "212.png", "213.png", "214.png", "215.png", "216.png", "217.png", "218.png", "219.png", "220.png", "221.png", "222.png", "223.png", "224.png", "225.png", "226.png", "227.png", "228.png", "229.png", "230.png", "231.png", "232.png", "233.png", "234.png", "235.png", "236.png", "237.png", "238.png", "239.png", "240.png", "241.png", "242.png", "243.png", "244.png", "245.png" };
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
