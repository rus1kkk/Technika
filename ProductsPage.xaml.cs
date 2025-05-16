using System.Collections.Generic;
using System.Windows;

namespace Technika
{
    public partial class ProductsPage : Window
    {
        public ProductsPage()
        {
            InitializeComponent(); // Убедитесь, что этот метод вызывается
            LoadProducts();
        }

        private void LoadProducts()
        {
            // Пример списка товаров
            var products = new List<Product>
            {
                new Product { Name = "Холодильник", Price = "50000" },
                new Product { Name = "Стиральная машина", Price = "30000" },
                new Product { Name = "Плита", Price = "25000" },
                new Product { Name = "Микроволновая печь", Price = "15000" }
            };

            ProductsListView.ItemsSource = products;
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            string filter = FilterTextBox.Text.ToLower();
            // Здесь можно добавить логику фильтрации товаров
            // Например, фильтрация по имени товара
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
}