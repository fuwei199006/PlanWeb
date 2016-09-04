using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Plain.CMS.Startup))]
namespace Plain.CMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
