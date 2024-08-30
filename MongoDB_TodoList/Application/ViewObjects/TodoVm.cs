namespace Application.ViewObjects
{
    public class TodoVm
    {
        public string UserId { get; set; }
        public string? Content { get; set; }
        public DateTime ExpirationTime { get; set; }
        public bool IsRemind { get; set; } = false;
        public DateTime RemindTime { get; set; }
        public int CompleteStatus { get; set; }
    }
}
