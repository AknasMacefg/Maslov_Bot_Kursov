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
using System.IO;

namespace Maslov_Bot_Kursov.Pages.Menu
{
    /// <summary>
    /// Логика взаимодействия для HotKeysTest.xaml
    /// </summary>
    public partial class HotKeysTest : Page
    {
        List<string> mass = new List<string>();
        int rightanswers;
        string[] vs1;
        List<string> rightanswer = new List<string>();
        string rightanswernow;
        int questionscount = 1;
        int[] alreadywere;
        public HotKeysTest()
        {
            InitializeComponent();
            Tutorial.Visibility = Visibility.Visible;
            Test.Visibility = Visibility.Hidden;
            Result.Visibility = Visibility.Hidden;
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Test.Visibility = Visibility.Visible;
            Tutorial.Visibility = Visibility.Visible;
            TextsLoad();
            
            
        }


        private void TextsLoad()
        {
            try
            {


                using (StreamReader sr = new StreamReader("Tests.txt"))
                {

                    while (sr.EndOfStream != true)
                    {
                        mass.Add(sr.ReadLine());

                    }
                    sr.Close();
                    TextInp();
                }
                return;
            }
            catch
            {
                NavigationService?.Navigate(new Test());
                MessageBox.Show("В корневом каталоге программы отсутсвует или не заполнен текстовый файл Tests.txt. Чтобы продолжить пользоваться данным функционалом, пожалуйста создайте и заполните файл Tests.txt");
                
            }
        }

        private void TextInp()
        {
            QuestionMark.Content = "Вопрос " + questionscount + ":";
            string[] vs;
            List<string> questions = new List<string>();
            List<string> answers = new List<string>();
           
            
           

                foreach (var word in mass)
                {
                    vs = word.Split(':');
                    questions.Add(vs[0]);
                    answers.Add(vs[1]);
                    rightanswer.Add(vs[2]);
                }
                Random rnd = new Random();
            int randnumber = rnd.Next(0, questions.Count);
            if (alreadywere != null)
            {
                while (true)
                {
                    int q = 0;
                    foreach (var i in alreadywere)
                    {
                        if (randnumber == i)
                        {
                            randnumber = rnd.Next(0, questions.Count);
                        }
                        else
                        {
                            q++;
                        }
                    }
                    if (q == 5)
                        break;
                }
            }
            TextIn.Text = questions[randnumber];
            rightanswernow = rightanswer[randnumber];

            vs1 = answers[randnumber].Split(';');

            Radio1.Content = vs1[0];
            Radio2.Content = vs1[1];
            Radio3.Content = vs1[2];
            Radio4.Content = vs1[3];
           
            return;
        }

        private void ButtonEnd_Click(object sender, RoutedEventArgs e)
        {

            if (vs1[0] == rightanswernow && Radio1.IsChecked == true)
            {
                rightanswers++;
            }
            if (vs1[1] == rightanswernow && Radio2.IsChecked == true)
            {
                rightanswers++;
            }
            if (vs1[2] == rightanswernow && Radio3.IsChecked == true)
            {
                rightanswers++;
            }
            if (vs1[3] == rightanswernow && Radio4.IsChecked == true)
            {
                rightanswers++;
            }


            if (questionscount == 5)
            {
                Test.Visibility = Visibility.Hidden;
                Result.Visibility = Visibility.Visible;
                ResultTask();
            }
            else
            {
                questionscount++;
                Radio1.IsChecked = false;
                Radio2.IsChecked = false;
                Radio3.IsChecked = false;
                Radio4.IsChecked = false;
                ButtonEnd.Visibility = Visibility.Hidden;
                TextInp();
            }
        }

        private void RadioButton1_Checked(object sender, RoutedEventArgs e)
        {
            ButtonEnd.Visibility = Visibility.Visible;
        }

        private void ResultTask()
        {
            AnswersResult.Content += rightanswers + " / 5";
        }

        private void RadioButton2_Checked(object sender, RoutedEventArgs e)
        {
            ButtonEnd.Visibility = Visibility.Visible;
        }

        private void RadioButton3_Checked(object sender, RoutedEventArgs e)
        {
            ButtonEnd.Visibility = Visibility.Visible;
        }

        private void RadioButton4_Checked(object sender, RoutedEventArgs e)
        {
            ButtonEnd.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new HotKeysTest());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Test());
        }
    }
}
