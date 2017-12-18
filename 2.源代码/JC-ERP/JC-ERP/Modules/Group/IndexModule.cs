using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using DataService.Model;
using JC.Domain.Respository;
using JC_ERP.Model;
using Nancy;
using Security;

namespace JC_ERP.Modules.Group
{
    public class IndexModule : NancyModule
    {
        public IndexModule() : base(RouteDictionary.GroupBase)
        {
            Get[RouteDictionary.Add] = p =>
            {
                UserIdentity user = (UserIdentity)Context.CurrentUser;
                NavManager mgr = new NavManager();
                NavInfo nav = mgr.CreateNav(Request.Path, user.Menus);
                return View[ViewDictionary.GroupAdd, nav];
            };

            Get[RouteDictionary.List] = p =>
            {
                UserIdentity user = (UserIdentity)Context.CurrentUser;
                NavManager mgr = new NavManager();
                NavInfo nav = mgr.CreateNav(Request.Path, user.Menus);
                return View[ViewDictionary.GroupList, nav];
            };

            Get[RouteDictionary.ListGet] = p =>
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

                GroupSource source = new GroupSource();
                var list = source.GetPageGroups("1=1", "GroupID desc", pageSize * (pageNum - 1) + 1, pageSize * pageNum);
                return Response.AsJson(list);
            };

            Post[RouteDictionary.Add] = p =>
            {
                ResponseModel model = new ResponseModel();
                string groupName = Request.Form["groupName"];
                string ids = Request.Form["selMember"];
                int userId = 0;
                if (!String.IsNullOrEmpty(Request.Form["selUser"]) && Int32.TryParse(Request.Form["selUser"], out userId) && userId > 0 && !String.IsNullOrEmpty(groupName) && !String.IsNullOrEmpty(ids))
                {
                    UserGroup groupModel = new UserGroup();
                    groupModel.GroupName = groupName;
                    groupModel.UserID = userId;
                    groupModel.Users = ids;
                    GroupSource group = new GroupSource();
                    try
                    {
                        bool bResult = group.AddGroup(groupModel);
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
                else
                {
                    model.StatusCode = HttpStatusCode.BadGateway;
                    model.Message = "请输入完整的信息";
                }                
                return Response.AsJson(model);
            };

            Post[RouteDictionary.Edit] = p =>
            {
                ResponseModel model = new ResponseModel();
                string groupName = Request.Form["groupName"];
                string ids = Request.Form["selMember"];
                string idStr = Request.Form["id"];
                int userId = 0;
                int id = 0;
                if (!String.IsNullOrEmpty(Request.Form["selUser"]) && Int32.TryParse(Request.Form["selUser"], out userId) && userId > 0 && !String.IsNullOrEmpty(groupName) && !String.IsNullOrEmpty(ids)&&Int32.TryParse(idStr,out id)&&id>0)
                {
                    DataService.BLL.UserGroup BGroup = new DataService.BLL.UserGroup();
                    UserGroup groupModel = BGroup.GetModel(id);
                    if (groupModel != null)
                    {
                        groupModel.GroupName = groupName;
                        groupModel.UserID = userId;
                        groupModel.Users = ids;
                        try
                        {
                            bool bResult = BGroup.Update(groupModel);
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

            Post[RouteDictionary.Del] = p =>
            {
                ResponseModel model = new ResponseModel();
                string ids = Request.Form["ids"];
                if (!String.IsNullOrEmpty(ids))
                {
                    DataService.BLL.UserGroup BGroup = new DataService.BLL.UserGroup();
                    try
                    {
                        bool bResult = BGroup.DeleteList(ids);
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