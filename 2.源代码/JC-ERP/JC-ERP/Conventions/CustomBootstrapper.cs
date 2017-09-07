using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.Authentication.Forms;

namespace JC_ERP
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            StaticConfiguration.DisableErrorTraces = false;
            base.ApplicationStartup(container, pipelines);
        }
        
        //protected override IRootPathProvider RootPathProvider
        //{

        //    get { return new CustomRootPathProvider(); }
        //}

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register<IUserMapper, UserMapper>();
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {            
            base.RequestStartup(container, pipelines, context);
            var formsAuthConfiguration = new FormsAuthenticationConfiguration
            {
                RedirectUrl = "/login",
                UserMapper = container.Resolve<IUserMapper>(),
            };
            FormsAuthentication.Enable(pipelines, formsAuthConfiguration);
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);
            nancyConventions.StaticContentsConventions.Clear();
            nancyConventions.StaticContentsConventions.AddDirectory("Content");
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Content/bootstrap"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Content/Scripts"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Content/dist"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Content/plugins"));
        }
    }

    //public class CustomRootPathProvider : IRootPathProvider
    //{
    //    private readonly string _rootPath = System.AppDomain.CurrentDomain.BaseDirectory + "bin";
    //    public string GetRootPath()
    //    {
    //        return _rootPath;
    //    }
    //}
}