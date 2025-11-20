
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
                // menu options
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

                // choice 1 - add items 
                if (choice == "1")
                {
                    Console.Write("Expense Name: ");
                    string name = Console.ReadLine() ?? "";

                    Console.Write("Category: ");
                    string category = Console.ReadLine() ?? "";

                    // decimal input
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

                // choice 2 - show all expenses
                else if (choice == "2")
                {
                    manager.ShowAllExpenses();
                }

                // choice 3 - remove an expense
                else if (choice == "3")
                {
                    manager.RemoveExpense();
                }

                // choice 4 - sort list 
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

                // choice 5 - show summary of all category
                else if (choice == "5")
                {
                    manager.ShowSummaryByCategory();
                }

                // choice 6 - exit - close program
                else if (choice == "6")
                {
                    running = false;
                    manager.SaveExpenses();
                    Console.WriteLine("Expenses saved.);
                }

                // invalid choices catch
                else
                {
                    Console.WriteLine("Invalid choice, try again.");
                }
            }
        }
    }

}
