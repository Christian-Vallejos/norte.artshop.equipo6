using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(norteArtshopEquipo6.WebSite.Startup))]
namespace norteArtshopEquipo6.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
