using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using TheDebtBook.Models;

namespace TheDebtBook.Models
{
    public class Debter : BindableBase
    {
        public String Name { get; set; }


        private double indebted_;
        public double Indebted
        {
            get
            {
                return indebted_;
            }
            private set
            {
                SetProperty(ref indebted_, value);
            }
        }

        private ObservableCollection<Debt> debts;
        public ObservableCollection<Debt> Debts
        {
            get
            {
                return debts;
            }
            set
            {
                SetProperty(ref debts, value);
            }
        }

        public Debter()
        {

        }

        public Debter(string name)
        {
            Name = name;
            debts = new ObservableCollection<Debt>();
        }
            

        public void AddDebt(double value)
        {
            Indebted += value;
            Debts.Add(new Debt(value));
        }
        
        
    }
}
