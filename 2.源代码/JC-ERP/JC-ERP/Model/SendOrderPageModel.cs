using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JC_ERP.Model
{
    public class SendOrderPageModel : PageBase
    {
        public List<DataService.Model.v_SendOrder> rows { get; set; }
    }
}