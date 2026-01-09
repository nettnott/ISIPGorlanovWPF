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
            this.Loaded += Page_Loaded;
            this.KeepAlive = true;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var mw = (MainWindow)Application.Current.MainWindow;

            if (listColors.ItemsSource == null)
            {
                listColors.ItemsSource = mw.ColorsList;
            }
            if (listOptions.ItemsSource == null)
            {
                listOptions.ItemsSource = mw.OptionsList;
            }


            if (mw.CurrentOrder.Color != null)
            {
                listColors.SelectedItem = mw.CurrentOrder.Color;
            }
            if (mw.CurrentOrder.SelectedEngine != null)
            {
                listOptions.SelectedItem = mw.CurrentOrder.Option;
            }
        }
        private void GoNext_Click(object sender, RoutedEventArgs e)
        {
            var mw = (MainWindow)Application.Current.MainWindow;
            if (listColors.SelectedItem is Colors c && listOptions.SelectedItem is Options o)
            {
                mw.CurrentOrder.Color = c;
                mw.CurrentOrder.Option = o;

                NavigationService.Navigate(new FinalCost());

                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.StepProgress.Value = 3;
            }
            else
            {
                MessageBox.Show("Выберите значения из списков!");
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.StepProgress.Value = 1;
        }
    }
}
