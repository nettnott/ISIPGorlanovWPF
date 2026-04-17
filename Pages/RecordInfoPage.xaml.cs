/*using System;
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
    /// Логика взаимодействия для RecordInfoPage.xaml
    /// </summary>
    public partial class RecordInfoPage : Page
    {
        private int _id;
        public RecordInfoPage(int id) { InitializeComponent(); _id = id; LoadInfo(); }

        private void LoadInfo()
        {
            var a = Lists.appointmentsBDL.FirstOrDefault(x => x.ID == _id);
            if (a == null) return;
            txtService.Text = "Услуга: " + Lists.servicesBDL.FirstOrDefault(s => s.ID == a.ServiceID)?.ServiceName;
            txtMaster.Text = "Мастер: " + Lists.usersBDL.FirstOrDefault(u => u.ID == a.MasterID)?.FullName;
            txtDate.Text = "Дата: " + a.AppointmentDate.ToString("dd.MM.yyyy HH:mm");
        }

        private void BtnRecord_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Подтверждаете запись?", "", MessageBoxButton.YesNo) == MessageBoxResult.No) return;

            var a = Lists.appointmentsBDL.FirstOrDefault(x => x.ID == _id);
            if (a != null)
            {
                a.ClientID = App.CurrentUserId;
                a.Status = "Записан";
                a.PaymentMethod = (cmbPayment.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Наличные";
                a.Comment = txtComment.Text;
                Core.Context.SaveChanges();//
                Lists.appointmentsBDL = Core.Context.Appointment.ToList();
            }
            MessageBox.Show("Запись подтверждена!");
            NavigationService.GoBack();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();
    }
}
        */