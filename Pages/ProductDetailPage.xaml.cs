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
    /// Логика взаимодействия для ProductDetailPage.xaml
    /// </summary>
    public partial class ProductDetailPage : Page
    {
        private int _id;
        public ProductDetailPage(int id) 
        { 
            InitializeComponent(); 
            _id = id; Load(); 
        }

        private void Load()
        {
            var p = Lists.productsBDL.FirstOrDefault(x => x.ID == _id);
            if (p == null) return;
            txtName.Text = p.ProductName;
            txtPrice.Text = $"Цена: {p.Price} ₽";
            txtDiscount.Text = $"Скидка: {p.Discount}%";
            txtRating.Text = $"Оценка: {p.Rating}";
            txtDesc.Text = p.Description ?? "Нет описания";
        }

        private void BtnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (App.CurrentUserId == 0) 
            { 
                MessageBox.Show("Войдите в аккаунт"); 
                return; 
            }
            var p = Lists.productsBDL.FirstOrDefault(x => x.ID == _id);
            if (p != null)
            {
                App.Cart.Add(new CartItem { ProductID = p.ID, Name = p.ProductName, Price = p.Price });
                MessageBox.Show("Добавлено в корзину!");
            }
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
