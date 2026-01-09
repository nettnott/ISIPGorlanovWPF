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
    public partial class MainWindow : Window
    {
        public int currentStepIndex = 0;
        public OrderData CurrentOrder { get; set; } = new OrderData();
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    public class OrderData
    {
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Color { get; set; }
        public string Options { get; set; }
        public string CreditDetails { get; set; }
        public string Contacts { get; set; }
    }

    public class Models
    {

    }
}
