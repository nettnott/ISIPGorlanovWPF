using ISIPGorlanovWPF.Pages;
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
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnAccount.Visibility = App.CurrentRoleId == 4 ? Visibility.Visible : Visibility.Collapsed;
            btnMaster.Visibility = App.CurrentRoleId == 3 ? Visibility.Visible : Visibility.Collapsed;
            btnManager.Visibility = App.CurrentRoleId == 2 ? Visibility.Visible : Visibility.Collapsed;
            btnAdmin.Visibility = App.CurrentRoleId == 1 ? Visibility.Visible : Visibility.Collapsed;
            btnCart.Visibility = App.CurrentRoleId == 4 ? Visibility.Visible : Visibility.Collapsed;

            MainFrame.Navigate(new StartPage());
        }

        private void BtnMain_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StartPage());
        }
        private void BtnRecord_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RecordPage());
        }
        private void BtnProducts_Click(object sender, RoutedEventArgs e) 
        { 
            MainFrame.Navigate(new ProductsPage()); 
        }
        private void BtnCart_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CartPage());
        }
        private void BtnAccount_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AccountPage());
        }
        private void BtnMaster_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MasterPage());
        }
        private void BtnManager_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManagerPage());
        }
        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AdminPage());
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentUserId = 0;
            App.CurrentRoleId = 0;
            App.Cart.Clear();
            new LoginWindow().Show();
            Close();
        }
    }
}
