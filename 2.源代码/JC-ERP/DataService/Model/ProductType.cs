using System;
namespace DataService.Model
{
    /// <summary>
    /// 产品类型
    /// </summary>
    [Serializable]
    public partial class ProductType
    {
        public ProductType()
        { }
        #region Model
        private int _protypeid;
        private string _typename;
        private string _proname;
        private int _progroupid = 0;
        private int _ordernum = 0;
        /// <summary>
        /// 产品类型ID
        /// </summary>
        public int ProTypeID
        {
            set { _protypeid = value; }
            get { return _protypeid; }
        }
        /// <summary>
        /// 业务类型名称
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 产品类型名称
        /// </summary>
        public string ProName
        {
            set { _proname = value; }
            get { return _proname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ProGroupID
        {
            set { _progroupid = value; }
            get { return _progroupid; }
        }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int OrderNum
        {
            set { _ordernum = value; }
            get { return _ordernum; }
        }
        #endregion Model

    }
}

