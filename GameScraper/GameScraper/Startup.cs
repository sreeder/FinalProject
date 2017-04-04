using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameScraper.Startup))]
namespace GameScraper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
