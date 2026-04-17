using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ISIPGorlanovWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static int CurrentUserId { get; set; } = 0;
        public static int CurrentRoleId { get; set; } = 0;
        public static string CurrentFullName { get; set; } = "";

        public static List<CartItem> Cart { get; set; } = new List<CartItem>();
    }

    public class CartItem
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
