using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JC.Domain.DTO
{
    /// <summary>
    /// 产品类型
    /// </summary>
    public class ProductTypeDTO
    {
        /// <summary>
        /// 产品类型ID
        /// </summary>
        public int ProTypeID { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string ProName { get; set; }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int OrderNum { get; set; }

        /// <summary>
        /// 产品分组ID
        /// </summary>
        public int ProGroupID { get; set; }
    }

    /// <summary>
    /// 业务类型
    /// </summary>
    public class BizType : IAggregateRoot
    {
        public int ID;

        public string BizTypeName;
        /// <summary>
        /// 产品类型集合
        /// </summary>
        public List<ProductTypeDTO> ProTypes;
    }
}
