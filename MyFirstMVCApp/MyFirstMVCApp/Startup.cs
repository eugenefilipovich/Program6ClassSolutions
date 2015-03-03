using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyFirstMVCApp.Startup))]
namespace MyFirstMVCApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
