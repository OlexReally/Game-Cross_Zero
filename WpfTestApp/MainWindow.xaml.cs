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

namespace WpfTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool check = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private StackPanel getCross()
        {
            Image img = new Image();
            img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/CROSS.jpg"));

            StackPanel stackPnl = new StackPanel();
            stackPnl.Orientation = Orientation.Horizontal;
            stackPnl.Margin = new Thickness(1);
            stackPnl.Children.Add(img);

            return stackPnl;
        }

        private StackPanel getZero()
        {
            Image img = new Image();
            img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Zero.jpg"));

            StackPanel stackPnl = new StackPanel();
            stackPnl.Orientation = Orientation.Horizontal;
            stackPnl.Margin = new Thickness(1);
            stackPnl.Children.Add(img);

            return stackPnl;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            Button b = sender as Button;

            b.IsEnabled = false;
            if (check)
                b.Content = getCross();
            else
                b.Content = getZero();

            check = !check;
        }

    }
}
