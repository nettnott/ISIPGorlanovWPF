using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()//Окак а зачем а господи это вс сделало
        {
            InitializeComponent();
            FilmsList.ItemsSource = Lists.filmsList;
        }

        private void InfoBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FilmPage());
        }

        private void ConfSortBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ByNameRB.IsChecked == true)
            {
                if (ByAscRB.IsChecked == true)
                {
                    FilmsList.Items.SortDescriptions.Clear();
                    FilmsList.Items.SortDescriptions.Add(
                        new SortDescription("Name", ListSortDirection.Ascending));
                }
                else if (ByDescRB.IsChecked == true)
                {
                    FilmsList.Items.SortDescriptions.Clear();
                    FilmsList.Items.SortDescriptions.Add(
                        new SortDescription("Name", ListSortDirection.Descending));
                }
                else
                {
                    MessageBox.Show("Выберите тип сортировки ормально а не как total sheine fa");
                }
            }
            else if (ByRateRB.IsChecked == true)
            {
                if (ByAscRB.IsChecked == true)
                {
                    FilmsList.Items.SortDescriptions.Clear();
                    FilmsList.Items.SortDescriptions.Add(
                       new SortDescription("Rate", ListSortDirection.Ascending));
                }
                else if (ByDescRB.IsChecked == true)
                {
                    FilmsList.Items.SortDescriptions.Clear();
                    FilmsList.Items.SortDescriptions.Add(
                        new SortDescription("Rate", ListSortDirection.Descending));
                }
                else
                {
                    MessageBox.Show("Выберите тип сортировки ормально а не как total sheine fa");
                }
            }
            else
            {
                MessageBox.Show("Выберите тип сортировки ормально а не как total sheine fa");
            }
        }

        private void ResetBTN_Click(object sender, RoutedEventArgs e)
        {
            FilmsList.Items.SortDescriptions.Clear();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTB.Text))
            {
                FilmsList.ItemsSource = Lists.filmsList;
            }
            else
            {
                FilmsList.ItemsSource = Lists.filmsList.Where(p => p.Name.ToLower().Contains(SearchTB.Text.ToLower())).ToList();
            }
        }

        private void LogInBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LogInPage());
        }

        private void CreateAccBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateAccPage());
        }
    }
}


