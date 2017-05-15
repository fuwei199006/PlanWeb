using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Plain.Log.Startup))]
namespace Plain.Log
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
