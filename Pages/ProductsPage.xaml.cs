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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage() 
        { 
            InitializeComponent(); 
            Loaded += Load; 
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            dgProducts.ItemsSource = Lists.productsBDL
                .Where(p => p.IsFrozen == false)
                .Select(p => new { p.ID, p.ProductName, p.Price, Скидка = p.Discount, Рейтинг = p.Rating })
                .ToList();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            dgProducts.ItemsSource = Lists.productsBDL
                .Where(p => p.ProductName.Contains(txtSearch.Text) && p.IsFrozen == false)
                .ToList();
        }

        private void dgProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgProducts.SelectedItem == null) return;
            dynamic item = dgProducts.SelectedItem;
            NavigationService.Navigate(new ProductDetailPage((int)item.ID));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
