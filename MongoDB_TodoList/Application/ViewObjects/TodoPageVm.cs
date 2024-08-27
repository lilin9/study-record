namespace Application.ViewObjects
{
    public record TodoPageVm
    {
        public string? Id { get; set; }
        public string? Content { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
