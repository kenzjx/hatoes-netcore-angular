using Beetsoft_Management_System.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Beetsoft_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ReportPosition>()
                      .HasKey(c => new { c.ReportId, c.PostionId });

            builder.Entity<MemberProject>()
                     .HasKey(c => new { c.UserId, c.ProjectId });

            builder.Entity<PmProject>()
                     .HasKey(c => new { c.ProjectId, c.UserId });

            builder.Entity<MemberProject>().HasOne<Project>(m => m.Project).WithMany(x => x.MemberProjects);

            builder.Entity<PmProject>().HasOne<Project>(m => m.Project).WithMany(x => x.PmProjects);

<<<<<<< HEAD
            builder.Entity<IdentityRole>().HasData(new List<IdentityRole>
                                                        {
                                                        new IdentityRole {
                                                            Id = "1",
                                                            Name = "Admin",
                                                            NormalizedName = "admin"
                                                        },
                                                        new IdentityRole {
                                                            Id = "2",
                                                            Name = "Member",
                                                            NormalizedName = "member"
                                                        },});

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
=======
            foreach (var entityType in builder.Model.GetEntityTypes ()) {
                var tableName = entityType.GetTableName ();
                if (tableName.StartsWith ("AspNet")) {
                    entityType.SetTableName (tableName.Substring (6));
>>>>>>> origin/khaivm_loginGG
                }
            }
        }

        public DbSet<Department> Departments { set; get; }

        public DbSet<FrameWork> FrameWorks { set; get; }

        public DbSet<Language> Languages { set; get; }

        public DbSet<Level> Levels { set; get; }

        public DbSet<MemberProject> MemberProjects { set; get; }

        public DbSet<OffReport> OffReports { set; get; }

        public DbSet<Partner> Partners { set; get; }

        public DbSet<PmProject> PmProjects { set; get; }

        public DbSet<Position> Postions { set; get; }

        public DbSet<Project> Projects { set; get; }

        public DbSet<ProjectType> ProjectTypes { set; get; }

        public DbSet<Recruitment> Recruitments { set; get; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<ReportPosition> ReportPositions { get; set; }

        public DbSet<Salary> Salarys { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<UserOnboard> UserOnboards { get; set; }

    }
}
