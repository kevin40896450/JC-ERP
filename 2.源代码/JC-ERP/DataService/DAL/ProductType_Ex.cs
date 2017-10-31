using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.DAL
{
    public partial class ProductType
    {
        /// <summary>
        /// 获取业务类型列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetTypeNames()
        {
            string sql = "select TypeName from ProductType group by TypeName order by TypeName desc";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            List<string> types = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                types.Add(row["TypeName"].ToString());
            }
            return types;
        }
    }
}
