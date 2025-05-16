using System.Windows;

namespace Technika
{
    public partial class CheckoutPage : Window
    {
        public CheckoutPage()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }



        private void ConfirmOrderButton_Click(object sender, RoutedEventArgs e)
        {
            string address = AddressTextBox.Text;

            // Здесь можно добавить код для обработки заказа

            MessageBox.Show("Заказ подтвержден!");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}