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
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
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
                    { new Guid("27b0ae4f-f5df-495d-9fb0-3ca59e1ea3ae"), null, new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9240), "user", "USER" },
                    { new Guid("7415fe13-f632-4281-acb0-443ac83b42b8"), null, new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9237), "project-manager", "PROJECT-MANAGER" },
                    { new Guid("86702504-a0c9-4c8f-af36-b6b4d454431a"), null, new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9223), "admin", "ADMIN" },
                    { new Guid("dc231def-8ac8-4f3f-a393-1bb4dacc83f7"), null, new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9242), "project-user", "PROJECT-USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("006a6ef0-4418-409c-bb83-a1cb1c988e34"), 0, new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9648), "537d9887-d418-4561-8efe-33578d27098e", new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9649), "yasingok@gmail.com", false, "Yasin", 1, "Gok", false, null, "YASINGOK@GMAIL.COM", "YASINGOK123", "AQAAAAIAAYagAAAAEBYOl8YIyZP7fN1XfKZ1ZJZZiZ7k7UzRv7EXs7Oz1qxrZwYJ/aDSabL7zCoGiQr/iA==", null, false, "b26bbd19-1bd1-45b7-8f5f-a0e7d2cf64c9", false, "yasingok123" },
                    { new Guid("02d2db96-4cb1-4a33-94af-cc562185939b"), 0, new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9623), "a2a3057f-adef-4c6e-b115-3bffd4114d3a", new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9624), "kemalcakir@gmail.com", false, "Kemal", 1, "Cakır", false, null, "KEMALCAKIR@GMAIL.COM", "KEMALCAKIR123", "AQAAAAIAAYagAAAAEAT2wYSXx6Xsp3QTFkLij8wZXM3VNh8XcRaeFKFQOE3j+XVGFvU98v8K/A3985a8Eg==", null, false, "4dba19f1-d78d-472a-993b-abd3f12b827d", false, "kemalcakir123" },
                    { new Guid("11cd88fe-4611-4cc2-beff-39359a285452"), 0, new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9532), "b5203343-92c9-46e6-a798-1a36af45a14b", new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9533), "aliyildiz@gmail.com", false, "Ali", 1, "Yildiz ", false, null, "ALIYILDIZ@GMAIL.COM", "ALIYILDIZ123", "AQAAAAIAAYagAAAAEInqPWPiH8uGZgl534VUezJUIKxUgg0r0v4ERhkKCRMTpoQAEKNSsVEhbnUoKyGsZA==", null, false, "889a16bf-659b-45c2-bd46-e68e6a10c1c8", false, "aliyildiz123" },
                    { new Guid("296e9a76-205b-4524-b666-be15a962b3f5"), 0, new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9629), "7d7708e4-d923-488b-8099-670dd94e344f", new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9630), "melekcay@gmail.com", false, "Melek", 1, "Cay", false, null, "MELEKCAY@GMAIL.COM", "MELEKCAY123", "AQAAAAIAAYagAAAAELFyUryL+B6FmUXMkOUPy8yG7YNbFn5mYqy+IewJUmE9DP6UHfhz2zdIMpC6AWZb6Q==", null, false, "50364ca9-667b-4a59-a32f-727c1e672d35", false, "melekcay123" },
                    { new Guid("3f597454-e804-4848-8ad7-735a512277f3"), 0, new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9609), "a74771a8-184d-4454-97bc-67854610fd7a", new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9610), "firatcanyanan@gmail.com", false, "Firat Can", 1, "Yanan", false, null, "FIRATCANYANAN@GMAIL.COM", "FIRATCANYANAN123", "AQAAAAIAAYagAAAAEEOd9WKya7cBPWLnmD5fM9hrJpANVSaRcmjO2N860HRl38ZwjeNB7Gb0qbg/Pl8UOQ==", null, false, "78ddce78-18f8-4803-ba70-4aa2c0e31272", false, "firatcanyanan123" },
                    { new Guid("96b2053d-3bf2-49c7-9071-6459da82bc26"), 0, new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9596), "929181bc-441b-4fb1-b828-a641c0e6ccc1", new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9597), "esrefyildiz@gmail.com", false, "Esref", 2, "Yildiz", false, null, "ESREFYILDIZ@GMAIL.COM", "ESREFYILDIZ123", "AQAAAAIAAYagAAAAEBCLEdeQCRRkQiqiR1H5zAfgFAf2zQaLz6F9E6CPTz0OpzSrOO9tDQOfDHrn/F/yoA==", null, false, "19058209-a6be-411d-ac4d-e10d5a2a3cd3", false, "esrefyildiz123" },
                    { new Guid("aed10caa-879b-4bbd-b578-9a987f4d34de"), 0, new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9643), "55782f53-8170-4318-85d2-7e49c100597f", new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9643), "rabiatopcu@gmail.com", false, "Rabia", 1, "Topcu", false, null, "RABIATOPCU@GMAIL.COM", "RABIATOPCU123", "AQAAAAIAAYagAAAAEHsEN5si5Wipt4PcmZvioC+NqydeXLGGdds+WYvnPmFQ1ocSt0VDCTwInWYfgy6GQA==", null, false, "351b3a8c-3ff6-4218-9166-fb0749da1654", false, "rabiatopcu123" },
                    { new Guid("b3e1c8fc-e664-491e-a189-8f0c8dc4b592"), 0, new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9635), "3191bda4-1419-40c5-be38-bc3d762b0cf7", new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9635), "gamzekayıs@gmail.com", false, "Gamze", 1, "Kayıs", false, null, "GAMZEKAYIS@GMAIL.COM", "gamzekayıs123", "AQAAAAIAAYagAAAAEDFwiZjfQV3eTjw2PVZiSPBNuaHgnbSBtKyoX6Dwn96j/BqwzCgoXNhFFOGT2XaNHQ==", null, false, "0a1870d6-c432-4138-ad10-96f5a36cb008", false, "gamzekayıs123" },
                    { new Guid("caae504f-65d9-4ccd-b6b6-8fc94c4fdfc0"), 0, new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9522), "39f3bb1a-c1ab-4480-b953-96ec54770526", new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9523), "admin@gmail.com", false, "Furkan", 1, "Aydin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEOZedzCkG7TMmkITM7BsdGFX261e4Y2ZKAXiBP5LmqRAGUiuHKqDwouGgZOx/UbwzQ==", null, false, "f557e9e9-ed33-49b0-8c87-30b8676a2bb5", false, "admin" },
                    { new Guid("d5a557f8-9f37-4792-bfc9-a36e520e376b"), 0, new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9617), "a3d0b5a4-9b8e-4815-af9b-71df9ee50597", new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9618), "mustafaturker@gmail.com", false, "Mustafa", 1, "Turker", false, null, "MUSTAFATURKER@GMAIL.COM", "MUSTAFATURKER123", "AQAAAAIAAYagAAAAEOl6NzvnucfyrUXnMbSVS5JgI+ODucCLcjVaLkyDJvLM8ML+SjIgxwBuxFroHSR2EQ==", null, false, "d10d1d99-11dd-41c9-b953-d6a74c7ce01c", false, "mustafaturke123" },
                    { new Guid("df9831f9-1b48-4ff7-9d4f-e091832e0f48"), 0, new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9541), "41c88942-66df-447d-a55b-d19274c17cb4", new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9542), "ayseyildiz@gmail.com", false, "Ayse", 2, "Yildiz", false, null, "AYSEYILDIZ@GMAIL.COM", "AYSEYILDIZ123", "AQAAAAIAAYagAAAAEPeWk9spaoRCB2v9L8d8W1GWixKzkRe8L19RzxXHYkceu3n46jo7fqaJ89rWy3ui2g==", null, false, "504eb00f-d6d8-492a-8bb1-879f08d4afb8", false, "ayseyildiz123" },
                    { new Guid("f06ff109-804e-4fcd-b796-d942270a726e"), 0, new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9603), "56a40cb2-a98a-416d-933d-3f10ba551b57", new DateTime(2024, 5, 29, 2, 39, 29, 57, DateTimeKind.Local).AddTicks(9604), "furkanaydin@gmail.com", false, "Furkan", 1, "Aydin", false, null, "FURKANAYDIN@GMAIL.COM", "FURKANAYDIN123", "AQAAAAIAAYagAAAAEI7oiPX3lGdU7dS5KQDc1eJn33TvgDzHFJY4KuAAYXR6zmR74xolo6gMSnYjbto8Pw==", null, false, "520e4234-c934-49ee-b541-51819673c3de", false, "furkanaydin123" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedOn", "Description", "EndDate", "ProjectName", "StartDate" },
                values: new object[,]
                {
                    { new Guid("2d706327-c0b6-44de-8b96-3c21c2be7fa3"), new DateTime(2024, 5, 29, 2, 39, 29, 894, DateTimeKind.Local).AddTicks(9568), "Yeni bir ürünün pazarlama stratejisinin oluşturulması", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pazarlama Kampanyası", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4530f8b5-fdac-48f2-96ed-634321b5c390"), new DateTime(2024, 5, 29, 2, 39, 29, 894, DateTimeKind.Local).AddTicks(9554), "Bu proje, kullanıcıların makaleler ve yazılar paylaşabileceği, okuyucuların yorum yapabileceği ve içeriklerin kategorize edilebileceği bir blog sitesi geliştirmeyi hedeflemektedir. Amacımız, kullanımı kolay bir arayüz ve zengin özellikler ile kullanıcıların etkili bir şekilde içerik oluşturmasını sağlamaktır.", new DateTime(2024, 6, 28, 2, 39, 29, 894, DateTimeKind.Local).AddTicks(9547), "Blog Site Projesi", new DateTime(2024, 5, 29, 2, 39, 29, 894, DateTimeKind.Local).AddTicks(9546) },
                    { new Guid("58c40920-ea65-43d5-b97a-9a4058f47721"), new DateTime(2024, 5, 29, 2, 39, 29, 894, DateTimeKind.Local).AddTicks(9558), "Bu proje, şirketlerin stok yönetim süreçlerini izlemelerini ve kontrol etmelerini sağlayan bir stok takip sistemi geliştirmeyi amaçlamaktadır. Kullanıcılar, stok seviyelerini gerçek zamanlı olarak izleyebilir, sipariş yönetimini yapabilir ve stokla ilgili raporlar oluşturabilir.", new DateTime(2024, 7, 28, 2, 39, 29, 894, DateTimeKind.Local).AddTicks(9558), "Stock takip Projesi", new DateTime(2024, 5, 29, 2, 39, 29, 894, DateTimeKind.Local).AddTicks(9557) },
                    { new Guid("6da16c63-9a78-4ac8-9951-ae5e670c8c7b"), new DateTime(2024, 5, 29, 2, 39, 29, 894, DateTimeKind.Local).AddTicks(9563), "Bu yazılım projesi, şirket içi süreçleri optimize etmeyi ve verimliliği artırmayı amaçlayan bir yönetim yazılımı geliştirmeyi içermektedir. Proje, çeşitli modüller aracılığıyla farklı departmanların ihtiyaçlarını karşılayacak ve entegre bir çözüm sunacaktır.", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılım Projesi", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7c591e9b-81f4-4593-9919-6b68c36f1fc3"), new DateTime(2024, 5, 29, 2, 39, 29, 894, DateTimeKind.Local).AddTicks(9571), "Yeni bir ürünün tasarım sürecinin yürütülmesi", new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yeni Ürün Tasarımı", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("dc231def-8ac8-4f3f-a393-1bb4dacc83f7"), new Guid("006a6ef0-4418-409c-bb83-a1cb1c988e34") },
                    { new Guid("dc231def-8ac8-4f3f-a393-1bb4dacc83f7"), new Guid("02d2db96-4cb1-4a33-94af-cc562185939b") },
                    { new Guid("7415fe13-f632-4281-acb0-443ac83b42b8"), new Guid("11cd88fe-4611-4cc2-beff-39359a285452") },
                    { new Guid("dc231def-8ac8-4f3f-a393-1bb4dacc83f7"), new Guid("296e9a76-205b-4524-b666-be15a962b3f5") },
                    { new Guid("dc231def-8ac8-4f3f-a393-1bb4dacc83f7"), new Guid("3f597454-e804-4848-8ad7-735a512277f3") },
                    { new Guid("dc231def-8ac8-4f3f-a393-1bb4dacc83f7"), new Guid("96b2053d-3bf2-49c7-9071-6459da82bc26") },
                    { new Guid("dc231def-8ac8-4f3f-a393-1bb4dacc83f7"), new Guid("aed10caa-879b-4bbd-b578-9a987f4d34de") },
                    { new Guid("dc231def-8ac8-4f3f-a393-1bb4dacc83f7"), new Guid("b3e1c8fc-e664-491e-a189-8f0c8dc4b592") },
                    { new Guid("86702504-a0c9-4c8f-af36-b6b4d454431a"), new Guid("caae504f-65d9-4ccd-b6b6-8fc94c4fdfc0") },
                    { new Guid("dc231def-8ac8-4f3f-a393-1bb4dacc83f7"), new Guid("d5a557f8-9f37-4792-bfc9-a36e520e376b") },
                    { new Guid("dc231def-8ac8-4f3f-a393-1bb4dacc83f7"), new Guid("df9831f9-1b48-4ff7-9d4f-e091832e0f48") },
                    { new Guid("dc231def-8ac8-4f3f-a393-1bb4dacc83f7"), new Guid("f06ff109-804e-4fcd-b796-d942270a726e") }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "CreatedOn", "ProjectId", "Title" },
                values: new object[,]
                {
                    { new Guid("3d685ea6-5b9a-40f3-8069-d7e34bfd074a"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3297), new Guid("58c40920-ea65-43d5-b97a-9a4058f47721"), "Front-end board" },
                    { new Guid("941575cd-f7ea-4804-9822-c21686dbb9c6"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3301), new Guid("58c40920-ea65-43d5-b97a-9a4058f47721"), "Back-end board" },
                    { new Guid("a4ec6ab7-58d0-4f50-87ae-e697cf39b332"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3305), new Guid("6da16c63-9a78-4ac8-9951-ae5e670c8c7b"), "Geliştirme" },
                    { new Guid("a6e7f3a5-3f33-4fdb-81da-2551edc602a3"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3303), new Guid("6da16c63-9a78-4ac8-9951-ae5e670c8c7b"), "Analiz" }
                });

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "CreatedOn", "Date", "Description", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("b4720fc6-60a3-4658-be76-b128f15d40fa"), 500.00m, new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3647), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3646), "Sample cost", new Guid("4530f8b5-fdac-48f2-96ed-634321b5c390") },
                    { new Guid("f8bf4243-3bd3-4d7a-a548-cf63c1a99f60"), 200.00m, new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3666), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3665), "Sample cost", new Guid("58c40920-ea65-43d5-b97a-9a4058f47721") }
                });

            migrationBuilder.InsertData(
                table: "ProjectUserAssociations",
                columns: new[] { "ProjectId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4530f8b5-fdac-48f2-96ed-634321b5c390"), new Guid("11cd88fe-4611-4cc2-beff-39359a285452") },
                    { new Guid("58c40920-ea65-43d5-b97a-9a4058f47721"), new Guid("11cd88fe-4611-4cc2-beff-39359a285452") },
                    { new Guid("58c40920-ea65-43d5-b97a-9a4058f47721"), new Guid("3f597454-e804-4848-8ad7-735a512277f3") },
                    { new Guid("58c40920-ea65-43d5-b97a-9a4058f47721"), new Guid("96b2053d-3bf2-49c7-9071-6459da82bc26") },
                    { new Guid("58c40920-ea65-43d5-b97a-9a4058f47721"), new Guid("df9831f9-1b48-4ff7-9d4f-e091832e0f48") },
                    { new Guid("58c40920-ea65-43d5-b97a-9a4058f47721"), new Guid("f06ff109-804e-4fcd-b796-d942270a726e") },
                    { new Guid("6da16c63-9a78-4ac8-9951-ae5e670c8c7b"), new Guid("006a6ef0-4418-409c-bb83-a1cb1c988e34") },
                    { new Guid("6da16c63-9a78-4ac8-9951-ae5e670c8c7b"), new Guid("02d2db96-4cb1-4a33-94af-cc562185939b") },
                    { new Guid("6da16c63-9a78-4ac8-9951-ae5e670c8c7b"), new Guid("11cd88fe-4611-4cc2-beff-39359a285452") },
                    { new Guid("6da16c63-9a78-4ac8-9951-ae5e670c8c7b"), new Guid("296e9a76-205b-4524-b666-be15a962b3f5") },
                    { new Guid("6da16c63-9a78-4ac8-9951-ae5e670c8c7b"), new Guid("3f597454-e804-4848-8ad7-735a512277f3") },
                    { new Guid("6da16c63-9a78-4ac8-9951-ae5e670c8c7b"), new Guid("96b2053d-3bf2-49c7-9071-6459da82bc26") },
                    { new Guid("6da16c63-9a78-4ac8-9951-ae5e670c8c7b"), new Guid("aed10caa-879b-4bbd-b578-9a987f4d34de") },
                    { new Guid("6da16c63-9a78-4ac8-9951-ae5e670c8c7b"), new Guid("b3e1c8fc-e664-491e-a189-8f0c8dc4b592") },
                    { new Guid("6da16c63-9a78-4ac8-9951-ae5e670c8c7b"), new Guid("d5a557f8-9f37-4792-bfc9-a36e520e376b") },
                    { new Guid("6da16c63-9a78-4ac8-9951-ae5e670c8c7b"), new Guid("f06ff109-804e-4fcd-b796-d942270a726e") }
                });

            migrationBuilder.InsertData(
                table: "BoardUserAssociations",
                columns: new[] { "AppUserId", "BoardId" },
                values: new object[,]
                {
                    { new Guid("3f597454-e804-4848-8ad7-735a512277f3"), new Guid("3d685ea6-5b9a-40f3-8069-d7e34bfd074a") },
                    { new Guid("96b2053d-3bf2-49c7-9071-6459da82bc26"), new Guid("3d685ea6-5b9a-40f3-8069-d7e34bfd074a") },
                    { new Guid("f06ff109-804e-4fcd-b796-d942270a726e"), new Guid("3d685ea6-5b9a-40f3-8069-d7e34bfd074a") },
                    { new Guid("006a6ef0-4418-409c-bb83-a1cb1c988e34"), new Guid("a4ec6ab7-58d0-4f50-87ae-e697cf39b332") },
                    { new Guid("02d2db96-4cb1-4a33-94af-cc562185939b"), new Guid("a4ec6ab7-58d0-4f50-87ae-e697cf39b332") },
                    { new Guid("296e9a76-205b-4524-b666-be15a962b3f5"), new Guid("a4ec6ab7-58d0-4f50-87ae-e697cf39b332") },
                    { new Guid("3f597454-e804-4848-8ad7-735a512277f3"), new Guid("a4ec6ab7-58d0-4f50-87ae-e697cf39b332") },
                    { new Guid("96b2053d-3bf2-49c7-9071-6459da82bc26"), new Guid("a4ec6ab7-58d0-4f50-87ae-e697cf39b332") },
                    { new Guid("aed10caa-879b-4bbd-b578-9a987f4d34de"), new Guid("a4ec6ab7-58d0-4f50-87ae-e697cf39b332") },
                    { new Guid("b3e1c8fc-e664-491e-a189-8f0c8dc4b592"), new Guid("a4ec6ab7-58d0-4f50-87ae-e697cf39b332") },
                    { new Guid("d5a557f8-9f37-4792-bfc9-a36e520e376b"), new Guid("a4ec6ab7-58d0-4f50-87ae-e697cf39b332") },
                    { new Guid("f06ff109-804e-4fcd-b796-d942270a726e"), new Guid("a4ec6ab7-58d0-4f50-87ae-e697cf39b332") }
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "StageName" },
                values: new object[,]
                {
                    { new Guid("83103c81-b8cd-403b-8fd7-51d9f7a2cb1c"), new Guid("a4ec6ab7-58d0-4f50-87ae-e697cf39b332"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3358), "Geliştirme aşaması için kodlama aşaması", "Kodlama" },
                    { new Guid("93c67ea7-db18-41f9-9e49-f3f7cee6c21f"), new Guid("a4ec6ab7-58d0-4f50-87ae-e697cf39b332"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3352), "Geliştirme aşaması için analiz aşaması", "Analiz" },
                    { new Guid("9bdde391-e519-4fc8-8b70-4420ec3be9a8"), new Guid("a4ec6ab7-58d0-4f50-87ae-e697cf39b332"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3354), "Geliştirme aşaması için tasarım aşaması", "Tasarım" },
                    { new Guid("c701be2c-31ed-4867-9b08-384963408a5f"), new Guid("3d685ea6-5b9a-40f3-8069-d7e34bfd074a"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3347), "Design stage for the blog site project", "Home Page" },
                    { new Guid("e389bdff-bcbb-4ef7-8f7c-8c0646c972f2"), new Guid("a4ec6ab7-58d0-4f50-87ae-e697cf39b332"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3364), "Geliştirme aşaması için test aşaması", "Test" },
                    { new Guid("f344611e-0a27-40a8-9823-9ba34a97817d"), new Guid("3d685ea6-5b9a-40f3-8069-d7e34bfd074a"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3350), "Planning stage for the stock tracking project", "Supplier Page" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CreatedOn", "Description", "DueDate", "IsComplete", "Priority", "StageId", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("03e6dca0-a9e1-4723-b784-99ce486b868f"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın prototipinin tasarlanması ve kullanıcı geri bildirimlerinin alınması", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new Guid("9bdde391-e519-4fc8-8b70-4420ec3be9a8"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prototip tasarımı" },
                    { new Guid("1d27105f-450f-4f62-869e-edb2399f67a1"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3550), "Yapılan analiz çalışmalarının sonuçlarının detaylı bir şekilde dokümante edilmesi", new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new Guid("93c67ea7-db18-41f9-9e49-f3f7cee6c21f"), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analiz sonuçlarının dokümantasyonu" },
                    { new Guid("1e8b04bf-d8f5-4cb3-b73d-37469ae06d42"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3510), "Depend job", new DateTime(2024, 6, 12, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3509), false, 2, new Guid("c701be2c-31ed-4867-9b08-384963408a5f"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3508), "Depend job" },
                    { new Guid("45b4743a-c10e-4104-b792-138317feff64"), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kullanıcı arayüzünün ön uç (frontend) bileşenlerinin geliştirilmesi ve entegrasyon testlerinin yapılması", new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, new Guid("83103c81-b8cd-403b-8fd7-51d9f7a2cb1c"), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frontend komponent geliştirme" },
                    { new Guid("5f6bafe4-bdf9-4612-9534-95e162a7b054"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3499), "Design user interface for the blog site", new DateTime(2024, 6, 5, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3494), false, 0, new Guid("f344611e-0a27-40a8-9823-9ba34a97817d"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3494), "Design UI" },
                    { new Guid("7fb6cf00-9584-49cb-9984-f3c5496be6f7"), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın farklı bileşenlerinin bir araya getirilerek sistem entegrasyon testlerinin yapılması", new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, new Guid("e389bdff-bcbb-4ef7-8f7c-8c0646c972f2"), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sistem entegrasyon testlerinin yapılması" },
                    { new Guid("a8909ddb-dd0a-4627-9f61-1d0708ae14ec"), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın test edilmesi için birinci aşama test senaryolarının hazırlanması", new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new Guid("e389bdff-bcbb-4ef7-8f7c-8c0646c972f2"), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Birinci aşama test senaryolarının hazırlanması" },
                    { new Guid("aaf5445c-966d-459e-b3f9-95346c98fd46"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3547), "Müşteri gereksinimlerinin toplanması ve analiz edilmesi", new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new Guid("93c67ea7-db18-41f9-9e49-f3f7cee6c21f"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Müşteri ihtiyaçlarının belirlenmesi" },
                    { new Guid("b39c1dcc-4ff6-4a4e-bdc6-1b08426b0287"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın arka uç (backend) API'larının geliştirilmesi ve test edilmesi", new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new Guid("83103c81-b8cd-403b-8fd7-51d9f7a2cb1c"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Backend API geliştirme" },
                    { new Guid("c1038880-6cbe-4529-bcfc-0717402da6c1"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kullanıcı arayüzünün revize edilmesi ve geliştirilmiş bir versiyonunun hazırlanması", new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new Guid("9bdde391-e519-4fc8-8b70-4420ec3be9a8"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arayüz tasarım revizyonu" },
                    { new Guid("d0442507-5736-4356-9f7f-d57e3ad21100"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3505), "Analyze requirements for the stock tracking project", new DateTime(2024, 6, 12, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3505), false, 1, new Guid("c701be2c-31ed-4867-9b08-384963408a5f"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3504), "Requirement Analysis" },
                    { new Guid("d108a301-32d1-4a2d-a8ac-e0fdf8aa7fff"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3566), "Kullanıcı arayüzünde kullanılacak animasyonların hazırlanması ve uygulanması", new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new Guid("9bdde391-e519-4fc8-8b70-4420ec3be9a8"), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arayüz animasyonlarının hazırlanması" },
                    { new Guid("d724fa4d-415b-452a-a58f-a114c5bc9570"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Müşteri ile bir araya gelerek yazılım gereksinimlerinin detaylı bir şekilde incelenmesi", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, new Guid("93c67ea7-db18-41f9-9e49-f3f7cee6c21f"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Müşteri toplantısı ve gereksinimlerin belirlenmesi" },
                    { new Guid("e620632a-c388-4890-b0af-0d63266efa21"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3544), "Mevcut sistem ve iş süreçlerinin detaylı bir şekilde incelenmesi", new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, new Guid("93c67ea7-db18-41f9-9e49-f3f7cee6c21f"), new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mevcut sistem analizi" },
                    { new Guid("ea77c5c3-d52e-43e3-a00f-f04ee8c63f48"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın işlevsel gereksinimlerinin ayrıntılı bir şekilde belirlenmesi", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new Guid("93c67ea7-db18-41f9-9e49-f3f7cee6c21f"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fonksiyonel gereksinimlerin belirlenmesi" },
                    { new Guid("f37af2d1-d197-4c4a-96b5-9392521c87c2"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3563), "Tasarım aşamasında alınan geri bildirimler doğrultusunda gerekli revizyonların yapılması", new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new Guid("9bdde391-e519-4fc8-8b70-4420ec3be9a8"), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tasarım revizyonu" },
                    { new Guid("f45a66ef-f8f7-490f-8d6d-3ce25da323bd"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3560), "Kullanıcı arayüzünün kullanılabilirliğinin test edilmesi ve geri bildirimlerin alınması", new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new Guid("9bdde391-e519-4fc8-8b70-4420ec3be9a8"), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arayüzün kullanılabilirlik testlerinin yapılması" },
                    { new Guid("f60eda8b-d77c-494e-b1b3-de8dcb352381"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3555), "Yazılımın kullanıcı arayüzü tasarımının ilk mockup'ları oluşturulması", new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, new Guid("9bdde391-e519-4fc8-8b70-4420ec3be9a8"), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kullanıcı arayüzünün mockup'larının hazırlanması" },
                    { new Guid("f78d8051-12d2-417e-96a0-92354f2ff80d"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3558), "Kullanılacak renklerin ve renk paletinin belirlenmesi", new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new Guid("9bdde391-e519-4fc8-8b70-4420ec3be9a8"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arayüz tasarımı için renk paletinin belirlenmesi" }
                });

            migrationBuilder.InsertData(
                table: "Dependencies",
                columns: new[] { "Id", "CreatedOn", "DependsOnJobId", "JobId" },
                values: new object[] { new Guid("bc406da2-959a-4740-a446-a2525030cce5"), new DateTime(2024, 5, 29, 2, 39, 29, 895, DateTimeKind.Local).AddTicks(3617), new Guid("d0442507-5736-4356-9f7f-d57e3ad21100"), new Guid("1e8b04bf-d8f5-4cb3-b73d-37469ae06d42") });

            migrationBuilder.InsertData(
                table: "JobUserAssociations",
                columns: new[] { "JobId", "UserId" },
                values: new object[,]
                {
                    { new Guid("03e6dca0-a9e1-4723-b784-99ce486b868f"), new Guid("006a6ef0-4418-409c-bb83-a1cb1c988e34") },
                    { new Guid("aaf5445c-966d-459e-b3f9-95346c98fd46"), new Guid("006a6ef0-4418-409c-bb83-a1cb1c988e34") },
                    { new Guid("c1038880-6cbe-4529-bcfc-0717402da6c1"), new Guid("006a6ef0-4418-409c-bb83-a1cb1c988e34") },
                    { new Guid("45b4743a-c10e-4104-b792-138317feff64"), new Guid("02d2db96-4cb1-4a33-94af-cc562185939b") },
                    { new Guid("b39c1dcc-4ff6-4a4e-bdc6-1b08426b0287"), new Guid("02d2db96-4cb1-4a33-94af-cc562185939b") },
                    { new Guid("f60eda8b-d77c-494e-b1b3-de8dcb352381"), new Guid("02d2db96-4cb1-4a33-94af-cc562185939b") },
                    { new Guid("f78d8051-12d2-417e-96a0-92354f2ff80d"), new Guid("02d2db96-4cb1-4a33-94af-cc562185939b") },
                    { new Guid("45b4743a-c10e-4104-b792-138317feff64"), new Guid("296e9a76-205b-4524-b666-be15a962b3f5") },
                    { new Guid("ea77c5c3-d52e-43e3-a00f-f04ee8c63f48"), new Guid("296e9a76-205b-4524-b666-be15a962b3f5") },
                    { new Guid("45b4743a-c10e-4104-b792-138317feff64"), new Guid("3f597454-e804-4848-8ad7-735a512277f3") },
                    { new Guid("a8909ddb-dd0a-4627-9f61-1d0708ae14ec"), new Guid("3f597454-e804-4848-8ad7-735a512277f3") },
                    { new Guid("b39c1dcc-4ff6-4a4e-bdc6-1b08426b0287"), new Guid("96b2053d-3bf2-49c7-9071-6459da82bc26") },
                    { new Guid("c1038880-6cbe-4529-bcfc-0717402da6c1"), new Guid("96b2053d-3bf2-49c7-9071-6459da82bc26") },
                    { new Guid("f78d8051-12d2-417e-96a0-92354f2ff80d"), new Guid("96b2053d-3bf2-49c7-9071-6459da82bc26") },
                    { new Guid("03e6dca0-a9e1-4723-b784-99ce486b868f"), new Guid("aed10caa-879b-4bbd-b578-9a987f4d34de") },
                    { new Guid("1d27105f-450f-4f62-869e-edb2399f67a1"), new Guid("aed10caa-879b-4bbd-b578-9a987f4d34de") },
                    { new Guid("d108a301-32d1-4a2d-a8ac-e0fdf8aa7fff"), new Guid("aed10caa-879b-4bbd-b578-9a987f4d34de") },
                    { new Guid("d724fa4d-415b-452a-a58f-a114c5bc9570"), new Guid("aed10caa-879b-4bbd-b578-9a987f4d34de") },
                    { new Guid("f37af2d1-d197-4c4a-96b5-9392521c87c2"), new Guid("aed10caa-879b-4bbd-b578-9a987f4d34de") },
                    { new Guid("f45a66ef-f8f7-490f-8d6d-3ce25da323bd"), new Guid("aed10caa-879b-4bbd-b578-9a987f4d34de") },
                    { new Guid("03e6dca0-a9e1-4723-b784-99ce486b868f"), new Guid("b3e1c8fc-e664-491e-a189-8f0c8dc4b592") },
                    { new Guid("d724fa4d-415b-452a-a58f-a114c5bc9570"), new Guid("b3e1c8fc-e664-491e-a189-8f0c8dc4b592") },
                    { new Guid("7fb6cf00-9584-49cb-9984-f3c5496be6f7"), new Guid("d5a557f8-9f37-4792-bfc9-a36e520e376b") },
                    { new Guid("a8909ddb-dd0a-4627-9f61-1d0708ae14ec"), new Guid("d5a557f8-9f37-4792-bfc9-a36e520e376b") },
                    { new Guid("e620632a-c388-4890-b0af-0d63266efa21"), new Guid("d5a557f8-9f37-4792-bfc9-a36e520e376b") },
                    { new Guid("f60eda8b-d77c-494e-b1b3-de8dcb352381"), new Guid("d5a557f8-9f37-4792-bfc9-a36e520e376b") },
                    { new Guid("b39c1dcc-4ff6-4a4e-bdc6-1b08426b0287"), new Guid("f06ff109-804e-4fcd-b796-d942270a726e") },
                    { new Guid("e620632a-c388-4890-b0af-0d63266efa21"), new Guid("f06ff109-804e-4fcd-b796-d942270a726e") },
                    { new Guid("f60eda8b-d77c-494e-b1b3-de8dcb352381"), new Guid("f06ff109-804e-4fcd-b796-d942270a726e") }
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
