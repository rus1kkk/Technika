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
            private string currentUser = null;

        public MainWindow()
        {
            InitializeComponent();
            RootGrid.Opacity = 0;
            var sb = (System.Windows.Media.Animation.Storyboard)this.Resources["WindowShowAnimation"];
            sb.Begin(RootGrid);
            DatabaseHelper.InitializeDatabase();

            // Проверяем, что таблица создана
            if (!DatabaseHelper.TableExists("Users"))
            {
                MessageBox.Show("Ошибка: таблица Users не существует!");
            }

            CartButton.Visibility = Visibility.Collapsed;
            UserNameText.Visibility = Visibility.Collapsed;
        }

        public MainWindow(string username) : this()
        {
            SetCurrentUser(username);
        }

        public void SetCurrentUser(string username)
    {
        currentUser = username;
        if (!string.IsNullOrEmpty(username))
        {
            UserNameText.Text = $"Пользователь: {username}";
            UserNameText.Visibility = Visibility.Visible;
            CartButton.Visibility = Visibility.Visible;
            RegisterButton.Visibility = Visibility.Collapsed;
            LoginButton.Visibility = Visibility.Collapsed;
            LogoutButton.Visibility = Visibility.Visible;
        }
        else
        {
            UserNameText.Visibility = Visibility.Collapsed;
            CartButton.Visibility = Visibility.Collapsed;
            RegisterButton.Visibility = Visibility.Visible;
            LoginButton.Visibility = Visibility.Visible;
            LogoutButton.Visibility = Visibility.Collapsed;
        }
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
            ProductsPage productsPage = new ProductsPage(currentUser);
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
            CartPage cartPage = new CartPage(currentUser);
            cartPage.Show();
            this.Close();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            SetCurrentUser(null); // Сброс авторизации
        }
    }
}
