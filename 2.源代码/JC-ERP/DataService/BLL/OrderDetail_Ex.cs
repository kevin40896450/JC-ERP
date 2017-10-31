using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Model;

namespace DataService.BLL
{
    /// <summary>
    /// 订单状态：
    ///   
    /// </summary>
    public partial class OrderDetail
    {
        public TransModel CreateAddSql(DataService.Model.OrderDetail model)
        {
            return dal.CreateAddSql(model);
        }
    }
}
