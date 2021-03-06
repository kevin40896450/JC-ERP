﻿using System;
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

            Get[RouteDictionary.UserList] = p =>
            {
                UserIdentity user = (UserIdentity)Context.CurrentUser;
                NavManager mgr = new NavManager();
                NavInfo nav = mgr.CreateNav(Request.Path, user.Menus);
                return View[ViewDictionary.BaseDataUserList, nav];
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

            Get[RouteDictionary.RolesSimpleGet] = p =>
            {                
                string sqlWhere = "1=1";
                DataService.BLL.Role BRole = new DataService.BLL.Role();
                var list = BRole.GetModelList(sqlWhere);                
                return Response.AsJson(list);
            };

            Get[RouteDictionary.UserListGet] = p =>
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
                UsersPageModel model = new UsersPageModel();
                DataService.BLL.v_UserRole BRole = new DataService.BLL.v_UserRole();
                model.rows = BRole.GetModelsByPage(sqlWhere, "UserID desc", pageSize * (pageNum - 1) + 1, pageSize * pageNum);
                model.total = BRole.GetRecordCount(sqlWhere);
                return Response.AsJson(model);
            };

            Post[RouteDictionary.UserEdit] = p =>
            {
                ResponseModel model = new ResponseModel();
                string uid = Request.Form["uid"];
                string userName = Request.Form["userName"];
                string roleId = Request.Form["roleId"];
                string realName = Request.Form["realName"];
                string sex = Request.Form["sex"];
                string tel = Request.Form["tel"];
                string into = Request.Form["intoDate"];
                int id = 0;
                int rid = 0;
                if (!String.IsNullOrEmpty(uid) && Int32.TryParse(uid, out id) && !String.IsNullOrEmpty(userName)&&!String.IsNullOrEmpty(roleId)&& Int32.TryParse(roleId, out rid))
                {
                    DataService.BLL.UserInfo BUser = new DataService.BLL.UserInfo();
                    UserInfo user = BUser.GetModel(id);
                    if (user == null)
                    {
                        UserInfo checkUser = BUser.GetModel(userName);
                        if(checkUser!=null)
                        {
                            model.StatusCode = HttpStatusCode.BadGateway;
                            model.Message = "该用户名已存在，请重新输入";
                            return Response.AsJson(model);
                        }
                        user = new UserInfo();
                        user.UserID = BUser.GetMaxId();
                        user.UserName = userName;
                        user.AddTime = DateTime.Now;
                    }
                    user.RoleID = rid;
                    user.UserGuid = Guid.NewGuid().ToString();
                    user.Pwd = UserMapper.DefaultPwd;
                    user.RealName = realName;
                    user.IDCard = "";
                    user.Status = "";
                    user.Sex = sex;
                    user.Tel = tel;
                    if (!String.IsNullOrEmpty(into))
                    {
                        user.IntoTime = DateTime.Parse(into);
                    }
                    try
                    {
                        bool bResult = id > 0 ? BUser.Update(user) : BUser.Add(user);
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

            Post[RouteDictionary.UserDel] = p =>
            {
                ResponseModel model = new ResponseModel();
                string ids = Request.Form["data"];

                int id = 0;
                if (!String.IsNullOrEmpty(ids))
                {
                    bool bResult = Common.SiteFun.CheckIds(ids);
                    if (bResult)
                    {
                        DataService.BLL.UserInfo BUser = new DataService.BLL.UserInfo();
                        try
                        {
                            bResult = BUser.DeleteList(ids); ;
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

            Post[RouteDictionary.RolesEdit] = p =>
            {
                ResponseModel model = new ResponseModel();
                string roleId = Request.Form["rid"];
                string name = Request.Form["name"];
                string ids = Request.Form["ids"];
                
                int id = 0;
                if (!String.IsNullOrEmpty(roleId) && Int32.TryParse(roleId, out id) && !String.IsNullOrEmpty(name))
                {
                    DataService.BLL.Role BRole = new DataService.BLL.Role();
                    Role role = BRole.GetModel(id);
                    if (role == null)
                    {
                        role = new Role();
                        role.RoleID = BRole.GetMaxId();
                    }
                    role.RoleName = name;
                    role.MenuList = ids;
                    try
                    {
                        bool bResult = id > 0 ? BRole.Update(role) : BRole.Add(role);
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

            Post[RouteDictionary.RolesDel] = p =>
            {
                ResponseModel model = new ResponseModel();
                string ids = Request.Form["data"];

                int id = 0;
                if (!String.IsNullOrEmpty(ids))
                {                    
                    bool bResult = Common.SiteFun.CheckIds(ids);
                    if(bResult)
                    {
                        DataService.BLL.Role BRole = new DataService.BLL.Role();
                        try
                        {
                            bResult = BRole.DeleteList(ids); ;
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

            Post[RouteDictionary.PwdEdit] = p =>
            {
                ResponseModel model = new ResponseModel();
                string old = Request.Form["oldPwd"];
                string newPwd = Request.Form["newPwd"];
                UserIdentity user = (UserIdentity)Context.CurrentUser;
                if (user!=null&&!String.IsNullOrEmpty(old) && !String.IsNullOrEmpty(newPwd))
                {
                    try
                    {
                        DataService.BLL.UserInfo BUser = new DataService.BLL.UserInfo();
                        UserInfo checkUser = BUser.GetModel(user.UserID);
                        if (checkUser != null)
                        {
                            if (checkUser.Pwd != old)
                            {
                                model.Message = "原始密码错误，请重新输入";
                                model.StatusCode = HttpStatusCode.BadGateway;
                            }
                            else
                            {
                                checkUser.Pwd = newPwd;
                                bool bResult = BUser.Update(checkUser);
                                if (!bResult)
                                {
                                    model.Message = "数据库访问错误，请联系管理员";
                                }
                                else
                                {
                                    model.StatusCode = HttpStatusCode.OK;
                                }
                            }
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