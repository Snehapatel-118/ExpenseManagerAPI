using ExpenseManagement.Model;
using ExpenseManagement.Service;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private IExpenseService _expenseService;
        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }


        [HttpPost]
        [ActionName("loadDropdowns")]

        public async Task<IActionResult> LoadDropdowns(Expense expense)
        {
            return Ok(await _expenseService.LoadDropdowns(expense));
        }

        [HttpPost]
        [ActionName("loadExpenses")]

        public async Task<IActionResult> LoadExpenses(Expense expense)
        {
            return Ok(await _expenseService.LoadExpenses(expense));
        }

        [HttpPost]
        [ActionName("loadExpenseDetailsTypeWise")]

        public async Task<IActionResult> LoadExpenseDetailsTypeWise(Expense expense)
        {
            return Ok(await _expenseService.LoadExpenseDetailsTypeWise(expense));
        }

        [HttpPost]
        [ActionName("createExpense")]

        public async Task<IActionResult> CreateExpense(Expense expense)
        {
            return Ok(await _expenseService.CreateExpense(expense));
        }

        [HttpPost]
        [ActionName("getExpenseById")]

        public async Task<IActionResult> GetExpenseById(Expense expense)
        {
            return Ok(await _expenseService.GetExpenseById(expense));
        }

        [HttpPost]
        [ActionName("editExpense")]

        public async Task<IActionResult> EditExpense(Expense expense)
        {
            return Ok(await _expenseService.EditExpense(expense));
        }
    }
}
