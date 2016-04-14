using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NextBuildHangfireDemo.Startup))]
namespace NextBuildHangfireDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
