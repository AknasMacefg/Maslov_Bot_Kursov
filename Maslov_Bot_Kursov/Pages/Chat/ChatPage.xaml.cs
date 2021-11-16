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

namespace Maslov_Bot_Kursov.Pages.Chat
{
    /// <summary>
    /// Логика взаимодействия для ChatPage.xaml
    /// </summary>
    public partial class ChatPage : Page
    {
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
            BotMessage();
           
        }

        private void MessageBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Counter.Text = MessageBox.Text.Length + "/100";
            
                
        }

        private async void BotMessage()
        {
            
            Message message = new Message();
            message.TextBox = "...";
            message.Date = Convert.ToString(DateTime.Now);
            message.Alignment = HorizontalAlignment.Left;
            await Task.Delay(2000);
            MessagesList.Items.Add(message);
        }

        
    }
}
