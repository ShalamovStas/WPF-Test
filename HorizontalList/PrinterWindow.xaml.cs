using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace HorizontalList
{
    /// <summary>
    /// Interaction logic for PrintWindow.xaml
    /// </summary>
    public partial class PrinterWindow : Window
    {
        public PrinterWindow()
        {
            InitializeComponent();

            List<Card> cardsListcontrol = new List<Card>();
            
            foreach (var item in GlobalVariables.PrintList)
            {
                Card card = new Card()
                {
                    Name = item,
                    Image = "Assets/" + item + ".png"
                };
                cardsListcontrol.Add(card);
            }

            //ListViewCards.ItemsSource = cardsListcontrol;

            GridContainer.Children.Add(new PrinterControl());
        }
    }
}
