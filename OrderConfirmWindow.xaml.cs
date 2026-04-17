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

namespace ISIPGorlanovWPF
{
    /// <summary>
    /// Логика взаимодействия для OrderConfirmWindow.xaml
    /// </summary>
    public partial class OrderConfirmWindow : Window
    {
        public OrderConfirmWindow()
        {
            InitializeComponent();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            var order = new Order
            {
                UserID = App.CurrentUserId,
                RecordDate = DateTime.Now,
                Comm = "Заказ из приложения",
                PaymentMethod = (cmbPayment.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Наличные",
                OrderStatus = "Новый"
            };

            Core.Context.Order.Add(order);
            Core.Context.SaveChanges();

            foreach (var item in App.Cart)
            {
                Core.Context.OrderProduct.Add(new OrderProduct { OrderID = order.ID, ProductID = item.ProductID });
            }
            Core.Context.SaveChanges();

            Lists.ordersBDL = Core.Context.Order.ToList();
            App.Cart.Clear();

            MessageBox.Show("Заказ оформлен!");
            Close();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) 
        {
            Close();
        }
    }
}