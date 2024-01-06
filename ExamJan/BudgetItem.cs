using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamJan
{
    internal class BudgetItem : IComparable
    {
        // Properties
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public enum ItemType { Income, Expense}
        public DateTime Date { get; set; }
        public bool Recurring { get; set; }

        //  Constructors
        public BudgetItem() { }
        public BudgetItem(string name, decimal amount, Enum itemType, DateTime date, bool recurring)
        {
            Name = name;
            Amount = amount;
            Date = date;
            Recurring = recurring;
        }

        //  Methods
        public override string ToString()
        {
            return $"{Date.ToString("dddd")} {Name} {Amount} - {Recurring}";
        }

        public int CompareTo(object obj)
        {
           BudgetItem that = obj as BudgetItem;
           return this.Date.CompareTo(that.Date);
        }
    } // End of Class
}
