using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;

namespace HorizontalList
{
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

            foreach (var paper in paperList)
                GenerateXml(paper);
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

        private void GenerateXml(A4_Paper paper)
        {
            Grid outerGrid = new Grid();
            Grid innerGrid = new Grid();
            Rectangle rectangle = new Rectangle();
            //Border border = new Border();
            //Image image = new Image();
            Button buttonPrint = new Button();
            Button buttonFolder = new Button();

            outerGrid.Width = 400;

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

            #region
            //border.Width = 210;
            //border.Height = 150;
            //border.BorderThickness = new Thickness(1, 1, 1, 1);
            //border.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            //border.VerticalAlignment = VerticalAlignment.Top;
            //border.Margin = new Thickness(0, 30, 0, 0);

            //var bitmap = new BitmapImage(new Uri(filePath));
            //image.Source = bitmap;
            //image.Width = 200;
            //image.Height = 150;
            //image.VerticalAlignment = VerticalAlignment.Top;
            #endregion


            ColumnDefinition gridCol1 = new ColumnDefinition();
            ColumnDefinition gridCol2 = new ColumnDefinition();
            RowDefinition gridRow1 = new RowDefinition();
            RowDefinition gridRow2 = new RowDefinition();

            innerGrid.RowDefinitions.Add(gridRow1);
            innerGrid.RowDefinitions.Add(gridRow2);
            innerGrid.ColumnDefinitions.Add(gridCol1);
            innerGrid.ColumnDefinitions.Add(gridCol2);


            innerGrid.Width = 200;
            innerGrid.Height = 150;
            innerGrid.VerticalAlignment = VerticalAlignment.Top;
            innerGrid.Margin = new Thickness(0, 30, 0, 0); ;


            for (int i = 0; i < paper.Cards.Length; i++)
            {

                int row = 0;
                int column = 0;
                switch (i)
                {
                    case 0:
                        row = 0;
                        column = 0;
                        break;
                    case 1:
                        row = 0;
                        column = 1;
                        break;
                    case 2:
                        row = 1;
                        column = 0;
                        break;
                    case 3:
                        row = 1;
                        column = 1;
                        break;
                }
                var grid = AddCardToInnerGrid(paper.Cards[i]);
                innerGrid.Children.Add(grid);
                Grid.SetColumn(grid, column);
                Grid.SetRow(grid, row);
            }


            buttonPrint.Style = Resources["PrintButtonStyle"] as Style;
            var icon = new PackIcon { Kind = PackIconKind.Printer };
            icon.Width = 30;
            icon.Height = 30;
            icon.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            buttonPrint.Content = icon;

            //button.Name = "name";
            buttonPrint.Click += (sender, routeEventArgs) =>
            {
                var btn = sender as Button;

                btn.Style = Resources["PrintButtonStyleDone"] as Style;
                var btnIcon = new PackIcon { Kind = PackIconKind.Done };
                btnIcon.Width = 0;
                btnIcon.Height = 0;
                btnIcon.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                buttonPrint.Content = btnIcon;

                DoubleAnimation iconWidthAnimation = new DoubleAnimation();
                iconWidthAnimation.From = 0;
                iconWidthAnimation.To = 30;
                iconWidthAnimation.Duration = TimeSpan.FromMilliseconds(300);

                DoubleAnimation iconHeightAnimation = new DoubleAnimation(0, 30, TimeSpan.FromMilliseconds(300));

                iconHeightAnimation.Completed += delegate (Object c, EventArgs d)
                {
                    Process objProcess = new Process();
                    objProcess.StartInfo.FileName = "explorer";
                    objProcess.StartInfo.Arguments = GlobalVariables.tempFolderPrint + paper.PaperName;
                    objProcess.Start();
                };

                btnIcon.BeginAnimation(Image.WidthProperty, iconWidthAnimation);
                btnIcon.BeginAnimation(Image.HeightProperty, iconHeightAnimation);


            };


            buttonFolder.Style = Resources["OpenImageButtonStyle"] as Style;
            var icon_buttonFolder = new PackIcon { Kind = PackIconKind.FolderImage };
            icon_buttonFolder.Width = 25;
            icon_buttonFolder.Height = 25;
            icon_buttonFolder.Foreground = new SolidColorBrush(Color.FromRgb(136, 136, 136));
            buttonFolder.Content = icon_buttonFolder;

            //button.Name = "name"; 
            buttonFolder.Click += (a, b) =>
            {

                Process objProcess = new Process();
                objProcess.StartInfo.FileName = "explorer";
                objProcess.StartInfo.Arguments = GlobalVariables.tempFolderPrint;
                objProcess.Start();
            };

            StackPanel topMarginPanel = new StackPanel();
            topMarginPanel.Height = 10;

            StackPanel buttomMarginPanel = new StackPanel();
            buttomMarginPanel.Height = 30;

            outerGrid.Children.Add(rectangle);

            //border.Child = image;
            //outerGrid.Children.Add(border);
            outerGrid.Children.Add(buttonPrint);
            outerGrid.Children.Add(buttonFolder);
            outerGrid.Children.Add(innerGrid);

            PrintListContainer.Children.Add(topMarginPanel);
            PrintListContainer.Children.Add(outerGrid);
            PrintListContainer.Children.Add(buttomMarginPanel);

        }

        private Grid AddCardToInnerGrid(Card card)
        {
            Grid grid = new Grid();
            Rectangle rectangle0 = new Rectangle();

            rectangle0.Stroke = new SolidColorBrush(Color.FromRgb(159, 159, 159));
            rectangle0.StrokeThickness = 1;

            grid.Children.Add(rectangle0);

            if (card != null)
            {
                Rectangle rectangle1 = new Rectangle();
                TextBlock textBlock = new TextBlock();

                rectangle1.Margin = new Thickness(2, 2, 2, 2);
                rectangle1.RadiusX = 5;
                rectangle1.RadiusY = 5;
                rectangle1.Fill = new SolidColorBrush(Color.FromRgb(159, 159, 159));

                textBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.FontSize = 30;
                textBlock.Text = card.Name;

                grid.Children.Add(rectangle1);
                grid.Children.Add(textBlock);
            }

            return grid;
        }
    }

    public class A4_Paper
    {
        public Card[] Cards { get; set; }
        public string PaperName { get; set; }

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

                PaperName += card.Name;
                Cards[i] = card;
                localPrintList.RemoveAt(0);
            }
            PaperName += ".png";
        }
    }
}
