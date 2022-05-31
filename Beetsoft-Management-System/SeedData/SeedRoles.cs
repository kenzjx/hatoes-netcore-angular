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
                            NormalizedName= "admin"
                        },
                         new Microsoft.AspNetCore.Identity.IdentityRole()
                        {
                            Name = "Member",
                            NormalizedName = "admin"
                        }
                    });
                    context.SaveChanges();
               }
           }
      }
}