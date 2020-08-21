using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelpingHand.WebMVC.Startup))]
namespace HelpingHand.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
