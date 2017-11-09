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

namespace JC_ERP.Modules.Order
{
    public class IndexModule : NancyModule
    {
        public IndexModule() : base(RouteDictionary.OrderBase)
        {
            this.RequiresAuthentication();

            Get[RouteDictionary.OrderAdd] = p =>
            {
                UserIdentity user = (UserIdentity)Context.CurrentUser;
                NavManager mgr = new NavManager();
                NavInfo nav = mgr.CreateNav(Request.Path, user.Menus);
                return View[ViewDictionary.OrderAdd, nav];
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

            Post[RouteDictionary.OrderAdd] = p =>
            {
                string buyer = Request.Form["buyer"].Value;//甲方名称
                string proName = Request.Form["proName"].Value;//项目名称
                string orderdate = Request.Form["orderdate"].Value;//下单日期
                string intodate = Request.Form["intodate"].Value;//进场日期
                string Province = Request.Form["Province"].Value;//省
                string City = Request.Form["City"].Value;//市
                string Area = Request.Form["Area"].Value;//区
                string address = Request.Form["address"].Value;//详细地址
                string selUsers = Request.Form["selUsers"].Value;//业务员
                string remarks1 = Request.Form["remarks1"].Value;//付款方式
                string remarks2 = Request.Form["remarks2"].Value;//备注
                string json = Request.Form["data"].Value;
                List<OrderDetailDTO> list = JsonHelper.ParseFromJson(json, typeof(List<OrderDetailDTO>)) as List<OrderDetailDTO>;
                OrderInfoDTO info = new OrderInfoDTO();
                info.Address = address;
                info.Area = Area;
                info.Buyer = buyer;
                info.City = City;
                if(!String.IsNullOrEmpty(intodate))
                {
                    info.IntoDate = DateTime.Parse(intodate);
                }
                info.OrderDate = DateTime.Parse(orderdate);
                info.ProName = proName;
                info.Province = Province;
                info.remarks1 = remarks1;
                info.remarks2 = remarks2;
                info.Use_UserID = Int32.Parse(selUsers);
                UserIdentity user = (UserIdentity)Context.CurrentUser;
                info.UserID = user.UserID;

                OrderSource order = new OrderSource();
                ResponseModel model = new ResponseModel();
                try
                {
                    order.AddOrder(info, list);
                    model.StatusCode = HttpStatusCode.OK;
                }
                catch(Exception ex)
                {
                    model.StatusCode = HttpStatusCode.BadGateway;
                    model.Message = ex.Message;
                }
                return Response.AsJson(model);
            };

            Get[RouteDictionary.OrderListGet] = p =>
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

            Get[RouteDictionary.OrderList] = p =>
            {
                UserIdentity user = (UserIdentity)Context.CurrentUser;
                NavManager mgr = new NavManager();
                NavInfo nav = mgr.CreateNav(Request.Path, user.Menus);
                return View[ViewDictionary.OrderList, nav];
            };
        }
    }
}