using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Model;

namespace DataService.BLL
{
    /// <summary>
    /// 订单表
    /// </summary>
    public partial class OrderInfo
    {
        public TransModel CreateAddSql(DataService.Model.OrderInfo model)
        {
            return dal.CreateAddSql(model);
        }
    }
}
