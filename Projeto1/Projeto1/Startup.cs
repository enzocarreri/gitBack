using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Projeto1.Startup))]
namespace Projeto1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
