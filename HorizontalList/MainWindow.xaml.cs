using System.Windows;
using System.Windows.Controls;

namespace HorizontalList
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GridPrincipal.Children.Clear();

            StartControl startControl = new StartControl(ShowControl);
            GridPrincipal.Children.Add(startControl);
            HideLeftPanel();
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
                    HideLeftPanel();

                    ListViewMenu.SelectedItem = Item_0;
                    Title.Text = "Главное меню";
                    GridPrincipal.Children.Clear();
                    StartControl startControl = new StartControl(ShowControl);
                    //startControl.Handler = this.ListViewMenu_SelectionChanged;
                    GridPrincipal.Children.Add(startControl);
                    startControl.AnimationItem();

                    break;
                case 1:
                    ShowLeftPanel();

                    ListViewMenu.SelectedItem = Item_1;
                    Title.Text = "Карточки участков";
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new CardsListcontrol());
                    break;
                case 2:
                    ShowLeftPanel();

                    ListViewMenu.SelectedItem = Item_2;
                    Title.Text = "Карта территории";
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new MapControl());
                    break;
                case 3:
                    ShowLeftPanel();

                    ListViewMenu.SelectedItem = Item_3;
                    Title.Text = "Печать участков";
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new PrintSettingsControl());
                    break;
                case 4:
                    ShowLeftPanel();

                    ListViewMenu.SelectedItem = Item_4;
                    Title.Text = "Настройки";
                    GridPrincipal.Children.Clear();
                    break;
                case 5:
                    ShowLeftPanel();

                    ListViewMenu.SelectedItem = Item_5;
                    Application.Current.Shutdown();
                    break;
                default:
                    break;
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void HideLeftPanel()
        {
            MainColumn1.Width = new GridLength(0);
            MainColumn2.Width = new GridLength(0);
        }

        private void ShowLeftPanel()
        {
            MainColumn1.Width = new GridLength(400);
            MainColumn2.Width = new GridLength(5);
        }
    }
}
