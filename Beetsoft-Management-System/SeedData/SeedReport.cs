// using System;
// using Beetsoft_Management_System.Data;
// using Beetsoft_Management_System.Data.Entities;

// namespace SeedDatas
// {
//     public static class SeedReport
//     {
//         public static void InitializeSeedSeedReport(IServiceProvider serviceProvider)
//         {
//             using (var context = serviceProvider.GetService<ApplicationDbContext>())
//             {
//                 if (context.Reports.Any())
//                 {
//                     return;
//                 }
//                 context.Reports.AddRange(new Report[]{
//                         new Report()
//                         {
//                            Id =1 ,
//                            Time = 8,
//                            Date = DateTime.Now,
//                            Note = "abc",
//                            Status = 1,
//                             Type = 1,
//                             CreatedAt = DateTime.Now,
//                             UpdatedAt = DateTime.Now,
//                             Rate = 5,
//                             UserId = "1",
//                             ProjectId = 1,
//                             ReportType  = true
//                         },

//                     });
//                 context.SaveChanges();
//             }
//         }
//     }
// }