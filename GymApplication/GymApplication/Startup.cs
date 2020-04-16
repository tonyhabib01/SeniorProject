using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GymApplication.Startup))]
namespace GymApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
