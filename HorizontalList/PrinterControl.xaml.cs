using MaterialDesignThemes.Wpf;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HorizontalList
{
    /// <summary>
    /// Interaction logic for printerControl.xaml
    /// </summary>
    public partial class PrinterControl : UserControl
    {
        private List<string> localPrintList;
        ImageGenerator imageGenerator = new ImageGenerator();
        List<A4_Paper> paperList = new List<A4_Paper>();

        List<string> outputFiles;

        public PrinterControl()
        {
            InitializeComponent();

            localPrintList = GlobalVariables.PrintList.ToList();

            GeneratePrintFilesModel();
            outputFiles = imageGenerator.GenerateImages(paperList);

            foreach (var file in outputFiles)
            {
                GenerateXml(file);
            }
        }

        private void GeneratePrintFilesModel()
        {
            var paperCount = GlobalVariables.CalcPaperCount();

            for (int i = 0; i < paperCount; i++)
            {
                var paper = new A4_Paper();
                paper.GeneratePaper(localPrintList);
                paperList.Add(paper);
            }
        }



        private void GenerateXml(string filePath)
        {
            Grid grid = new Grid();
            Rectangle rectangle = new Rectangle();
            Image image = new Image();
            Button button = new Button();

            grid.Width = 400;

            rectangle.Height = 200;
            rectangle.VerticalAlignment = VerticalAlignment.Top;
            rectangle.Margin = new Thickness(10, 10, 10, 10);
            rectangle.RadiusX = 10;
            rectangle.RadiusY = 10;
            rectangle.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            DropShadowEffect effect = new DropShadowEffect();
            effect.BlurRadius = 15;
            effect.Direction = 0;
            effect.RenderingBias = RenderingBias.Performance;
            effect.ShadowDepth = 1;
            effect.Color = Color.FromRgb(187, 187, 187);
            rectangle.Effect = effect;

            var bitmap = new BitmapImage(new Uri(filePath));
            image.Source = bitmap;
            image.Width = 200;
            image.Margin = new Thickness(0, 35, 0, 0);
            image.VerticalAlignment = VerticalAlignment.Top;


            button.Style = Resources["PrintButtonStyle"] as Style;
            var icon = new PackIcon { Kind = PackIconKind.Printer };
            icon.Width = 30;
            icon.Height = 30;
            icon.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            button.Content = icon;

            //button.Name = "name";
            button.Click += (a, b) =>
            {
                MessageBox.Show(filePath);
            };

            StackPanel stackPanel = new StackPanel();
            stackPanel.Height = 50;

            grid.Children.Add(rectangle);
            grid.Children.Add(image);
            grid.Children.Add(button);

            PrintListContainer.Children.Add(grid);
            PrintListContainer.Children.Add(stackPanel);
        }
    }


    public class A4_Paper
    {
        public Card[] Cards { get; set; }

        public A4_Paper()
        {
            Cards = new Card[4];
        }

        public void GeneratePaper(List<string> localPrintList)
        {

            for (int i = 0; i < Cards.Length; i++)
            {
                if (localPrintList.Count == 0)
                    break;

                Card card = new Card()
                {
                    Name = localPrintList.First(),
                    Image = localPrintList.First() + ".png"
                };

                Cards[i] = card;
                localPrintList.RemoveAt(0);
            }
        }
    }
}
