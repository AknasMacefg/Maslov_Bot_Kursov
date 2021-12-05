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
using Maslov_Bot_Kursov.Pages.Menu;
using Maslov_Bot_Kursov.Pages.Bot;

namespace Maslov_Bot_Kursov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            BotClass bot = new BotClass();
            bot.GetState();
            if (bot.firstTime == false)
            {
                FirstTime first = new FirstTime();
                this.IsEnabled = false;
                this.Hide();
                first.Show();

            }
            NameBox.Text = bot.name;
            switch(bot.img)
            {
                case "Кот":
                    BotImage.Source = new BitmapImage(new Uri("Images/CatFace.png", UriKind.Relative));
                    break;
                case "Собака":
                    BotImage.Source = new BitmapImage(new Uri("Images/DogFace.png", UriKind.Relative));
                    break;
                case "Смайлик":
                    BotImage.Source = new BitmapImage(new Uri("Images/SmileFace.png", UriKind.Relative));
                    break;
                
            }
        }

        private void ButtonChat_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri("Pages/Menu/ChatPage.xaml", UriKind.Relative);
        }

        private void ButtonStudy_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri("Pages/Menu/StudyBook.xaml", UriKind.Relative);
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri("Pages/Menu/SettingsPage.xaml", UriKind.Relative);
        }

        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri("Pages/Menu/Test.xaml", UriKind.Relative);
        }
    }
}
