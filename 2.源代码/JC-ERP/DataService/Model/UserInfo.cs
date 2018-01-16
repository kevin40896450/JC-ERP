using System;
namespace DataService.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Serializable]
    public partial class UserInfo
    {
        public UserInfo()
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
        private DateTime? _intotime;
        private DateTime _addtime = DateTime.Now;
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 用户识别码
        /// </summary>
        public string UserGuid
        {
            set { _userguid = value; }
            get { return _userguid; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCard
        {
            set { _idcard = value; }
            get { return _idcard; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime? IntoTime
        {
            set { _intotime = value; }
            get { return _intotime; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        #endregion Model

    }
}

