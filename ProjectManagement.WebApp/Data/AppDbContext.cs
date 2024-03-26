using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.WebApp.Models.Identity;

namespace ProjectManagement.WebApp.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
            SeedUsers(builder);
            SeedUserRoles(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            AppUser admin = new AppUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                FirstName = "Furkan",
                LastName = "Aydýn",
                BirthDay = DateTime.Now,
                Gender = Models.Gender.Male,
                CreatedOn = DateTime.Now,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = false
            };

            AppUser projectManagement = new AppUser()
            {
                Id = "3c1def2b-a3cb-4bc7-a443-7fb9f966bf80",
                FirstName = "Ali",
                LastName = "Yýldýz ",
                BirthDay = DateTime.Now,
                Gender = Models.Gender.Male,
                CreatedOn = DateTime.Now,
                UserName = "aliyýldýz123",
                NormalizedUserName = "ALIYILDIZ123",
                Email = "aliyildiz@gmail.com",
                NormalizedEmail = "ALIYILDIZ@GMAIL.COM",
                EmailConfirmed = false
            };

            AppUser user = new AppUser()
            {
                Id = "13a6fdfc-0936-455f-9c0e-f2d3c118b56a",
                FirstName = "Ayþe",
                LastName = "Yýldýz",
                BirthDay = DateTime.Now,
                Gender = Models.Gender.Female,
                CreatedOn = DateTime.Now,
                UserName = "ayseyýldýz123",
                NormalizedUserName = "AYSEYILDIZ123",
                Email = "ayseyildiz@gmail.com",
                NormalizedEmail = "AYSEYILDIZ@GMAIL.COM",
                EmailConfirmed = false
            };

            CreatePasswordFor(builder,
                new UserSeedDataModel<AppUser>() { User = admin, Password = "admin123" },
                new UserSeedDataModel<AppUser>() { User = projectManagement, Password = "user123" },
                new UserSeedDataModel<AppUser>() { User = user, Password = "user123" });
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<AppRole>().HasData(
                           new AppRole
                           {
                               Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                               CreatedOn = DateTime.Now,
                               Name = "admin",
                               NormalizedName = "ADMIN",
                           },
                           new AppRole
                           {
                               Id = "49145ace-8fcc-4dfc-8033-243890fa9f91",
                               CreatedOn = DateTime.Now,
                               Name = "project-manager",
                               NormalizedName = "PROJECT-MANAGER",
                           },
                           new AppRole
                           {
                               Id = "8f4d6fb7-40d3-4696-bd74-bc04e5a7b3e6",
                               CreatedOn = DateTime.Now,
                               Name = "project-user",
                               NormalizedName = "PROJECT-USER",
                           });
        }
        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" },
                new IdentityUserRole<string>() { RoleId = "49145ace-8fcc-4dfc-8033-243890fa9f91", UserId = "3c1def2b-a3cb-4bc7-a443-7fb9f966bf80" },
                new IdentityUserRole<string>() { RoleId = "8f4d6fb7-40d3-4696-bd74-bc04e5a7b3e6", UserId = "13a6fdfc-0936-455f-9c0e-f2d3c118b56a" }
                );
        }


        private void CreatePasswordFor<TUser>(ModelBuilder builder, params UserSeedDataModel<TUser>[] userSeedDataModel)
            where TUser : IdentityUser, new()
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
           where TUser : IdentityUser, new()
        {
            public TUser User { get; set; }
            public string Password { get; set; }
        }
    }
}