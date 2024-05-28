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
                    { new Guid("173fdfd9-4d38-46b5-8e73-7f02edef60e0"), null, new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(3974), "admin", "ADMIN" },
                    { new Guid("5bd21a62-9db8-4169-b38c-80fe43d96dbd"), null, new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(3991), "user", "USER" },
                    { new Guid("66a40408-a63b-447b-991a-a9950bf9fa70"), null, new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(3988), "project-manager", "PROJECT-MANAGER" },
                    { new Guid("9adcfb94-9acc-4316-a9cf-7d75d8010bbe"), null, new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(3993), "project-user", "PROJECT-USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("25a41ca5-e030-4fc9-ac4b-d6da99822549"), 0, new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4246), "477c1774-57e3-4463-957d-c34dde51a72a", new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4247), "firatcanyanan@gmail.com", false, "Firat Can", 1, "Yanan", false, null, "FIRATCANYANAN@GMAIL.COM", "FIRATCANYANAN123", "AQAAAAIAAYagAAAAEKebLacRmiB+Yb13NTIaEI0iByu4wcCjPkOJ77A+xWLYgra/zR7dKmX/wqHPA1e7XQ==", null, false, "1fd3584c-5b69-4165-a3f9-e515ff831c77", false, "firatcanyanan123" },
                    { new Guid("2b53a09f-1be7-415e-aab7-987ae43856d1"), 0, new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4233), "f6e53660-1dbb-4af8-8b11-9180f42e2577", new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4233), "esrefyildiz@gmail.com", false, "Esref", 2, "Yildiz", false, null, "ESREFYILDIZ@GMAIL.COM", "ESREFYILDIZ123", "AQAAAAIAAYagAAAAEP/wNAK0kBosLNTltle5/PdV65j9S6rcI9lxp4/uhv69oJvU0dw1vtsJfpJkc22qzQ==", null, false, "33f7090f-2776-4f02-8df6-f0c35cd02171", false, "esrefyildiz123" },
                    { new Guid("499c61e6-d682-4cce-b944-d48f65173986"), 0, new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4260), "81798432-503e-4379-9b2e-26dbb97c731f", new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4261), "kemalcakir@gmail.com", false, "Kemal", 1, "Cakır", false, null, "KEMALCAKIR@GMAIL.COM", "KEMALCAKIR123", "AQAAAAIAAYagAAAAEDdwvskw4xAPU8tcjpOsRpluJAztbZter4JWxDTag9gg0hyvvvVxdhmY7hTUo0xrkQ==", null, false, "29086069-605a-4721-b29c-dd5a19132254", false, "kemalcakir123" },
                    { new Guid("4b5c9a93-758b-4c11-a513-8dbf9452e15d"), 0, new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4313), "0de3747c-8512-4f5d-a601-e7def1b559fb", new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4314), "gamzekayıs@gmail.com", false, "Gamze", 1, "Kayıs", false, null, "GAMZEKAYIS@GMAIL.COM", "gamzekayıs123", "AQAAAAIAAYagAAAAEFTg76VUk7vFTWgu1UtejZtEwaTjk+vB313cWPI/TjU7HChGRpMhft35P3kVlky1KQ==", null, false, "9bebaa58-091a-4695-b889-ce86ebb2fac2", false, "gamzekayıs123" },
                    { new Guid("5bcd11c8-148a-4b66-9db1-05c32758f010"), 0, new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4319), "90f062bd-c2d8-4767-bff2-ffe6bae91e21", new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4319), "rabiatopcu@gmail.com", false, "Rabia", 1, "Topcu", false, null, "RABIATOPCU@GMAIL.COM", "RABIATOPCU123", "AQAAAAIAAYagAAAAEBVU94ta3mxouL0P0kqRHE0ADMJ/eP4jjJcDYxY4NjSVIBF3d8rUYYm+Duv2kFmz0g==", null, false, "2f0bf642-5ce0-4e0f-a59b-3373d445b5f4", false, "rabiatopcu123" },
                    { new Guid("69bef816-11b2-4892-919e-4235aed64cbc"), 0, new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4210), "104d733e-c160-439d-ad3e-813e071f7c5c", new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4211), "admin@gmail.com", false, "Furkan", 1, "Aydin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEJAGEPaJGLsU4sOftADIhh+mfi87pXAKxZa1iwbFOzdQmb+e851xb1MGnac1+LqvaA==", null, false, "9236c8d2-16a4-406a-971e-6b707906e8e2", false, "admin" },
                    { new Guid("6a257783-dcb3-4b8f-b448-9a27f3a858f4"), 0, new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4240), "79e600f8-2235-49da-80b7-833efd66e48b", new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4241), "furkanaydin@gmail.com", false, "Furkan", 1, "Aydin", false, null, "FURKANAYDIN@GMAIL.COM", "FURKANAYDIN123", "AQAAAAIAAYagAAAAEIr4hy2x9AXAOqx20Cqh3bRb7uOLQK14dHnqqayukocgCncmmZZ3SAbAvsH8BZcVxg==", null, false, "cb927709-79b4-42ae-bbe4-95de09e3f445", false, "furkanaydin123" },
                    { new Guid("7fb4c8bb-a1e1-4727-9c17-e4b44d7b8ad6"), 0, new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4253), "9ae5a6a8-d846-4b44-bb58-bb685ee53e26", new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4254), "mustafaturker@gmail.com", false, "Mustafa", 1, "Turker", false, null, "MUSTAFATURKER@GMAIL.COM", "MUSTAFATURKER123", "AQAAAAIAAYagAAAAELYbeXE3f6R4Ms3nZaZ31KzoJlgCKxjEtQkGMvdTNLUxVQzO1GU4tzd5dJw7T32lzg==", null, false, "32098a40-1807-4c99-bc75-d04e182c8a03", false, "mustafaturke123" },
                    { new Guid("8d83caf4-dcbf-4ffd-8536-a209975825e5"), 0, new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4325), "0efaf050-24ea-40f6-aa11-f8239e488076", new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4325), "yasingok@gmail.com", false, "Yasin", 1, "Gok", false, null, "YASINGOK@GMAIL.COM", "YASINGOK123", "AQAAAAIAAYagAAAAEAWBqyP1/We/htlnwYz+ZYvo9/S0dnaJNvPzn1E5PA/qwMobujStywLoU7tIKeuE/Q==", null, false, "5ef09b30-0a1a-476c-8790-6a80b4a7da1a", false, "yasingok123" },
                    { new Guid("97dfcda5-ae9b-4ca7-aee8-07642efffa01"), 0, new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4226), "9ea19922-ad3f-4c64-b9a2-6a140d830f52", new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4227), "ayseyildiz@gmail.com", false, "Ayse", 2, "Yildiz", false, null, "AYSEYILDIZ@GMAIL.COM", "AYSEYILDIZ123", "AQAAAAIAAYagAAAAEOt3XkKkkln9qQ9mMOCO+K+aYG+qAz6m+WJGC+YeV1pW0LL9Z/BKABihh9e5GuQ5Uw==", null, false, "c98fd2d2-44ba-4a40-acfd-8ac2fa46f190", false, "ayseyildiz123" },
                    { new Guid("9f55c7c4-2adf-4ba0-b1c4-379f17cfe0a6"), 0, new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4307), "651dd8d0-0ba9-464e-ac30-0bc68d4f0ed1", new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4307), "melekcay@gmail.com", false, "Melek", 1, "Cay", false, null, "MELEKCAY@GMAIL.COM", "MELEKCAY123", "AQAAAAIAAYagAAAAEMeFuvWagyTV9ORdxZj95kZQjJOyOIq2tgVRIfG/sz3XTaRPsKO2fjKOh1fLAbMV1w==", null, false, "c9e47c8d-725a-4a95-80ae-50b00f2cfb1d", false, "melekcay123" },
                    { new Guid("a56a5c88-1174-4b89-b83c-d7c896f1835d"), 0, new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4220), "8c59282f-85b3-493e-8aa5-901638fb320f", new DateTime(2024, 5, 29, 2, 6, 37, 170, DateTimeKind.Local).AddTicks(4221), "aliyildiz@gmail.com", false, "Ali", 1, "Yildiz ", false, null, "ALIYILDIZ@GMAIL.COM", "ALIYILDIZ123", "AQAAAAIAAYagAAAAEOxZLQR04/wEHJfKDk/KxJM19IAXyQ3/cUDOVThRYXHtqR5w9XbTIUQAxlaRXg8JQQ==", null, false, "3c277ba0-2cff-45db-bf59-3bb545069154", false, "aliyildiz123" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedOn", "Description", "EndDate", "ProjectName", "StartDate" },
                values: new object[,]
                {
                    { new Guid("1ba48f40-759e-4ffc-b614-6b12a47fd5ad"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(5095), "Bu yazılım projesi, şirket içi süreçleri optimize etmeyi ve verimliliği artırmayı amaçlayan bir yönetim yazılımı geliştirmeyi içermektedir. Proje, çeşitli modüller aracılığıyla farklı departmanların ihtiyaçlarını karşılayacak ve entegre bir çözüm sunacaktır.", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılım Projesi", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4d1c5fa6-d146-4477-8f92-222847832991"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(5083), "Bu proje, kullanıcıların makaleler ve yazılar paylaşabileceği, okuyucuların yorum yapabileceği ve içeriklerin kategorize edilebileceği bir blog sitesi geliştirmeyi hedeflemektedir. Amacımız, kullanımı kolay bir arayüz ve zengin özellikler ile kullanıcıların etkili bir şekilde içerik oluşturmasını sağlamaktır.", new DateTime(2024, 6, 28, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(5074), "Blog Site Projesi", new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(5074) },
                    { new Guid("509393f7-39d9-479d-8f1a-d26a66b48862"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(5105), "Yeni bir ürünün tasarım sürecinin yürütülmesi", new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yeni Ürün Tasarımı", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("87ca58ff-019d-4feb-8eb5-3f44a43a2e83"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(5090), "Bu proje, şirketlerin stok yönetim süreçlerini izlemelerini ve kontrol etmelerini sağlayan bir stok takip sistemi geliştirmeyi amaçlamaktadır. Kullanıcılar, stok seviyelerini gerçek zamanlı olarak izleyebilir, sipariş yönetimini yapabilir ve stokla ilgili raporlar oluşturabilir.", new DateTime(2024, 7, 28, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(5089), "Stock takip Projesi", new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(5089) },
                    { new Guid("a7c4527e-f3db-47ea-a7df-ff64516b3383"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(5101), "Yeni bir ürünün pazarlama stratejisinin oluşturulması", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pazarlama Kampanyası", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("9adcfb94-9acc-4316-a9cf-7d75d8010bbe"), new Guid("25a41ca5-e030-4fc9-ac4b-d6da99822549") },
                    { new Guid("9adcfb94-9acc-4316-a9cf-7d75d8010bbe"), new Guid("2b53a09f-1be7-415e-aab7-987ae43856d1") },
                    { new Guid("9adcfb94-9acc-4316-a9cf-7d75d8010bbe"), new Guid("499c61e6-d682-4cce-b944-d48f65173986") },
                    { new Guid("9adcfb94-9acc-4316-a9cf-7d75d8010bbe"), new Guid("4b5c9a93-758b-4c11-a513-8dbf9452e15d") },
                    { new Guid("9adcfb94-9acc-4316-a9cf-7d75d8010bbe"), new Guid("5bcd11c8-148a-4b66-9db1-05c32758f010") },
                    { new Guid("173fdfd9-4d38-46b5-8e73-7f02edef60e0"), new Guid("69bef816-11b2-4892-919e-4235aed64cbc") },
                    { new Guid("9adcfb94-9acc-4316-a9cf-7d75d8010bbe"), new Guid("6a257783-dcb3-4b8f-b448-9a27f3a858f4") },
                    { new Guid("9adcfb94-9acc-4316-a9cf-7d75d8010bbe"), new Guid("7fb4c8bb-a1e1-4727-9c17-e4b44d7b8ad6") },
                    { new Guid("9adcfb94-9acc-4316-a9cf-7d75d8010bbe"), new Guid("8d83caf4-dcbf-4ffd-8536-a209975825e5") },
                    { new Guid("9adcfb94-9acc-4316-a9cf-7d75d8010bbe"), new Guid("97dfcda5-ae9b-4ca7-aee8-07642efffa01") },
                    { new Guid("9adcfb94-9acc-4316-a9cf-7d75d8010bbe"), new Guid("9f55c7c4-2adf-4ba0-b1c4-379f17cfe0a6") },
                    { new Guid("66a40408-a63b-447b-991a-a9950bf9fa70"), new Guid("a56a5c88-1174-4b89-b83c-d7c896f1835d") }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "CreatedOn", "ProjectId", "Title" },
                values: new object[,]
                {
                    { new Guid("13df68f7-aea1-4c4b-a5ee-e24fa2642c3a"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(8888), new Guid("1ba48f40-759e-4ffc-b614-6b12a47fd5ad"), "Geliştirme" },
                    { new Guid("b4344ba4-7ed5-4623-bdfb-0184cc9779de"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(8880), new Guid("87ca58ff-019d-4feb-8eb5-3f44a43a2e83"), "Front-end board" },
                    { new Guid("bdad9520-d6c1-4589-9361-6ef8eb102f28"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(8887), new Guid("1ba48f40-759e-4ffc-b614-6b12a47fd5ad"), "Analiz" },
                    { new Guid("fdff8baa-fdfb-496d-a3ca-a9306f9176b2"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(8885), new Guid("87ca58ff-019d-4feb-8eb5-3f44a43a2e83"), "Back-end board" }
                });

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "CreatedOn", "Date", "Description", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("01148b0d-8d98-43d2-a922-ba53e44ee855"), 200.00m, new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9286), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9286), "Sample cost", new Guid("87ca58ff-019d-4feb-8eb5-3f44a43a2e83") },
                    { new Guid("980a86dc-2bde-44a2-a0bd-85caa697a1de"), 500.00m, new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9266), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9265), "Sample cost", new Guid("4d1c5fa6-d146-4477-8f92-222847832991") }
                });

            migrationBuilder.InsertData(
                table: "ProjectUserAssociations",
                columns: new[] { "ProjectId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1ba48f40-759e-4ffc-b614-6b12a47fd5ad"), new Guid("25a41ca5-e030-4fc9-ac4b-d6da99822549") },
                    { new Guid("1ba48f40-759e-4ffc-b614-6b12a47fd5ad"), new Guid("2b53a09f-1be7-415e-aab7-987ae43856d1") },
                    { new Guid("1ba48f40-759e-4ffc-b614-6b12a47fd5ad"), new Guid("499c61e6-d682-4cce-b944-d48f65173986") },
                    { new Guid("1ba48f40-759e-4ffc-b614-6b12a47fd5ad"), new Guid("4b5c9a93-758b-4c11-a513-8dbf9452e15d") },
                    { new Guid("1ba48f40-759e-4ffc-b614-6b12a47fd5ad"), new Guid("5bcd11c8-148a-4b66-9db1-05c32758f010") },
                    { new Guid("1ba48f40-759e-4ffc-b614-6b12a47fd5ad"), new Guid("6a257783-dcb3-4b8f-b448-9a27f3a858f4") },
                    { new Guid("1ba48f40-759e-4ffc-b614-6b12a47fd5ad"), new Guid("7fb4c8bb-a1e1-4727-9c17-e4b44d7b8ad6") },
                    { new Guid("1ba48f40-759e-4ffc-b614-6b12a47fd5ad"), new Guid("8d83caf4-dcbf-4ffd-8536-a209975825e5") },
                    { new Guid("1ba48f40-759e-4ffc-b614-6b12a47fd5ad"), new Guid("9f55c7c4-2adf-4ba0-b1c4-379f17cfe0a6") },
                    { new Guid("1ba48f40-759e-4ffc-b614-6b12a47fd5ad"), new Guid("a56a5c88-1174-4b89-b83c-d7c896f1835d") },
                    { new Guid("4d1c5fa6-d146-4477-8f92-222847832991"), new Guid("a56a5c88-1174-4b89-b83c-d7c896f1835d") },
                    { new Guid("87ca58ff-019d-4feb-8eb5-3f44a43a2e83"), new Guid("25a41ca5-e030-4fc9-ac4b-d6da99822549") },
                    { new Guid("87ca58ff-019d-4feb-8eb5-3f44a43a2e83"), new Guid("2b53a09f-1be7-415e-aab7-987ae43856d1") },
                    { new Guid("87ca58ff-019d-4feb-8eb5-3f44a43a2e83"), new Guid("6a257783-dcb3-4b8f-b448-9a27f3a858f4") },
                    { new Guid("87ca58ff-019d-4feb-8eb5-3f44a43a2e83"), new Guid("97dfcda5-ae9b-4ca7-aee8-07642efffa01") },
                    { new Guid("87ca58ff-019d-4feb-8eb5-3f44a43a2e83"), new Guid("a56a5c88-1174-4b89-b83c-d7c896f1835d") }
                });

            migrationBuilder.InsertData(
                table: "BoardUserAssociations",
                columns: new[] { "AppUserId", "BoardId" },
                values: new object[,]
                {
                    { new Guid("25a41ca5-e030-4fc9-ac4b-d6da99822549"), new Guid("13df68f7-aea1-4c4b-a5ee-e24fa2642c3a") },
                    { new Guid("2b53a09f-1be7-415e-aab7-987ae43856d1"), new Guid("13df68f7-aea1-4c4b-a5ee-e24fa2642c3a") },
                    { new Guid("499c61e6-d682-4cce-b944-d48f65173986"), new Guid("13df68f7-aea1-4c4b-a5ee-e24fa2642c3a") },
                    { new Guid("4b5c9a93-758b-4c11-a513-8dbf9452e15d"), new Guid("13df68f7-aea1-4c4b-a5ee-e24fa2642c3a") },
                    { new Guid("5bcd11c8-148a-4b66-9db1-05c32758f010"), new Guid("13df68f7-aea1-4c4b-a5ee-e24fa2642c3a") },
                    { new Guid("6a257783-dcb3-4b8f-b448-9a27f3a858f4"), new Guid("13df68f7-aea1-4c4b-a5ee-e24fa2642c3a") },
                    { new Guid("7fb4c8bb-a1e1-4727-9c17-e4b44d7b8ad6"), new Guid("13df68f7-aea1-4c4b-a5ee-e24fa2642c3a") },
                    { new Guid("8d83caf4-dcbf-4ffd-8536-a209975825e5"), new Guid("13df68f7-aea1-4c4b-a5ee-e24fa2642c3a") },
                    { new Guid("9f55c7c4-2adf-4ba0-b1c4-379f17cfe0a6"), new Guid("13df68f7-aea1-4c4b-a5ee-e24fa2642c3a") },
                    { new Guid("25a41ca5-e030-4fc9-ac4b-d6da99822549"), new Guid("b4344ba4-7ed5-4623-bdfb-0184cc9779de") },
                    { new Guid("2b53a09f-1be7-415e-aab7-987ae43856d1"), new Guid("b4344ba4-7ed5-4623-bdfb-0184cc9779de") },
                    { new Guid("6a257783-dcb3-4b8f-b448-9a27f3a858f4"), new Guid("b4344ba4-7ed5-4623-bdfb-0184cc9779de") }
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "StageName" },
                values: new object[,]
                {
                    { new Guid("2da52147-e769-4f95-a8b5-9f8dd828c33e"), new Guid("13df68f7-aea1-4c4b-a5ee-e24fa2642c3a"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(8944), "Geliştirme aşaması için analiz aşaması", "Analiz" },
                    { new Guid("a9b2b5d5-2e3d-40af-8051-eb6a9547ba4e"), new Guid("b4344ba4-7ed5-4623-bdfb-0184cc9779de"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(8939), "Design stage for the blog site project", "Home Page" },
                    { new Guid("c1a7f251-d822-4ad3-860b-c1ad50a5fc87"), new Guid("13df68f7-aea1-4c4b-a5ee-e24fa2642c3a"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(8946), "Geliştirme aşaması için tasarım aşaması", "Tasarım" },
                    { new Guid("c2c64f55-94f5-4c3e-bd77-68388153ccaf"), new Guid("13df68f7-aea1-4c4b-a5ee-e24fa2642c3a"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(8951), "Geliştirme aşaması için kodlama aşaması", "Kodlama" },
                    { new Guid("cf09bcfb-fb59-4da8-9a89-49b171136f57"), new Guid("b4344ba4-7ed5-4623-bdfb-0184cc9779de"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(8942), "Planning stage for the stock tracking project", "Supplier Page" },
                    { new Guid("f0a4dff8-16d6-4ec0-8241-efe4a1a4ca8f"), new Guid("13df68f7-aea1-4c4b-a5ee-e24fa2642c3a"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(8958), "Geliştirme aşaması için test aşaması", "Test" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CreatedOn", "Description", "DueDate", "Priority", "StageId", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("441649c9-6ac9-45fd-9eac-a2a93ef97b72"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın işlevsel gereksinimlerinin ayrıntılı bir şekilde belirlenmesi", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("2da52147-e769-4f95-a8b5-9f8dd828c33e"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fonksiyonel gereksinimlerin belirlenmesi" },
                    { new Guid("56d61723-173d-415e-b802-cb5d920315d9"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9179), "Kullanılacak renklerin ve renk paletinin belirlenmesi", new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c1a7f251-d822-4ad3-860b-c1ad50a5fc87"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arayüz tasarımı için renk paletinin belirlenmesi" },
                    { new Guid("5d743882-3468-4354-a029-926ddcb26035"), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın farklı bileşenlerinin bir araya getirilerek sistem entegrasyon testlerinin yapılması", new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("f0a4dff8-16d6-4ec0-8241-efe4a1a4ca8f"), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sistem entegrasyon testlerinin yapılması" },
                    { new Guid("68028e81-c3ad-4713-bc29-6f64d97eb8b1"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9176), "Yazılımın kullanıcı arayüzü tasarımının ilk mockup'ları oluşturulması", new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("c1a7f251-d822-4ad3-860b-c1ad50a5fc87"), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kullanıcı arayüzünün mockup'larının hazırlanması" },
                    { new Guid("6bf510e5-01cb-453e-a15a-3788bdc2bf7d"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9172), "Yapılan analiz çalışmalarının sonuçlarının detaylı bir şekilde dokümante edilmesi", new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("2da52147-e769-4f95-a8b5-9f8dd828c33e"), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analiz sonuçlarının dokümantasyonu" },
                    { new Guid("7a0842ff-f78a-41ab-aff6-e835e66e41a5"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9189), "Kullanıcı arayüzünde kullanılacak animasyonların hazırlanması ve uygulanması", new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c1a7f251-d822-4ad3-860b-c1ad50a5fc87"), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arayüz animasyonlarının hazırlanması" },
                    { new Guid("7a6f159a-7e20-4414-b361-684d6dbc750f"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9182), "Kullanıcı arayüzünün kullanılabilirliğinin test edilmesi ve geri bildirimlerin alınması", new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c1a7f251-d822-4ad3-860b-c1ad50a5fc87"), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arayüzün kullanılabilirlik testlerinin yapılması" },
                    { new Guid("85f2d20e-5f35-47a2-b5a7-5333756646b5"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9040), "Analyze requirements for the stock tracking project", new DateTime(2024, 6, 12, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9040), 1, new Guid("a9b2b5d5-2e3d-40af-8051-eb6a9547ba4e"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9039), "Requirement Analysis" },
                    { new Guid("9cdcc22a-8723-4176-b018-4354aeca0676"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9169), "Müşteri gereksinimlerinin toplanması ve analiz edilmesi", new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("2da52147-e769-4f95-a8b5-9f8dd828c33e"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Müşteri ihtiyaçlarının belirlenmesi" },
                    { new Guid("9dc7493c-36ce-4cd9-8dfc-0666dd1669d6"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın arka uç (backend) API'larının geliştirilmesi ve test edilmesi", new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c2c64f55-94f5-4c3e-bd77-68388153ccaf"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Backend API geliştirme" },
                    { new Guid("a80af05f-b4b7-41a4-8d02-71e3429e21ac"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın prototipinin tasarlanması ve kullanıcı geri bildirimlerinin alınması", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c1a7f251-d822-4ad3-860b-c1ad50a5fc87"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prototip tasarımı" },
                    { new Guid("ba979def-bbe6-4c7e-9f7b-3f8bfdcb1b4d"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9044), "Depend job", new DateTime(2024, 6, 12, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9044), 2, new Guid("a9b2b5d5-2e3d-40af-8051-eb6a9547ba4e"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9043), "Depend job" },
                    { new Guid("bf109e8f-0ca0-4a1d-bc0f-6fa410c2d79d"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kullanıcı arayüzünün revize edilmesi ve geliştirilmiş bir versiyonunun hazırlanması", new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c1a7f251-d822-4ad3-860b-c1ad50a5fc87"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arayüz tasarım revizyonu" },
                    { new Guid("c559ec7d-042e-4c46-9e59-36217d0b4877"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9166), "Mevcut sistem ve iş süreçlerinin detaylı bir şekilde incelenmesi", new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("2da52147-e769-4f95-a8b5-9f8dd828c33e"), new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mevcut sistem analizi" },
                    { new Guid("ce5eb9bd-ddfb-47a6-a2b1-f0adf813b654"), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kullanıcı arayüzünün ön uç (frontend) bileşenlerinin geliştirilmesi ve entegrasyon testlerinin yapılması", new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("c2c64f55-94f5-4c3e-bd77-68388153ccaf"), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frontend komponent geliştirme" },
                    { new Guid("e401433a-f24a-4f9a-9c29-ee1cd7ddcea0"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9185), "Tasarım aşamasında alınan geri bildirimler doğrultusunda gerekli revizyonların yapılması", new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("c1a7f251-d822-4ad3-860b-c1ad50a5fc87"), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tasarım revizyonu" },
                    { new Guid("e9fcd3ea-06da-4eaf-877b-d317c7bc6279"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Müşteri ile bir araya gelerek yazılım gereksinimlerinin detaylı bir şekilde incelenmesi", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("2da52147-e769-4f95-a8b5-9f8dd828c33e"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Müşteri toplantısı ve gereksinimlerin belirlenmesi" },
                    { new Guid("f646d7a8-8498-4c0f-922b-3709659dd76c"), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın test edilmesi için birinci aşama test senaryolarının hazırlanması", new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("f0a4dff8-16d6-4ec0-8241-efe4a1a4ca8f"), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Birinci aşama test senaryolarının hazırlanması" },
                    { new Guid("fd099300-2326-4f43-a766-232f1f7e707d"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9035), "Design user interface for the blog site", new DateTime(2024, 6, 5, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9030), 0, new Guid("cf09bcfb-fb59-4da8-9a89-49b171136f57"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9030), "Design UI" }
                });

            migrationBuilder.InsertData(
                table: "Dependencies",
                columns: new[] { "Id", "CreatedOn", "DependsOnJobId", "JobId" },
                values: new object[] { new Guid("540c39a2-1431-43b3-96d7-e1cecef1fca2"), new DateTime(2024, 5, 29, 2, 6, 38, 145, DateTimeKind.Local).AddTicks(9239), new Guid("85f2d20e-5f35-47a2-b5a7-5333756646b5"), new Guid("ba979def-bbe6-4c7e-9f7b-3f8bfdcb1b4d") });

            migrationBuilder.InsertData(
                table: "JobUserAssociations",
                columns: new[] { "JobId", "UserId" },
                values: new object[,]
                {
                    { new Guid("ce5eb9bd-ddfb-47a6-a2b1-f0adf813b654"), new Guid("25a41ca5-e030-4fc9-ac4b-d6da99822549") },
                    { new Guid("f646d7a8-8498-4c0f-922b-3709659dd76c"), new Guid("25a41ca5-e030-4fc9-ac4b-d6da99822549") },
                    { new Guid("56d61723-173d-415e-b802-cb5d920315d9"), new Guid("2b53a09f-1be7-415e-aab7-987ae43856d1") },
                    { new Guid("9dc7493c-36ce-4cd9-8dfc-0666dd1669d6"), new Guid("2b53a09f-1be7-415e-aab7-987ae43856d1") },
                    { new Guid("bf109e8f-0ca0-4a1d-bc0f-6fa410c2d79d"), new Guid("2b53a09f-1be7-415e-aab7-987ae43856d1") },
                    { new Guid("56d61723-173d-415e-b802-cb5d920315d9"), new Guid("499c61e6-d682-4cce-b944-d48f65173986") },
                    { new Guid("68028e81-c3ad-4713-bc29-6f64d97eb8b1"), new Guid("499c61e6-d682-4cce-b944-d48f65173986") },
                    { new Guid("9dc7493c-36ce-4cd9-8dfc-0666dd1669d6"), new Guid("499c61e6-d682-4cce-b944-d48f65173986") },
                    { new Guid("ce5eb9bd-ddfb-47a6-a2b1-f0adf813b654"), new Guid("499c61e6-d682-4cce-b944-d48f65173986") },
                    { new Guid("a80af05f-b4b7-41a4-8d02-71e3429e21ac"), new Guid("4b5c9a93-758b-4c11-a513-8dbf9452e15d") },
                    { new Guid("e9fcd3ea-06da-4eaf-877b-d317c7bc6279"), new Guid("4b5c9a93-758b-4c11-a513-8dbf9452e15d") },
                    { new Guid("6bf510e5-01cb-453e-a15a-3788bdc2bf7d"), new Guid("5bcd11c8-148a-4b66-9db1-05c32758f010") },
                    { new Guid("7a0842ff-f78a-41ab-aff6-e835e66e41a5"), new Guid("5bcd11c8-148a-4b66-9db1-05c32758f010") },
                    { new Guid("7a6f159a-7e20-4414-b361-684d6dbc750f"), new Guid("5bcd11c8-148a-4b66-9db1-05c32758f010") },
                    { new Guid("a80af05f-b4b7-41a4-8d02-71e3429e21ac"), new Guid("5bcd11c8-148a-4b66-9db1-05c32758f010") },
                    { new Guid("e401433a-f24a-4f9a-9c29-ee1cd7ddcea0"), new Guid("5bcd11c8-148a-4b66-9db1-05c32758f010") },
                    { new Guid("e9fcd3ea-06da-4eaf-877b-d317c7bc6279"), new Guid("5bcd11c8-148a-4b66-9db1-05c32758f010") },
                    { new Guid("68028e81-c3ad-4713-bc29-6f64d97eb8b1"), new Guid("6a257783-dcb3-4b8f-b448-9a27f3a858f4") },
                    { new Guid("9dc7493c-36ce-4cd9-8dfc-0666dd1669d6"), new Guid("6a257783-dcb3-4b8f-b448-9a27f3a858f4") },
                    { new Guid("c559ec7d-042e-4c46-9e59-36217d0b4877"), new Guid("6a257783-dcb3-4b8f-b448-9a27f3a858f4") },
                    { new Guid("5d743882-3468-4354-a029-926ddcb26035"), new Guid("7fb4c8bb-a1e1-4727-9c17-e4b44d7b8ad6") },
                    { new Guid("68028e81-c3ad-4713-bc29-6f64d97eb8b1"), new Guid("7fb4c8bb-a1e1-4727-9c17-e4b44d7b8ad6") },
                    { new Guid("c559ec7d-042e-4c46-9e59-36217d0b4877"), new Guid("7fb4c8bb-a1e1-4727-9c17-e4b44d7b8ad6") },
                    { new Guid("f646d7a8-8498-4c0f-922b-3709659dd76c"), new Guid("7fb4c8bb-a1e1-4727-9c17-e4b44d7b8ad6") },
                    { new Guid("9cdcc22a-8723-4176-b018-4354aeca0676"), new Guid("8d83caf4-dcbf-4ffd-8536-a209975825e5") },
                    { new Guid("a80af05f-b4b7-41a4-8d02-71e3429e21ac"), new Guid("8d83caf4-dcbf-4ffd-8536-a209975825e5") },
                    { new Guid("bf109e8f-0ca0-4a1d-bc0f-6fa410c2d79d"), new Guid("8d83caf4-dcbf-4ffd-8536-a209975825e5") },
                    { new Guid("441649c9-6ac9-45fd-9eac-a2a93ef97b72"), new Guid("9f55c7c4-2adf-4ba0-b1c4-379f17cfe0a6") },
                    { new Guid("ce5eb9bd-ddfb-47a6-a2b1-f0adf813b654"), new Guid("9f55c7c4-2adf-4ba0-b1c4-379f17cfe0a6") }
                });

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
