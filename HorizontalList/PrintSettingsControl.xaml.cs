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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HorizontalList
{
    /// <summary>
    /// Interaction logic for PrintControl.xaml
    /// </summary>
    public partial class PrintSettingsControl : UserControl
    {
        public PrintSettingsControl()
        {
            InitializeComponent();
        }



        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CardNumber.Text))
                return;

            AddCard();

        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Button clicked = (Button)sender;
            Grid grid = (Grid)clicked.Parent;
            WrapPanel wrapPanel = (WrapPanel)grid.Parent;

            Rectangle rectangle = grid.Children.OfType<Rectangle>().FirstOrDefault();
            Button btn = grid.Children.OfType<Button>().FirstOrDefault();

            ColorAnimation animation;
            animation = new ColorAnimation();
            animation.From = Color.FromRgb(159, 159, 159);
            animation.To = Colors.White;
            animation.Duration = new Duration(TimeSpan.FromMilliseconds(200));
            animation.Completed += (ns, ne) =>
            {
                wrapPanel.Children.Remove(grid);
            };

            ColorAnimation animationBtn;
            animationBtn = new ColorAnimation();
            animationBtn.From = Color.FromRgb(214, 118, 118);
            animationBtn.To = Colors.White;
            animationBtn.Duration = new Duration(TimeSpan.FromMilliseconds(200));

            grid.Children.Remove(btn);
            rectangle.Fill.BeginAnimation(SolidColorBrush.ColorProperty, animation);



            TextBlock textBlock = grid.Children.OfType<TextBlock>().FirstOrDefault();

            if (textBlock != null)
                GlobalVariables.PrintList.Remove(textBlock.Text);

            ShowPrintMessage();
            //ShowDataList();



        }

        private void DeleteAnimation_Completed(object sender, EventArgs e)
        {
            Rectangle rectangle = (Rectangle)sender;
            Grid grid = (Grid)rectangle.Parent;
            WrapPanel wrapPanel = (WrapPanel)grid.Parent;
            wrapPanel.Children.Remove(grid);
        }

        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            //ShowDataList();
            PrinterWindow printWindow = new PrinterWindow();
            printWindow.Show();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(CardNumber.Text))
                return;
            if (e.Key == Key.Enter)
                AddCard();

            ShowPrintMessage();
        }

        private void AddCard()
        {
            if (!GlobalVariables.assets.Contains(CardNumber.Text + ".png"))
            {
                ErrorMessage.Text = "Карточка не найдена!";
                return;
            }
            ErrorMessage.Text = "";

            Grid grid = new Grid();
            Rectangle rectangle = new Rectangle();
            TextBlock textBlock = new TextBlock();
            Button button = new Button();

            rectangle.Width = 150;
            rectangle.Height = 100;
            rectangle.Margin = new Thickness(10, 10, 10, 10);
            rectangle.RadiusX = 10;
            rectangle.RadiusY = 10;
            rectangle.Fill = new SolidColorBrush(Color.FromRgb(159, 159, 159));

            textBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.FontSize = 30;
            textBlock.Text = CardNumber.Text;

            button.Style = Resources["RoundedButtonStyleDelete"] as Style;
            var icon = new PackIcon { Kind = PackIconKind.DeleteEmpty };
            icon.Width = 30;
            icon.Height = 30;
            icon.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            button.Content = icon;

            //button.Name = "name";
            button.Click += ButtonDelete_Click;

            grid.Children.Add(rectangle);
            grid.Children.Add(textBlock);
            grid.Children.Add(button);

            CardsContainer.Children.Add(grid);


            GlobalVariables.PrintList.Add(CardNumber.Text);
            ShowPrintMessage();
            //ShowDataList();
            CardNumber.Text = "";
        }

        private void ShowDataList()
        {
            string dataList = "";
            foreach (var item in GlobalVariables.PrintList)
            {
                dataList += "[" + item + "] ";
            }

            MessageBox.Show(dataList);
        }

        private void ShowPrintMessage()
        {
            var paperCount = GlobalVariables.CalcPaperCount();

            PrintMessage.Text = "Печать: " + paperCount + " листов";
        }
    }
}
