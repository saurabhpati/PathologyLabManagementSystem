using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PathologyLabManagementSystem.Startup))]
namespace PathologyLabManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
