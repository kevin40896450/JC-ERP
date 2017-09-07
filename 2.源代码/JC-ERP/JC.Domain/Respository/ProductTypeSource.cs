using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Model;
using JC.Domain.DTO;

namespace JC.Domain.Respository
{
    public class ProductTypeSource
    {
        /// <summary>
        /// 创建业务类型
        /// </summary>
        /// <returns></returns>
        public List<BizType> CreateBizTypes()
        {
            DataService.BLL.ProductType BType = new DataService.BLL.ProductType();
            List<string> types = BType.GetTypeNames();
            List<BizType> BizTypes = new List<BizType>();
            BizType biz = null;
            int i = 1;
            foreach (string t in types)
            {
                biz = new BizType();
                biz.ID = i;
                biz.BizTypeName = t;
                BizTypes.Add(biz);
                i++;
            }
            return BizTypes;
        }

        /// <summary>
        /// 根据业务类型获取产品类型集合
        /// </summary>
        /// <param name="bizTypeName"></param>
        /// <returns></returns>
        public List<ProductTypeDTO> CreateProTypes(string bizTypeName)
        {
            DataService.BLL.ProductType BType = new DataService.BLL.ProductType();
            List<ProductType> ProTypes = BType.GetModelList("TypeName='" + bizTypeName + "' order by OrderNum asc,ProTypeID asc");
            List<ProductTypeDTO> dto = new List<ProductTypeDTO>();
            ProductTypeDTO d = null;
            foreach (ProductType t in ProTypes)
            {
                d = new ProductTypeDTO();
                d.ProTypeID = t.ProTypeID;
                d.ProName = t.ProName;
                d.ProGroupID = t.ProGroupID;
                d.OrderNum = t.OrderNum;
                dto.Add(d);
            }
            return dto;
        }
    }
}
