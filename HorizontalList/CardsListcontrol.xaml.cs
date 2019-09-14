using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
            // Console.WriteLine("[Line 31] " + DateTime.Now.ToString("HH:mm:ss.ff"));



            //Loaded += MyLoadedRoutedEventHandler;
            // new Thread(() =>
            // {
            //     var products = GetImages();
            //     ListViewProducts.Dispatcher.Invoke(() =>
            //     {
            //         if (products.Count > 0)
            //             ListViewProducts.ItemsSource = products;
            //
            //     });
            //
            //    // ListViewProducts.UpdateLayout();
            //
            // }).Start();
            //

            GenerateImagesViews();

        }

        private void GenerateImagesViews()
        {


            for (int i = 11; i < 246; i++)
            {
                Grid grid = new Grid();
                Rectangle rectangleBackground = new Rectangle();
                Rectangle rectangleHead = new Rectangle();
                TextBlock textBlock = new TextBlock();
                TextBlock textBlockHead = new TextBlock();
                //Button button = new Button();

                rectangleBackground.Width = 150;
                rectangleBackground.Height = 100;
                rectangleBackground.Margin = new Thickness(10, 10, 10, 10);
                rectangleBackground.Fill = new SolidColorBrush(Color.FromRgb(184, 184, 184));

                rectangleHead.Width = 150;
                rectangleHead.Height = 22;
                rectangleHead.Margin = new Thickness(10, 10, 10, 10);
                rectangleHead.VerticalAlignment = VerticalAlignment.Top;
                rectangleHead.Fill = new SolidColorBrush(Color.FromRgb(108, 108, 108));


                textBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.VerticalAlignment = VerticalAlignment.Top;
                textBlock.Margin = new Thickness(0, 45, 0, 0);
                textBlock.FontSize = 35;
                textBlock.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                textBlock.Text = i.ToString();

                textBlockHead.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                textBlockHead.HorizontalAlignment = HorizontalAlignment.Center;
                textBlockHead.VerticalAlignment = VerticalAlignment.Top;
                textBlockHead.Margin = new Thickness(10, 12, 10, 10);
                textBlockHead.FontSize = 15;
                textBlockHead.Text = "КАРТА УЧАСТКА";

                //button.Click += ButtonDelete_Click;

                grid.Children.Add(rectangleBackground);
                grid.Children.Add(rectangleHead);
                grid.Children.Add(textBlock);

                grid.Children.Add(textBlockHead);

                grid.MouseLeftButtonDown += (object sender, MouseButtonEventArgs e) =>
                {

                    Process objProcess = new Process();
                    objProcess.StartInfo.FileName = "explorer";
                    objProcess.StartInfo.Arguments = GlobalVariables.tempFolder + textBlock.Text + ".png";
                    objProcess.Start();
                };


                Container.Children.Add(grid);
            }


        }

        private void UpdateUI(List<Card> products) {
           //if (products.Count > 0)
           //    ListViewProducts.ItemsSource = products;
        }


     // private List<Card> GetImages()
     // {
     //     List<Card> cards = new List<Card>();
     //     bool needSaveCardsToTempDir = false;
     //     for (int i = 0; i < GlobalVariables.assets.Length; i++)
     //     {
     //         cards.Add(new Card(ParseFileName(GlobalVariables.assets[i]), "Assets/" + GlobalVariables.assets[i]));
     //
     //         if (!File.Exists(GlobalVariables.tempFolder + GlobalVariables.assets[i]))
     //             needSaveCardsToTempDir = true;
     //     }
     //     Thread.Sleep(1000);
     //     if (needSaveCardsToTempDir)
     //         SaveCardsToTempDir();
     //     return cards;
     // }


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


    }
}
