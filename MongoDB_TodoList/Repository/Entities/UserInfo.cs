using MongoDB.Bson;
using NETCore.Encrypt;

namespace Domain.Entities {
    public class UserInfo: BaseEntity {
        public UserInfo() { }

        public UserInfo(Builder builder) {
            Id = ObjectId.GenerateNewId().ToString();
            UserName = builder.UserName;
            Password = builder.Password;
            NickName = builder.NickName;
            HeadPortrait = builder.HeadPortrait;
            Email = builder.Email;
            Status = builder.Status;
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 登录账号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>

        public string Password {
            get; set;
        }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string? NickName { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string? HeadPortrait { get; set; }

        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 用户状态（0冻结，1正常，2注销）
        /// </summary>
        public int Status { get; set; } = 1;

        public class Builder {
            public string UserName { get; private set; }

            public string Password { get; private set; }

            public string? NickName { get; private set; }

            public string? HeadPortrait { get; private set; }

            public string Email { get; private set; }

            public int Status { get; private set; }

            public Builder SetUserName(string userName) {
                UserName = userName;
                return this;
            }

            public Builder SetPassword(string password) {
                Password = LockPassword(password);
                return this;
            }

            public Builder SetNickName(string? nickName) {
                NickName = nickName;
                return this;
            }

            public Builder SetHeadPortrait(string? headPortrait) {
                HeadPortrait = headPortrait;
                return this;
            }

            public Builder SetEmail(string email) {
                Email = email;
                return this;
            }

            public Builder SetStatus(int status) {
                Status = status;
                return this;
            }

            /// <summary>
            /// 将用户密码进行md5加密
            /// </summary>
            /// <param name="password"></param>
            private string LockPassword(string password) {
                return EncryptProvider.Md5(password);
            }
        }
    }
}
