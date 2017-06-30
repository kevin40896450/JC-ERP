using System;
using System.Drawing;
using System.IO;
using DataService.Model;
using Nancy;
using Nancy.Security;

namespace JC_ERP.Modules
{
    //首页展示路由管理
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            this.RequiresAuthentication();

            Get["/"]= Get["/index"] = Post["/"] = p => View["/index"];

            Get["/MenuList"] = p =>
            {
                v_UserRole user = UserMapper.GetUser(Context.CurrentUser.UserName);
                UserLimit limit = new UserLimit(user);
                return Response.AsJson(limit.MenuList);
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