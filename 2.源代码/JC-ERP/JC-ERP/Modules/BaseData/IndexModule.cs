using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataService.Model;
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

            Post[RouteDictionary.RolesEdit] = p =>
            {
                ResponseModel model = new ResponseModel();
                string roleId = Request.Form["rid"];
                string name = Request.Form["name"];
                string ids = Request.Form["ids"];
                
                int id = 0;
                if (!String.IsNullOrEmpty(roleId) && Int32.TryParse(roleId, out id) && id > 0 && !String.IsNullOrEmpty(name))
                {
                    DataService.BLL.Role BRole = new DataService.BLL.Role();
                    Role role = BRole.GetModel(id);
                    if (role != null)
                    {
                        role.RoleName = name;
                        role.MenuList = ids;
                        try
                        {
                            bool bResult = BRole.Update(role);
                            if (!bResult)
                            {
                                model.Message = "数据库访问错误，请联系管理员";
                            }
                            else
                            {
                                model.StatusCode = HttpStatusCode.OK;
                            }
                        }
                        catch (Exception ex)
                        {
                            model.StatusCode = HttpStatusCode.BadGateway;
                            model.Message = ex.Message;
                        }
                    }
                }
                else
                {
                    model.StatusCode = HttpStatusCode.BadGateway;
                    model.Message = "请输入完整的信息";
                }
                return Response.AsJson(model);
            };
        }
    }
}