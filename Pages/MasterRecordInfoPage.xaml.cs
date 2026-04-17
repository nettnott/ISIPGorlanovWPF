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
    /// Логика взаимодействия для MasterRecordInfoPage.xaml
    /// </summary>
    public partial class MasterRecordInfoPage : Page
    {
        private int _id;
        public MasterRecordInfoPage(int id) 
        { 
            InitializeComponent(); 
            _id = id; LoadInfo(); 
        }

        private void LoadInfo()
        {
            var a = Lists.appointmentsBDL.FirstOrDefault(x => x.ID == _id);
            var client = Lists.usersBDL.FirstOrDefault(u => u.ID == a?.ClientID);
            var service = Lists.servicesBDL.FirstOrDefault(s => s.ID == a?.ServiceID);
            txtInfo.Text = $"Клиент: {client?.FullName}\nТелефон: {client?.Phone}\nУслуга: {service?.ServiceName}\nДата: {a?.AppointmentDate}";
        }

        private void BtnComplete_Click(object sender, RoutedEventArgs e)
        {
            var a = Lists.appointmentsBDL.FirstOrDefault(x => x.ID == _id);
            if (a != null)
            {
                a.Status = "Выполнена";
                Core.Context.SaveChanges();
                Lists.appointmentsBDL = Core.Context.Appointment.ToList();
            }
            MessageBox.Show("Услуга выполнена!");
            NavigationService.GoBack();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
