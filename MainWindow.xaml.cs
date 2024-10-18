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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int count = 6;
        private Random random = new Random();
        private bool isPlayer1Turn = true;
        private int bulletPosition = 0;
        private const int Bullet = 6;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_play_Click(object sender, RoutedEventArgs e)
        {
            play();
        }

        private void play()
        {
            btn_play.Visibility = Visibility.Hidden;
            ishvk_roulette_label.Visibility = Visibility.Hidden;
            string player1_name = Player1_textbox.Text;
            string player2_name = Player2_textbox.Text;
            Player1_textbox.Visibility = Visibility.Hidden;
            Player2_textbox.Visibility = Visibility.Hidden;
            try_btn.Visibility = Visibility.Visible;
            hod_label.Visibility = Visibility.Visible;

            bulletPosition = random.Next(Bullet);
            UpdateTurnLabel();
        }

        private void try_btn_Click(object sender, RoutedEventArgs e)
        {
            Try();
        }

        private void Try()
        {
            count++;
            if (count != 6) {
                
                Console.WriteLine(count);
                int currentChamber = random.Next(Bullet);

                if (currentChamber == bulletPosition)
                {
                    string loser = isPlayer1Turn ? Player1_textbox.Text : Player2_textbox.Text;
                    MessageBox.Show($"{loser} Умирает! Игра окончена.");
                    ResetGame();
                }
                else
                {
                    isPlayer1Turn = !isPlayer1Turn;
                    UpdateTurnLabel();
                }
            }
            else
            {
                string loser = isPlayer1Turn ? Player1_textbox.Text : Player2_textbox.Text;
                MessageBox.Show($"{loser} Умирает! Игра окончена.");
                ResetGame();
            }
                
        }

        private void UpdateTurnLabel()
        {
            string currentPlayer = isPlayer1Turn ? Player1_textbox.Text : Player2_textbox.Text;
            hod_label.Content = $"Ход игрока: {currentPlayer}";
        }

        private void ResetGame()
        {
            btn_play.Visibility = Visibility.Visible;
            ishvk_roulette_label.Visibility = Visibility.Visible;
            Player1_textbox.Visibility = Visibility.Visible;
            Player2_textbox.Visibility = Visibility.Visible;
            try_btn.Visibility = Visibility.Hidden;
            hod_label.Visibility = Visibility.Hidden;
            isPlayer1Turn = true;
            count = 0;
        }
    }
}