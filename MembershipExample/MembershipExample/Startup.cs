using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MembershipExample.Startup))]
namespace MembershipExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
