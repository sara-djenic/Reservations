using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ispit_asp.Startup))]
namespace Ispit_asp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
