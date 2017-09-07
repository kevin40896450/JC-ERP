using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JC.Domain.DTO
{
    [DataContract]
    public class OrderDetailDTO
    {
        public OrderDetailDTO()
        { }
        public OrderDetailDTO(int id, string _spec, float _planNum, float _price, float _total, string _remark)
        {
            ProTypeID = id;
            Spec = _spec;
            PlanNum = _planNum;
            Price = _price;
            Total = _total;
            Remark = _remark;
        }
        /// <summary>
        /// 产品类型ID
        /// </summary>
        [DataMember]
        public int ProTypeID { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [DataMember]
        public string Spec { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [DataMember]
        public float PlanNum { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [DataMember]
        public float Price { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [DataMember]
        public float Total { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }
    }
}
