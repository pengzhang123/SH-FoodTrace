using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodTrace.WebSite.Startup))]
namespace FoodTrace.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
