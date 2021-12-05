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
using Maslov_Bot_Kursov.Pages.Bot;

namespace Maslov_Bot_Kursov.Pages.Menu
{
    /// <summary>
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        BotClass bot = new BotClass();
        public SettingsPage()
        {
            InitializeComponent();
            bot.GetState();
            NameForBot.Text = bot.name;
            Image.Text = bot.img;
            DesignBox.Text = bot.design;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
         

            bot.name = NameForBot.Text;
            bot.firstTime = true;
            bot.img = Image.Text;
            bot.design = DesignBox.Text;
            bot.CreateState();

            MessageBox.Show("Изменения сохранены успешно! Изменения вступят в силу при перезапуске программы!");
            
        }

       
    }
}
