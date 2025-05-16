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

namespace Technika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Открыть страницу регистрации
            RegisterPage registerPage = new RegisterPage();
            registerPage.Show();
            this.Close();
        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            ProductsPage productsPage = new ProductsPage();
            productsPage.Show();
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Открыть страницу авторизации
            LogPage logPage = new LogPage();
            logPage.Show();
            this.Close();
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            // Открыть страницу корзины
            CartPage cartPage = new CartPage();
            cartPage.Show();
            this.Close();
        }
    }

    public partial class LogPage : Window
    {

        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика авторизации пользователя
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Здесь можно добавить код для проверки пользователя

            MessageBox.Show("Авторизация успешна!");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }

}
