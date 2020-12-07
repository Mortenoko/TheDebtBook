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


        private int currentIndex = -1;
        public int CurrentIndex
        {
            get
            {
                return currentIndex;
            }
            set
            {
                SetProperty(ref currentIndex, value);
            }
        }

        private Debter currentDebter = null;

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
        public ICommand AddNewDebterCommand
        {
            get
            {
                return _AddNewDebterCommand ?? (_AddNewDebterCommand = new DelegateCommand(() =>

            {
                var newDebter = new Debter();
                var vm = new AddDebterViewModel(newDebter);

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
            }
        }



                                                                    



        private ICommand _EditDebterCommand;
        public ICommand EditDebterCommand
        {

            get 
            {
                return _EditDebterCommand ?? (_EditDebterCommand = new DelegateCommand(() =>
                {
                    var tempDebter = CurrentDebter.Clone();
                    var vm = new AddDebtViewModel(tempDebter);

                    PersonDebt win = new PersonDebt
                    {
                        DataContext = vm,
                        Owner = App.Current.MainWindow
                    };
                    if (win.ShowDialog() == true)
                    {
                        CurrentDebter.DebtList = tempDebter.DebtList;
                        CurrentDebter.Indebted = tempDebter.Indebted;
                    }
                },
                () =>
                {
                    return CurrentIndex >= 0;
                }
                ).ObservesProperty(() => CurrentIndex));
            }
        }

    }
}
