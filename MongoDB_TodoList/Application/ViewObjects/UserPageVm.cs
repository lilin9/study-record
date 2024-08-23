namespace Application.ViewObjects {
    public class UserPageVm {
        public string? Id { get; set; }
        public string? NickName { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
