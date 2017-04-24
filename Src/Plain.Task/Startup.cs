using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Plain.Task.Startup))]
namespace Plain.Task
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        }
    }
}
