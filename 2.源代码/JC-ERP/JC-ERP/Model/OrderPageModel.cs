using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataService.Model;

namespace JC_ERP.Model
{
    public class OrderPageModel : PageBase
    {
        public List<v_Order> rows { get; set; }
    }
}