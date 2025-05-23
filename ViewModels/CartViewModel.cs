using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using Technika.Commands;
using Technika.Models;

namespace Technika.ViewModels
{
    public class CartViewModel : ViewModelBase
    {
        private ObservableCollection<CartItemModel> _cartItems;
        private string _currentUser;
        private decimal _totalAmount;

        public CartViewModel(string username = null)
        {
            _currentUser = username;
            CartItems = new ObservableCollection<CartItemModel>();
            LoadCartItems();

            IncreaseQuantityCommand = new RelayCommand(ExecuteIncreaseQuantity);
            DecreaseQuantityCommand = new RelayCommand(ExecuteDecreaseQuantity);
            RemoveItemCommand = new RelayCommand(ExecuteRemoveItem);
            CheckoutCommand = new RelayCommand(ExecuteCheckout);
            HomeCommand = new RelayCommand(ExecuteHome);
        }

        public ObservableCollection<CartItemModel> CartItems
        {
            get => _cartItems;
            set => SetProperty(ref _cartItems, value);
        }

        public decimal TotalAmount
        {
            get => _totalAmount;
            set => SetProperty(ref _totalAmount, value);
        }

        public ICommand IncreaseQuantityCommand { get; }
        public ICommand DecreaseQuantityCommand { get; }
        public ICommand RemoveItemCommand { get; }
        public ICommand CheckoutCommand { get; }
        public ICommand HomeCommand { get; }

        private void LoadCartItems()
        {
            CartItems.Clear();
            if (ProductsPage.CartManager.CartItems != null)
            {
                foreach (var item in ProductsPage.CartManager.CartItems)
                {
                    CartItems.Add(new CartItemModel
                    {
                        Product = new ProductModel
                        {
                            Name = item.Product.Name,
                            Price = item.Product.Price,
                            Description = item.Product.Description
                        },
                        Quantity = item.Quantity
                    });
                }
            }
            UpdateTotalAmount();
        }

        private void UpdateTotalAmount()
        {
            decimal total = 0;
            foreach (var item in CartItems)
            {
                total += item.TotalPrice;
            }
            TotalAmount = total;
        }

        private void ExecuteIncreaseQuantity(object parameter)
        {
            if (parameter is CartItemModel item)
            {
                // Обновляем количество в CartManager
                var cartItem = ProductsPage.CartManager.CartItems.FirstOrDefault(ci => ci.Product.Name == item.Product.Name);
                if (cartItem != null)
                {
                    ProductsPage.CartManager.ChangeQuantity(cartItem.Product, 1);
                    item.Quantity = cartItem.Quantity;
                    UpdateTotalAmount();
                }
            }
        }

        private void ExecuteDecreaseQuantity(object parameter)
        {
            if (parameter is CartItemModel item)
            {
                // Обновляем количество в CartManager
                var cartItem = ProductsPage.CartManager.CartItems.FirstOrDefault(ci => ci.Product.Name == item.Product.Name);
                if (cartItem != null && cartItem.Quantity > 1)
                {
                    ProductsPage.CartManager.ChangeQuantity(cartItem.Product, -1);
                    item.Quantity = cartItem.Quantity;
                    UpdateTotalAmount();
                }
            }
        }

        private void ExecuteRemoveItem(object parameter)
        {
            if (parameter is CartItemModel item)
            {
                // Удаляем товар из CartManager
                var cartItem = ProductsPage.CartManager.CartItems.FirstOrDefault(ci => ci.Product.Name == item.Product.Name);
                if (cartItem != null)
                {
                    ProductsPage.CartManager.RemoveFromCart(cartItem.Product);
                    CartItems.Remove(item);
                    UpdateTotalAmount();
                }
            }
        }

        private void ExecuteCheckout(object parameter)
        {
            if (CartItems.Count == 0)
            {
                System.Windows.MessageBox.Show("Корзина пуста! Добавьте товары перед оформлением заказа.", 
                    "Предупреждение", 
                    System.Windows.MessageBoxButton.OK, 
                    System.Windows.MessageBoxImage.Warning);
                return;
            }

            // Здесь будет логика оформления заказа
            System.Windows.MessageBox.Show("Заказ оформлен!");
        }

        private void ExecuteHome(object parameter)
        {
            // Здесь будет логика возврата на главную страницу
            var mainWindow = new MainWindow(_currentUser);
            mainWindow.Show();
            System.Windows.Application.Current.Windows[0].Close();
        }
    }
} 