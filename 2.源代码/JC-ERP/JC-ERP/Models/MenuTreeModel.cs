using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataService.Model;

namespace JC_ERP
{
    public class MenuTreeModel
    {
        /// <summary>
        /// 菜单编号
        /// </summary>
        public int id;
        /// <summary>
        /// 菜单标题
        /// </summary>
        public string title;
        /// <summary>
        /// 图标
        /// </summary>
        public string icon;
        /// <summary>
        /// 链接地址
        /// </summary>
        public string url;

        public List<MenuTreeModel> Children;
    }    
}