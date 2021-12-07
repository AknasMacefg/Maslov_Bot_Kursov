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
using Maslov_Bot_Kursov;

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
            NameForBot.MaxLength = 10;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            if (NameForBot.Text != "")
            {
                bot.name = NameForBot.Text;
                bot.firstTime = true;
                bot.img = Image.Text;
                bot.design = DesignBox.Text;
                bot.CreateState();
                bot.GetState();

                var window = (Application.Current.MainWindow as MainWindow);
                window.NameBox.Text = bot.name;
                switch (bot.img)
                {
                    case "Кот":
                        window.BotImage.Source = new BitmapImage(new Uri("Images/CatFace.png", UriKind.Relative));
                        break;
                    case "Собака":
                        window.BotImage.Source = new BitmapImage(new Uri("Images/DogFace.png", UriKind.Relative));
                        break;
                    case "Смайлик":
                        window.BotImage.Source = new BitmapImage(new Uri("Images/SmileFace.png", UriKind.Relative));
                        break;

                }
                switch (bot.design)
                {
                    case "Темная тема":
                        var uri1 = new Uri("Dictionaries/DarkTheme.xaml", UriKind.Relative);
                        ResourceDictionary resourceDict1 = Application.LoadComponent(uri1) as ResourceDictionary;
                        Application.Current.Resources.Clear();
                        Application.Current.Resources.MergedDictionaries.Add(resourceDict1);
                        break;
                    case "Светлая тема":
                        var uri2 = new Uri("Dictionaries/BrightTheme.xaml", UriKind.Relative);
                        ResourceDictionary resourceDict2 = Application.LoadComponent(uri2) as ResourceDictionary;
                        Application.Current.Resources.Clear();
                        Application.Current.Resources.MergedDictionaries.Add(resourceDict2);
                        break;
                    case "Свежая мята":
                        var uri3 = new Uri("Dictionaries/FreshMint.xaml", UriKind.Relative);
                        ResourceDictionary resourceDict3 = Application.LoadComponent(uri3) as ResourceDictionary;
                        Application.Current.Resources.Clear();
                        Application.Current.Resources.MergedDictionaries.Add(resourceDict3);
                        break;

                }
                NameAlert.Visibility = Visibility.Hidden;

                MessageBox.Show("Изменения сохранены успешно!");
            }
            else
            {
                MessageBox.Show("Не все поля заполнены правильно!");
                NameAlert.Visibility = Visibility.Visible;
            }
           

           



           
            

        }

       
    }
}
