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

namespace ISIPGorlanovWPF.pages
{
    /// <summary>
    /// Логика взаимодействия для products.xaml
    /// </summary>
    public partial class products : Page
    {
        public products()
        {
            InitializeComponent();
            ProductsList.ItemsSource = Lists.productList;
        }
        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var product = button.DataContext as Product;

            if (product != null)
            {
                if (Lists.cart.FirstOrDefault)
                {

                }
                Lists.cart.Add(product);
            }
        }
        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new cart());
        }
    }
}
