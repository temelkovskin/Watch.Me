using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Watch.Me.Startup))]
namespace Watch.Me
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
