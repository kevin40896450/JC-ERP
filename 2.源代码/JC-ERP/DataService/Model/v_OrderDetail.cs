using System;
namespace DataService.Model
{
    /// <summary>
    /// v_OrderDetail:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class v_OrderDetail
    {
        public v_OrderDetail()
        { }
        #region Model
        private int _orderdetailid;
        private int _orderid;
        private int _protypeid;
        private string _spec;
        private decimal _plannum;
        private decimal _price;
        private decimal _total;
        private string _remark;
        private decimal _finishnum;
        private int _orderstatus;
        private DateTime _uptime;
        private string _typename;
        private string _proname;
        private decimal _sendarea;
        private decimal _realarea;
        /// <summary>
        /// 
        /// </summary>
        public int OrderDetailID
        {
            set { _orderdetailid = value; }
            get { return _orderdetailid; }
        }
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
        public int ProTypeID
        {
            set { _protypeid = value; }
            get { return _protypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Spec
        {
            set { _spec = value; }
            get { return _spec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal PlanNum
        {
            set { _plannum = value; }
            get { return _plannum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal total
        {
            set { _total = value; }
            get { return _total; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FinishNum
        {
            set { _finishnum = value; }
            get { return _finishnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OrderStatus
        {
            set { _orderstatus = value; }
            get { return _orderstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpTime
        {
            set { _uptime = value; }
            get { return _uptime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
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
        public decimal SendArea
        {
            set { _sendarea = value; }
            get { return _sendarea; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal RealArea
        {
            set { _realarea = value; }
            get { return _realarea; }
        }
        #endregion Model

    }
}

