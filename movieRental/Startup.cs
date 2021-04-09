using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(movieRental.Startup))]
namespace movieRental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
