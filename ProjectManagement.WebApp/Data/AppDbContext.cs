using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProjectManagement.WebApp.Helpers.Identity;
using ProjectManagement.WebApp.Models.Entities;
using ProjectManagement.WebApp.Models.Identity;

namespace ProjectManagement.WebApp.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        #region Tables
        public DbSet<Project> Projects { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Dependency> Dependencies { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<ProjectUserAssociation> ProjectUserAssociations { get; set; }
        public DbSet<BoardUserAssociation> BoardUserAssociations { get; set; }
        public DbSet<JobUserAssociation> JobUserAssociations { get; set; }

        #endregion

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Relationships

            builder.Entity<JobUserAssociation>().HasKey(ju => new { ju.UserId, ju.JobId });
            builder.Entity<JobUserAssociation>()
                .HasOne<AppUser>(ju => ju.User)
                .WithMany(u => u.Jobs)
                .HasForeignKey(ju => ju.UserId)
                .IsRequired(required: true)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<JobUserAssociation>()
                .HasOne<Job>(ju => ju.Job)
                .WithMany(j => j.Users)
                .HasForeignKey(ju => ju.JobId)
                .IsRequired(required: true)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BoardUserAssociation>().HasKey(bu => new { bu.BoardId, bu.AppUserId });
            builder.Entity<BoardUserAssociation>()
                .HasOne<Board>(bu => bu.Board)
                .WithMany(b => b.Users)
                .HasForeignKey(bu => bu.BoardId)
                .IsRequired(required: true)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<BoardUserAssociation>()
                .HasOne<AppUser>(bu => bu.AppUser)
                .WithMany(u => u.Boards)
                .HasForeignKey(bu => bu.AppUserId)
                .IsRequired(required: true)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProjectUserAssociation>().HasKey(pu => new { pu.ProjectId, pu.UserId });
            builder.Entity<ProjectUserAssociation>()
                .HasOne<AppUser>(pu => pu.User)
                .WithMany(p => p.Projects)
                .HasForeignKey(pu => pu.UserId)
                .IsRequired(required: true)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ProjectUserAssociation>()
                .HasOne<Project>(pu => pu.Project)
                .WithMany(p => p.Users)
                .HasForeignKey(pu => pu.ProjectId)
                .IsRequired(required: true)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Project>()
              .HasMany(p => p.boards)
              .WithOne(b => b.Project)
              .HasForeignKey(b => b.ProjectId)
              .IsRequired(required: true)
              .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Project>()
                .HasMany(p => p.Costs)
                .WithOne(c => c.Project)
                .IsRequired(required: true)
                .HasForeignKey(c => c.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Stage>()
                .HasMany(s => s.Jobs)
                .WithOne(j => j.Stage)
                .HasForeignKey(j => j.StageId)
                .IsRequired(required: false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Stage>()
                .HasOne(s => s.Board)
                .WithMany(b => b.Stages)
                .HasForeignKey(s => s.BoardId)
                .IsRequired(required: true)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Job>()
                .HasMany(j => j.Dependencies)
                .WithOne(d => d.Job)
                .HasForeignKey(d => d.JobId)
                .IsRequired(required: true)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            GenerateSeedData(builder);
        }

        private void GenerateSeedData(ModelBuilder builder)
        {
            Dictionary<string, Guid> userIds;

            // User Identity Data Seeding
            SeedUserRoles(builder, out userIds);

            // These will use for data seeding in entity related
            Guid blogSiteProjectGuid = Guid.NewGuid();
            Guid stockTrackingProjectGuid = Guid.NewGuid();
            Guid homePageStageGuid = Guid.NewGuid();
            Guid supplierPageGuid = Guid.NewGuid();
            Guid dependJobGuid = Guid.NewGuid();
            Guid designUIJobGuid = Guid.NewGuid();
            Guid requirenmentAnalysisJobGuid = Guid.NewGuid();
            Guid dependencyGuid = Guid.NewGuid();
            Guid developerConstGuid = Guid.NewGuid();
            Guid serverConstGuid = Guid.NewGuid();
            Guid frontendBoarGuid = Guid.NewGuid();

            builder.Entity<Project>().HasData(
                new Project
                {
                    Id = blogSiteProjectGuid,
                    ProjectName = "Blog Site Project",
                    Description = "A project to create a blog site",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(30),
                    Status = "InProgress",
                    CreatedOn = DateTime.Now
                },
                new Project
                {
                    Id = stockTrackingProjectGuid,
                    ProjectName = "Stock Tracking Project",
                    Description = "A project to develop a stock tracking system",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(60),
                    Status = "Planning",
                    CreatedOn = DateTime.Now,
                }
            );

            builder.Entity<ProjectUserAssociation>().HasData(
               new ProjectUserAssociation { ProjectId = blogSiteProjectGuid, UserId = userIds["project-manager"] },
               new ProjectUserAssociation { ProjectId = blogSiteProjectGuid, UserId = userIds["project-user"] },
               new ProjectUserAssociation { ProjectId = stockTrackingProjectGuid, UserId = userIds["project-manager"] },
               new ProjectUserAssociation { ProjectId = stockTrackingProjectGuid, UserId = userIds["user"] }
            );

            builder.Entity<Board>().HasData(
                new Board { Id = frontendBoarGuid, ProjectId = stockTrackingProjectGuid, Title = "Front-end board"}
            );

            builder.Entity<Stage>().HasData(
                new Stage
                {
                    Id = homePageStageGuid,
                    StageName = "Home Page",
                    Description = "Design stage for the blog site project",
                    CreatedOn = DateTime.Now,
                    BoardId = frontendBoarGuid
                },
                new Stage
                {
                    Id = supplierPageGuid,
                    StageName = "Supplier Page",
                    Description = "Planning stage for the stock tracking project",
                    CreatedOn = DateTime.Now,
                    BoardId = frontendBoarGuid
                }
            );

            builder.Entity<Job>().HasData(
                new Job
                {
                    Id = designUIJobGuid,
                    Title = "Design UI",
                    Description = "Design user interface for the blog site",
                    AssignedTo = "John Doe",
                    StartDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7),
                    Priority = Models.JobPriority.low,
                    Status = "ToDo",
                    CreatedOn = DateTime.Now,
                    StageId = supplierPageGuid,
                },
                new Job
                {
                    Id = requirenmentAnalysisJobGuid,
                    Title = "Requirement Analysis",
                    Description = "Analyze requirements for the stock tracking project",
                    AssignedTo = "John Doe",
                    StartDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(14),
                    Priority = Models.JobPriority.medium,
                    Status = "InProgress",
                    CreatedOn = DateTime.Now,
                    StageId = homePageStageGuid,
                },
                new Job
                {
                    Id = dependJobGuid,
                    Title = "Depend job",
                    Description = "Depend job",
                    AssignedTo = "John Doe",
                    StartDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(14),
                    Priority = Models.JobPriority.high,
                    Status = "Pending",
                    CreatedOn = DateTime.Now,
                    StageId = homePageStageGuid,
                }
            );

            builder.Entity<Dependency>().HasData(
                new Dependency
                {
                    Id = dependencyGuid,
                    DependsOnJobId = requirenmentAnalysisJobGuid,
                    CreatedOn = DateTime.Now,
                    JobId = dependJobGuid,
                }
            );

            builder.Entity<Cost>().HasData(
                new Cost
                {
                    Id = developerConstGuid,
                    Description = "Sample cost",
                    Amount = 500.00m,
                    Date = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    ProjectId = blogSiteProjectGuid,
                }
            );

            builder.Entity<Cost>().HasData(
                new Cost
                {
                    Id = serverConstGuid,
                    Description = "Sample cost",
                    Amount = 200.00m,
                    Date = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    ProjectId = stockTrackingProjectGuid,
                }
            );
        }

        private void SeedUsers(ModelBuilder builder, out Dictionary<string, Guid> userIds)
        {
            userIds = new Dictionary<string, Guid>(){
                {"admin", Guid.NewGuid()},
                {"project-manager", Guid.NewGuid()},
                {"user", Guid.NewGuid()},
                {"project-user", Guid.NewGuid()}
            };

            AppUser admin = new AppUser()
            {
                Id = userIds["admin"],
                FirstName = "Furkan",
                LastName = "Aydin",
                BirthDay = DateTime.Now,
                Gender = Models.Gender.Male,
                CreatedOn = DateTime.Now,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            AppUser projectManager = new AppUser()
            {
                Id = userIds["project-manager"],
                FirstName = "Ali",
                LastName = "Yildiz ",
                BirthDay = DateTime.Now,
                Gender = Models.Gender.Male,
                CreatedOn = DateTime.Now,
                UserName = "aliyildiz123",
                NormalizedUserName = "ALIYILDIZ123",
                Email = "aliyildiz@gmail.com",
                NormalizedEmail = "ALIYILDIZ@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            AppUser user = new AppUser()
            {
                Id = userIds["user"],
                FirstName = "Ayse",
                LastName = "Yildiz",
                BirthDay = DateTime.Now,
                Gender = Models.Gender.Female,
                CreatedOn = DateTime.Now,
                UserName = "ayseyildiz123",
                NormalizedUserName = "AYSEYILDIZ123",
                Email = "ayseyildiz@gmail.com",
                NormalizedEmail = "AYSEYILDIZ@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            AppUser projectUser = new AppUser()
            {
                Id = userIds["project-user"],
                FirstName = "Esref",
                LastName = "Yildiz",
                BirthDay = DateTime.Now,
                Gender = Models.Gender.Female,
                CreatedOn = DateTime.Now,
                UserName = "esrefyildiz123",
                NormalizedUserName = "ESREFYILDIZ123",
                Email = "esrefyildiz@gmail.com",
                NormalizedEmail = "ESREFYILDIZ@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            CreatePasswordFor(builder,
                new UserSeedDataModel<AppUser>() { User = admin, Password = "admin123" },
                new UserSeedDataModel<AppUser>() { User = projectManager, Password = "user123" },
                new UserSeedDataModel<AppUser>() { User = user, Password = "user123" },
                new UserSeedDataModel<AppUser>() { User = projectUser, Password = "user123" });
        }

        private void SeedRoles(ModelBuilder builder, out Dictionary<string, Guid> roleIds)
        {
            roleIds = new Dictionary<string, Guid>(){
                {"admin", Guid.NewGuid()},
                {"project-manager", Guid.NewGuid()},
                {"user", Guid.NewGuid()},
                {"project-user", Guid.NewGuid()}
            };

            builder.Entity<AppRole>().HasData(
                           new AppRole
                           {
                               Id = roleIds["admin"],
                               CreatedOn = DateTime.Now,
                               Name = "admin",
                               NormalizedName = "ADMIN",
                           },
                           new AppRole
                           {
                               Id = roleIds["project-manager"],
                               CreatedOn = DateTime.Now,
                               Name = "project-manager",
                               NormalizedName = "PROJECT-MANAGER",
                           }, new AppRole
                           {
                               Id = roleIds["user"],
                               CreatedOn = DateTime.Now,
                               Name = "user",
                               NormalizedName = "USER",
                           },
                           new AppRole
                           {
                               Id = roleIds["project-user"],
                               CreatedOn = DateTime.Now,
                               Name = "project-user",
                               NormalizedName = "PROJECT-USER",
                           });
        }

        private void SeedUserRoles(ModelBuilder builder, out Dictionary<string, Guid> userIds)
        {
            Dictionary<string, Guid> roleIds;

            SeedRoles(builder, out roleIds);
            SeedUsers(builder, out userIds);

            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>() { RoleId = roleIds["admin"], UserId = userIds["admin"] },
                new IdentityUserRole<Guid>() { RoleId = roleIds["project-manager"], UserId = userIds["project-manager"] },
                new IdentityUserRole<Guid>() { RoleId = roleIds["user"], UserId = userIds["user"] },
                new IdentityUserRole<Guid>() { RoleId = roleIds["project-user"], UserId = userIds["project-user"] }
                );
        }

        private void CreatePasswordFor<TUser>(ModelBuilder builder, params UserSeedDataModel<TUser>[] userSeedDataModel)
            where TUser : IdentityUser<Guid>, new()
        {
            foreach (var item in userSeedDataModel)
            {
                PasswordHasher<TUser> passwordHasher = new PasswordHasher<TUser>();
                item.User.PasswordHash = passwordHasher.HashPassword(item.User, item.Password);

                builder.Entity<TUser>().HasData(item.User);
            }
        }

        private void CreatePasswordFor<TUser, TRole>(ModelBuilder builder, params UserRoleSeedDataModel<TUser, TRole>[] userSeedDataModel)
            where TUser : IdentityUser, new()
            where TRole : IdentityRole, new()
        {
            foreach (var item in userSeedDataModel)
            {
                PasswordHasher<TUser> passwordHasher = new PasswordHasher<TUser>();
                passwordHasher.HashPassword(item.User, item.Password);
                builder.Entity<TUser>().HasData(item.User);

                if (item.Role != null)
                    builder.Entity<IdentityUserRole<string>>()
                        .HasData(new IdentityUserRole<string>()
                        {
                            RoleId = item.Role.Id,
                            UserId = item.User.Id,
                        });
            }
        }

        private class UserRoleSeedDataModel<TUser, TRole>
            where TUser : IdentityUser, new()
            where TRole : IdentityRole, new()
        {
            public TUser User { get; set; }
            public string Password { get; set; }
            public TRole Role { get; set; }
        }

        private class UserSeedDataModel<TUser>
           where TUser : IdentityUser<Guid>, new()
        {
            public TUser User { get; set; }
            public string Password { get; set; }
        }
    }
}