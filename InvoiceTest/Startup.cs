using Microsoft.Owin;
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
