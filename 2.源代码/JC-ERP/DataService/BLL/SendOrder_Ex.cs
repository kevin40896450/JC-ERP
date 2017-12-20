using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Model;

namespace DataService.BLL
{
    public partial class SendOrder
    {
        public TransModel CreateAddSql(DataService.Model.SendOrder model)
        {
            return dal.CreateAddSql(model);
        }
    }
}
