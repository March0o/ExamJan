using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamJan
{
    internal class BudgetItem : IComparable
    {
        public enum BudgetItemType { Income, Expense }

        // Properties
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public BudgetItemType ItemType {  get; set; } 
        public DateTime Date { get; set; }
        public bool Recurring { get; set; }

        //  Constructors
        public BudgetItem() { }
        public BudgetItem(string name, decimal amount,BudgetItemType itemtype, DateTime date, bool recurring)
        {
            Name = name;
            Amount = amount;
            ItemType = itemtype;
            Date = date;
            Recurring = recurring;
        }

        //  Methods
        public override string ToString()
        {
            return $"{Date.ToString("dd") + " of month"} {Name} {Amount:c} - {Recurring}";
        }

        public int CompareTo(object obj)
        {
           BudgetItem that = obj as BudgetItem;
           return this.Date.CompareTo(that.Date);
        }
    } // End of Class
}
