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
    /// Interaction logic for StartControl.xaml
    /// </summary>
    public partial class StartControl : UserControl
    {
        public delegate void SelectedHandler(int indexControl);
        public delegate void AnimationDelegate();

        public SelectedHandler Handler { get; set; }
        public AnimationDelegate AnimationItem { get; set; }

        public StartControl(SelectedHandler Handler)
        {
            InitializeComponent();
            this.Handler = Handler;
            AnimationItem = AnimateItem;
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
           // AnimateItem();
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
            Handler?.Invoke(5);
        }

        public void AnimateItem()
        {
            ColorAnimation animation = new ColorAnimation();

            DoubleAnimation opacityAnimation = new DoubleAnimation();
            opacityAnimation.From = 0.0;
            opacityAnimation.To = 0.1;
            opacityAnimation.Duration = TimeSpan.FromSeconds(0.5);

            SolidColorBrush brush_item1 = new SolidColorBrush();
            brush_item1.Color = Colors.White;
            brush_item1.Opacity = 0.1;
            Item_1.Background = brush_item1;
            Item_2.Background = brush_item1;
            Item_3.Background = brush_item1;
            Item_5.Background = brush_item1;
            brush_item1.BeginAnimation(SolidColorBrush.OpacityProperty, opacityAnimation);
        }

    }
}
