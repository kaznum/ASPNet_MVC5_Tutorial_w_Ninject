using MvcMovie.Services;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcMovie
{
    public class MvcApplication : HttpApplication
    {

        ///// <summary>
        ///// Registers the global filters.
        ///// </summary>
        ///// <param name="filters">The filters.</param>
        //public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        //{
        //    filters.Add(new HandleErrorAttribute());
        //}

        ///// <summary>
        ///// Registers the routes.
        ///// </summary>
        ///// <param name="routes">The routes.</param>
        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    routes.MapRoute(
        //        "Default", // Route name
        //        "{controller}/{action}/{id}", // URL with parameters
        //        new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        //}



        //protected override void OnApplicationStarted()
        //{
        //    base.OnApplicationStarted();

        //    AreaRegistration.RegisterAllAreas();
        //    RegisterGlobalFilters(GlobalFilters.Filters);
        //    RegisterRoutes(RouteTable.Routes);


        //    //AreaRegistration.RegisterAllAreas();
        //    //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    //RouteConfig.RegisterRoutes(RouteTable.Routes);
        //    //BundleConfig.RegisterBundles(BundleTable.Bundles);
        //}

        //protected override IKernel CreateKernel()
        //{
        //    var kernel = new StandardKernel();
        //    kernel.Load(Assembly.GetExecutingAssembly());
        //    return kernel;
        //}



        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //protected override IKernel CreateKernel()
        // {
        //    var kernel = new StandardKernel();
        //    kernel.Load(Assembly.GetExecutingAssembly());
        //    kernel.Bind<IMessageService>().To<MessageService>();
        //    return kernel;
        //}
        //protected override void OnApplicationStarted()
        //{
        //    base.OnApplicationStarted();
        //    AreaRegistration.RegisterAllAreas();
        //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //    BundleConfig.RegisterBundles(BundleTable.Bundles);
        //}
    }
}
