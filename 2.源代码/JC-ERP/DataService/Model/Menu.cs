using System;
namespace DataService.Model
{
    /// <summary>
    /// 菜单表
    /// </summary>
    [Serializable]
    public partial class Menu
    {
        public Menu()
        { }
        #region Model
        private int _menuid;
        private string _menuname;
        private int _parentid = -1;
        private string _icon;
        private string _url;
        /// <summary>
        /// 菜单ID
        /// </summary>
        public int MenuID
        {
            set { _menuid = value; }
            get { return _menuid; }
        }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName
        {
            set { _menuname = value; }
            get { return _menuname; }
        }
        /// <summary>
        /// 父级菜单ID
        /// </summary>
        public int ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon
        {
            set { _icon = value; }
            get { return _icon; }
        }
        /// <summary>
        /// 链接地址
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        #endregion Model

    }
}

