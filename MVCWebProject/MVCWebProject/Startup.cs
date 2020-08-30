using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MatejCervelinMvcProjekt.Startup))]
namespace MatejCervelinMvcProjekt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
