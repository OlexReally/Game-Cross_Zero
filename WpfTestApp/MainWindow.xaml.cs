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
        private bool check = false;//zero always starts girst
        private int[,] board;
        public MainWindow()
        {
            InitializeComponent();

            setMatrix();
        }

        private void setMatrix()
        {
            board = new int[3, 3];
            for(int i = 0; i<3;i++)
            {
                for (int j = 0; j < 3; j++)
                    board[i, j] = 2;
            }
        }

        private void chooseBoard(int num)
        {
            int row = 0;
            int column = 0;

            row = (int)num / 3;
            column = num % 3;
            if (check)
                board[row, column] = 1;//for cross
            else
                board[row, column] = 0;//for zero
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

            chooseBoard(Int32.Parse(b.Tag.ToString())-1);

            if (check)
                b.Content = getCross();
            else
                b.Content = getZero();

            if (winCheck())
            {
                MessageBox.Show("Game over!");
                Reload();
            }
            else
            {
                check = !check;

                playerChange();
            }
        }

        private bool winCheck()
        {
            if (check)
            {
                if (crossWinCheck())
                    return true;
            }
            else if (!check)
            {
                if (zeroWinCheck())
                    return true;
            }

            return false;
        }

        private bool zeroWinCheck()//0
        {
            //!check
            if (Check(0))
                return true;
            else
                return false;
        }
        private bool crossWinCheck()//1
        {
            //check
            if (Check(1))
                return true;
            else
                return false;
        }

        private bool Check(int num)
        {
            if (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2] && board[0, 2] == num)
                return true;
            else if (board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2] && board[1, 2] == num)
                return true;
            else if (board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2] && board[2, 2] == num)
                return true;

            else if (board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0] && board[2, 0] == num)
                return true;
            else if (board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1] && board[2, 1] == num)
                return true;
            else if (board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2] && board[2, 2] == num)
                return true;

            else if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[2, 2] == num)
                return true;
            else if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[2, 0] == num)
                return true;

            return false;
        }

        private void playerChange()
        {
            if (check)
                Label1.Content = "Player: Cross";
            else
                Label1.Content = "Player: Zero";
        }

        private void click1_Button(object sender, RoutedEventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            check = false;
            Label1.Content = "Player: Zero";
            setFormToDefault();
            setMatrix();
        }

        private void setFormToDefault()
        {
            List<Button> bList = new List<Button>(10);
            
            bList.Add(Button1);
            bList.Add(Button2);
            bList.Add(Button3);
            bList.Add(Button4);
            bList.Add(Button5);
            bList.Add(Button6);
            bList.Add(Button7);
            bList.Add(Button8);
            bList.Add(Button9);
            
            foreach (var data in bList)
            {
                data.Content = "Choose";
                data.IsEnabled = true;
            }
        }
    }
}
