﻿using System;
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
    // https://github.com/March0o/ExamJan.git
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //  Create Lists
        List<BudgetItem> incomeList = new List<BudgetItem>();
        List<BudgetItem> expenseList = new List<BudgetItem>();

        List<BudgetItem> filteredIncomeList = new List<BudgetItem>();
        List<BudgetItem> filteredExpenseList = new List<BudgetItem>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create 7 items
                // Income
            BudgetItem budgetItem1 = new BudgetItem("Grant",300m, BudgetItem.BudgetItemType.Income ,DateTime.Parse("5/08/3003"),true);
            BudgetItem budgetItem2 = new BudgetItem("Bonus", 300m, BudgetItem.BudgetItemType.Income, DateTime.Parse("15/08/3003"), false);
            BudgetItem budgetItem3 = new BudgetItem("100", 300m, BudgetItem.BudgetItemType.Income, DateTime.Parse("25/08/3003"), true);
                //  Expenses
            BudgetItem budgetItem4 = new BudgetItem("Grant", 400m, BudgetItem.BudgetItemType.Expense, DateTime.Parse("1/08/3003"), true);
            BudgetItem budgetItem5 = new BudgetItem("Flight", 100m, BudgetItem.BudgetItemType.Expense, DateTime.Parse("5/08/3003"), false);
            BudgetItem budgetItem6 = new BudgetItem("Netflix", 10m, BudgetItem.BudgetItemType.Expense, DateTime.Parse("15/08/3003"), true);
            BudgetItem budgetItem7 = new BudgetItem("Spotify", 8m, BudgetItem.BudgetItemType.Expense, DateTime.Parse("20/08/3003"), true);

            // Add to Lists
            incomeList.Add(budgetItem1);
            incomeList.Add(budgetItem2);
            incomeList.Add(budgetItem3);

            expenseList.Add(budgetItem4);
            expenseList.Add(budgetItem5);
            expenseList.Add(budgetItem6);
            expenseList.Add(budgetItem7);

            // Populate filtered lists
            filteredIncomeList = incomeList;
            filteredExpenseList = expenseList;

            // Display List in Listboxes
            UpdateListBoxes();
        }

        public void AddItem()
        {
            // Get values
            string name = tbxName.Text;
            decimal amount = decimal.Parse(tbxAmount.Text);
            BudgetItem.BudgetItemType itemType = BudgetItem.BudgetItemType.Income;
            if (rbtnIncome.IsChecked == true)
            {
                itemType = BudgetItem.BudgetItemType.Income;
            }
            else if (rbtnExpense.IsChecked == true) 
            {
                itemType = BudgetItem.BudgetItemType.Expense;
            }
            DateTime date = datepicker.SelectedDate.Value.ToUniversalTime();
            bool recurring = false;
            if (cbxRecurring.IsChecked == true) 
            {
                recurring = true;
            }

            // Create Item
            BudgetItem newItem = new BudgetItem(name,amount,itemType,date,recurring);

            // Add to list
            if (newItem.ItemType == BudgetItem.BudgetItemType.Income) 
            {
                incomeList.Add(newItem);
            }
            else if (newItem.ItemType == BudgetItem.BudgetItemType.Expense)
            {
                expenseList.Add(newItem);
            }

            // Update Boxes
            UpdateListBoxes();
        }

        public void RemoveItem()
        {
            //  Declare Item
            BudgetItem chosen = null;

            // Determine what is selected
            if (lbxIncome.SelectedItem != null) 
            {
                chosen = lbxIncome.SelectedItem as BudgetItem;
            }
            else if (lbxExpenses.SelectedItem != null) 
            {
                chosen = lbxExpenses.SelectedItem as BudgetItem;
            }

            if (chosen == null)
            {
                MessageBox.Show("Please choose an item");
            }
            else
            {
                // Remove from list
                if (chosen.ItemType == BudgetItem.BudgetItemType.Income)
                {
                    incomeList.Remove(chosen);
                }
                else if (chosen.ItemType == BudgetItem.BudgetItemType.Expense)
                {
                    expenseList.Remove(chosen);
                }

                //  Update Display
                UpdateListBoxes();
            }
        }

        public void UpdateListBoxes()
        {
            lbxExpenses.ItemsSource = null;
            lbxIncome.ItemsSource = null;

            lbxExpenses.ItemsSource = filteredExpenseList;
            lbxIncome.ItemsSource = filteredIncomeList;

            UpdateTotals();
        }

        public void UpdateTotals()
        {
            //  Total Income
            decimal totalIncome = 0;
            foreach (BudgetItem item in incomeList) 
            {
                totalIncome += item.Amount;
            }

            //  Total Expenses
            decimal totalExpenses = 0;
            foreach (BudgetItem item in expenseList)
            {
                totalExpenses += item.Amount;
            }

            // Total Balance
            decimal totalBalance = totalIncome - totalExpenses;

            // Update Boxes
            tblkIncome.Text = $"{totalIncome:c}";
            tblkTotalOutgoings.Text = $"{totalExpenses:c}";
            tblkCurrentBalance.Text = $"{totalBalance:c}";
        }

        public void Search()
        {
            // Assign List Values
            filteredIncomeList.Clear();
            filteredExpenseList.Clear();

            // Get input value
            string input = tbxSearch.Text;

            // Loop to find matching items
            foreach (BudgetItem item in incomeList) // Loop through income
            {
                if (item.Name.Contains(input))
                {
                    filteredIncomeList.Add(item);
                }
            }
            foreach (BudgetItem item in expenseList)
            {
                if ( item.Name.Contains(input)) 
                {
                    filteredExpenseList.Add(item);
                }
            }

            // Update Display
            UpdateListBoxes();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddItem();
        }

        private void lbxIncome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbxExpenses.SelectedItem = null; 
        }

        private void lbxExpenses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbxIncome.SelectedItem = null;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            RemoveItem();
        }

        private void tbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void tbxName_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxName.Text = null;
        }

        private void tbxAmount_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxAmount.Text = null;
        }
    }
}
