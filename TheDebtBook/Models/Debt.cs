using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;

namespace TheDebtBook.Models
{
    public class Debt : BindableBase
    {

        private DateTime date;
        private double amount;

        public Debt(double amount)
        {
            Amount = amount;
            date = DateTime.Now;
        }
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                SetProperty(ref date, value);
            }
        }

        public double Amount
        {
            get
            {
                return amount;
            }
            set
            {
                SetProperty(ref amount, value);
            }
        }

    }
}
