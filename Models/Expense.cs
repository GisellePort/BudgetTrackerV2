using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTrackerV2.Models
{
    namespace BudgetTracker.Models
    {
        public class Expense
        {
            public string Name { get; set; } = string.Empty; //initialize to avoide null warnings also Expense NAme
            public string Category { get; set; } = string.Empty;   // food, transport, bills
            public decimal Amount { get; set; }     // amount it cost
            public DateTime Date { get; set; }      // date it was spent
        }
    }
}
