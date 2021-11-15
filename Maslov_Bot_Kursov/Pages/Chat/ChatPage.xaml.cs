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
        }

        private void ButtonSend_Click(object sender, RoutedEventArgs e)
        {
           

                string text = "";

                if (!string.IsNullOrEmpty(MessageBox.Text))
                {

                    text = MessageBox.Text.Trim();
                }

                if (!string.IsNullOrEmpty(text))
                {

                    bool result = true;

                    if (result)
                    {
                        MessageBox.Text = "";
                    }

                }

                
            
        }
    }
}
