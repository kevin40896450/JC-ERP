using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using DataService.Model;

namespace JC_ERP
{
    public class UserMapper : IUserMapper
    {
        private static List<v_UserRole> users;
        static UserMapper()
        {
            users = UserDataService.SingleObj.Users;
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
            return userRecord == null ? null : new UserIdentity {
                UserName = userRecord.UserName,
                Claims = new [] {userRecord.UserID.ToString(),userRecord.Pwd }
            };
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
        public static v_UserRole GetUser(string username)
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
