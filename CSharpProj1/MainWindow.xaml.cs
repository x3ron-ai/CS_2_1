using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace CSharpProj1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TicTacToe tictac;
        bool playing_x = false;
        public MainWindow()
        {
            InitializeComponent();
            BlockMenu();
        }
        private void AllowMenu()
        {
            pole1_1.IsEnabled = true;
            pole1_1.Content = "";
            pole1_2.IsEnabled = true;
            pole1_2.Content = "";
            pole1_3.IsEnabled = true;
            pole1_3.Content = "";
            pole2_1.IsEnabled = true;
            pole2_1.Content = "";
            pole2_2.IsEnabled = true;
            pole2_2.Content = "";
            pole2_3.IsEnabled = true;
            pole2_3.Content = "";
            pole3_1.IsEnabled = true;
            pole3_1.Content = "";
            pole3_2.IsEnabled = true;
            pole3_2.Content = "";
            pole3_3.IsEnabled = true;
            pole3_3.Content = "";
            RezTextBox.Text = "";
            tictac = new TicTacToe();
            playing_x = !playing_x;
            if (!playing_x)
            {
                BotClick(playing_x ? 1 : 2);
            }
        }
        private void BotClick(int val)
        {
            Random random = new Random();
            while (true)
            {
                int num1 = random.Next(1, 4);
                int num2 = random.Next(1, 4);
                var myBut = (Button)this.FindName($"pole{num1}_{num2}");
                if (myBut.IsEnabled)
                {
                    myBut.Content = val == 1 ? "o" : "x";
                    myBut.IsEnabled = false;
                    tictac.Click(new int[] { num1-1, num2-1 }, val);
                    return;
                }
            }
        }
        private bool getWinner()
        {
            bool end = true;
            switch (tictac.Scan())
            {
                case 3:
                    RezTextBox.Text = "Ничья!";
                    BlockMenu();
                    break;
                case 2:
                    RezTextBox.Text = "Победа X!";
                    BlockMenu();
                    break;
                case 1:
                    RezTextBox.Text = "Победа O!";
                    BlockMenu();
                    break;
                default:
                    end = false;
                    break;
            }
            return end;
        }
        private void BlockMenu()
        {
            pole1_1.IsEnabled = false;
            pole1_2.IsEnabled = false;
            pole1_3.IsEnabled = false;
            pole2_1.IsEnabled = false;
            pole2_2.IsEnabled = false;
            pole2_3.IsEnabled = false;
            pole3_1.IsEnabled = false;
            pole3_2.IsEnabled = false;
            pole3_3.IsEnabled = false;
            startButton.IsEnabled = true;
        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            AllowMenu();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button obj = sender as Button;
            string[] prepCoords = obj.Name.Replace("pole", "").Split('_');
            int[] coords = new int[2];
            coords[0] = Convert.ToInt32(prepCoords[0])-1;
            coords[1] = Convert.ToInt32(prepCoords[1])-1;
            bool clicked = tictac.Click(coords, playing_x ? 2: 1);
            var myBut = (Button)this.FindName($"pole{prepCoords[0]}_{prepCoords[1]}");
            myBut.Content = playing_x ? "x" : "o";
            myBut.IsEnabled = false;
            if (!getWinner())
            {
                BotClick(playing_x ? 1 : 2);
                getWinner();
            }
        }
    }
}
