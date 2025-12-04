using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AplikacijaVremenskePrognoze.Startup))]
namespace AplikacijaVremenskePrognoze
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
