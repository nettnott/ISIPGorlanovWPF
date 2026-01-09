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
    /// Логика взаимодействия для CreditParametres.xaml
    /// </summary>
    public partial class CreditParametres : Page
    {
        public CreditParametres()
        {
            InitializeComponent();
            this.KeepAlive = true;
        }
        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            var mw = (MainWindow)Application.Current.MainWindow;
            var cost = mw.CurrentOrder.TotalCost;

            if (decimal.TryParse(txtFeePercent.Text, out decimal percent) && Convert.ToBoolean((int)sliderTerm.Value))
            {
                //decimal initialFee, int termInMonths, decimal carCost, decimal yearStavka)
                decimal fee = (cost * percent) / 100;
                int months = (int)sliderTerm.Value;
                mw.Credit = new Credit(fee, months, cost, 15.0m);
                lblResult.Text = $"{mw.Credit.MonthlyPayment:N2} руб.";
            }
            else
            {
                MessageBox.Show("Введите корректные числа");
            }
        }
        private void GoNext_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MakingAZayavka());

            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.StepProgress.Value = 5;
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.StepProgress.Value = 3;
        }
    }
}
