using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCAngularjsTestProject.Startup))]
namespace MVCAngularjsTestProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
