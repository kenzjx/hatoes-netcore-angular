using Beetsoft_Management_System.Data;

namespace SeedDatas
{
      public static class SeedRoles
      {
           public static void InitializeSeedRoles(IServiceProvider serviceProvider)
           {
               using(var context = serviceProvider.GetService<ApplicationDbContext>())
               {
                   if(context.Roles.Any())
                   {
                       return ;
                   }
                    context.Roles.AddRange(new Microsoft.AspNetCore.Identity.IdentityRole[]
                    {
                        new Microsoft.AspNetCore.Identity.IdentityRole()
                        {
                            Name = "Admin",
<<<<<<< HEAD
                            // NormalizedName= "admin"
=======
                            NormalizedName= "ADMIN"
>>>>>>> origin/khaivm_loginGG
                        },
                         new Microsoft.AspNetCore.Identity.IdentityRole()
                        {
                            Name = "Member",
<<<<<<< HEAD
                            // NormalizedName = "admin"
=======
                            NormalizedName = "MEMBER"
>>>>>>> origin/khaivm_loginGG
                        }
                    });
                    context.SaveChanges();
               }
           }
      }
}