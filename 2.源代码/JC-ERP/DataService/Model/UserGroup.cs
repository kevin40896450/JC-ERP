using System;
namespace DataService.Model
{
    /// <summary>
    /// 用户组
    /// </summary>
    [Serializable]
    public partial class UserGroup
    {
        public UserGroup()
        { }
        #region Model
        private int _groupid;
        private int? _userid;
        private string _groupname;
        private string _users;
        private DateTime _addtime;
        /// <summary>
        /// 组编号
        /// </summary>
        public int GroupID
        {
            set { _groupid = value; }
            get { return _groupid; }
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int? UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 组名称
        /// </summary>
        public string GroupName
        {
            set { _groupname = value; }
            get { return _groupname; }
        }
        /// <summary>
        /// 组员列表
        /// </summary>
        public string Users
        {
            set { _users = value; }
            get { return _users; }
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

