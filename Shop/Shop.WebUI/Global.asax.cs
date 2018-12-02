using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using Shop.Core.Contracts;
using Shop.DAL.InMemory;
using Shop.Core.Models;
using System.Reflection;
using Microsoft.AspNet.Identity;
using Shop.WebUI.Models;

namespace Shop.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //var container = new Container();
            //container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            //// Register your types, for instance:

            //container.Register<IRepository<Product>, InMemoryRepository<Product>>(Lifestyle.Scoped);
            //container.Register<IRepository<ProductCategory>, InMemoryRepository<ProductCategory>>(Lifestyle.Scoped);

            //// This is an extension method from the integration package.
            //container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            //container.Verify();

            //DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));



        }

    }
}
