using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppElec.Startup))]
namespace AppElec
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
