using Dapper;
using ExpenseManagement.Model;
using ExpenseManagement.Service;
using System.Data.SqlClient;

namespace ExpenseManagement.Repository
{
    public class ExpenseRepo : IExpenseService
    {
        string connectionString;
        ConnectionStrings connectionName;
        private readonly IDictionary<ConnectionStrings, string> _connectionDict;

        public ExpenseRepo(IDictionary<ConnectionStrings, string> connectionDict)
        {
            _connectionDict = connectionDict;
            _connectionDict.TryGetValue(connectionName, out connectionString);
        }

        public async Task<Response> LoadDropdowns(Expense expense)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@action", "loadDropdowns");
                dynamicParameters.Add("@expenseUserId", expense.expenseUserId);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var cmd = new CommandDefinition("Manage_Expense_Module", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure, flags:CommandFlags.NoCache);
                    var multiResult = await connection.QueryMultipleAsync(cmd);

                    dynamic dynamicResponse = new System.Dynamic.ExpandoObject();

                    dynamicResponse.expenseTypes = multiResult.Read<Expense>();
                    dynamicResponse.userInfo = multiResult.Read().FirstOrDefault();

                    return new Response() { isSuccessful = true, data = dynamicResponse, message = "Successful" };
                }
            }
            catch (Exception e)
            {

                return new Response() { isSuccessful = false, message = "Some error occured while loading expenses.", data = e };
            }
        }
        public async Task<Response> LoadExpenses(Expense expense)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@action", "loadExpensesDetails");
                dynamicParameters.Add("@fromDate", expense.fromDate);
                dynamicParameters.Add("@toDate", expense.toDate);
                dynamicParameters.Add("@expenseUserId", expense.expenseUserId);
                dynamicParameters.Add("@expenseTypeId", expense.expenseTypeId);


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var result = await connection.QueryAsync<Expense>("Manage_Expense_Module", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { isSuccessful = true, data = result, message = "Successful" };
                }
            }
            catch (Exception e)
            {

                return new Response() { isSuccessful = false, message = "Some error occured while loading expenses.", data = e };
            }
        }
        public async Task<Response> LoadExpenseDetailsTypeWise(Expense expense)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@action", "loadExpenseDetailsTypeWise");
                dynamicParameters.Add("@fromDate", expense.fromDate);
                dynamicParameters.Add("@toDate", expense.toDate);
                dynamicParameters.Add("@expenseUserId", expense.expenseUserId);
                dynamicParameters.Add("@expenseTypeId", expense.expenseTypeId);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var result = await connection.QueryAsync<Expense>("Manage_Expense_Module", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { isSuccessful = true, data = result, message = "Successful" };
                }
            }
            catch (Exception e)
            {
                return new Response() { isSuccessful = false, message = "Some error occured while loading expenses.", data = e };
            }
        }

        public async Task<Response> CreateExpense(Expense expense)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@action", "createExpense");
                dynamicParameters.Add("@expenseDate", expense.expenseDate);
                dynamicParameters.Add("@expenseNarration", expense.expenseNarration);
                dynamicParameters.Add("@amount", expense.amount);
                dynamicParameters.Add("@userId", expense.userId);
                dynamicParameters.Add("@expenseUserId", expense.expenseUserId);
                dynamicParameters.Add("@expenseTypeId", expense.expenseTypeId);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    return await connection.QueryFirstAsync<Response>("Manage_Expense_Module", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception e)
            {
                return new Response() { isSuccessful = false, message = "Some error occured while loading expenses.", data = e };
            }
        }

        public async Task<Response> GetExpenseById(Expense expense)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@action", "getExpesnseById");
                dynamicParameters.Add("@expenseId", expense.expenseId);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var result = await connection.QueryFirstAsync<Expense>("Manage_Expense_Module", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                    return new Response() { isSuccessful = true, message = "Successful", data = result };
                }
            }
            catch (Exception e)
            {
                return new Response() { isSuccessful = false, message = "Some error occured while loading expenses.", data = e };
            }
        }

        public async Task<Response> EditExpense(Expense expense)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@action", "editExpense");
                dynamicParameters.Add("@expenseId", expense.expenseId);
                dynamicParameters.Add("@expenseNarration", expense.expenseNarration);
                dynamicParameters.Add("@amount", expense.amount);
                dynamicParameters.Add("@userId", expense.userId);
                dynamicParameters.Add("@expenseUserId", expense.expenseUserId);
                dynamicParameters.Add("@expenseTypeId", expense.expenseTypeId);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    return await connection.QueryFirstAsync<Response>("Manage_Expense_Module", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception e)
            {
                return new Response() { isSuccessful = false, message = "Some error occured while loading expenses.", data = e };
            }
        }
    }
}
