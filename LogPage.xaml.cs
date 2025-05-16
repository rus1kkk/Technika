using System.Windows;
using System.Windows.Controls;

namespace Technika
{
    public partial class LogPage : Window
    {
        public LogPage()
        {
            InitializeComponent(); // Убедитесь, что этот метод вызывается
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text; // Убедитесь, что это имя совпадает с XAML
            string password = PasswordBox.Password; // Убедитесь, что это имя совпадает с XAML

            // Здесь можно добавить код для проверки пользователя

            MessageBox.Show("Авторизация успешна!");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}