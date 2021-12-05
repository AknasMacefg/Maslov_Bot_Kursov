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
    /// Логика взаимодействия для StudyBook.xaml
    /// </summary>
    public partial class StudyBook : Page
    {
        public StudyBook()
        {
            InitializeComponent();
            TextBox.Text = "Приложение предназначено для ускорения работы пользователя при помощи:\n- общения с ботом\n- тренировки быстрого печатания текста\n- использования горячих клавиш  \n\nАвтор: \n- студент Колледжа информатики и программирования\n- группа 4ПКС-318 \n- Маслов Александр Николаевич \n\n Приложение разработано в среде Microsoft Visual Studio 2019 и написано на языке C#\n\n 05.12.2021";
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text = "На странице 'Чат' можно как общаться с ботом, так и обучать его общению. Если Бот знает ответ на ваше сообщение, то он ответит вам. В противном случае, он предложит вам самим придумать ответ на сообщение.";

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBox.Text = "На странице 'Обучение' можно поупражняться в быстрой работе с компьютером. Выбрам тему 'Проверка скоростного печатания' вы сможете проверить, насколько быстро вы печатаете текст и как часто ошибаетесь. Выбрав тему 'Обучение горячим клавишам' вы сможете побольше узнать о существующих в Windows 10 горячих клавишах, которую помогут вам более быстро работать с компьютером.";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TextBox.Text = "На странице 'Настройки' вы можете поменять как имя боту, так и его изображение, а так же цветовую гамму интерфейса приложения.";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TextBox.Text = "На странице 'Справочник' хранится информация о назначении всех кнопок в приложении, а также информация о самом приложении.";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            TextBox.Text = "Приложение предназначено для ускорения работы пользователя при помощи:\n- общения с ботом\n- тренировки быстрого печатания текста\n- использования горячих клавиш  \n\nАвтор: \n- студент Колледжа информатики и программирования\n- группа 4ПКС-318 \n- Маслов Александр Николаевич \n\n Приложение разработано в среде Microsoft Visual Studio 2019 и написано на языке C#\n\n 05.12.2021";
        }
    }
}
