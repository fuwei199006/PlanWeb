using Microsoft.Owin;
using Owin;
using Plain.UI;

[assembly: OwinStartup(typeof(Startup))]
namespace Plain.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
