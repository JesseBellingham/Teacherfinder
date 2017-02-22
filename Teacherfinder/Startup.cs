using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Teacherfinder.Startup))]
namespace Teacherfinder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
