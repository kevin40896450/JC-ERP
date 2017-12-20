using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JC.Domain.DTO
{
    [DataContract]
    public class SendOrderAddDTO
    {
        /// <summary>
        /// 订单详情编号
        /// </summary>
        public int OrderDetailID { get; set; }

        /// <summary>
        /// 发货数量
        /// </summary>
        public int SendNum { get; set; }
    }
}
