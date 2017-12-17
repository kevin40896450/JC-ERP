using System;
namespace DataService.Model
{
    /// <summary>
    /// v_Order:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class v_Order
    {
        public v_Order()
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
        private decimal? _totalnum;
        private decimal? _total;
        /// <summary>
        /// 
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
        public int Use_UserID
        {
            set { _use_userid = value; }
            get { return _use_userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Buyer
        {
            set { _buyer = value; }
            get { return _buyer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProName
        {
            set { _proname = value; }
            get { return _proname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Province
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remarks1
        {
            set { _remarks1 = value; }
            get { return _remarks1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remarks2
        {
            set { _remarks2 = value; }
            get { return _remarks2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? IntoDate
        {
            set { _intodate = value; }
            get { return _intodate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime OrderDate
        {
            set { _orderdate = value; }
            get { return _orderdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsCheck
        {
            set { _ischeck = value; }
            get { return _ischeck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDel
        {
            set { _isdel = value; }
            get { return _isdel; }
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
        public decimal? TotalNum
        {
            set { _totalnum = value; }
            get { return _totalnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? total
        {
            set { _total = value; }
            get { return _total; }
        }
        #endregion Model

    }
}

