using System;
namespace DataService.Model
{
    /// <summary>
    /// 角色表
    /// </summary>
    [Serializable]
    public partial class Role
    {
        public Role()
        { }
        #region Model
        private int _roleid;
        private string _rolename;
        private string _menulist;
        private bool _isallowcheck;
        private bool _isallowdel;
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            set { _rolename = value; }
            get { return _rolename; }
        }
        /// <summary>
        /// 菜单列表
        /// </summary>
        public string MenuList
        {
            set { _menulist = value; }
            get { return _menulist; }
        }
        /// <summary>
        /// 是否允许审核
        /// </summary>
        public bool IsAllowCheck
        {
            set { _isallowcheck = value; }
            get { return _isallowcheck; }
        }
        /// <summary>
        /// 是否允许删除
        /// </summary>
        public bool IsAllowDel
        {
            set { _isallowdel = value; }
            get { return _isallowdel; }
        }
        #endregion Model

    }
}

