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
        string rightanswer;
        int questionscount = 1;
        public HotKeysTest()
        {
            InitializeComponent();
            Tutorial.Visibility = Visibility.Visible;
            Test.Visibility = Visibility.Hidden;
            Result.Visibility = Visibility.Hidden;
            TextsLoad();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Test.Visibility = Visibility.Visible;
            Tutorial.Visibility = Visibility.Visible;
            TextInp();
            
        }


        private void TextsLoad()
        {
            using (StreamReader sr = new StreamReader("Tests.txt"))
            {

                while (sr.EndOfStream != true)
                {
                    mass.Add(sr.ReadLine());

                }
                sr.Close();
                
            }
            return;
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
                rightanswer = vs[2];
                }
                Random rnd = new Random();
            int randnumber = rnd.Next(0, questions.Count);
                TextIn.Text = questions[randnumber];

            vs1 = answers[randnumber].Split(';');

            Radio1.Content = vs1[0];
            Radio2.Content = vs1[1];
            Radio3.Content = vs1[2];
            Radio4.Content = vs1[3];

            return;
        }

        private void ButtonEnd_Click(object sender, RoutedEventArgs e)
        {

            if (vs1[0] == rightanswer && Radio1.IsChecked == true)
            {
                rightanswers++;
            }
            if (vs1[1] == rightanswer && Radio2.IsChecked == true)
            {
                rightanswers++;
            }
            if (vs1[2] == rightanswer && Radio3.IsChecked == true)
            {
                rightanswers++;
            }
            if (vs1[3] == rightanswer && Radio4.IsChecked == true)
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
