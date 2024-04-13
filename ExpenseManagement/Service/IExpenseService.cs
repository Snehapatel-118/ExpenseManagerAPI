using ExpenseManagement.Model;

namespace ExpenseManagement.Service
{
    public interface IExpenseService
    {
        public Task<Response> LoadDropdowns(Expense expense);
        public Task<Response> LoadExpenses(Expense expense);
        public Task<Response> LoadExpenseDetailsTypeWise(Expense expense);
        public Task<Response> CreateExpense(Expense expense);
        public Task<Response> GetExpenseById(Expense expense);
        public Task<Response> EditExpense(Expense expense);
    }
}
