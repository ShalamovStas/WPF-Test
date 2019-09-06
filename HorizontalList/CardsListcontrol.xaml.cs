using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace HorizontalList
{
    /// <summary>
    /// Interaction logic for CardsListcontrol.xaml
    /// </summary>
    public partial class CardsListcontrol : UserControl
    {
        public CardsListcontrol()
        {
            InitializeComponent();
            var products = GetProducts();
            if (products.Count > 0)
                ListViewProducts.ItemsSource = products;
        }

        private List<Card> GetProducts()
        {



            //var files = Directory.GetFiles("../../Assets", "*.png");
            List<Card> cards = new List<Card>();
            // foreach (var filePath in files)
            // {
            //  FileInfo fileInf = new FileInfo(filePath);
            //  cards.Add(new Card(ParseFileName(fileInf.Name), fileInf.FullName));
            //}

            cards.Add(new Card(ParseFileName("11.png"), "Assets/11.png"));

            return cards;
        }


        private string ParseFileName(string fileName)
        {
            return fileName.Remove(fileName.Length - 4);
        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            //this.MyImageSource = new BitmapImage(...); //you change source of the Image

            //var item = sender.
            var c = (sender as Button).Content;
            var childrens = (c as StackPanel).Children;

            var text = (childrens[1] as TextBlock).Text;

            var bitmap = new BitmapImage(new Uri("Assets/" + text + ".png", UriKind.Relative));


            var path = System.IO.Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + @"\Documents\Cards\";

            if (!File.Exists(path + text + ".png"))
            {

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                StreamResourceInfo res = Application.GetResourceStream(new Uri("Assets/" + text + ".png", UriKind.Relative));

                using (var stream = res.Stream)
                {
                    stream.CopyTo(new FileStream(path + text + ".png", FileMode.Create));
                }
            }



            Process objProcess = new Process();
            objProcess.StartInfo.FileName = "explorer";
            objProcess.StartInfo.Arguments = path + text + ".png";

            objProcess.Start();


        }
    }
}
