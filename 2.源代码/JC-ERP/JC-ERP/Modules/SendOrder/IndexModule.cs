using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using DataService.Model;
using JC.Domain.DTO;
using JC.Domain.Respository;
using JC_ERP.Model;
using Nancy;
using Nancy.Security;
using Security;

namespace JC_ERP.Modules.SendOrder
{
    public class IndexModule : NancyModule
    {
        public IndexModule() : base(RouteDictionary.SendOrderBase)
        {
            this.RequiresAuthentication();

            Get[RouteDictionary.Add] = p =>
            {
                UserIdentity user = (UserIdentity)Context.CurrentUser;
                NavManager mgr = new NavManager();
                NavInfo nav = mgr.CreateNav(Request.Path, user.Menus);
                return View[ViewDictionary.SendOrderAdd, nav];
            };

            Get[RouteDictionary.OrderBizType] = p =>
            {
                ProductTypeSource pt = new ProductTypeSource();
                List<BizType> types = pt.CreateBizTypes();
                return Response.AsJson(types);
            };

            Get[RouteDictionary.OrderProType] = p =>
            {
                string typeName = SiteFun.cutechar(p.name);
                ProductTypeSource pt = new ProductTypeSource();
                List<ProductTypeDTO> types = pt.CreateProTypes(typeName);
                return Response.AsJson(types);
            };

            Post[RouteDictionary.SendOrderAdd] = p =>
            {
                string group = Request.Form["groupId"].Value;
                int groupId = 0;
                ResponseModel model = new ResponseModel();
                if (String.IsNullOrEmpty(group) || Int32.TryParse(group, out groupId))
                {
                    model.StatusCode = HttpStatusCode.BadGateway;
                    model.Message = "数据异常";
                }
                else
                {
                    string json = Request.Form["data"].Value;
                    List<SendOrderAddDTO> list = JsonHelper.ParseFromJson(json, typeof(List<SendOrderAddDTO>)) as List<SendOrderAddDTO>;
                    SendOrderSource send = new SendOrderSource();
                    try
                    {
                        send.AddSendOrder(groupId, list);
                        model.StatusCode = HttpStatusCode.OK;
                    }
                    catch (Exception ex)
                    {
                        model.StatusCode = HttpStatusCode.BadGateway;
                        model.Message = ex.Message;
                    }
                }                
                return Response.AsJson(model);
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
                string sqlWhere = "1=1";
                string buyer = Request.Query["buyer"];
                if (!String.IsNullOrEmpty(buyer))
                {
                    sqlWhere += " and Buyer like '%" + SiteFun.cutechar(buyer) + "%'";
                }                
                string pro = Request.Query["p"];
                if (!String.IsNullOrEmpty(pro))
                {
                    sqlWhere += " and ProName like '%" + SiteFun.cutechar(pro) + "%'";
                }
                string user = Request.Query["u"];
                int uid = 0;
                if (!String.IsNullOrEmpty(user) && Int32.TryParse(user, out uid) && uid > 0)
                {
                    sqlWhere += " and Use_UserID =" + uid;
                }

                OrderPageModel model = new OrderPageModel();
                DataService.BLL.v_Order BOrder = new DataService.BLL.v_Order();
                model.rows = BOrder.GetModelsByPage(sqlWhere, "OrderID desc", pageSize * (pageNum - 1) + 1, pageSize * pageNum);
                model.total = BOrder.GetRecordCount(sqlWhere);
                return Response.AsJson(model);
            };

            Get[RouteDictionary.List] = p =>
            {
                UserIdentity user = (UserIdentity)Context.CurrentUser;
                NavManager mgr = new NavManager();
                NavInfo nav = mgr.CreateNav(Request.Path, user.Menus);
                return View[ViewDictionary.SendOrderList, nav];
            };

            Get[RouteDictionary.GetSendList] = p =>
            {
                int id = 0;
                List<v_OrderDetail> list = new List<v_OrderDetail>();
                if (Int32.TryParse(p.id,out id))
                {
                    DataService.BLL.v_OrderDetail BOrder = new DataService.BLL.v_OrderDetail();
                    list.AddRange(BOrder.GetModelList("OrderID = " + id));
                }
                return Response.AsJson(list);
            };
        }
    }
}