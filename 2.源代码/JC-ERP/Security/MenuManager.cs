using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Model;

namespace Security
{
    public class MenuManager
    {        
        /// <summary>
        /// 初始化菜单对象
        /// </summary>
        /// <param name="MenuList"></param>
        public List<MenuTreeInfo> InitMenu(string MenuList)
        {
            List<MenuTreeInfo> Menus = new List<MenuTreeInfo>();
            List<Menu> list = new DataService.BLL.Menu().GetModelList("MenuID in(" + MenuList + ")");
            //加载根目录
            MenuTreeInfo model = null;
            foreach (Menu menu in list)
            {
                model = new MenuTreeInfo();
                model.id = menu.MenuID;
                model.title = menu.MenuName;
                model.icon = menu.Icon;
                model.url = menu.Url;
                model.ParentID = menu.ParentID;
                Menus.Add(model);
            }
            return Menus;
        }

        /// <summary>
        /// 将菜单集合序列化为父子结构的对象
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<MenuTreeInfo> SerializationMenu(List<MenuTreeInfo> list)
        {
            List<MenuTreeInfo> Menus = new List<MenuTreeInfo>();
            //加载根目录
            MenuTreeInfo model = null;
            foreach (MenuTreeInfo menu in list.FindAll(m => m.ParentID <= 0))
            {
                model = new MenuTreeInfo();
                model.id = menu.id;
                model.title = menu.title;
                model.icon = menu.icon;
                model.url = menu.url;
                model.ParentID = menu.ParentID;
                model.Children = GetChildLimitTree(list, menu.id);
                Menus.Add(model);
            }
            return Menus;
        }

        /// <summary>
        /// 获取子菜单权限
        /// </summary>
        /// <param name="list"></param>
        /// <param name="parentID"></param>
        /// <returns></returns>
        private List<MenuTreeInfo> GetChildLimitTree(List<MenuTreeInfo> list, int parentID)
        {
            List<MenuTreeInfo> modelList = new List<MenuTreeInfo>();
            MenuTreeInfo model = null;
            foreach (MenuTreeInfo menu in list.FindAll(m => m.ParentID == parentID))
            {
                model = new MenuTreeInfo();
                model.id = menu.id;
                model.title = menu.title;
                model.icon = menu.icon;
                model.url = menu.url;
                model.ParentID = menu.ParentID;
                model.Children = GetChildLimitTree(list, menu.id);
                modelList.Add(model);
            }
            return modelList;
        }
        
    }
}
