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

        #region 订单页面路由
        public const string OrderBase = "/order";
        /// <summary>
        /// 订单首页
        /// </summary>
        public const string OrderIndex = "/index";
        /// <summary>
        /// 添加订单
        /// </summary>
        public const string OrderAdd = "/add";
        /// <summary>
        /// 查询合同
        /// </summary>
        public const string OrderList = "/List";
        /// <summary>
        /// 获取产品类型分类
        /// </summary>
        public const string OrderBizType = "/BizType/List";
        /// <summary>
        /// 获取业务类型分类
        /// </summary>
        public const string OrderProType = "/ProType/List/{name}";        

        public const string OrderListGet = "/Get";        
        #endregion
    }
}