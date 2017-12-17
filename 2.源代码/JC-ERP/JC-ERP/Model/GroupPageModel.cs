using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JC.Domain.DTO;

namespace JC_ERP.Model
{
    public class GroupPageModel : PageBase
    {
        public List<GroupInfoDto> rows { get; set; }
    }
}