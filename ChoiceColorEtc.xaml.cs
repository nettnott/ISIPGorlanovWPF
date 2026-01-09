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
    /// Логика взаимодействия для ChoiceColorEtc.xaml
    /// </summary>
    public partial class ChoiceColorEtc : Page
    {
        public ChoiceColorEtc()
        {
            InitializeComponent();
        }
        private void GoNext_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new FinalCost());

            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.StepProgress.Value = 3;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ChoiceModelNType());

            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.StepProgress.Value = 1;
        }
    }
}
