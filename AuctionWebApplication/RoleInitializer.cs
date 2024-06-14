using AuctionWebApplication.Models;
using AuctionWebApplication.ViewModel;
using Microsoft.AspNetCore.Identity;
namespace AuctionWebApplication
{
    public class RoleInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DbauctionContext>();

                context.Database.EnsureCreated();

                if (!context.Users.Any())
                {
                    UserIdent admin = new UserIdent {};
                    context.Users.AddRange(new List<User>()
                    {
                        new User(){ 
                            UserId = "Admin01",
                            Name = "Admin",
                            Balance = 100000,
                            Freeze = 0
                        }                       
                    });
                    context.SaveChanges();
                }
            }
        }



        public static async Task InitializeAsync(UserManager<UserIdent> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "Admin@1234";
            string UserID = "Admin01";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));

            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
			if (await roleManager.FindByNameAsync("block") == null)
			{
				await roleManager.CreateAsync(new IdentityRole("block"));
			}
			if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                UserIdent admin = new UserIdent {Id = UserID, Email = adminEmail, UserName = adminEmail };
              /*  User usr = new User { UserId = admin.Id, Name = "Admin", Balance = 10000, Freeze = 0 };*/
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {

                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}