Budget Tracker v2

**Description:**  
A simple, console-based **budget tracker** written in C#. Users can add, view, remove, and sort expenses, as well as view summaries by category. Expenses are saved to a JSON file for persistence across sessions.  

**Features:**  
- Add new expenses (name, category, amount, date defaults to today)  
- View all recorded expenses in a formatted table  
- Remove expenses by selecting from a numbered list  
- Sort expenses by **Amount, Date, or Category** using LINQ  
- View a **summary of total expenses per category**  
- Persist expenses in a 'JSON' file ('expenses.json')  

**Technologies Used:**  
- C# (.NET 6+)  
- LINQ for sorting and aggregation  
- JSON serialization for saving/loading data  
- Console-based UI with formatting and colors  

**File Structure:** 

BudgetTrackerV2/
│
├── Models/
│ └── Expense.cs # Defines the Expense object
│
├── Services/
│ └── ExpenseManager.cs # Handles all expense operations (add, remove, sort, summary)
│
└── Program.cs # User interface and menu

**How to Run:**  
1. Clone or download the project.  
2. Open the solution in Visual Studio or VS Code.  
3. Build the project (ensure .NET 6+ is installed).  
4. Run the console app.  
5. Follow the menu instructions to manage your expenses.

   
