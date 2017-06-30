using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataService.Model;

namespace JC_ERP
{
    public class UserLimit
    {
        private v_UserRole _user;

        private List<MenuTreeModel> _menuList;

        public List<MenuTreeModel> MenuList
        {
            get
            {
                if (_menuList == null)
                {
                    _menuList = CreateLimitTree();
                }
                return _menuList;
            }
        }

        public UserLimit(v_UserRole user)
        {
            this._user = user;
        }

        private List<MenuTreeModel> CreateLimitTree()
        {
            List<Menu> list = new DataService.BLL.Menu().GetModelList("MenuID in(" + this._user.MenuList + ")");
            //加载根目录
            List<MenuTreeModel> modelList = new List<MenuTreeModel>();
            MenuTreeModel model = null;
            foreach (Menu menu in list.FindAll(m => m.ParentID <= 0))
            {
                model = new MenuTreeModel();
                model.id = menu.MenuID;
                model.title = menu.MenuName;
                model.icon = menu.Icon;
                model.url = menu.Url;
                model.Children = GetChildLimitTree(list, menu.MenuID);
                modelList.Add(model);
            }
            return modelList;
        }

        /// <summary>
        /// 获取子菜单权限
        /// </summary>
        /// <param name="list"></param>
        /// <param name="parentID"></param>
        /// <returns></returns>
        private List<MenuTreeModel> GetChildLimitTree(List<Menu> list,int parentID)
        {
            List<MenuTreeModel> modelList = new List<MenuTreeModel>();
            MenuTreeModel model = null;
            foreach (Menu menu in list.FindAll(m => m.ParentID == parentID))
            {
                model = new MenuTreeModel();
                model.id = menu.MenuID;
                model.title = menu.MenuName;
                model.icon = menu.Icon;
                model.url = menu.Url;
                model.Children = GetChildLimitTree(list, menu.MenuID);
                modelList.Add(model);
            }
            return modelList;
        }
    }
}