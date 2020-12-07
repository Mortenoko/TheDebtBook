using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDebtBook.Models;
using Prism.Mvvm;
using System.Windows;
using Prism.Commands;
using System.Windows.Input;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;

namespace TheDebtBook.ViewModels
{
    class AddDebtViewModel : BindableBase
    {
        public Debter Debter { get; set; }
        public ObservableCollection<Debt> Debts { get; private set; }
        public int debtAmount { get; set; }

        public AddDebtViewModel(Debter debter)
        {
            Debts = new ObservableCollection<Debt>(debter.DebtList);
            Debter = debter;
        }

        

        private ICommand _AddDebtCommand;
        public ICommand AddDebtCommand
        {
            get
            {
                return _AddDebtCommand ?? (_AddDebtCommand = new DelegateCommand(AddDebt));
            }
        }


        private void AddDebt()
        {
            var debt = new Debt
            {
                Amount = debtAmount,
                Date = DateTime.Now
            };

            Debts.Add(debt);
            Debter.DebtList.Add(debt);
            Debter.Indebted += debtAmount;

        }

        /*
        private ICommand _CloseWindowCommand;
        public ICommand CloseWindowCommand
        {
            get
            {
                return _CloseWindowCommand ?? (_CloseWindowCommand = new DelegateCommand(CloseWindow));
            }
        }
        */





    }
}
