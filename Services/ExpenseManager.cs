using BudgetTrackerV2.Models;
using BudgetTrackerV2.Models.BudgetTracker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BudgetTrackerV2.Services
{
    public class ExpenseManager
    {
        private List<Expense> _expenses;
        private string _fileName = "expenses.json";

        public ExpenseManager()
        {
            _expenses = new List<Expense>();
            LoadExpenses();
        }

        // crud methods
        public void AddExpense(string name, string category, decimal amount, DateTime date)
        {
            _expenses.Add(new Expense
            {
                Name = name,
                Category = category,
                Amount = amount,
                Date = date
            });
            Console.WriteLine("Expense added successfully.");
        }

        public void ShowAllExpenses()
        {
            if (_expenses.Count == 0)
            {
                Console.WriteLine("No expenses recorded.");
                return;
            }

            // add color to console
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" All Expenses ");
            Console.WriteLine("{0,-20} {1,-15} {2,10} {3,12}", "Name", "Category", "Amount", "Date");
            Console.ResetColor();

            foreach (var e in _expenses)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0,-20} {1,-15} ${2,9:F2} {3,12}", e.Name, e.Category, e.Amount, e.Date.ToShortDateString());
                Console.ResetColor();
            }
        }

        public void RemoveExpense()
        {
            if (_expenses.Count == 0)
            {
                Console.WriteLine("No expenses to remove.");
                return;
            }

            Console.WriteLine("Select an expense to remove:");
            for (int i = 0; i < _expenses.Count; i++)
            {
                var e = _expenses[i];
                Console.WriteLine($"{i + 1}. {e.Name} - {e.Category} - ${e.Amount:F2} on {e.Date.ToShortDateString()}");
            }

            int choice = GetValidatedIntInput("Enter number: ");

            if (choice < 1 || choice > _expenses.Count)
            {
                Console.WriteLine("Invalid number.");
                return;
            }

            var removed = _expenses[choice - 1];
            _expenses.RemoveAt(choice - 1);
            Console.WriteLine($"Removed expense: {removed.Name} - {removed.Category} - ${removed.Amount:F2}");
        }

        
        // sorting methods
        
        public void SortByAmount()
        {
            DisplaySorted(_expenses.OrderBy(e => e.Amount).ToList(), "Amount");
        }

        public void SortByDate()
        {
            DisplaySorted(_expenses.OrderBy(e => e.Date).ToList(), "Date");
        }

        public void SortByCategory()
        {
            DisplaySorted(_expenses.OrderBy(e => e.Category).ToList(), "Category");
        }

        private void DisplaySorted(List<Expense> sorted, string criteria)
        {
            if (sorted.Count == 0)
            {
                Console.WriteLine("No expenses to display.");
                return;
            }

            Console.WriteLine($" Expenses Sorted by {criteria} ");
            foreach (var e in sorted)
            {
                Console.WriteLine($"{e.Name} - {e.Category} - ${e.Amount:F2} on {e.Date.ToShortDateString()}");
            }
        }

        
        // summary
        
        public void ShowSummaryByCategory()
        {
            if (_expenses.Count == 0)
            {
                Console.WriteLine("No expenses to summarize.");
                return;
            }

            var summary = _expenses
                .GroupBy(e => e.Category)
                .Select(g => new { Category = g.Key, Total = g.Sum(x => x.Amount) });

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Summary by Category ");
            Console.ResetColor();
            foreach (var item in summary)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{item.Category,-15}: ${item.Total:F2}");
                Console.ResetColor();
            }
        }

        
        // helper methods
        
        private int GetValidatedIntInput(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result))
                    return result;
                Console.WriteLine("Invalid input, try again.");
            }
        }

        private void LoadExpenses()
        {
            if (File.Exists(_fileName))
            {
                string json = File.ReadAllText(_fileName);
                _expenses = JsonSerializer.Deserialize<List<Expense>>(json) ?? new List<Expense>();
            }
        }

        public void SaveExpenses()
        {
            string json = JsonSerializer.Serialize(_expenses, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_fileName, json);
        }
    }

}
