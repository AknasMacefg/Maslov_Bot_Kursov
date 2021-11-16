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
using Maslov_Bot_Kursov.Pages.Chat;
using Maslov_Bot_Kursov.Pages.Study;
using Maslov_Bot_Kursov.Pages.Settings;

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
            Bot botname = new Bot();
            Main.Title = botname.Name;
            NameBox.Text = botname.Name;


        }

        public class Bot
        {
            public string Name = "Alex";
            private int rep { get; set; }

    }

        private void ButtonChat_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri("Pages/Chat/ChatPage.xaml", UriKind.Relative);
        }

        private void ButtonStudy_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri("Pages/Study/StudyBook.xaml", UriKind.Relative);
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri("Pages/Settings/SettingsPage.xaml", UriKind.Relative);
        }
    }
}
