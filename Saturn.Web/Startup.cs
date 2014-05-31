using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Saturn.Web.Startup))]
namespace Saturn.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
