
using BudgetTrackerV2.Services;
using System;

namespace BudgetTrackerV2
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new ExpenseManager();
            bool running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n Budget Tracker ");
                Console.ResetColor();
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. Show All Expenses");
                Console.WriteLine("3. Remove Expense");
                Console.WriteLine("4. Sort Expenses");
                Console.WriteLine("5. Show Summary by Category");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice (1-6): ");

                string choice = Console.ReadLine() ?? "";

                if (choice == "1")
                {
                    Console.Write("Expense Name: ");
                    string name = Console.ReadLine() ?? "";

                    Console.Write("Category: ");
                    string category = Console.ReadLine() ?? "";

                    // ✅ Safe decimal input
                    decimal amount;
                    while (true)
                    {
                        Console.Write("Amount: ");
                        string? input = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(input) && decimal.TryParse(input, out amount))
                            break;

                        Console.WriteLine("Invalid number. Please enter a valid amount.");
                    }

                    DateTime date = DateTime.Now;

                    manager.AddExpense(name, category, amount, date);
                }
                else if (choice == "2")
                {
                    manager.ShowAllExpenses();
                }
                else if (choice == "3")
                {
                    manager.RemoveExpense();
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Sort by:");
                    Console.WriteLine("1. Amount");
                    Console.WriteLine("2. Date");
                    Console.WriteLine("3. Category");
                    string sortChoice = Console.ReadLine() ?? "";

                    if (sortChoice == "1") manager.SortByAmount();
                    else if (sortChoice == "2") manager.SortByDate();
                    else if (sortChoice == "3") manager.SortByCategory();
                    else Console.WriteLine("Invalid choice.");
                }
                else if (choice == "5")
                {
                    manager.ShowSummaryByCategory();
                }
                else if (choice == "6")
                {
                    running = false;
                    manager.SaveExpenses();
                    Console.WriteLine("Expenses saved. Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid choice, try again.");
                }
            }
        }
    }
}