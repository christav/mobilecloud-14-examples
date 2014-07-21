using Microsoft.Owin;
using Owin;
using SimpleServlet;

[assembly: OwinStartupAttribute(typeof(Startup))]
namespace SimpleServlet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
