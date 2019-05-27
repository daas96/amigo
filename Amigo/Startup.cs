using Microsoft.Owin;
using Owin;
using System.Web.Services.Description;

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
