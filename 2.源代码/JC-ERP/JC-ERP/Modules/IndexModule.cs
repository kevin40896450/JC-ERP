using System;
using System.Drawing;
using System.IO;
using Nancy;
using Nancy.Security;
using Security;

namespace JC_ERP.Modules
{
    //首页展示路由管理
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            this.RequiresAuthentication();

            Get["/"]= Get[RouteDictionary.Index] = Post["/"] = p => View[ViewDictionary.Index];

            Get[RouteDictionary.MenuList] = p =>
            {
                UserIdentity user = (UserIdentity)Context.CurrentUser;
                return Response.AsJson(user.MenuTrees);
            };

            //获取编辑密码页面
            Get["/EditPwd"] = p =>
            {
                return View["/EditPwd"];
            };

            //编辑密码
            Post["/ChangePwd"] = p => ChangePwd();
            
        }
        

        private dynamic ChangePwd()
        {
            string oldpwd = Request.Form["oldpwd"];
            string newpwd = Request.Form["newpwd"];
            string newpwdAgain = Request.Form["newpwdAgain"];
            return Response.AsText(true.ToString());
        }
    }
}