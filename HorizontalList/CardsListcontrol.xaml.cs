using System;
using System.Collections.Generic;
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
            var files = Directory.GetFiles("../../Assets", "*.png");
            List<Card> cards = new List<Card>();
            foreach (var filePath in files)
            {
                FileInfo fileInf = new FileInfo(filePath);
                cards.Add(new Card(ParseFileName(fileInf.Name), fileInf.FullName));
            }


            return cards;
        }


        private string ParseFileName(string fileName)
        {
            return fileName.Remove(fileName.Length - 4);
        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            //this.MyImageSource = new BitmapImage(...); //you change source of the Image

            
        }
    }
}
