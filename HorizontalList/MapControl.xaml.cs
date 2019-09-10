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
    /// Interaction logic for MapControl.xaml
    /// </summary>
    public partial class MapControl : UserControl
    {
        public double X { get; set; }
        public double Y { get; set; }

        public int Count { get; set; }

        public MapControl()
        {
            InitializeComponent();

        }

        private void Map_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Point position = e.GetPosition(this);
            //X = position.X;
            //Y = position.Y;
            // Console.WriteLine("pressed = " + X);

        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            //
            //    if (e.LeftButton == MouseButtonState.Pressed)
            //    {
            //
            //        Point position = e.GetPosition(this);
            //        var scrollValue = 0.0;
            //       
            //        if (position.X - X > 0)
            //           scrollValue = 0.1;
            //        else
            //            scrollValue = -0.1;
            //
            //        Scroll.ScrollToHorizontalOffset(Scroll.HorizontalOffset + scrollValue);
            //
            //        //Console.WriteLine(scrolledValue.ToString());
            //
            //        X = Scroll.HorizontalOffset;
            //
            //        //Console.WriteLine("X - position.X = " + (X - position.X));
            //    }
        }



        private void ZoomInBtn_Click(object sender, RoutedEventArgs e)
        {
            ZoomIn();
        }

        private void ZoomOutBtn_Click(object sender, RoutedEventArgs e)
        {
            ZoomOut();
        }

        private void ZoomReloadBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Grid innerGrid = button.Parent as Grid;
            Grid outerGrid = innerGrid.Parent as Grid;

            Image.Width = outerGrid.ActualWidth - 20;
            Image.Height = outerGrid.ActualHeight - 20;
        }

        private void Window_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            bool ctrlPressed = Keyboard.IsKeyDown(Key.LeftCtrl);
            if (ctrlPressed)
            {
                if (e.Delta > 0)
                    ZoomIn();
                else
                    ZoomOut();
            }
        }

        private void ZoomIn()
        {
            Image.Height += 100;
            Image.Width += 100;
        }

        private void ZoomOut()
        {
            if (Image.Height > 100)
            {
                Image.Height -= 100;
                Image.Width -= 100;
            }
        }
    }
}
