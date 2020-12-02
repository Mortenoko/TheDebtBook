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
        public Debter Debter { get; set; }

       

        public AddDebterViewModel()
        {
            Debter = new Debter("Navn her");
            currentDebt = 0;
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



        ICommand _addDebterCommand;
        public ICommand AddDebterCommand
        {
            get
            {
                return _addDebterCommand ?? (_addDebterCommand = new DelegateCommand(
                    AddDebterCommand_Execute, AddDebterCommand_CanExecute)
                    .ObservesProperty(() => Debter.Name)
                    .ObservesProperty(() => Debter.Indebted));
            }
        }

        private void AddDebterCommand_Execute()
        {

        }

        private bool AddDebterCommand_CanExecute()
        {
            return true;
        }

        /*
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
            Debter.AddDebt(currentDebt);
            var args = new DebterEvent();
            args.Debter = Debter;
            AddDebterEvent?.Invoke(this, args);
            this.Close();

        }

        public event EventHandler<DebterEvent> AddDebterEvent; 
        */


    }
}
