using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public class NavManager
    {
        /// <summary>
        /// 创建导航对象
        /// </summary>
        /// <param name="url"></param>
        /// <param name="Menus"></param>
        /// <returns></returns>
        public NavInfo CreateNav(string url,List<MenuTreeInfo> Menus)
        {

            MenuTreeInfo menu = Menus.Find(m => m.url == url);
            NavInfo navModel = new NavInfo();
            if (menu != null)
            {
                string parentNav = CreateParentNav(Menus, menu.ParentID);
                string nav = "<li><a href=\"/\"><i class=\"fa fa-dashboard\"></i>首页</a></li>" + parentNav + "<li class=\"active\">" + menu.title + "</li>";
                navModel.Nav = nav;
                navModel.Title = menu.title;
            }
            return navModel;
        }

        /// <summary>
        /// 创建父级导航
        /// </summary>
        /// <param name="menuList"></param>
        /// <param name="parentID"></param>
        /// <returns></returns>
        private static string CreateParentNav(List<MenuTreeInfo> menuList, int parentID)
        {
            if (parentID <= 0) return "";
            string nav = "";
            MenuTreeInfo menu = menuList.Find(m => m.id == parentID);
            if (menu != null)
            {
                string parentNav = CreateParentNav(menuList, menu.ParentID);
                nav = parentNav + "<li><a href=\"" + (!String.IsNullOrEmpty(menu.url) ? menu.url : "#") + "\">" + menu.title + "</a></li>";
            }
            return nav;
        }
    }
}
