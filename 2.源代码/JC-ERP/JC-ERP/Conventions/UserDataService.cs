using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataService.Model;

namespace JC_ERP
{
    public class UserDataService
    {
        private UserDataService() { }
        public static readonly UserDataService SingleObj = new UserDataService();

        private List<v_UserRole> _Users;

        public List<v_UserRole> Users
        {
            get
            {
                if (_Users == null)
                {
                    UpdateUsers();
                }
                return _Users;
            }
        }

        /// <summary>
        /// 更新缓存的用户数据
        /// </summary>
        public void UpdateUsers()
        {
            DataService.BLL.v_UserRole BUserInfo = new DataService.BLL.v_UserRole();
            _Users = BUserInfo.GetModelList("");
        }
    }
}