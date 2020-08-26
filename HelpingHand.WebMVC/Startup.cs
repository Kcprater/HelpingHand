using HelpingHand.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            createRolesandUsers();
        }
    private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "kcprater";
                user.Email = "admin@gmail.com";
                string userPWD = "Abc123!";


                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Admin");
                }
            }
            if (!roleManager.RoleExists("Provider"))
            {
                var role = new IdentityRole();
                role.Name = "Provider";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
        }
    }
}
