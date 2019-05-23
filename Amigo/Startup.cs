using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Amigo.Startup))]
namespace Amigo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
