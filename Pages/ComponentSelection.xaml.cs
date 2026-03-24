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
            ManufacturerCombo.ItemsSource = Lists.manufacturers;
            SelectedPartsList.ItemsSource = null;
        }

        private void SaveBuild_BTN_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BuildName.Text))
            {
                MessageBox.Show("Пожалуйста, введите название сборки!", "Ошибка");
                return;
            }
            if (string.IsNullOrWhiteSpace(AuthorName.Text))
            {
                MessageBox.Show("Пожалуйста, введите имя автора!", "Ошибка");
                return;
            }
            if (selectedParts.Count == 0)
            {
                MessageBox.Show("Нельзя сохранить пустую сборку!", "Ошибка");
                return;
            }

            assembly_ newAssembly = new assembly_()
            {
                name = BuildName.Text,
                author = AuthorName.Text
            };

            Core.Context.assembly_.Add(newAssembly);
            Core.Context.SaveChanges();

            foreach (var part in selectedParts)
            {
                partassembly_ link = new partassembly_()
                {
                    assemblyid = newAssembly.id,
                    partid = part.id
                };
                Core.Context.partassembly_.Add(link);
            }
            Core.Context.SaveChanges();

            MessageBox.Show("Сборка успешно сохранена в базу!", "Сохранение");

            BuildName.Clear();
            AuthorName.Clear();
            selectedParts.Clear();
            SelectedPartsList.ItemsSource = null;
            totalPrice = 0;
            PriceLabel.Text = "0 руб.";
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            string searchText = SearchBox.Text.ToLower();
            var selectedMan = ManufacturerCombo.SelectedItem as manufacturer_;

            var filtered = Lists.baseparts.Where(p => {
                bool matchesText = p.name.ToLower().Contains(searchText);
                bool matchesManufacturer = selectedMan == null || p.manufacturerid == selectedMan.id;
                return matchesText && matchesManufacturer;
            }).ToList();

            PartsList.ItemsSource = filtered;
        }

        private void ResetFilter_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "";
            ManufacturerCombo.SelectedItem = null;
            PartsList.ItemsSource = Lists.baseparts;
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
            if (motherboard != null && pcCase != null)
            {
                var mbInfo = Lists.motherboards.FirstOrDefault(m => m.id == motherboard.id);
                int requiredFactor = mbInfo.formfactorid;

                var compatibility = Core.Context.boardformfactorcase_
                    .FirstOrDefault(cf => cf.caseid == pcCase.id && cf.formfactorid == requiredFactor);

                if (compatibility == null)
                {
                    MessageBox.Show("Данный корпус не поддерживает размер этой материнской платы!", "Ошибка совместимости", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }

            return true;
        }
    }
}
