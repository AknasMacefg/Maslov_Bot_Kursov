using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;


namespace Maslov_Bot_Kursov.Pages.Menu
{
    /// <summary>
    /// Логика взаимодействия для FastTyping.xaml
    /// </summary>
    public partial class FastTypingPage : Page
    {
        int errors = 0;
        float minutes;
        float sec;
        DispatcherTimer timer = new DispatcherTimer();

        public FastTypingPage()
        {
            InitializeComponent();
            Tutorial.Visibility = Visibility.Visible;
            Game.Visibility = Visibility.Hidden;
            Result.Visibility = Visibility.Hidden;
        }

        public void GameStart()
        {
            Tutorial.Visibility = Visibility.Hidden;
            Game.Visibility = Visibility.Visible;
            TextInp();
            UserTextBox.MaxLength = TextIn.Text.Length;

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timerTick;
            timer.Start();

            void timerTick(object sender, EventArgs e)
            {
                sec++;
                if (sec > 59)
                {
                    minutes++;
                    sec = 0;
                }
             
            }
        }

        private void TextInp()
        {
            List<string> mass = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader("Texts.txt"))
                {

                    while (sr.EndOfStream != true)
                    {
                        mass.Add(sr.ReadLine());

                    }
                    sr.Close();
                    Random rnd = new Random();
                    TextIn.Text = mass[rnd.Next(0, mass.Count)];


                }
                return;
            }
            catch
            {
                NavigationService?.Navigate(new Test());
                MessageBox.Show("В корневом каталоге программы отсутсвует или не заполнен текстовый файл Texts.txt. Чтобы продолжить пользоваться данным функционалом, пожалуйста создайте и заполните файл Texts.txt в корневом каталоге программы");
            }
        } 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            ResultInfo();
        }

        private void ResultInfo()
        {
            Result.Visibility = Visibility.Visible;
            Game.Visibility = Visibility.Hidden;

            Time.Content += minutes + " минут " + sec + " секунд";

          
            Speed.Content += Math.Round((TextIn.Text.Length / (minutes + (sec / 60)))) + " знаков/мин";

            int accur = 100 - errors / (TextIn.Text.Length / 100);
            if (accur < 0)
            {
                accur = 0;
            }

                Accurance.Content += accur + " %";

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GameStart();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new FastTypingPage());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Test());
        }

        private void UserTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            char[] characters = TextIn.Text.ToCharArray();
            if (UserTextBox.Text.Length == 1)
            {
                if (UserTextBox.Text.EndsWith(characters[0]) == false)
                {
                    UserTextBox.Text = "";
                    errors++;
                }
            }
            if (UserTextBox.Text.Length > 1)
            {
                if (UserTextBox.Text.EndsWith(characters[UserTextBox.Text.Length - 1]) == false)
                {
                    UserTextBox.Text = UserTextBox.Text.Remove(UserTextBox.Text.Length - 1);
                    UserTextBox.CaretIndex = UserTextBox.Text.Length;
                    errors++;
                }
            }
           
            if (UserTextBox.Text.Length == TextIn.Text.Length)
            {
                ButtonEnd.Visibility = Visibility.Visible;
            }
        }
    }
}

