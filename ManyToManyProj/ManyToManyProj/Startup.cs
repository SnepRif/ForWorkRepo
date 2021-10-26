using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManyToManyProj.Startup))]
namespace ManyToManyProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
