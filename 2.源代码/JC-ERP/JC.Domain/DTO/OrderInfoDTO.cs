using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JC.Domain.DTO
{
    [DataContract]
    public class OrderInfoDTO
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 业务员ID
        /// </summary>
        public int Use_UserID { get; set; }

        /// <summary>
        /// 甲方名称
        /// </summary>
        public string Buyer { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProName { get; set; }

        /// <summary>
        /// 施工所属省
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 区
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 备注1
        /// </summary>
        public string remarks1 { get; set; }
        /// <summary>
        /// 备注2
        /// </summary>
        public string remarks2 { get; set; }
        /// <summary>
        /// 进场时间
        /// </summary>
        public DateTime? IntoDate { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderDate { get; set; }
    }
}
