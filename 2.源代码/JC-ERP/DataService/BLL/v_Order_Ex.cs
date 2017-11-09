using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.BLL
{
    public partial class v_Order
    {
        public List<Model.v_Order> GetModelsByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            DataTable dT = dal.GetListByPage(strWhere, orderby, startIndex, endIndex).Tables[0];

            return DataTableToList(dT);
        }
    }
}
