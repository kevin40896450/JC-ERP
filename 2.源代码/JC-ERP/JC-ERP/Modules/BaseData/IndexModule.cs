using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JC_ERP.Model;
using Nancy;
using Nancy.Security;
using Security;

namespace JC_ERP.Modules.BaseData
{
    public class IndexModule : NancyModule
    {
        public IndexModule() : base(RouteDictionary.BaseDataBase)
        {
            this.RequiresAuthentication();

            Get[RouteDictionary.Roles] = p =>
            {
                UserIdentity user = (UserIdentity)Context.CurrentUser;
                NavManager mgr = new NavManager();
                NavInfo nav = mgr.CreateNav(Request.Path, user.Menus);
                return View[ViewDictionary.BaseDataRolesList, nav];
            };

            Get[RouteDictionary.RolesGet] = p =>
            {
                string per = Request.Query["limit"];//显示数量
                string offset = Request.Query["offset"];//当前记录条数
                int pageSize = 10;//每页显示条数
                int offsetNum = 0;//当前记录偏移量
                if (!Int32.TryParse(offset, out offsetNum))
                {
                    offsetNum = 0;
                }
                if (!Int32.TryParse(per, out pageSize))
                {
                    pageSize = 10;
                }
                int pageNum = (offsetNum / pageSize) + 1;//当前页码
                string sqlWhere = "1=1";
                RolesPageModel model = new RolesPageModel();
                DataService.BLL.Role BRole = new DataService.BLL.Role();
                model.rows = BRole.GetModelsByPage(sqlWhere, "RoleID desc", pageSize * (pageNum - 1) + 1, pageSize * pageNum);
                model.total = BRole.GetRecordCount(sqlWhere);
                return Response.AsJson(model);
            };
        }
    }
}