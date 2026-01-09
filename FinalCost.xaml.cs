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
        }
        private void GoNext_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreditParametres());

            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.StepProgress.Value = 4;
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ChoiceColorEtc());

            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.StepProgress.Value = 2;
        }
    }
}
