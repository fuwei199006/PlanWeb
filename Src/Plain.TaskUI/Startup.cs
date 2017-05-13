using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Plain.TaskUI.Startup))]
namespace Plain.TaskUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
