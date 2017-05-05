using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Working.Startup))]
namespace Working
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
