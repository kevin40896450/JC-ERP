using System;
namespace DataService.Model
{
    /// <summary>
    /// 业务类型
    ///   1  销售
    ///   2  拆装
    /// </summary>
    [Serializable]
    public partial class SendOrder
    {
        public SendOrder()
        { }
        #region Model
        private int _sendorderid;
        private int _orderdetailid;
        private int _groupid;
        private string _buildaddr;
        private int _sendtype;
        private decimal _sendarea;
        private decimal? _realarea;
        private decimal? _price;
        private decimal? _realprice;
        private string _remark;
        private DateTime _addtime;
        /// <summary>
        /// 发货单ID
        /// </summary>
        public int SendOrderID
        {
            set { _sendorderid = value; }
            get { return _sendorderid; }
        }
        /// <summary>
        /// 编号
        /// </summary>
        public int OrderDetailID
        {
            set { _orderdetailid = value; }
            get { return _orderdetailid; }
        }
        /// <summary>
        /// 组编号
        /// </summary>
        public int GroupID
        {
            set { _groupid = value; }
            get { return _groupid; }
        }
        /// <summary>
        /// 施工地点
        /// </summary>
        public string BuildAddr
        {
            set { _buildaddr = value; }
            get { return _buildaddr; }
        }
        /// <summary>
        /// 业务类型
        /// </summary>
        public int SendType
        {
            set { _sendtype = value; }
            get { return _sendtype; }
        }
        /// <summary>
        /// 发货面积
        /// </summary>
        public decimal SendArea
        {
            set { _sendarea = value; }
            get { return _sendarea; }
        }
        /// <summary>
        /// 结算面积
        /// </summary>
        public decimal? RealArea
        {
            set { _realarea = value; }
            get { return _realarea; }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal? RealPrice
        {
            set { _realprice = value; }
            get { return _realprice; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
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

