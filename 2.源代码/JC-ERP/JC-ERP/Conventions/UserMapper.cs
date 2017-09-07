using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using Security;

namespace JC_ERP
{
    public class UserMapper : IUserMapper
    {
        public static List<UserLimitInfo> users;
        static UserMapper()
        {
            UserManager manage = new UserManager();
            users = manage.Users;
        }

        /// <summary>
        /// 验证用户权限
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            var userRecord = users.FirstOrDefault(u => new Guid(u.UserGuid) == identifier);
            if (userRecord != null)
            {
                List<MenuTreeInfo> list = new MenuManager().InitMenu(userRecord.MenuList);
                return new UserIdentity
                {
                    UserID = userRecord.UserID,
                    UserName = userRecord.UserName,
                    Claims = new[] { userRecord.Pwd },
                    Menus = list,
                    MenuTrees = new MenuManager().SerializationMenu(list)
                };
            }
            else return null;
        }

        /// <summary>
        /// 用户验证，返回用户Guid
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Guid? ValidateUser(string username, string password)
        {
            var userRecord = users.FirstOrDefault(u => u.UserName.ToLower() == username.ToLower() && u.Pwd.ToLower() == password.ToLower());

            if (userRecord != null)
            {
                return new Guid(userRecord.UserGuid);
            }
            else return null;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static UserLimitInfo GetUser(string username)
        {
            var userRecord = users.FirstOrDefault(u => u.UserName== username);

            if (userRecord != null)
            {
                return userRecord;
            }
            else return null;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldPwd"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        public static bool ChangePwd(string username,string oldPwd,string newPwd)
        {
            var userRecord = users.FirstOrDefault(u => u.UserName == username);
            if (userRecord != null && userRecord.Pwd.ToLower() == oldPwd.ToLower())
            {
                userRecord.Pwd = newPwd;
                return true;
            }
            else return false;
        }
    }
}
