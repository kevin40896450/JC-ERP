using System;
namespace DataService.Model
{
    /// <summary>
    /// 订单表
    /// </summary>
    [Serializable]
    public partial class OrderInfo
    {
        public OrderInfo()
        { }
        #region Model
        private int _orderid;
        private string _ordercode;
        private int _userid;
        private int _use_userid;
        private string _buyer;
        private string _proname;
        private string _province;
        private string _city;
        private string _area;
        private string _address;
        private string _remarks1;
        private string _remarks2;
        private DateTime? _intodate;
        private DateTime _orderdate;
        private bool _ischeck;
        private bool _isdel;
        private DateTime _addtime;
        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderCode
        {
            set { _ordercode = value; }
            get { return _ordercode; }
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 用户表_用户编号
        /// </summary>
        public int Use_UserID
        {
            set { _use_userid = value; }
            get { return _use_userid; }
        }
        /// <summary>
        /// 甲方名称
        /// </summary>
        public string Buyer
        {
            set { _buyer = value; }
            get { return _buyer; }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProName
        {
            set { _proname = value; }
            get { return _proname; }
        }
        /// <summary>
        /// 施工所属省
        /// </summary>
        public string Province
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// 市
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 区
        /// </summary>
        public string Area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 备注1
        /// </summary>
        public string remarks1
        {
            set { _remarks1 = value; }
            get { return _remarks1; }
        }
        /// <summary>
        /// 备注2
        /// </summary>
        public string remarks2
        {
            set { _remarks2 = value; }
            get { return _remarks2; }
        }
        /// <summary>
        /// 进场时间
        /// </summary>
        public DateTime? IntoDate
        {
            set { _intodate = value; }
            get { return _intodate; }
        }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderDate
        {
            set { _orderdate = value; }
            get { return _orderdate; }
        }
        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsCheck
        {
            set { _ischeck = value; }
            get { return _ischeck; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDel
        {
            set { _isdel = value; }
            get { return _isdel; }
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

