using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JC_ERP.Modules
{
    /// <summary>
    /// 视图字典
    /// </summary>
    public class ViewDictionary
    {
        /// <summary>
        /// 首页视图
        /// </summary>
        public const string Index = "/index";
        /// <summary>
        /// 登陆页面
        /// </summary>
        public const string Login = "/login.html";

        #region 订单相关
        public const string OrderAdd = "/Order/AddOrder";

        /// <summary>
        /// 查询合同
        /// </summary>
        public const string OrderList = "/Order/OrderList";
        #endregion

        #region 发货单相关
        public const string SendOrderAdd = "/SendOrder/AddSendOrder";
        /// <summary>
        /// 查询发货单
        /// </summary>
        public const string SendOrderList = "/SendOrder/SendOrderList";
        #endregion

        #region 发货组相关
        /// <summary>
        /// 查询发货组
        /// </summary>
        public const string GroupList = "/Group/List";
        /// <summary>
        /// 添加发货组
        /// </summary>
        public const string GroupAdd = "/Group/Add";
        #endregion
    }
}