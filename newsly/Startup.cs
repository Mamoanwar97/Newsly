using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(newsly.Startup))]
namespace newsly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
