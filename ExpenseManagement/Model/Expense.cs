namespace ExpenseManagement.Model
{
    public class Expense
    {
        public long expenseId { get; set; }
        public string? expenseDate { get; set; }
        public string? fromDate { get; set; }
        public string? toDate { get; set; }
        public long expenseTypeId { get; set; }
        public string? expenseNarration { get; set; }
        public decimal amount { get; set; }
        public long userId { get; set; }
        public long expenseUserId { get; set; }
        public string? expenseTypeDesc { get; set; }
    }
}
