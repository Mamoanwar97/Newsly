using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(news.Startup))]
namespace news
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
