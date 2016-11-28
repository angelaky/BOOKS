using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BooksBlog.Startup))]
namespace BooksBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
