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
    public partial class MainWindow : Window
    {
        public int currentStepIndex = 0;
        public OrderData CurrentOrder { get; set; } = new OrderData();
        public List<Models> ModelsList { get; set; } = new List<Models> ();
        public List<Engines> EnginesList { get; set; } = new List<Engines> ();
        public List<Colors> ColorsList { get; set; } = new List<Colors>();
        public List<Options> OptionsList { get; set; } = new List<Options>();
        public Credit Credit { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            //данные для списков моделей и двигателей
            ModelsList.Add(new Models("Lada Vesta", "2023", 1500000m));
            ModelsList.Add(new Models("Lada Granta", "2022", 800000m));
            ModelsList.Add(new Models("UAZ Patriot", "2023", 1800000m));
            ModelsList.Add(new Models("Molniya Macquinn", "200w", 1800000m));

            EnginesList.Add(new Engines("1.6 MPI", 0m, 106));
            EnginesList.Add(new Engines("1.8 Turbo", 200000m, 145));
            EnginesList.Add(new Engines("2.0 Diesel", 350000m, 150));

            //данные для списков моделей и двигателей
            ColorsList.Add(new Colors("Белый", 0m));
            ColorsList.Add(new Colors("Черный", 15000m));
            ColorsList.Add(new Colors("Красный", 20000m));
            ColorsList.Add(new Colors("Синий", 25000m));

            OptionsList.Add(new Options("Климат-контроль", 50000m));
            OptionsList.Add(new Options("Мультимедиа система", 40000m));
            OptionsList.Add(new Options("Парктроник", 15000m));
            OptionsList.Add(new Options("Тонировочка", 150000000m));
            OptionsList.Add(new Options("Бумбокс", 5000m));

            MainFrame.Navigate(new ChoiceModelNType());
        }
    }
    public class OrderData
    {
        public int id;
        public Models SelectedModel { get; set; }
        public Engines SelectedEngine { get; set; }
        public Colors Color { get; set; }
        public Options Option { get; set; }
        public Credit CreditData { get; set; }
        public string Contacts { get; set; }
        public decimal TotalCost { get; set; }
    }

    public class Models
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public decimal BasePrice { get; set; }

        public Models(string name, string year, decimal price)
        { Name = name; Year = year; BasePrice = price; }
    }

    public class Engines
    {
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public int Power { get; set; }

        public Engines(string name, decimal price, int power)
        { Name = name; BasePrice = price; Power = power; }
    }

    public class Colors
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Colors( string name, decimal price)
        { Name = name; Price = price; }
    }

    public class Options
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Options(string name, decimal price)
        { Name = name; Price = price; }
    }

    public class Credit
    {
        public decimal InitialFee { get; set; } //первоначальный взнос
        public int TermInMonths { get; set; } //срок кредита в месяцах
        public decimal CarCost { get; set; } //общая стоимость машины
        public decimal MonthlyPayment { get; set; } //ежемесячный платеж
        public decimal TotalPayment { get; set; } //общая сумма выплат по кредиту
        public decimal MonthlyStavka { get; set; } //ежемесячная ставка
        public decimal YearStavka { get; set; } //годовая ставка по кредиту

        public Credit(decimal initialFee, int termInMonths, decimal carCost, decimal yearStavka)
        {
            InitialFee = initialFee;
            TermInMonths = termInMonths;
            CarCost = carCost;
            YearStavka = yearStavka;

            TotalPayment = CarCost - InitialFee; // расчет общей суммы выплат по кредиту
            MonthlyStavka = YearStavka/100/12; // расчет ежемесячной ставки
            MonthlyPayment = TotalPayment*(MonthlyStavka * Convert.ToDecimal(Math.Pow(Convert.ToDouble(1+MonthlyStavka), Convert.ToDouble(TermInMonths)))/ Convert.ToDecimal(Math.Pow(Convert.ToDouble(1 + MonthlyStavka), Convert.ToDouble(TermInMonths - 1))));
        }
        //мб добаить вывод данных кредита в строку или сделать на странице кредита
    }

}
