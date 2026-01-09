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
    /// Логика взаимодействия для FinalCost.xaml
    /// </summary>
    public partial class FinalCost : Page
    {
        public FinalCost()
        {
            InitializeComponent();
            this.KeepAlive = true;
            this.Loaded += FinalCost_Loaded;
        }
        private void FinalCost_Loaded(object sender, RoutedEventArgs e)
        {
            var mw = (MainWindow)Application.Current.MainWindow;
            var order = mw.CurrentOrder;

            ResultPanel.Children.Clear();

            decimal total = 0;

            // модель
            if (order.SelectedModel != null)
            {
                AddResultRow($"Автомобиль: {order.SelectedModel.Name}", order.SelectedModel.BasePrice);
                total += order.SelectedModel.BasePrice;
            }

            // двигатель
            if (order.SelectedEngine != null)
            {
                AddResultRow($"Двигатель: {order.SelectedEngine.Name}", order.SelectedEngine.BasePrice);
                total += order.SelectedEngine.BasePrice;
            }

            // цвет
            if (order.Color != null)
            {
                AddResultRow($"Автомобиль: {order.Color.Name}", order.Color.Price);
                total += order.Color.Price;
            }

            // доп. опции
            if (order.Option != null)
            {
                AddResultRow($"Двигатель: {order.Option.Name}", order.Option.Price);
                total += order.Option.Price;
            }

            txtTotalCost.Text = $"Итого: {total} руб.";
        }
        private void AddResultRow(string name, decimal price)
        {
            TextBlock row = new TextBlock { Margin = new Thickness(0, 5, 0, 5), FontSize = 14 };
            row.Text = $"{name} — {price} руб.";
            ResultPanel.Children.Add(row);
        }
        private void GoNext_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreditParametres());

            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.StepProgress.Value = 4;
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.StepProgress.Value = 2;
        }
    }
}
