using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIPGorlanovWPF
{
    internal class Lists
    {
        public static List<Product> productList = Core.Context.Product.ToList();
        public static List<Order> orderList = Core.Context.Order.ToList();
        public static List<ProductOrder> cartList = Core.Context.ProductOrder.ToList();
        public static List<Product> cart = new List<Product>();
    }
}
