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
            BotClass bot = new BotClass();

            bot.name = NameForBot.Text;
            bot.firstTime = true;
            bot.img = Image.Text;
            bot.design = DesignBox.Text;
            bot.CreateState();

            MessageBox.Show("Настройка прошла успешно!");
            MainWindow window = new MainWindow();
            window.Show();
            window.IsEnabled = true;
            window.NameBox.Text = bot.name;
            Application.Current.MainWindow.Close();

            Close();

           

            

            
        }
    }
}
