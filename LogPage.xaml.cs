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

        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            bool isValid = DatabaseHelper.CheckUser(username, password);
            if (isValid)
            {
                MessageBox.Show("Авторизация успешна!");
                MainWindow mainWindow = new MainWindow();
                mainWindow.SetCurrentUser(username);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }
    }
}