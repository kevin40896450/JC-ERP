using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public class UserManager
    {
        private List<UserLimitInfo> _Users;

        public List<UserLimitInfo> Users
        {
            get
            {
                if (_Users == null)
                {
                    InitUsers();
                }
                return _Users;
            }
        }
        
        /// <summary>
        /// 获取当前用户集合
        /// </summary>
        /// <returns></returns>
        private void InitUsers()
        {
            _Users = new List<UserLimitInfo>();
            DataService.BLL.v_UserRole BUserInfo = new DataService.BLL.v_UserRole();
            List<DataService.Model.v_UserRole> users = BUserInfo.GetModelList("");
            UserLimitInfo info = null;
            foreach (DataService.Model.v_UserRole model in users)
            {
                info = new UserLimitInfo();
                info.UserID = model.UserID;
                info.RoleID = model.RoleID;
                info.UserGuid = model.UserGuid;
                info.UserName = model.UserName;
                info.Pwd = model.Pwd;
                info.RealName = model.RealName;
                info.Sex = model.Sex;
                info.IDCard = model.IDCard;
                info.Tel = model.Tel;
                info.Status = model.Status;
                info.AddTime = model.AddTime;
                info.RoleName = model.RoleName;
                info.MenuList = model.MenuList;
                info.IsAllowCheck = model.IsAllowCheck;
                info.IsAllowDel = model.IsAllowDel;
                _Users.Add(info);
            }
        }
    }
}
