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
    /// Логика взаимодействия для AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public AccountPage() 
        { 
            InitializeComponent(); 
            Loaded += Load; 
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            dgAppointments.ItemsSource = Lists.appointmentsBDL
                .Where(a => a.ClientID == App.CurrentUserId).ToList();
            dgOrders.ItemsSource = Lists.ordersBDL.Where(o => o.UserID == App.CurrentUserId).ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
