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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Product> productList = Core.Context.Product.ToList();
        public static List<Order> orderList = Core.Context.Order.ToList();
        public static List<ProductOrder> cartList = Core.Context.ProductOrder.ToList();
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
