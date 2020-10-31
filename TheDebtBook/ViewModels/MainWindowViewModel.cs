using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using TheDebtBook.Views;
using System.Collections.ObjectModel;
using TheDebtBook.Models;

namespace TheDebtBook.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        private Debter currentDebter = null;
        private ObservableCollection<Debter> debters;

        public MainWindowViewModel()
        {
            debters = new ObservableCollection<Debter>();
        }


        public ObservableCollection<Debter> Debters
        {
            get
            {
                return debters;
            }
            set
            {
                SetProperty(ref debters, value);
            }
        }

        public Debter CurrentDebter
        {
            get
            {
                return currentDebter;
            }
            set
            {
                SetProperty(ref currentDebter, value);
            }
        }




        private ICommand _AddNewDebterCommand;
        public ICommand AddNewDebterCommand => _AddNewDebterCommand ?? (_AddNewDebterCommand = new DelegateCommand(() =>

            {
                var newDebter = new Debter();
                var vm = new AddDebterViewModel();

                var view = new AddDebter()
                {
                    DataContext = vm
                };

                if (view.ShowDialog() == true)
                {
                    Debters.Add(newDebter);
                    CurrentDebter = newDebter;
                }

            }));



                                                                    



        private ICommand _EditDebterCommand;
        public ICommand EditDebterCommand
        {
            get 
            {
                return _EditDebterCommand ?? (_EditDebterCommand = new DelegateCommand(EditDebterWindow));
            }
        }

        private void EditDebterWindow()
        {
            PersonDebt EditDebterWin = new PersonDebt();

            EditDebterWin.Show();
        }
    }
}
