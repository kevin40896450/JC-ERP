using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JC_ERP.Model
{
    public class RolesPageModel : PageBase
    {
        public List<DataService.Model.Role> rows { get; set; }
    }
}