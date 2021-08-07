using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Project_IA.Models;

[assembly: OwinStartupAttribute(typeof(Project_IA.Startup))]
namespace Project_IA
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private RoleManager roleManager;

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
            CreateUsers();
        }
        public void CreateUsers()
        {
            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            //var user = new ApplicationUser();
            //user.Email = "galalshaaban@gmail.com";
            //user.UserName = "galal";
            //var check = userManager.Create(user, "Galal@123");
            //if(check.Succeeded)
            //{
            //    userManager.AddToRole(user.Id, "Admins");
            //}
        }

        public void CreateRoles()
        {
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            //IdentityRole role;
            //if (!roleManager.RoleExists("Admins"))
            //{
            //    role = new IdentityRole();
            //    role.Name = "Admins";
            //    roleManager.Create(role);
            //}
            //if (!roleManager.RoleExists("Editor"))
            //{
            //    role = new IdentityRole();
            //    role.Name = "Editor";
            //    roleManager.Create(role);
            //}
            //if (!roleManager.RoleExists("Viewer"))
            //{
            //    role = new IdentityRole();
            //    role.Name = "Viewer";
            //    roleManager.Create(role);
            //}
        }
    }
}
