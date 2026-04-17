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

namespace ISIPGorlanovWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        public CartPage() 
        { 
            InitializeComponent(); 
            Loaded += (s, e) => dgCart.ItemsSource = App.Cart; 
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            if (App.Cart.Count == 0) return;
            OrderConfirmWindow orderConfirmWindow = new OrderConfirmWindow();
            orderConfirmWindow.Show();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
