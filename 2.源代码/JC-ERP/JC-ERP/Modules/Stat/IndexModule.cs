using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JC.Domain.Respository;
using Nancy;
using Security;

namespace JC_ERP.Modules.Stat
{
    public class IndexModule : NancyModule
    {
        public IndexModule() : base(RouteDictionary.BaseStat)
        {
            Get[RouteDictionary.Add] = p =>
            {
                UserIdentity user = (UserIdentity)Context.CurrentUser;
                NavManager mgr = new NavManager();
                NavInfo nav = mgr.CreateNav(Request.Path, user.Menus);
                return View[ViewDictionary.GroupAdd, nav];
            };

            Get[RouteDictionary.StatOrder] = p =>
            {
                UserIdentity user = (UserIdentity)Context.CurrentUser;
                NavManager mgr = new NavManager();
                NavInfo nav = mgr.CreateNav(Request.Path, user.Menus);
                return View[ViewDictionary.StatOrderList, nav];
            };

            Get[RouteDictionary.StatOrderGet] = p =>
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
        }
    }
}