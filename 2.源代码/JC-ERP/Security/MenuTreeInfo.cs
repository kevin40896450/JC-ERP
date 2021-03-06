﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public class MenuTreeInfo
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

        /// <summary>
        /// 父级菜单编号
        /// </summary>
        public int ParentID;

        public List<MenuTreeInfo> Children;
    }
}
