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

namespace Maslov_Bot_Kursov.Pages.Menu
{
    /// <summary>
    /// Логика взаимодействия для Test.xaml
    /// </summary>
    public partial class Test : Page
    {
        public Test()
        {
            InitializeComponent();
        }

        private void HotKeys_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new HotKeysTest());
        }

        private void FastTypingButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new FastTypingPage());
        }
    }
}
