using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoseStore.Startup))]
namespace ShoseStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
