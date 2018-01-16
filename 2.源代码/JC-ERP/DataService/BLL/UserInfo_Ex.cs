using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.BLL
{
    /// <summary>
    /// 用户表
    /// </summary>
    public partial class UserInfo
    {
        public DataService.Model.UserInfo GetModel(string userName)
        {

            return dal.GetModel(userName);
        }
    }
}
