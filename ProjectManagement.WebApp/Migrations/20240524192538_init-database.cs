using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectManagement.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class initdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boards_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Costs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUserAssociations",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUserAssociations", x => new { x.ProjectId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ProjectUserAssociations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUserAssociations_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardUserAssociations",
                columns: table => new
                {
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardUserAssociations", x => new { x.BoardId, x.AppUserId });
                    table.ForeignKey(
                        name: "FK_BoardUserAssociations_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardUserAssociations_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stages_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DependsOnJobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dependencies_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobUserAssociations",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobUserAssociations", x => new { x.UserId, x.JobId });
                    table.ForeignKey(
                        name: "FK_JobUserAssociations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobUserAssociations_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubJobs_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedOn", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0b75611c-532e-45e5-80ab-c8009a0c43b7"), null, new DateTime(2024, 5, 24, 22, 25, 36, 771, DateTimeKind.Local).AddTicks(7462), "project-manager", "PROJECT-MANAGER" },
                    { new Guid("36f31f98-9ae2-4e56-9e61-375c0d3ceb7b"), null, new DateTime(2024, 5, 24, 22, 25, 36, 771, DateTimeKind.Local).AddTicks(7470), "user", "USER" },
                    { new Guid("3a4124db-ca29-4926-90f1-2a539ad10337"), null, new DateTime(2024, 5, 24, 22, 25, 36, 771, DateTimeKind.Local).AddTicks(7474), "project-user", "PROJECT-USER" },
                    { new Guid("99bdcf45-4f91-4af5-bf31-1d5fa93b95f8"), null, new DateTime(2024, 5, 24, 22, 25, 36, 771, DateTimeKind.Local).AddTicks(7392), "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("28cf6447-8cd8-4b04-93de-f94a8ff3eb1d"), 0, new DateTime(2024, 5, 24, 22, 25, 36, 771, DateTimeKind.Local).AddTicks(9371), "2ff40355-8d66-471f-a895-6d32f09c0666", new DateTime(2024, 5, 24, 22, 25, 36, 771, DateTimeKind.Local).AddTicks(9373), "admin@gmail.com", false, "Furkan", 1, "Aydin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEK0PmJ3zbUDqcQPqeEUWdoiSuoLux7wUKmFaMUOVgl2cEOBW5rX4OXVRdUs2FKQY+A==", null, false, "21e204e4-9cae-4f76-ab36-43bbcf616c07", false, "admin" },
                    { new Guid("5306c7d5-de1a-4ed8-878d-075c3b78aeb3"), 0, new DateTime(2024, 5, 24, 22, 25, 36, 771, DateTimeKind.Local).AddTicks(9529), "14cd5cba-421d-411e-997d-94fda554c62f", new DateTime(2024, 5, 24, 22, 25, 36, 771, DateTimeKind.Local).AddTicks(9530), "furkanaydin@gmail.com", false, "Furkan", 1, "Aydin", false, null, "FURKANAYDIN@GMAIL.COM", "FURKANAYDIN123", "AQAAAAIAAYagAAAAEL326R/MhQWk16ci7GJ7nIbQ/0hXDzyOvGBLsbP658x56zqj3TwZK2aUmY6c3mUp2w==", null, false, "99d264f7-2f39-4909-a811-5dd2b0ebd501", false, "furkanaydin123" },
                    { new Guid("5ca9ffe1-9ebd-4447-abee-b1cf6f90e3a3"), 0, new DateTime(2024, 5, 24, 22, 25, 36, 771, DateTimeKind.Local).AddTicks(9494), "478beb9a-43e8-481c-9246-239f28d4c676", new DateTime(2024, 5, 24, 22, 25, 36, 771, DateTimeKind.Local).AddTicks(9495), "ayseyildiz@gmail.com", false, "Ayse", 2, "Yildiz", false, null, "AYSEYILDIZ@GMAIL.COM", "AYSEYILDIZ123", "AQAAAAIAAYagAAAAEDVFe7WcIbaZcaZFB28WPTV6m59e6/EMJkhjgKMALWZmGy0EBvIBYGp1ob2qYnB2uw==", null, false, "2f5a8979-3630-480e-8887-c2ffc4b979d1", false, "ayseyildiz123" },
                    { new Guid("69f70423-e890-4b4d-99b7-447fbc8c1a3d"), 0, new DateTime(2024, 5, 24, 22, 25, 36, 771, DateTimeKind.Local).AddTicks(9514), "a5df07f1-253f-4291-8b6d-21f24d7137f6", new DateTime(2024, 5, 24, 22, 25, 36, 771, DateTimeKind.Local).AddTicks(9516), "esrefyildiz@gmail.com", false, "Esref", 2, "Yildiz", false, null, "ESREFYILDIZ@GMAIL.COM", "ESREFYILDIZ123", "AQAAAAIAAYagAAAAEKF4KuISZp6j1zXCT8qER44m39vvngCfw5hiEdtsRKY7ZcjCiPDI/zZ5hRwncw/jLg==", null, false, "5c6da2ca-03f4-46e7-a5ea-5ff6e38b31f3", false, "esrefyildiz123" },
                    { new Guid("6d2ae4df-f3ab-439f-9e51-0eb60e5d2568"), 0, new DateTime(2024, 5, 24, 22, 25, 36, 771, DateTimeKind.Local).AddTicks(9477), "951d4fc6-c189-468e-bdff-c93493ed7ea4", new DateTime(2024, 5, 24, 22, 25, 36, 771, DateTimeKind.Local).AddTicks(9478), "aliyildiz@gmail.com", false, "Ali", 1, "Yildiz ", false, null, "ALIYILDIZ@GMAIL.COM", "ALIYILDIZ123", "AQAAAAIAAYagAAAAEHHaai0iyzKyHoYTYzOOzQ/rE+9fEZOqNcoYjnMWebKM55cBcJDc8i7ivi6+vhIYww==", null, false, "a89f0caf-1798-449d-a83e-ab87f65bc4a6", false, "aliyildiz123" },
                    { new Guid("a9faab74-e449-42f3-99a0-0386489a82c6"), 0, new DateTime(2024, 5, 24, 22, 25, 36, 771, DateTimeKind.Local).AddTicks(9543), "2b709da1-8450-42b5-a31b-4057fd533ff3", new DateTime(2024, 5, 24, 22, 25, 36, 771, DateTimeKind.Local).AddTicks(9544), "firatcanyanan@gmail.com", false, "Firat Can", 1, "Yanan", false, null, "FIRATCANYANAN@GMAIL.COM", "FIRATCANYANAN123", "AQAAAAIAAYagAAAAENyMTgDYd4yL8eWOk7bd0wS7MnTMk+bBQ5lyfxM0QBdX6uXLSMdigsmMqS8yLCxtOw==", null, false, "b8f52f21-c93e-4dd4-987b-5449d1cb9cb2", false, "firatcanyanan123" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedOn", "Description", "EndDate", "ProjectName", "StartDate" },
                values: new object[,]
                {
                    { new Guid("8a351462-5a20-4291-9692-9d2f125641b6"), new DateTime(2024, 5, 24, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1181), "A project to create a blog site", new DateTime(2024, 6, 23, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1173), "Blog Site Project", new DateTime(2024, 5, 24, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1172) },
                    { new Guid("c3d815c5-95d3-494d-b72b-814d84f62b9e"), new DateTime(2024, 5, 24, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1190), "A project to develop a stock tracking system", new DateTime(2024, 7, 23, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1189), "Stock Tracking Project", new DateTime(2024, 5, 24, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1188) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("99bdcf45-4f91-4af5-bf31-1d5fa93b95f8"), new Guid("28cf6447-8cd8-4b04-93de-f94a8ff3eb1d") },
                    { new Guid("36f31f98-9ae2-4e56-9e61-375c0d3ceb7b"), new Guid("5ca9ffe1-9ebd-4447-abee-b1cf6f90e3a3") },
                    { new Guid("3a4124db-ca29-4926-90f1-2a539ad10337"), new Guid("69f70423-e890-4b4d-99b7-447fbc8c1a3d") },
                    { new Guid("0b75611c-532e-45e5-80ab-c8009a0c43b7"), new Guid("6d2ae4df-f3ab-439f-9e51-0eb60e5d2568") }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "CreatedOn", "ProjectId", "Title" },
                values: new object[,]
                {
                    { new Guid("8d22c567-f65b-475c-a3e1-75d74def6fd7"), new DateTime(2024, 5, 24, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1663), new Guid("c3d815c5-95d3-494d-b72b-814d84f62b9e"), "Back-end board" },
                    { new Guid("d22d17db-f681-4e4c-8b84-72bf25e45197"), new DateTime(2024, 5, 24, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1658), new Guid("c3d815c5-95d3-494d-b72b-814d84f62b9e"), "Front-end board" }
                });

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "CreatedOn", "Date", "Description", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("2848a532-0010-4174-9025-99f94307a9ec"), 500.00m, new DateTime(2024, 5, 24, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1955), new DateTime(2024, 5, 24, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1954), "Sample cost", new Guid("8a351462-5a20-4291-9692-9d2f125641b6") },
                    { new Guid("3ac46782-bb72-4430-aaa1-e3f0ac6fd105"), 200.00m, new DateTime(2024, 5, 24, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(2077), new DateTime(2024, 5, 24, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(2076), "Sample cost", new Guid("c3d815c5-95d3-494d-b72b-814d84f62b9e") }
                });

            migrationBuilder.InsertData(
                table: "ProjectUserAssociations",
                columns: new[] { "ProjectId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8a351462-5a20-4291-9692-9d2f125641b6"), new Guid("6d2ae4df-f3ab-439f-9e51-0eb60e5d2568") },
                    { new Guid("c3d815c5-95d3-494d-b72b-814d84f62b9e"), new Guid("5306c7d5-de1a-4ed8-878d-075c3b78aeb3") },
                    { new Guid("c3d815c5-95d3-494d-b72b-814d84f62b9e"), new Guid("5ca9ffe1-9ebd-4447-abee-b1cf6f90e3a3") },
                    { new Guid("c3d815c5-95d3-494d-b72b-814d84f62b9e"), new Guid("69f70423-e890-4b4d-99b7-447fbc8c1a3d") },
                    { new Guid("c3d815c5-95d3-494d-b72b-814d84f62b9e"), new Guid("6d2ae4df-f3ab-439f-9e51-0eb60e5d2568") },
                    { new Guid("c3d815c5-95d3-494d-b72b-814d84f62b9e"), new Guid("a9faab74-e449-42f3-99a0-0386489a82c6") }
                });

            migrationBuilder.InsertData(
                table: "BoardUserAssociations",
                columns: new[] { "AppUserId", "BoardId" },
                values: new object[,]
                {
                    { new Guid("5306c7d5-de1a-4ed8-878d-075c3b78aeb3"), new Guid("d22d17db-f681-4e4c-8b84-72bf25e45197") },
                    { new Guid("69f70423-e890-4b4d-99b7-447fbc8c1a3d"), new Guid("d22d17db-f681-4e4c-8b84-72bf25e45197") },
                    { new Guid("a9faab74-e449-42f3-99a0-0386489a82c6"), new Guid("d22d17db-f681-4e4c-8b84-72bf25e45197") }
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "StageName" },
                values: new object[,]
                {
                    { new Guid("082359a1-97d4-4cb4-b8e6-123ddb485568"), new Guid("d22d17db-f681-4e4c-8b84-72bf25e45197"), new DateTime(2024, 5, 24, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1724), "Design stage for the blog site project", "Home Page" },
                    { new Guid("ddb0fa4a-ea2b-4f0f-8935-8503ec87b148"), new Guid("d22d17db-f681-4e4c-8b84-72bf25e45197"), new DateTime(2024, 5, 24, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1728), "Planning stage for the stock tracking project", "Supplier Page" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CreatedOn", "Description", "DueDate", "Priority", "StageId", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("5010df47-17cc-484a-a7ad-7d6705af777c"), new DateTime(2024, 5, 24, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1832), "Analyze requirements for the stock tracking project", new DateTime(2024, 6, 7, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1831), 1, new Guid("082359a1-97d4-4cb4-b8e6-123ddb485568"), new DateTime(2024, 5, 24, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1830), "Requirement Analysis" },
                    { new Guid("76946e58-a7ff-405b-9d49-9f5b9624809e"), new DateTime(2024, 5, 24, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1844), "Depend job", new DateTime(2024, 6, 7, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1843), 2, new Guid("082359a1-97d4-4cb4-b8e6-123ddb485568"), new DateTime(2024, 5, 24, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1843), "Depend job" },
                    { new Guid("d98fd1d7-ac24-4c28-b925-46fb62da8046"), new DateTime(2024, 5, 24, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1823), "Design user interface for the blog site", new DateTime(2024, 5, 31, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1821), 0, new Guid("ddb0fa4a-ea2b-4f0f-8935-8503ec87b148"), new DateTime(2024, 5, 24, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1820), "Design UI" }
                });

            migrationBuilder.InsertData(
                table: "Dependencies",
                columns: new[] { "Id", "CreatedOn", "DependsOnJobId", "JobId" },
                values: new object[] { new Guid("9c08bc7d-cb5a-4e06-b8ff-96eedf9a89d1"), new DateTime(2024, 5, 24, 22, 25, 37, 579, DateTimeKind.Local).AddTicks(1903), new Guid("5010df47-17cc-484a-a7ad-7d6705af777c"), new Guid("76946e58-a7ff-405b-9d49-9f5b9624809e") });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Boards_ProjectId",
                table: "Boards",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardUserAssociations_AppUserId",
                table: "BoardUserAssociations",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_JobId",
                table: "Comments",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SenderId",
                table: "Comments",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Costs_ProjectId",
                table: "Costs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependencies_JobId",
                table: "Dependencies",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_StageId",
                table: "Jobs",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_JobUserAssociations_JobId",
                table: "JobUserAssociations",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUserAssociations_UserId",
                table: "ProjectUserAssociations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_BoardId",
                table: "Stages",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_SubJobs_JobId",
                table: "SubJobs",
                column: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BoardUserAssociations");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.DropTable(
                name: "Dependencies");

            migrationBuilder.DropTable(
                name: "JobUserAssociations");

            migrationBuilder.DropTable(
                name: "ProjectUserAssociations");

            migrationBuilder.DropTable(
                name: "SubJobs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
