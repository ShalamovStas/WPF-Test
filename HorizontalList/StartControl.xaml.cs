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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HorizontalList
{
    /// <summary>
    /// Interaction logic for StartControl.xaml
    /// </summary>
    public partial class StartControl : UserControl
    {
        public delegate void SelectedHandler(int indexControl);


        public SelectedHandler Handler { get; set; }

        public StartControl(SelectedHandler Handler)
        {
            InitializeComponent();
            this.Handler = Handler;
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // Handler?.Invoke(sender, e);
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            // Handler?.Invoke(sender, e);
        }

        private void Menu1_Click(object sender, MouseButtonEventArgs e)
        {
            Handler?.Invoke(1);
        }

        private void Menu2_Click(object sender, MouseButtonEventArgs e)
        {
            Handler?.Invoke(2);
        }

        private void Menu3_Click(object sender, MouseButtonEventArgs e)
        {
            Handler?.Invoke(3);
        }

        private void Menu4_Click(object sender, MouseButtonEventArgs e)
        {
            Handler?.Invoke(4);
        }

    }
}
