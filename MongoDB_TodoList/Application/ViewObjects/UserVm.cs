namespace Application.ViewObjects {
    public class UserVm {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public string? HeadPortrait { get; set; }
        public string Email { get; set; }
        public int Status { get; set; } = 1;
    }
}
