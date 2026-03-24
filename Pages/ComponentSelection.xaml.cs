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
    /// Логика взаимодействия для ComponentSelection.xaml
    /// </summary>
    public partial class ComponentSelection : Page
    {
        List<basepart_> selectedParts = new List<basepart_>();
        decimal totalPrice = 0;
        public ComponentSelection()
        {
            InitializeComponent();
            PartsList.ItemsSource = Lists.baseparts;
            SelectedPartsList.ItemsSource = "";
        }

        private void SaveBuild_BTN_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchBox.Text.ToLower();

            var filteredList = Lists.baseparts
                .Where(p => p.name.ToLower().Contains(searchText))
                .ToList();

            PartsList.ItemsSource = filteredList;
        }

        private void OpenHistory_BTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("При переходе текущий билд не сохранится. Нажмите кнопку `Сохранить` перед переходом",
                                                      "Вы уверены, что хотите перейти к списку билдов?",
                                                      MessageBoxButton.YesNo,
                                                      MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new SavedBuilds());
            }
        }

        private void AddPart_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            int partId = Convert.ToInt32(btn.Tag);

            var selectedItem = Lists.baseparts.FirstOrDefault(p => p.id == partId);

            if (selectedItem != null)
            {
                selectedParts.Add(selectedItem);

                SelectedPartsList.ItemsSource = null;
                SelectedPartsList.ItemsSource = selectedParts;

                totalPrice += (decimal)selectedItem.price;
                PriceLabel.Text = $"{totalPrice:N0} руб.";
            }

            if (!CheckCompatibility())
            {
                var lastItem = selectedParts.Last();
                selectedParts.Remove(lastItem);
                totalPrice -= (decimal)lastItem.price;

                SelectedPartsList.ItemsSource = null;
                SelectedPartsList.ItemsSource = selectedParts;
                PriceLabel.Text = $"{totalPrice:N0} руб.";
            }
        }

        private bool CheckCompatibility()
        {
            var cpu = selectedParts.FirstOrDefault(p => p.parttypeid == 1);
            var motherboard = selectedParts.FirstOrDefault(p => p.parttypeid == 2);
            var ram = selectedParts.FirstOrDefault(p => p.parttypeid == 3);
            var gpu = selectedParts.FirstOrDefault(p => p.parttypeid == 4);
            var psu = selectedParts.FirstOrDefault(p => p.parttypeid == 5);
            var pcCase = selectedParts.FirstOrDefault(p => p.parttypeid == 6);

            if (cpu != null && motherboard != null)
            {
                var cpuInfo = Lists.cpus.FirstOrDefault(c => c.id == cpu.id);
                var mbInfo = Lists.motherboards.FirstOrDefault(m => m.id == motherboard.id);

                if (cpuInfo.socketid != mbInfo.socketid)
                {
                    MessageBox.Show("Процессор и материнская плата имеют разные сокеты!", "Ошибка совместимости", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }

            // 2. Проверка Типа памяти (ОЗУ + Мать)
            if (ram != null && motherboard != null)
            {
                var ramInfo = Lists.rams.FirstOrDefault(r => r.id == ram.id);
                var mbInfo = Lists.motherboards.FirstOrDefault(m => m.id == motherboard.id);

                if (ramInfo.memorytypeid != mbInfo.memorytypeid)
                {
                    MessageBox.Show("Тип памяти ОЗУ не подходит к материнской плате!", "Ошибка совместимости", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }

            // 3. Проверка Блока питания (БП + Видеокарта)
            if (gpu != null && psu != null)
            {
                var gpuInfo = Lists.gpus.FirstOrDefault(g => g.id == gpu.id);
                var psuInfo = Lists.powersupplies.FirstOrDefault(p => p.id == psu.id);

                if (gpuInfo.recommendpower > psuInfo.power)
                {
                    MessageBox.Show("Мощности блока питания недостаточно для этой видеокарты!", "Ошибка совместимости", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }

            // Проверка: Материнская плата + Корпус
            if (motherboard != null && pcCase != null)
            {
                // 1. Получаем ID форм-фактора выбранной материнки
                var mbInfo = Lists.motherboards.FirstOrDefault(m => m.id == motherboard.id);
                int requiredFactor = mbInfo.formfactorid;

                // 2. Ищем в таблице связей, поддерживает ли этот корпус такой ID
                // Предполагаем, что таблица в EF называется caseformfactor_
                var compatibility = Core.Context.boardformfactorcase_
                    .FirstOrDefault(cf => cf.caseid == pcCase.id && cf.formfactorid == requiredFactor);

                if (compatibility == null)
                {
                    MessageBox.Show("Данный корпус не поддерживает размер этой материнской платы!",
                                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }

            return true;
        }
    }
}
