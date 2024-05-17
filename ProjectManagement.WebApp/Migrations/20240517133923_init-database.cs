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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedOn", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("87fb4e59-b227-4950-9c68-3b1f1673dfcd"), null, new DateTime(2024, 5, 17, 16, 39, 22, 362, DateTimeKind.Local).AddTicks(9958), "admin", "ADMIN" },
                    { new Guid("8c6cb990-5988-47e2-bafe-3125e9d19db7"), null, new DateTime(2024, 5, 17, 16, 39, 22, 362, DateTimeKind.Local).AddTicks(9984), "project-user", "PROJECT-USER" },
                    { new Guid("8d78594d-9bba-43fe-bc95-7671163c83d1"), null, new DateTime(2024, 5, 17, 16, 39, 22, 362, DateTimeKind.Local).AddTicks(9981), "user", "USER" },
                    { new Guid("b77f5ccb-5b92-4b6b-8f95-044d9bdabcf3"), null, new DateTime(2024, 5, 17, 16, 39, 22, 362, DateTimeKind.Local).AddTicks(9977), "project-manager", "PROJECT-MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("08bcd6da-dda2-4c30-ab67-e44a756615f5"), 0, new DateTime(2024, 5, 17, 16, 39, 22, 363, DateTimeKind.Local).AddTicks(380), "e7df39ca-76a1-4158-811e-de6b34ac47a0", new DateTime(2024, 5, 17, 16, 39, 22, 363, DateTimeKind.Local).AddTicks(381), "aliyildiz@gmail.com", false, "Ali", 1, "Yildiz ", false, null, "ALIYILDIZ@GMAIL.COM", "ALIYILDIZ123", "AQAAAAIAAYagAAAAEGrxionBxoZcbicGF5/ncrX6/AYbuWSWvDUAaOYS7Pvn9jPkjaQItTaT2R43JaY7+w==", null, false, "1626a066-75c9-4880-abdc-965d2819a516", false, "aliyildiz123" },
                    { new Guid("6c236d86-1f7b-4af3-816c-ecb799c4487c"), 0, new DateTime(2024, 5, 17, 16, 39, 22, 363, DateTimeKind.Local).AddTicks(401), "b72b48a5-2d65-404e-b462-2971af4f5f1a", new DateTime(2024, 5, 17, 16, 39, 22, 363, DateTimeKind.Local).AddTicks(402), "esrefyildiz@gmail.com", false, "Esref", 2, "Yildiz", false, null, "ESREFYILDIZ@GMAIL.COM", "ESREFYILDIZ123", "AQAAAAIAAYagAAAAEHrPEiZ8rap8mUSUYQuQwUp//8JSykQrOfV02DQnhr6kSOSiyybCmAWzziv0C2ZRLQ==", null, false, "ce7207de-7af9-4f84-8b72-12272d2483fe", false, "esrefyildiz123" },
                    { new Guid("a835d45f-7927-4c27-958b-64c9f6fe303a"), 0, new DateTime(2024, 5, 17, 16, 39, 22, 363, DateTimeKind.Local).AddTicks(391), "22843090-c53b-40de-8a16-e71362fadd67", new DateTime(2024, 5, 17, 16, 39, 22, 363, DateTimeKind.Local).AddTicks(392), "ayseyildiz@gmail.com", false, "Ayse", 2, "Yildiz", false, null, "AYSEYILDIZ@GMAIL.COM", "AYSEYILDIZ123", "AQAAAAIAAYagAAAAEJPfFAI9vgvxoVTNiscrws/Hj84wHeGP7VOeLPM+mQ6xY7T1buSZy3pfoQCPuYJ52g==", null, false, "f175b742-bbdb-468f-ad28-2334129c1bf3", false, "ayseyildiz123" },
                    { new Guid("aee6e8d0-335e-418a-97b2-3604a4d20fa9"), 0, new DateTime(2024, 5, 17, 16, 39, 22, 363, DateTimeKind.Local).AddTicks(360), "45a85f98-b6e3-43b6-ad1d-5e7e50ee388d", new DateTime(2024, 5, 17, 16, 39, 22, 363, DateTimeKind.Local).AddTicks(362), "admin@gmail.com", false, "Furkan", 1, "Aydin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEOClMRSsrMBj1hzhcK7JxBm2g13TWEYgaEgGSoMXbOutbe2SFsdLlL4mG42PeIiHMw==", null, false, "60aa878a-96aa-4dc8-91f4-5b8cc04e3e0f", false, "admin" },
                    { new Guid("b3930bd4-f9ca-443f-9a0b-f6886d58193e"), 0, new DateTime(2024, 5, 17, 16, 39, 22, 363, DateTimeKind.Local).AddTicks(424), "269e7d67-84c1-4853-a04c-a38b1aec9017", new DateTime(2024, 5, 17, 16, 39, 22, 363, DateTimeKind.Local).AddTicks(425), "firatcanyanan@gmail.com", false, "Firat Can", 1, "Yanan", false, null, "FIRATCANYANAN@GMAIL.COM", "FIRATCANYANAN123", "AQAAAAIAAYagAAAAENokdzxGQ5hhv2FCVLuVSBWJh8iLt59uGJRc+dAAI5e0tnZ9T/g570Pu+JBpsniiyw==", null, false, "1f0f7c9d-635a-4051-a473-1dde3d83ccfe", false, "firatcanyanan123" },
                    { new Guid("e2d03b55-a086-42de-9967-db00786c7196"), 0, new DateTime(2024, 5, 17, 16, 39, 22, 363, DateTimeKind.Local).AddTicks(411), "ffa54771-d914-41ed-b3fd-f702410525ea", new DateTime(2024, 5, 17, 16, 39, 22, 363, DateTimeKind.Local).AddTicks(412), "furkanaydin@gmail.com", false, "Furkan", 1, "Aydin", false, null, "FURKANAYDIN@GMAIL.COM", "FURKANAYDIN123", "AQAAAAIAAYagAAAAEEK5KXPrsbagZqzH+8P2dS6TsmoMimj61Jn+rEhhUY+0ozmtsuhjWu5rr9QWILMFwQ==", null, false, "54e85b2d-c7ca-4383-b557-204c1fa38f8b", false, "furkanaydin123" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedOn", "Description", "EndDate", "ProjectName", "StartDate" },
                values: new object[,]
                {
                    { new Guid("49b4ea7c-2b2a-4654-8d7f-cafe2c092c2f"), new DateTime(2024, 5, 17, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3013), "A project to develop a stock tracking system", new DateTime(2024, 7, 16, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3012), "Stock Tracking Project", new DateTime(2024, 5, 17, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3011) },
                    { new Guid("5a9c0119-2c52-4a91-8f0c-025dd8eb330d"), new DateTime(2024, 5, 17, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3006), "A project to create a blog site", new DateTime(2024, 6, 16, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(2997), "Blog Site Project", new DateTime(2024, 5, 17, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(2995) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("b77f5ccb-5b92-4b6b-8f95-044d9bdabcf3"), new Guid("08bcd6da-dda2-4c30-ab67-e44a756615f5") },
                    { new Guid("8c6cb990-5988-47e2-bafe-3125e9d19db7"), new Guid("6c236d86-1f7b-4af3-816c-ecb799c4487c") },
                    { new Guid("8d78594d-9bba-43fe-bc95-7671163c83d1"), new Guid("a835d45f-7927-4c27-958b-64c9f6fe303a") },
                    { new Guid("87fb4e59-b227-4950-9c68-3b1f1673dfcd"), new Guid("aee6e8d0-335e-418a-97b2-3604a4d20fa9") }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "CreatedOn", "ProjectId", "Title" },
                values: new object[,]
                {
                    { new Guid("29742f28-f4f9-4e0c-95a1-4c383cb3d5f0"), new DateTime(2024, 5, 17, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3301), new Guid("49b4ea7c-2b2a-4654-8d7f-cafe2c092c2f"), "Front-end board" },
                    { new Guid("c827041b-7464-4270-944f-0726ad8353dd"), new DateTime(2024, 5, 17, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3306), new Guid("49b4ea7c-2b2a-4654-8d7f-cafe2c092c2f"), "Back-end board" }
                });

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "CreatedOn", "Date", "Description", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("329812c0-5645-4837-9194-e15597900982"), 200.00m, new DateTime(2024, 5, 17, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3736), new DateTime(2024, 5, 17, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3735), "Sample cost", new Guid("49b4ea7c-2b2a-4654-8d7f-cafe2c092c2f") },
                    { new Guid("dd5fc0ae-313b-45f6-97eb-626f697bb3ce"), 500.00m, new DateTime(2024, 5, 17, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3590), new DateTime(2024, 5, 17, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3589), "Sample cost", new Guid("5a9c0119-2c52-4a91-8f0c-025dd8eb330d") }
                });

            migrationBuilder.InsertData(
                table: "ProjectUserAssociations",
                columns: new[] { "ProjectId", "UserId" },
                values: new object[,]
                {
                    { new Guid("49b4ea7c-2b2a-4654-8d7f-cafe2c092c2f"), new Guid("08bcd6da-dda2-4c30-ab67-e44a756615f5") },
                    { new Guid("49b4ea7c-2b2a-4654-8d7f-cafe2c092c2f"), new Guid("6c236d86-1f7b-4af3-816c-ecb799c4487c") },
                    { new Guid("49b4ea7c-2b2a-4654-8d7f-cafe2c092c2f"), new Guid("a835d45f-7927-4c27-958b-64c9f6fe303a") },
                    { new Guid("49b4ea7c-2b2a-4654-8d7f-cafe2c092c2f"), new Guid("b3930bd4-f9ca-443f-9a0b-f6886d58193e") },
                    { new Guid("49b4ea7c-2b2a-4654-8d7f-cafe2c092c2f"), new Guid("e2d03b55-a086-42de-9967-db00786c7196") },
                    { new Guid("5a9c0119-2c52-4a91-8f0c-025dd8eb330d"), new Guid("08bcd6da-dda2-4c30-ab67-e44a756615f5") }
                });

            migrationBuilder.InsertData(
                table: "BoardUserAssociations",
                columns: new[] { "AppUserId", "BoardId" },
                values: new object[,]
                {
                    { new Guid("6c236d86-1f7b-4af3-816c-ecb799c4487c"), new Guid("29742f28-f4f9-4e0c-95a1-4c383cb3d5f0") },
                    { new Guid("b3930bd4-f9ca-443f-9a0b-f6886d58193e"), new Guid("29742f28-f4f9-4e0c-95a1-4c383cb3d5f0") },
                    { new Guid("e2d03b55-a086-42de-9967-db00786c7196"), new Guid("29742f28-f4f9-4e0c-95a1-4c383cb3d5f0") }
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "StageName" },
                values: new object[,]
                {
                    { new Guid("3939d19a-67a6-4fe3-8aae-17de67e9384a"), new Guid("29742f28-f4f9-4e0c-95a1-4c383cb3d5f0"), new DateTime(2024, 5, 17, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3387), "Planning stage for the stock tracking project", "Supplier Page" },
                    { new Guid("db44d1b1-fa72-4017-b9dd-9cf94e226561"), new Guid("29742f28-f4f9-4e0c-95a1-4c383cb3d5f0"), new DateTime(2024, 5, 17, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3382), "Design stage for the blog site project", "Home Page" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CreatedOn", "Description", "DueDate", "Priority", "StageId", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("179b01a3-b070-4b39-b2b5-35e1d97ee986"), new DateTime(2024, 5, 17, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3461), "Design user interface for the blog site", new DateTime(2024, 5, 24, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3459), 0, new Guid("3939d19a-67a6-4fe3-8aae-17de67e9384a"), new DateTime(2024, 5, 17, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3458), "Design UI" },
                    { new Guid("cde69f6c-e44c-4a70-b05a-1f692073be74"), new DateTime(2024, 5, 17, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3475), "Analyze requirements for the stock tracking project", new DateTime(2024, 5, 31, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3474), 1, new Guid("db44d1b1-fa72-4017-b9dd-9cf94e226561"), new DateTime(2024, 5, 17, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3473), "Requirement Analysis" },
                    { new Guid("e707a273-8331-421a-a058-66aeb0425d34"), new DateTime(2024, 5, 17, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3481), "Depend job", new DateTime(2024, 5, 31, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3480), 2, new Guid("db44d1b1-fa72-4017-b9dd-9cf94e226561"), new DateTime(2024, 5, 17, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3479), "Depend job" }
                });

            migrationBuilder.InsertData(
                table: "Dependencies",
                columns: new[] { "Id", "CreatedOn", "DependsOnJobId", "JobId" },
                values: new object[] { new Guid("ff7863d0-ef80-47b0-89ff-26d9bb8231df"), new DateTime(2024, 5, 17, 16, 39, 22, 942, DateTimeKind.Local).AddTicks(3540), new Guid("cde69f6c-e44c-4a70-b05a-1f692073be74"), new Guid("e707a273-8331-421a-a058-66aeb0425d34") });

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
                name: "Costs");

            migrationBuilder.DropTable(
                name: "Dependencies");

            migrationBuilder.DropTable(
                name: "JobUserAssociations");

            migrationBuilder.DropTable(
                name: "ProjectUserAssociations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
