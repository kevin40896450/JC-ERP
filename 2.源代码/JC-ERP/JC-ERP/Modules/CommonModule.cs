using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Security;

namespace JC_ERP.Modules
{
    public class CommonModule : NancyModule
    {
        public CommonModule()
        {
            this.RequiresAuthentication();
            //获取简单信息用户集合
            Get[RouteDictionary.SimpleUsers] = p =>
            {
                List<UserSimpleModel> list = new List<UserSimpleModel>();
                UserSimpleModel model = null;
                int roleID = 2;//设置业务员角色编号
                foreach (Security.UserLimitInfo info in UserMapper.users.FindAll(m => m.RoleID == roleID))
                {
                    model = new UserSimpleModel();
                    model.id = info.UserID;
                    model.text = info.RealName;
                    list.Add(model);
                }
                return Response.AsJson(list);
            };
        }
    }

    /// <summary>
    /// 简单用户模型，用于用户列表下拉菜单设置
    /// </summary>
    public class UserSimpleModel
    {
        public int id { get; set; }

        public string text { get; set; }
    }
}