using System;
namespace DataService.Model
{
    /// <summary>
    /// 订单状态：
    ///   1 未完成
    ///   2 已完成
    ///   3 取消
    /// </summary>
    [Serializable]
    public partial class OrderDetail
    {
        public OrderDetail()
        { }
        #region Model
        private int _orderdetailid;
        private int _orderid;
        private int _protypeid;
        private string _spec;
        private float _plannum;
        private float _price;
        private float _total;
        private string _remark;
        private float _finishnum;
        private int _orderstatus;
        private DateTime _uptime;
        /// <summary>
        /// 编号
        /// </summary>
        public int OrderDetailID
        {
            set { _orderdetailid = value; }
            get { return _orderdetailid; }
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 产品类型ID
        /// </summary>
        public int ProTypeID
        {
            set { _protypeid = value; }
            get { return _protypeid; }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string Spec
        {
            set { _spec = value; }
            get { return _spec; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public float PlanNum
        {
            set { _plannum = value; }
            get { return _plannum; }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public float Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public float total
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
        /// 完成数量
        /// </summary>
        public float FinishNum
        {
            set { _finishnum = value; }
            get { return _finishnum; }
        }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderStatus
        {
            set { _orderstatus = value; }
            get { return _orderstatus; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpTime
        {
            set { _uptime = value; }
            get { return _uptime; }
        }
        #endregion Model

    }
}

