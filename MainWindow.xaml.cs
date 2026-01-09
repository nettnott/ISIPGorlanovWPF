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
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    public class OrderData
    {
        public int id;
        public Models Model { get; set; }
        public Engines Engine { get; set; }
        public Colors Color { get; set; }
        public Options Options { get; set; }
        public Credit CreditDetails { get; set; }
        public string Contacts { get; set; }
    }

    public class Models
    {
        public int id;
        public string Name;
        public string Year;
        public decimal BasePrice;

        public Models(string name, string year, decimal basePrice)
        {
            Name = name;
            Year = year;
            BasePrice = basePrice;
        }
    }
    public class Engines
    {
        public int id;
        public string Name;
        public decimal BasePrice;
        public int Power;

        public Engines(string name,  decimal basePrice, int power)
        {
            Name = name;
            BasePrice = basePrice;
            Power = power;
        }
    }

    public class Colors
    {
        public int id;
        public string Name;
        public decimal Price;
        public Colors( string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    public class Options
    {
        public int id;
        public string Name;
        public decimal Price;
        public Options(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    public class Credit
    {
        public decimal InitialFee; //первоначальный взнос
        public int TermInMonths; //срок кредита в месяцах
        public decimal CarCost; //общая стоимость машины
        public decimal MonthlyPayment; //ежемесячный платеж
        public decimal TotalPayment; //общая сумма выплат по кредиту
        public decimal MonthlyStavka; //ежемесячная ставка
        public decimal YearStavka; //годовая ставка по кредиту

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

        public void CalculateCreditDetails()
        {
            
        }
    }

}
