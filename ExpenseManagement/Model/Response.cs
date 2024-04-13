namespace ExpenseManagement.Model
{
    public class Response
    {
        public bool isSuccessful { get; set; }
        public string? message { get; set; }
        public dynamic? data { get; set; }
    }
}
