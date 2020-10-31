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

namespace TheDebtBook.ViewModels
{
    class AddDebtViewModel : BindableBase
    {
        public Debter Debter { get; set; }

        public Window Window { get; set; }

        private double _debtAmount = 0.0; 

        
        private void CloseWindow()
        {
            Window.Close();
        }

        private double debtAmount
        {
            get
            {
                return _debtAmount;
            }
            set
            {
                SetProperty(ref _debtAmount, value);
            }
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
            Debter.AddDebt(debtAmount);
        }


        private ICommand _CloseWindowCommand;
        public ICommand CloseWindowCommand
        {
            get
            {
                return _CloseWindowCommand ?? (_CloseWindowCommand = new DelegateCommand(CloseWindow));
            }
        }





    }
}
