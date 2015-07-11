using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AsyncGrid.Startup))]
namespace AsyncGrid
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
