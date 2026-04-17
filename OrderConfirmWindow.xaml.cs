using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            if (App.Cart.Count == 0)
            {
                MessageBox.Show("Корзина пуста!");
                return;
            }

            if (dpDate.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату получения товара!");
                return;
            }
            Order newOrder;

            MessageBox.Show(App.CurrentUserId.ToString());
            newOrder = new Order();
            newOrder.UserID = App.CurrentUserId;
            newOrder.RecordDate = DateTime.Now;
            newOrder.Comm = "Заказ из приложения";
            newOrder.PaymentMethod = (cmbPayment.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Наличные";
            newOrder.OrderStatus = "Новый";
            
            Core.Context.Order.Add(newOrder);
            Core.Context.SaveChanges();


            foreach (var item in App.Cart)
            {
                MessageBox.Show($"{item.ProductID} || {newOrder.ID}");
                Core.Context.OrderProduct.Add(new OrderProduct
                {
                    OrderID = newOrder.ID,
                    ProductID = item.ProductID
                });
            }

            Core.Context.SaveChanges();

            Lists.ordersBDL = Core.Context.Order.ToList();
            App.Cart.Clear();

            MessageBox.Show($"Заказ №{newOrder.ID} успешно оформлен!", "Успех");
            this.DialogResult = true;
            Close();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}