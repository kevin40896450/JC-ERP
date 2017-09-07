using System;
namespace DataService.Model
{
    /// <summary>
    /// v_UserRole:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class v_UserRole
    {
        public v_UserRole()
        { }
        #region Model
        private int _userid;
        private int _roleid;
        private string _userguid;
        private string _username;
        private string _pwd;
        private string _realname;
        private string _sex;
        private string _idcard;
        private string _tel;
        private string _status;
        private DateTime _addtime;
        private string _rolename;
        private string _menulist;
        private bool _isallowcheck;
        private bool _isallowdel;
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserGuid
        {
            set { _userguid = value; }
            get { return _userguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IDCard
        {
            set { _idcard = value; }
            get { return _idcard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RoleName
        {
            set { _rolename = value; }
            get { return _rolename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MenuList
        {
            set { _menulist = value; }
            get { return _menulist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsAllowCheck
        {
            set { _isallowcheck = value; }
            get { return _isallowcheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsAllowDel
        {
            set { _isallowdel = value; }
            get { return _isallowdel; }
        }
        #endregion Model

    }
}

