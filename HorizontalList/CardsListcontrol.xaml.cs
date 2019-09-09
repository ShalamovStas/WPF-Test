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

            List<string> fileNames = new List<string>();
            List<Card> cards = new List<Card>();

            for (int i = 0; i < GlobalVariables.assets.Length; i++)
            {
                cards.Add(new Card(ParseFileName(GlobalVariables.assets[i]), "Assets/" + GlobalVariables.assets[i]));
            }

            SaveCardsToDir();
            return cards;
        }


        private string ParseFileName(string fileName)
        {
            return fileName.Remove(fileName.Length - 4);
        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            var c = (sender as Button).Content;
            var childrens = (c as StackPanel).Children;

            var text = (childrens[1] as TextBlock).Text;

            Process objProcess = new Process();
            objProcess.StartInfo.FileName = "explorer";
            objProcess.StartInfo.Arguments = GlobalVariables.tempFolder + text + ".png";
            objProcess.Start();
        }

        private void SaveCardsToDir()
        {

            if (!Directory.Exists(GlobalVariables.tempFolder))
                Directory.CreateDirectory(GlobalVariables.tempFolder);
            
            foreach (var name in GlobalVariables.assets)
            {
                if (!File.Exists(GlobalVariables.tempFolder + name))
                {
                    var bitmap = new BitmapImage(new Uri("Assets/" + name, UriKind.Relative));

                    using (var stream = Application.GetResourceStream(new Uri("Assets/" + name, UriKind.Relative)).Stream)
                    {
                        stream.CopyTo(new FileStream(GlobalVariables.tempFolder + name, FileMode.Create));
                    }
                }
            }
        }
    }
}
