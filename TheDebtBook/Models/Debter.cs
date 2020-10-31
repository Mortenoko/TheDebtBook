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
        
        private string name;
        private double amount;
        private ObservableCollection<Debt> debts;
       

        public Debter()
        {

        }

        public Debter(string aName, double aAmount)
        {
            name = aName;
            amount = aAmount;
            debts = new ObservableCollection<Debt>();
        }

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

        public Debter clone()
        {
            return this.MemberwiseClone() as Debter;
        }

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                SetProperty(ref name, value);
            }
        }

        public Double Amount
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

        public void AddDebt(double value)
        {
            Amount += value;
            Debts.Add(new Debt(value));
        }
        


        

        
    }
}
