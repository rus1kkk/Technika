using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Media.Animation;

namespace Technika
{
    public partial class ProductsPage : Window
    {
        private List<Product> products;
        private string currentUser;

        public ProductsPage(string username)
        {
            InitializeComponent();
            RootGrid.Opacity = 0;
            var sb = (System.Windows.Media.Animation.Storyboard)this.Resources["WindowShowAnimation"];
            sb.Begin(RootGrid);
            currentUser = username;
            LoadProducts();
            ProductsList.ItemsSource = products;
        }

        public ProductsPage() : this(null) { }

        private void LoadProducts()
        {
            products = new List<Product>
            {
                new Product { Name = "Холодильник Samsung", Price = 450, Description = "Двухкамерный холодильник с No Frost" },
                new Product { Name = "Стиральная машина LG", Price = 350, Description = "Автоматическая стиральная машина" },
                new Product { Name = "Телевизор Sony", Price = 550, Description = "4K Smart TV" },
                new Product { Name = "Посудомоечная машина Bosch", Price = 400, Description = "Встраиваемая посудомойка" },
                new Product { Name = "Плита электрическая Electrolux", Price = 300, Description = "Электрическая плита с духовкой" },
                new Product { Name = "Микроволновая печь Panasonic", Price = 150, Description = "Микроволновка с грилем" },
                new Product { Name = "Кондиционер Daikin", Price = 350, Description = "Сплит-система" },
                new Product { Name = "Пылесос Dyson", Price = 250, Description = "Беспроводной пылесос" }
            };
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(currentUser);
            mainWindow.Show();
            this.Close();
        }

        public class CartItem
        {
            public Product Product { get; set; }
            public int Quantity { get; set; }
        }

        public static class CartManager
        {
            public static List<CartItem> CartItems { get; } = new List<CartItem>();

            public static void AddToCart(Product product)
            {
                var item = CartItems.FirstOrDefault(ci => ci.Product.Name == product.Name);
                if (item != null)
                    item.Quantity++;
                else
                    CartItems.Add(new CartItem { Product = product, Quantity = 1 });
            }

            public static void RemoveFromCart(Product product)
            {
                var item = CartItems.FirstOrDefault(ci => ci.Product.Name == product.Name);
                if (item != null)
                {
                    CartItems.Remove(item);
                }
            }

            public static void ChangeQuantity(Product product, int delta)
            {
                var item = CartItems.FirstOrDefault(ci => ci.Product.Name == product.Name);
                if (item != null)
                {
                    item.Quantity += delta;
                    if (item.Quantity <= 0)
                        CartItems.Remove(item);
                }
            }
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var product = button.DataContext as Product;
            CartManager.AddToCart(product);
            MessageBox.Show($"{product.Name} добавлен в корзину!");
        }

        public bool IsAuthorized => !string.IsNullOrEmpty(currentUser);

    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}