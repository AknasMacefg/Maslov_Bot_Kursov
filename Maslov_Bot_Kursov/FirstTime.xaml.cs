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
using System.Windows.Shapes;
using Maslov_Bot_Kursov.Pages.Bot;

namespace Maslov_Bot_Kursov
{
    
    public partial class FirstTime : Window
    {
        public FirstTime()
        {
            InitializeComponent();
        }

      

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameForBot.Text != "" && Image.Text != "" && DesignBox.Text != "")
            {
                BotClass bot = new BotClass();

                bot.name = NameForBot.Text;
                bot.firstTime = true;
                bot.img = Image.Text;
                bot.design = DesignBox.Text;
                bot.CreateState();

                MessageBox.Show("Настройка прошла успешно!");
                MainWindow window = new MainWindow();
                window.Show();
                window.NameBox.Text = bot.name;

                Close();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены правильно!");
            }
            if (NameForBot.Text == "")
            {
                NameAlert.Visibility = Visibility.Visible;
            }
            else
            {
                NameAlert.Visibility = Visibility.Hidden;
            }

            if (Image.Text == "")
            {
                ImageAlert.Visibility = Visibility.Visible;
            }
            else
            {
                ImageAlert.Visibility = Visibility.Hidden;
            }

            if (DesignBox.Text == "")
            {
                DesignAlert.Visibility = Visibility.Visible;
            }
            else
            {
                DesignAlert.Visibility = Visibility.Hidden;
            }






        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
