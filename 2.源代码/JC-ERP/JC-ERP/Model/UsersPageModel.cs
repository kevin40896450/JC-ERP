using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JC_ERP.Model
{
    public class UsersPageModel : PageBase
    {
        public List<DataService.Model.v_UserRole> rows { get; set; }
    }
}