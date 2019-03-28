using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(agenda3.Startup))]
namespace agenda3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
