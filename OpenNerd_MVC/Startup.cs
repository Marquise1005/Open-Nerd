using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Animal_Paradise_MVC.Startup))]
namespace Animal_Paradise_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
