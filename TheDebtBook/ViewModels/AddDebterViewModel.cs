using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Mvvm;
using TheDebtBook.Models;
using Prism.Commands;
using TheDebtBook.Views;

namespace TheDebtBook.ViewModels
{
    public class AddDebterViewModel : BindableBase
    {
        private double currentDebt;
        public Debter debter { get; set; }

       

        public AddDebterViewModel()
        {
            debter = new Debter("JohnJohn", 300);
            currentDebt = 0.0;
        }

        public double CurrentDebt
        {
            get
            {
                return currentDebt;
            }
            set
            {
                SetProperty(ref currentDebt, value);
            }
        }



        ICommand _AddDebterCommand;
        public ICommand AddDebterCommand
        {
            get
            {
                return _AddDebterCommand ?? (_AddDebterCommand = new DelegateCommand(AddDebter));
            }
        }

        private void AddDebter()
        {
            debter.AddDebt(currentDebt);
            var args = new DebterEvent();
            args.Debter = debter;
            AddDebterEvent?.Invoke(this, args);

        }

        public event EventHandler<DebterEvent> AddDebterEvent; 
        


    }
}
