using System;
using Beetsoft_Management_System.Data;
using Beetsoft_Management_System.Data.Entities;

namespace SeedDatas
{
    public static class SeedProject
    {
        public static void InitializeSeedSeedReport(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetService<ApplicationDbContext>())
            {
                if (context.Projects.Any())
                {
                    return;
                }
                context.Projects.AddRange(new Project[]{
                        new Project()
                        {
                           Id =1 ,
                           ProjectName = "Abc",
                           StartDate = DateTime.Now,
                           EndDate = DateTime.Now,
                           Revenue = 1,
                           PmEstimate = 100,
                           BrseEstimate =100,
                           ComtorEstimate =100,
                           TestEstimate =1000,
                           DeveloperEstimate =100,
                           Description = "asdfasd",
                           ProjectTypeId = 1,
                           UpdatedAt= DateTime.Now
                        },
                        
                    });
                context.SaveChanges();
            }
        }
    }
}