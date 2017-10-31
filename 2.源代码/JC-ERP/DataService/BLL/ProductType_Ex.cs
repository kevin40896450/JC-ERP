using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.BLL
{
    public partial class ProductType
    {
        /// <summary>
        /// 获取业务分类列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetTypeNames()
        {
            return dal.GetTypeNames();
        }
    }
}
