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
            using (StreamReader sr = new StreamReader("Texts.txt"))
            {

                while (sr.EndOfStream != true)
                {
                    mass.Add(sr.ReadLine());

                }
                sr.Close();
                Random rnd = new Random();
                TextIn.Text = mass[rnd.Next(0,3)];

                
            }
            return;
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

            Time.Content += minutes + ":" + sec;

          
                Speed.Content += Math.Round((TextIn.Text.Length / (minutes + (sec / 60)))) + " знаков/мин";


            char[] characters = TextIn.Text.ToCharArray();
            char[] Usercharacters = UserTextBox.Text.ToCharArray();


            int i = 0;
            int errors = 0;
            if (characters.Length != Usercharacters.Length)
            {
                errors += characters.Length - Usercharacters.Length;
            }
            else
            {
                foreach (var letter in Usercharacters)
                {
                    if (letter != characters[i])
                    {
                        errors++;
                    }
                    i++;
                }
            }

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
    }
}

