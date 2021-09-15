using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClothingStoreApp.Startup))]
namespace ClothingStoreApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
