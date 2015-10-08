using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using InvoiceTest.Repositories;
using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Owin;

[assembly: OwinStartupAttribute(typeof(InvoiceTest.Startup))]
namespace InvoiceTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
