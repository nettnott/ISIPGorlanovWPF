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
    /// Логика взаимодействия для cart.xaml
    /// </summary>
    public partial class cart : Page
    {
        public cart()
        {
            InitializeComponent();
            CartList.ItemsSource = Lists.cart;
            
            Decimal TotalCost = 0;
            foreach (Product p in Lists.cart)
            {
                TotalCost += p.Cost;
            }
            TotalTB.Text = TotalCost.ToString();

        }

        Order curOrder = new Order();

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            curOrder.FIO = NameTBx.Text;
            curOrder.Email = MailTBx.Text;
            curOrder.Address = AddressTBx.Text;

            Core.Context.Order.Add(curOrder);
            Core.Context.SaveChanges();

            foreach (Product p in Lists.cart)
            {
                ProductOrder newEntry = new ProductOrder
                {
                    OrderID = curOrder.ID,
                    ProductID = p.ID       
                };
                Core.Context.ProductOrder.Add(newEntry);
            }

            Core.Context.SaveChanges();
            Lists.cart.Clear();

            MessageBox.Show("Successfully Pepe Scneined!");
            Application.Current.Shutdown();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
