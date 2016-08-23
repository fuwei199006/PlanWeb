using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Plan.UI.Startup))]
namespace Plan.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
