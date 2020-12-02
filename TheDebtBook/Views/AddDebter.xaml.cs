using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TheDebtBook.Models;
using TheDebtBook.ViewModels;

namespace TheDebtBook.Views
{
    /// <summary>
    /// Interaction logic for AddDebter.xaml
    /// </summary>
    public partial class AddDebter : Window
    {
        public AddDebter()
        {
            InitializeComponent();

            AddDebterViewModel = DataContext as AddDebter;
            
        }

        public AddDebter AddDebterViewModel { get; set; }

        private void GemBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }

    public class DebterEvent : EventArgs
    {
        public Debter Debter;
    }
}
