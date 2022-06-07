using Beetsoft_Management_System.Data;
using Beetsoft_Management_System.Data.Entities;

namespace SeedDatas.Depart
{
      public static class SeedDepartment
      {
           public static void InitializeSeedDepartment(IServiceProvider serviceProvider)
           {
               using(var context = serviceProvider.GetService<ApplicationDbContext>())
               {
                   if(context.Departments.Any())
                   {
                       return ;
                   }
                    context.Departments.AddRange(new Department[]
                    {
                        new Department()
                        {
                             
                            DepartmentName = "Divison",

                        },

                        new Department()
                        {
                           
                            DepartmentName = "BOD",
                            
                        },

                    });
                    context.SaveChanges();
               }
           }
      }
}