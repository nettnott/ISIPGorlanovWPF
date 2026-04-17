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
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage() 
        { 
            InitializeComponent(); 
            Loaded += StartPage_Loaded;
        }

        private void StartPage_Loaded(object sender, RoutedEventArgs e)
        {
            cmbServiceType.ItemsSource = Lists.servicesBDL.Select(s => new { s.ID, s.ServiceName }).ToList();
            cmbServiceType.DisplayMemberPath = "ServiceName";
        }

        private void cmbServiceType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbServiceType.SelectedItem == null) return;
            dynamic item = cmbServiceType.SelectedItem;
            lbMasters.ItemsSource = Lists.usersBDL.Where(u => u.RoleID == 3)
                .Select(u => new { u.ID, u.FullName }).ToList();
            lbMasters.DisplayMemberPath = "FullName";
        }

        private void lbMasters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbMasters.SelectedItem == null) return;
            dynamic m = lbMasters.SelectedItem;
            dgAppointments.ItemsSource = Lists.appointmentsBDL
                .Where(a => a.MasterID == m.ID && a.Status == "Ожидается")
                .Select(a => new { a.ID, a.AppointmentDate, Service = Lists.servicesBDL.FirstOrDefault(s => s.ID == a.ServiceID)?.ServiceName })
                .ToList();
        }

        private void BtnMakeAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (dgAppointments.SelectedItem == null) 
            {
                MessageBox.Show("Выберите запись"); 
                return; 
            }
            if (MessageBox.Show("Подтверждаете запись?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.No) return;

            dynamic row = dgAppointments.SelectedItem;
            var app = Lists.appointmentsBDL.FirstOrDefault(a => a.ID == row.ID);
            if (app != null)
            {
                app.ClientID = App.CurrentUserId;
                app.Status = "Записан";
                Core.Context.SaveChanges();
                Lists.appointmentsBDL = Core.Context.Appointment.ToList();
            }
            MessageBox.Show("Вы записаны!");
        }
    }
}
