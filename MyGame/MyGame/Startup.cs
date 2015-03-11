using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyGame.Startup))]
namespace MyGame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
