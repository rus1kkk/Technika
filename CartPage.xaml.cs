using System.Windows;
using Technika.ViewModels;

namespace Technika
{
    public partial class CartPage : Window
    {
        public CartPage(string username)
        {
            InitializeComponent();
            DataContext = new CartViewModel(username);
            RootGrid.Opacity = 0;
            var sb = (System.Windows.Media.Animation.Storyboard)this.Resources["WindowShowAnimation"];
            sb.Begin(RootGrid);
        }

        public CartPage() : this(null) { }
    }
}