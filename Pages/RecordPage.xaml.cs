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
    /// Логика взаимодействия для RecordPage.xaml
    /// </summary>
    public partial class RecordPage : Page
    {
        public RecordPage() 
        { 
            InitializeComponent();
            Loaded += (s, e) => dgRecords.ItemsSource = Lists.appointmentsBDL.ToList(); 
        }

        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {
            if (dpFilter.SelectedDate == null) return;
            var d = dpFilter.SelectedDate.Value.Date;
            dgRecords.ItemsSource = Lists.appointmentsBDL.Where(a => a.AppointmentDate.Date == d).ToList();
        }

        private void dgRecords_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (dgRecords.SelectedItem == null) return;
            var app = (Appointment)dgRecords.SelectedItem;
            RecordInfoWindow recordInfoWindow = new RecordInfoWindow(app.ID);
            recordInfoWindow.Show();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
