using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using InvoiceTest.Repositories;

namespace InvoiceTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterAutoFac(GlobalConfiguration.Configuration);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void RegisterAutoFac(HttpConfiguration config)
        {
            // Setup the Container Builder
            var builder = new ContainerBuilder();

            // Register the controller in scope 
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerDependency();

            // Register types
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerDependency();
            builder.RegisterType<InvoiceItemRepository>().As<IInvoiceItemRepository>().InstancePerDependency();
            builder.RegisterType<InvoiceRepository>().As<IInvoiceRepository>().InstancePerDependency();
            // Build the container
            var container = builder.Build();
            //config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            // Setup the dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            config.DependencyResolver = new AutoFacContainer(new AutofacDependencyResolver(container));
            //app.UseAutofacMiddleware(container);
            //app.UseAutofacMvc();
        }
    }
}
