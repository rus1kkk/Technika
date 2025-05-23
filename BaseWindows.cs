using System.Windows;

namespace Technika
{
    public class BaseWindow : Window
    {
        public BaseWindow()
        {
            this.Loaded += BaseWindow_Loaded;
        }

        private void BaseWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Получаем размеры экрана
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            // Получаем размеры окна
            double windowWidth = this.Width;
            double windowHeight = this.Height;

            // Вычисляем позицию для центрирования
            this.Left = (screenWidth - windowWidth) / 2;
            this.Top = (screenHeight - windowHeight) / 2;
        }
    }
}