/*using ISIPGorlanovWPF;
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
using System.Xml.Linq;

namespace ISIPGorlanovWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChosenRecordPage.xaml
    /// </summary>
    public partial class ChosenRecordPage : Page
    {
        private int _appointmentId;

        public ChosenRecordPage(int appointmentId)
        {
            InitializeComponent();
            _appointmentId = appointmentId;
            LoadRecordInfo();
        }

        private void LoadRecordInfo()
        {
            var app = Lists.appointmentsBDL.FirstOrDefault(a => a.ID == _appointmentId);
            if (app == null) return;

            var service = Lists.servicesBDL.FirstOrDefault(s => s.ID == app.ServiceID);
            var master = Lists.usersBDL.FirstOrDefault(u => u.ID == app.MasterID);

            txtService.Text = "Услуга: " + (service?.ServiceName ?? "Неизвестно");
            txtMaster.Text = "Мастер: " + (master?.FullName ?? "Неизвестно");
            txtDate.Text = "Дата: " + app.AppointmentDate.ToString("dd.MM.yyyy HH:mm");
        }

        private void BtnRecord_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Подтверждаете запись на эту услугу?",
                                "Подтверждение",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            var app = Lists.appointmentsBDL.FirstOrDefault(a => a.ID == _appointmentId);
            if (app != null)
            {
                app.ClientID = App.CurrentUserId;
                app.Status = "Записан";
                app.PaymentMethod = (cmbPayment.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Наличные";
                app.Comment = txtComment.Text;

                Core.Context.SaveChanges();

                Lists.appointmentsBDL = Core.Context.Appointment.ToList();

                MessageBox.Show("Вы успешно записаны!", "Готово");
                NavigationService.GoBack();
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
*/