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
        private double indebted;
        private List<Debt> debtList;


        public string Name
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


        public double Indebted
        {
            get
            {
                return indebted;
            }
            set
            {
                SetProperty(ref indebted, value);
            }
        }

        public List<Debt>DebtList
        {
            get
            {
                return debtList;
            }
            set
            {
                SetProperty(ref debtList, value);
            }
        }

        public Debter Clone()
        {
            return this.MemberwiseClone() as Debter;
        }

        public Debter()
        {
            DebtList = new List<Debt>();
        }

        public Debter(string name)
        {
            Name = name;
            DebtList = new List<Debt>();
        }
                    
        
    }
}
