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
    /// Логика взаимодействия для MasterPage.xaml
    /// </summary>
    public partial class MasterPage : Page
    {
        public MasterPage() 
        { 
            InitializeComponent(); 
            Loaded += Load; 
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            dgMyRecords.ItemsSource = Lists.appointmentsBDL.Where(a => a.MasterID == App.CurrentUserId).ToList();
        }

        private void dgMyRecords_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (dgMyRecords.SelectedItem == null) return;
            var app = (Appointment)dgMyRecords.SelectedItem;
            NavigationService.Navigate(new MasterRecordInfoPage(app.ID));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
