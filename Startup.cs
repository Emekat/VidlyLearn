using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyLearn.Startup))]
namespace VidlyLearn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
