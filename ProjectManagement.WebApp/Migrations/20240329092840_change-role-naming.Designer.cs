﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManagement.WebApp.Data;

#nullable disable

namespace ProjectManagement.WebApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240329092840_change-role-naming")]
    partial class changerolenaming
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("8eb125cc-8df0-4437-966f-fe37baa01cce"),
                            RoleId = new Guid("63d9cc3b-c6ac-48dc-ae6d-b9da6f28744b")
                        },
                        new
                        {
                            UserId = new Guid("ec8a8eb4-c286-458d-acdc-642d7a7f9140"),
                            RoleId = new Guid("71b83e0d-2a79-46d2-b04d-3cef44ddae9c")
                        },
                        new
                        {
                            UserId = new Guid("2591192c-f0cc-41ee-8f3a-ec0652ec926a"),
                            RoleId = new Guid("130fb7c3-67e2-497c-853a-e1fd3ddbd55c")
                        },
                        new
                        {
                            UserId = new Guid("cee52ce3-88c9-4521-8d54-e2602f20adac"),
                            RoleId = new Guid("7023a59e-968c-4a30-9269-29612a6ad2ed")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProjectManagement.WebApp.Models.Entities.Cost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Costs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0e25dbba-59b7-4945-a324-1843e42ec5bc"),
                            Amount = 500.00m,
                            CreatedOn = new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9658),
                            Date = new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9657),
                            Description = "Sample cost",
                            ProjectId = new Guid("b0841c4f-9735-46aa-8d37-f7006d1e5db6")
                        },
                        new
                        {
                            Id = new Guid("de30b874-4dfd-472c-8830-594534d4c1b3"),
                            Amount = 200.00m,
                            CreatedOn = new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9714),
                            Date = new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9714),
                            Description = "Sample cost",
                            ProjectId = new Guid("ad77749c-2fd0-46da-9c2f-2e5c08a0a003")
                        });
                });

            modelBuilder.Entity("ProjectManagement.WebApp.Models.Entities.Dependency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DependsOnJobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Dependencies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ebc99809-cadf-49ce-9ac2-809b55c546e3"),
                            CreatedOn = new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9572),
                            DependsOnJobId = new Guid("ee39d6ac-a605-4c6d-94da-bdc6aeef2aa3"),
                            JobId = new Guid("701cceef-83b3-4103-ab71-7f60a2ea782a")
                        });
                });

            modelBuilder.Entity("ProjectManagement.WebApp.Models.Entities.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AssignedTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StageId");

                    b.ToTable("Jobs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("28103f20-dfe2-4cfa-a2ab-4dd121b5a6dd"),
                            AssignedTo = "John Doe",
                            CreatedOn = new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9508),
                            Description = "Design user interface for the blog site",
                            DueDate = new DateTime(2024, 4, 5, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9504),
                            Priority = 1,
                            ProjectId = new Guid("b0841c4f-9735-46aa-8d37-f7006d1e5db6"),
                            StageId = new Guid("14d007b9-1308-4ecb-af53-6229a205818e"),
                            StartDate = new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9503),
                            Status = "ToDo",
                            Title = "Design UI"
                        },
                        new
                        {
                            Id = new Guid("ee39d6ac-a605-4c6d-94da-bdc6aeef2aa3"),
                            AssignedTo = "John Doe",
                            CreatedOn = new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9515),
                            Description = "Analyze requirements for the stock tracking project",
                            DueDate = new DateTime(2024, 4, 12, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9514),
                            Priority = 2,
                            ProjectId = new Guid("ad77749c-2fd0-46da-9c2f-2e5c08a0a003"),
                            StageId = new Guid("2195ff14-e525-45c6-ae7b-ba6a3327241a"),
                            StartDate = new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9513),
                            Status = "InProgress",
                            Title = "Requirement Analysis"
                        },
                        new
                        {
                            Id = new Guid("701cceef-83b3-4103-ab71-7f60a2ea782a"),
                            AssignedTo = "John Doe",
                            CreatedOn = new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9520),
                            Description = "Depend job",
                            DueDate = new DateTime(2024, 4, 12, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9519),
                            Priority = 2,
                            ProjectId = new Guid("ad77749c-2fd0-46da-9c2f-2e5c08a0a003"),
                            StageId = new Guid("2195ff14-e525-45c6-ae7b-ba6a3327241a"),
                            StartDate = new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9518),
                            Status = "Pending",
                            Title = "Depend job"
                        });
                });

            modelBuilder.Entity("ProjectManagement.WebApp.Models.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b0841c4f-9735-46aa-8d37-f7006d1e5db6"),
                            CreatedOn = new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(6918),
                            Description = "A project to create a blog site",
                            EndDate = new DateTime(2024, 4, 28, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(6911),
                            ProjectName = "Blog Site Project",
                            StartDate = new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(6910),
                            Status = "InProgress"
                        },
                        new
                        {
                            Id = new Guid("ad77749c-2fd0-46da-9c2f-2e5c08a0a003"),
                            CreatedOn = new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(6923),
                            Description = "A project to develop a stock tracking system",
                            EndDate = new DateTime(2024, 5, 28, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(6922),
                            ProjectName = "Stock Tracking Project",
                            StartDate = new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(6922),
                            Status = "Planning"
                        });
                });

            modelBuilder.Entity("ProjectManagement.WebApp.Models.Entities.ProjectUserAssociation", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectUserAssociation");

                    b.HasData(
                        new
                        {
                            ProjectId = new Guid("b0841c4f-9735-46aa-8d37-f7006d1e5db6"),
                            UserId = new Guid("ec8a8eb4-c286-458d-acdc-642d7a7f9140")
                        },
                        new
                        {
                            ProjectId = new Guid("b0841c4f-9735-46aa-8d37-f7006d1e5db6"),
                            UserId = new Guid("cee52ce3-88c9-4521-8d54-e2602f20adac")
                        },
                        new
                        {
                            ProjectId = new Guid("ad77749c-2fd0-46da-9c2f-2e5c08a0a003"),
                            UserId = new Guid("ec8a8eb4-c286-458d-acdc-642d7a7f9140")
                        },
                        new
                        {
                            ProjectId = new Guid("ad77749c-2fd0-46da-9c2f-2e5c08a0a003"),
                            UserId = new Guid("2591192c-f0cc-41ee-8f3a-ec0652ec926a")
                        });
                });

            modelBuilder.Entity("ProjectManagement.WebApp.Models.Entities.Stage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Stages");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2195ff14-e525-45c6-ae7b-ba6a3327241a"),
                            CreatedOn = new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9440),
                            Description = "Design stage for the blog site project",
                            ProjectId = new Guid("b0841c4f-9735-46aa-8d37-f7006d1e5db6"),
                            StageName = "Design"
                        },
                        new
                        {
                            Id = new Guid("14d007b9-1308-4ecb-af53-6229a205818e"),
                            CreatedOn = new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9443),
                            Description = "Planning stage for the stock tracking project",
                            ProjectId = new Guid("ad77749c-2fd0-46da-9c2f-2e5c08a0a003"),
                            StageName = "Planning"
                        });
                });

            modelBuilder.Entity("ProjectManagement.WebApp.Models.Identity.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("63d9cc3b-c6ac-48dc-ae6d-b9da6f28744b"),
                            CreatedOn = new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1173),
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("71b83e0d-2a79-46d2-b04d-3cef44ddae9c"),
                            CreatedOn = new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1185),
                            Name = "project-manager",
                            NormalizedName = "PROJECT-MANAGER"
                        },
                        new
                        {
                            Id = new Guid("130fb7c3-67e2-497c-853a-e1fd3ddbd55c"),
                            CreatedOn = new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1187),
                            Name = "user",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = new Guid("7023a59e-968c-4a30-9269-29612a6ad2ed"),
                            CreatedOn = new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1189),
                            Name = "project-user",
                            NormalizedName = "PROJECT-USER"
                        });
                });

            modelBuilder.Entity("ProjectManagement.WebApp.Models.Identity.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8eb125cc-8df0-4437-966f-fe37baa01cce"),
                            AccessFailedCount = 0,
                            BirthDay = new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1342),
                            ConcurrencyStamp = "c0cb0ab4-6559-4660-bf47-9ae57effca66",
                            CreatedOn = new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1343),
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Furkan",
                            Gender = 1,
                            LastName = "Aydin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEJYeoNuD8bA/8yLSYJ/CRr7PmkGh5sMS7tPqoJ2ulw8Ic31eV3/hA3GM52uhxVyijw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "04ae181f-c8f4-47f2-9774-f97b90c73524",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = new Guid("ec8a8eb4-c286-458d-acdc-642d7a7f9140"),
                            AccessFailedCount = 0,
                            BirthDay = new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1350),
                            ConcurrencyStamp = "86d96d5a-df0d-4610-9219-5951dc861fbb",
                            CreatedOn = new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1351),
                            Email = "aliyildiz@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Ali",
                            Gender = 1,
                            LastName = "Yildiz ",
                            LockoutEnabled = false,
                            NormalizedEmail = "ALIYILDIZ@GMAIL.COM",
                            NormalizedUserName = "ALIYILDIZ123",
                            PasswordHash = "AQAAAAIAAYagAAAAEL8MkyOXXO/3xVXFHgYVRDWZM/nzgjxUzRn+34UWljezttvdWlPH/LIMzM6dZunJcA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9bbfe04e-8d59-44c7-b157-68a9fe3057d8",
                            TwoFactorEnabled = false,
                            UserName = "aliyildiz123"
                        },
                        new
                        {
                            Id = new Guid("2591192c-f0cc-41ee-8f3a-ec0652ec926a"),
                            AccessFailedCount = 0,
                            BirthDay = new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1359),
                            ConcurrencyStamp = "4809970f-9f2f-4090-8cec-bce38f6a2366",
                            CreatedOn = new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1360),
                            Email = "ayseyildiz@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Ayse",
                            Gender = 2,
                            LastName = "Yildiz",
                            LockoutEnabled = false,
                            NormalizedEmail = "AYSEYILDIZ@GMAIL.COM",
                            NormalizedUserName = "AYSEYILDIZ123",
                            PasswordHash = "AQAAAAIAAYagAAAAEFrRRLOq35FxE4aBZbCBb3sVJmmTOGNrkeLf8E0kfzHqxCbC7Dkh3CYfyhXKaLa7Ow==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fba52f14-ac22-4544-8a0f-3ce6b60ce924",
                            TwoFactorEnabled = false,
                            UserName = "ayseyildiz123"
                        },
                        new
                        {
                            Id = new Guid("cee52ce3-88c9-4521-8d54-e2602f20adac"),
                            AccessFailedCount = 0,
                            BirthDay = new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1365),
                            ConcurrencyStamp = "71498616-7281-400f-8853-21d453a00736",
                            CreatedOn = new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1366),
                            Email = "esrefyildiz@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Esref",
                            Gender = 2,
                            LastName = "Yildiz",
                            LockoutEnabled = false,
                            NormalizedEmail = "ESREFYILDIZ@GMAIL.COM",
                            NormalizedUserName = "ESREFYILDIZ123",
                            PasswordHash = "AQAAAAIAAYagAAAAEHd7PBv6/XmjVgQgmwoijA4pBpJ/eNm8VYbQ4XCGsxTNhdmi4NEt1/6L6MFDH2q2XA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b99a7e91-18a7-4fb4-8512-a5b57eaef2c5",
                            TwoFactorEnabled = false,
                            UserName = "esrefyildiz123"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("ProjectManagement.WebApp.Models.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("ProjectManagement.WebApp.Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("ProjectManagement.WebApp.Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("ProjectManagement.WebApp.Models.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManagement.WebApp.Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("ProjectManagement.WebApp.Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectManagement.WebApp.Models.Entities.Cost", b =>
                {
                    b.HasOne("ProjectManagement.WebApp.Models.Entities.Project", "Project")
                        .WithMany("Costs")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectManagement.WebApp.Models.Entities.Dependency", b =>
                {
                    b.HasOne("ProjectManagement.WebApp.Models.Entities.Job", "Job")
                        .WithMany("Dependencies")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("ProjectManagement.WebApp.Models.Entities.Job", b =>
                {
                    b.HasOne("ProjectManagement.WebApp.Models.Entities.Project", "Project")
                        .WithMany("Jobs")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManagement.WebApp.Models.Entities.Stage", "Stage")
                        .WithMany("Jobs")
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Project");

                    b.Navigation("Stage");
                });

            modelBuilder.Entity("ProjectManagement.WebApp.Models.Entities.ProjectUserAssociation", b =>
                {
                    b.HasOne("ProjectManagement.WebApp.Models.Entities.Project", "Project")
                        .WithMany("Users")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManagement.WebApp.Models.Identity.AppUser", "User")
                        .WithMany("Projects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectManagement.WebApp.Models.Entities.Stage", b =>
                {
                    b.HasOne("ProjectManagement.WebApp.Models.Entities.Project", "Project")
                        .WithMany("Stages")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectManagement.WebApp.Models.Entities.Job", b =>
                {
                    b.Navigation("Dependencies");
                });

            modelBuilder.Entity("ProjectManagement.WebApp.Models.Entities.Project", b =>
                {
                    b.Navigation("Costs");

                    b.Navigation("Jobs");

                    b.Navigation("Stages");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ProjectManagement.WebApp.Models.Entities.Stage", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("ProjectManagement.WebApp.Models.Identity.AppUser", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
