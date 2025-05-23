using System.Windows;

namespace Technika
{
    public partial class RegisterPage : Window
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            bool success = DatabaseHelper.RegisterUser(username, password);
            if (success)
            {
                MessageBox.Show("Регистрация прошла успешно!");
                LogPage logPage = new LogPage();
                logPage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь с таким именем уже существует.");
            }
        }
    }
}