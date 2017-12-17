using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JC.Domain.DTO
{
    public class SendOrderDetailInputDTO
    {
        /// <summary>
        /// 发货详情编号
        /// </summary>
        public int OrderDetailID { get; set; }

        /// <summary>
        /// 发货数量
        /// </summary>
        public float SendNum { get; set; }
    }
}
