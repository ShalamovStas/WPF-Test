using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows.Documents;

using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HorizontalList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int MyProperty { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            GridPrincipal.Children.Clear();

            StartControl startControl = new StartControl(ShowControl);
            GridPrincipal.Children.Add(startControl);
            //startControl.Handler = this.ListViewMenu_SelectionChanged;

            App.Current.Properties["PrintCardsList"] = new[] { "11", "12" };

        }



        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;

            if (GridPrincipal == null)
                return;
            ShowControl(index);

        }

        public void ShowControl(int control)
        {
            switch (control)
            {
                case 0:
                    Title.Text = "Главное меню";
                    GridPrincipal.Children.Clear();
                    StartControl startControl = new StartControl(ShowControl);
                    //startControl.Handler = this.ListViewMenu_SelectionChanged;
                    GridPrincipal.Children.Add(startControl);
                    break;
                case 1:
                    Title.Text = "Карточки участков";
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new CardsListcontrol());
                    break;
                case 2:
                    Title.Text = "Карта территории";
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new MapControl());
                    break;
                case 3:
                    Title.Text = "Печать участков";
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new PrintSettingsControl());
                    break;
                case 4:
                    Title.Text = "Настройки";
                    GridPrincipal.Children.Clear();
                    break;
                case 5:
                    Application.Current.Shutdown();
                    break;
                default:
                    break;
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            // Shutdown the application.
            Application.Current.Shutdown();
            // OR You can Also go for below logic
            // Environment.Exit(0);
        }

    }
}
