using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Security;

namespace JC_ERP
{
    public class UserIdentity : IUserIdentity
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public IEnumerable<string> Claims { get; set; }

        /// <summary>
        /// 非序列化结构的菜单集合
        /// </summary>
        public List<MenuTreeInfo> Menus { get; set; }
        /// <summary>
        /// 含有父子结构的菜单集合
        /// </summary>
        public List<MenuTreeInfo> MenuTrees { get; set; }
    }
}
