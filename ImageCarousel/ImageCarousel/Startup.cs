using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImageCarousel.Startup))]
namespace ImageCarousel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
