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
using System.Threading.Tasks;
using Maslov_Bot_Kursov.Pages.Bot;


namespace Maslov_Bot_Kursov.Pages.Menu
{
    /// <summary>
    /// Логика взаимодействия для ChatPage.xaml
    /// </summary>
    public partial class ChatPage : Page
    {
        BotClass bot = new BotClass();
        bool oldmessage = true;
        string oldtext;

        public ChatPage()
        {
            InitializeComponent();
            MessageBox.MaxLength = 100;
        }

        private class Message
            {

            public string TextBox { get; set; }
            public string Date { get; set; }
            public HorizontalAlignment Alignment { get; set; }

        }

      

        private void ButtonSend_Click(object sender, RoutedEventArgs e)
        {
           
            Message message = new Message();
            message.TextBox = MessageBox.Text;
            message.Date = Convert.ToString(DateTime.Now);
            message.Alignment = HorizontalAlignment.Right;

            MessagesList.Items.Add(message);
            if (oldmessage == true)
            {
                oldmessage = BotMessage(message.TextBox);

            }
            else
            {
                bot.NewMessageReg(oldtext, message.TextBox);
                oldmessage = true;
            }
            oldtext = message.TextBox;
            MessageBox.Text = "";
        }

        private void MessageBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Counter.Text = MessageBox.Text.Length + "/100";
            
                
        }

        private bool BotMessage(string userText)
        {
          
            Message message = new Message();
            var answer = bot.Chat(userText);
            bool decision = answer.Item2;
            message.TextBox = answer.Item1;
            message.Date = Convert.ToString(DateTime.Now);
            message.Alignment = HorizontalAlignment.Left;
            MessagesList.Items.Add(message);
            
            return decision;
        }

        private void ButtonChat_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ChatPage());
        }

        private void ButtonStudy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new StudyBook());
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new SettingsPage());
        }
    }
}
