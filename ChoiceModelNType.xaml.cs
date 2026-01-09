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
    /// Логика взаимодействия для ChoiceModelNType.xaml
    /// </summary>
    public partial class ChoiceModelNType : Page
    {
        public ChoiceModelNType()
        {
            InitializeComponent();
            this.Loaded += Page_Loaded;
            this.KeepAlive = true;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var mw = (MainWindow)Application.Current.MainWindow;
            if (listModels.ItemsSource == null)
            {
                listModels.ItemsSource = mw.ModelsList;
            }
            if (listEngines.ItemsSource == null)
            {
                listEngines.ItemsSource = mw.EnginesList;
            }
        }
        private void GoNext_Click(object sender, RoutedEventArgs e)
        {
            var mw = (MainWindow)Application.Current.MainWindow;
            if (listModels.SelectedItem is Models m && listEngines.SelectedItem is Engines en)
            {
                mw.CurrentOrder.SelectedModel = m;
                mw.CurrentOrder.SelectedEngine = en;

                NavigationService.Navigate(new ChoiceColorEtc());
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.StepProgress.Value = 2;
            }
            else
            {
                MessageBox.Show("Выберите значения из списков!");
            }
        }
    }
}
