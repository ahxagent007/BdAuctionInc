using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BD_Auction_inc.Startup))]
namespace BD_Auction_inc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}