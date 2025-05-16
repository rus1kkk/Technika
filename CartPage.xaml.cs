using System.Windows;

namespace Technika
{
    public partial class CartPage : Window
    {
        public CartPage()
        {
            InitializeComponent();
            // Здесь можно добавить код для загрузки товаров в корзину
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            CheckoutPage checkoutPage = new CheckoutPage();
            checkoutPage.Show();
            this.Close();
        }
    }
}