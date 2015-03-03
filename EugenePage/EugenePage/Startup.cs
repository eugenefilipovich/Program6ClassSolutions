using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EugenePage.Startup))]
namespace EugenePage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
