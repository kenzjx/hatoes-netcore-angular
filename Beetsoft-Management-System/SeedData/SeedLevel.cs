using Beetsoft_Management_System.Data;
using Beetsoft_Management_System.Data.Entities;

namespace SeedDatas.Lv
{
      public static class SeedLevel
      {
           public static void InitializeSeedSeedLevel(IServiceProvider serviceProvider)
           {
               using(var context = serviceProvider.GetService<ApplicationDbContext>())
               {
                   if(context.Levels.Any())
                   {
                       return ;
                   }
                    context.Levels.AddRange(new Level[]{
                        new Level()
                        {
                            LevelName = "Inter"
                        },
                         new Level()
                        {
                            LevelName = "Fesher"
                        }
                    });
                    context.SaveChanges();
               }
           }
      }
}