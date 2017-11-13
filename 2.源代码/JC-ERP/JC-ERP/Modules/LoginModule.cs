using Nancy;
using Nancy.Authentication.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.ModelBinding;

namespace JC_ERP.Modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule()
        {
            Post[RouteDictionary.Login] = p =>
            {
                string url = Request.Query["returnUrl"].Value;
                if (String.IsNullOrEmpty(url)) url = "/";
                
                Guid? UserGuid = UserMapper.ValidateUser(Request.Form["username"], Request.Form["pwd"]);
                if(UserGuid != null)
                {
                    DateTime cookieExpiry = DateTime.Now.AddHours(2);
                    return this.LoginAndRedirect(UserGuid.Value, cookieExpiry, url);
                }
                else
                {
                    return Response.AsText(false.ToString());
                }
            };
            
            Get[RouteDictionary.Login] = p =>
            {
                return View[ViewDictionary.Login];
            };

            Get[RouteDictionary.Logout] = p =>
            {
                return this.LogoutAndRedirect(RouteDictionary.Login);
            };
        }        
    }
}
