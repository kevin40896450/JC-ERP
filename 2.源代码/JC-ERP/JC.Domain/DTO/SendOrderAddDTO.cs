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
        [DataMember]
        public int OrderDetailID { get; set; }

        /// <summary>
        /// 发货数量
        /// </summary>
        [DataMember]
        public decimal SendNum { get; set; }
    }
}
