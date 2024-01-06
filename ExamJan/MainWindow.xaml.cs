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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExamJan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<BudgetItem> budgetList = new List<BudgetItem>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create 7 items
            // Income
            BudgetItem budgetItem1 = new BudgetItem("Grant",300m,DateTime.Parse("5/08/3003"),true);
            BudgetItem budgetItem2 = new BudgetItem("Bonus", 300m, DateTime.Parse("15/08/3003"), false);
            BudgetItem budgetItem3 = new BudgetItem("100", 300m, DateTime.Parse("25/08/3003"), true);
            //  Expenses
            BudgetItem budgetItem4 = new BudgetItem("Grant", 400m, DateTime.Parse("1/08/3003"), true);
            BudgetItem budgetItem5 = new BudgetItem("Flight", 100m, DateTime.Parse("5/08/3003"), false);
            BudgetItem budgetItem6 = new BudgetItem("Netflix", 10m, DateTime.Parse("15/08/3003"), true);
            BudgetItem budgetItem7 = new BudgetItem("Spotify", 8m, DateTime.Parse("20/08/3003"), true);

            // Add to List
        }
    }
}
