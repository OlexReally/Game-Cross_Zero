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
        private Color[] ColorArr;
        private int[] Pictures;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            GetColors();
            Border1.Background = new SolidColorBrush(ColorArr[new Random().Next(0, ColorArr.Length)]);
        }

        private void GetColors()
        {
            ColorArr = new Color[] {
                Colors.Black,
                Colors.Aqua,
                Colors.GreenYellow,
                Colors.Indigo,
                Colors.Beige,
                Colors.Firebrick
            };
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            GetPictures();
            Image1.Source = new BitmapImage(new Uri(@"D:\Pictures\" + new Random().Next(1,4)+ ".jpg"));
            //comment
        }

        private void GetPictures()
        {
            Pictures = new int[] {
                1,
                2,
                3,
                4
            };
        }

        private void Button3Click(object sender, RoutedEventArgs e)
        {
            Button1_Click(sender, e);
            Button2Click(sender, e);
        }
    }
}
