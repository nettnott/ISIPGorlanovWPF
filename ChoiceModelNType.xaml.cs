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
        }
        
    private void GoNext_Click(object sender, RoutedEventArgs e)
        {
            var mw = (MainWindow)Application.Current.MainWindow;

            // 2. Сохраняем данные (допустим, из TextBox или ComboBox)
            mw.CurrentOrder.Model = txtModel.Text;
            mw.CurrentOrder.Engine = comboEngine.Text;

            this.NavigationService.Navigate(new ChoiceColorEtc());

            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.StepProgress.Value = 2;
        }
    }
}
