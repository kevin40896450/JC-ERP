using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JC_ERP.Modules
{
    /// <summary>
    /// 路由字典
    /// </summary>
    public class RouteDictionary
    {
        /// <summary>
        /// 首页
        /// </summary>
        public const string Index = "/index";
        /// <summary>
        /// 菜单列表
        /// </summary>
        public const string MenuList = "/MenuList";

        #region Common
        /// <summary>
        /// 用户列表路由(获取简单的用户信息)
        /// </summary>
        public const string SimpleUsers = "/SimpleUsers";
        #endregion

        #region 登陆相关
        public const string Login = "/login";

        public const string Logout = "/logout";

        #endregion

        public const string Add = "/add";

        public const string Edit = "/edit";

        public const string Del = "/Del";

        public const string All = "/All";

        #region 订单页面路由
        public const string OrderBase = "/order";
        /// <summary>
        /// 订单首页
        /// </summary>
        public const string OrderIndex = "/index";
        /// <summary>
        /// 查询合同
        /// </summary>
        public const string List = "/List";
               
        /// <summary>
        /// 获取产品类型分类
        /// </summary>
        public const string OrderBizType = "/BizType/List";
        /// <summary>
        /// 获取业务类型分类
        /// </summary>
        public const string OrderProType = "/ProType/List/{name}";        

        public const string ListGet = "/Get";
        #endregion

        #region 发货页面路由
        public const string SendOrderBase = "/SendOrder";

        /// <summary>
        /// 获取发货明细列表
        /// </summary>
        public const string GetSendList = "GetSendList/{id:int}";

        public const string SendOrderAdd = "SendOrderAdd";

        public const string GetDetail = "/GetDetail/{id:int}";
        #endregion

        #region 
        public const string GroupBase = "/Group";
        #endregion

        #region
        public const string BaseDataBase = "/BaseData";

        public const string Roles = "/Roles";

        public const string RolesGet = "/Roles/Get";

        public const string RolesEdit = "/Roles/Edit";

        public const string RolesDel = "/Roles/Del";

        public const string RolesMenus = "/Menus";
        #endregion
    }
}