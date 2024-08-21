using NETCore.Encrypt;

namespace Repository.Entities {
    public class UserInfo: BaseEntity {
        private UserInfo() { }

        public UserInfo(string userName, string password, string? nickName, string? headPortrait, string email, byte status) {
            UserName = userName;
            Password = password;
            NickName = nickName;
            HeadPortrait = headPortrait;
            Email = email;
            Status = status;
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 登录账号
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// 登录密码
        /// </summary>

        public string Password {
            get => Password;
            private set => LockPassword(Password);
        }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string? NickName { get; private set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string? HeadPortrait { get; private set; }

        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// 用户状态（0冻结，1正常，2注销）
        /// </summary>
        public byte Status { get; private set; }


        /// <summary>
        /// 将用户密码进行md5加密
        /// </summary>
        /// <param name="password"></param>
        public void LockPassword(string password) {
            Password = EncryptProvider.Md5(password);
        }
    }
}
