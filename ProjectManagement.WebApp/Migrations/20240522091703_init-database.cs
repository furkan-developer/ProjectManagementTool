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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedOn", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("219e3246-85e6-434b-996b-89b1622a11dc"), null, new DateTime(2024, 5, 22, 12, 17, 1, 119, DateTimeKind.Local).AddTicks(622), "admin", "ADMIN" },
                    { new Guid("50c62541-0e9f-4a87-a0c0-451e9cf5e978"), null, new DateTime(2024, 5, 22, 12, 17, 1, 119, DateTimeKind.Local).AddTicks(644), "user", "USER" },
                    { new Guid("85ba69ed-8512-497c-8a74-e1bf9250fd3b"), null, new DateTime(2024, 5, 22, 12, 17, 1, 119, DateTimeKind.Local).AddTicks(641), "project-manager", "PROJECT-MANAGER" },
                    { new Guid("e45116ee-78c3-4aaa-b298-3369e7d38b03"), null, new DateTime(2024, 5, 22, 12, 17, 1, 119, DateTimeKind.Local).AddTicks(647), "project-user", "PROJECT-USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0a4e1516-cf00-4dd0-bda3-a7887288341a"), 0, new DateTime(2024, 5, 22, 12, 17, 1, 119, DateTimeKind.Local).AddTicks(1087), "f2d7cd7e-a2fb-4fa7-9f9c-de1077d8f65e", new DateTime(2024, 5, 22, 12, 17, 1, 119, DateTimeKind.Local).AddTicks(1088), "ayseyildiz@gmail.com", false, "Ayse", 2, "Yildiz", false, null, "AYSEYILDIZ@GMAIL.COM", "AYSEYILDIZ123", "AQAAAAIAAYagAAAAEGjQ3SCA6sqalvtRJJBNQ7aeLYU0VRjyrsyO/rsz81Y7OKo3bjE01dpvBBaFzSEEbA==", null, false, "89770733-d16c-410a-bc1b-1dd344382b3c", false, "ayseyildiz123" },
                    { new Guid("7e1e388c-406f-41f7-a887-d9d3ebf8115c"), 0, new DateTime(2024, 5, 22, 12, 17, 1, 119, DateTimeKind.Local).AddTicks(1062), "e92bc29f-650e-4452-96d0-e7bfc11f0c12", new DateTime(2024, 5, 22, 12, 17, 1, 119, DateTimeKind.Local).AddTicks(1063), "admin@gmail.com", false, "Furkan", 1, "Aydin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEOe0mt0Dfs/d0tFqUxbgkMBCkmXvOPUbUYJ77vFObA4wYInaLWLKEMMIuzgGzG/9Ww==", null, false, "70b2dd31-0133-434d-a707-cfaac553f864", false, "admin" },
                    { new Guid("a499d983-6a13-4f79-9164-3c5b6526904b"), 0, new DateTime(2024, 5, 22, 12, 17, 1, 119, DateTimeKind.Local).AddTicks(1077), "5b5b8288-feb6-489d-8d20-decc881fc138", new DateTime(2024, 5, 22, 12, 17, 1, 119, DateTimeKind.Local).AddTicks(1078), "aliyildiz@gmail.com", false, "Ali", 1, "Yildiz ", false, null, "ALIYILDIZ@GMAIL.COM", "ALIYILDIZ123", "AQAAAAIAAYagAAAAEFOIeFzV5pZStCe4aP5EyX+QFnHg/UQsAxorIVEhHv/QzcOZopnh/Mdzx1x7nj+jlw==", null, false, "5c2eae45-4fc6-4d77-9550-996fef140d63", false, "aliyildiz123" },
                    { new Guid("ad362efa-1370-412f-8ba4-5239e656ed44"), 0, new DateTime(2024, 5, 22, 12, 17, 1, 119, DateTimeKind.Local).AddTicks(1111), "d04a435e-5603-422f-8f4e-f1e8a128b040", new DateTime(2024, 5, 22, 12, 17, 1, 119, DateTimeKind.Local).AddTicks(1112), "furkanaydin@gmail.com", false, "Furkan", 1, "Aydin", false, null, "FURKANAYDIN@GMAIL.COM", "FURKANAYDIN123", "AQAAAAIAAYagAAAAEFyu512wVjUuSE5GPNdjDLiZbgbf/+sLR8vLaHRvBlXhTwKaz/eFaiI6/CU8WJX7dw==", null, false, "eb193e08-815e-46f6-866a-38645f3ea2ed", false, "furkanaydin123" },
                    { new Guid("bec26585-1799-4174-8505-af3ecf7fb985"), 0, new DateTime(2024, 5, 22, 12, 17, 1, 119, DateTimeKind.Local).AddTicks(1121), "92a325a6-8343-4e15-8a16-113b0f8cd15e", new DateTime(2024, 5, 22, 12, 17, 1, 119, DateTimeKind.Local).AddTicks(1122), "firatcanyanan@gmail.com", false, "Firat Can", 1, "Yanan", false, null, "FIRATCANYANAN@GMAIL.COM", "FIRATCANYANAN123", "AQAAAAIAAYagAAAAEGbOQ/7pJ5Ll5Z8e9egOxBdiyoRZ6831irn43Xt0k1+rWpuOsGHWCHjllbIy8cpvew==", null, false, "0c162bb3-4914-4c13-a18f-4c89dbbdef88", false, "firatcanyanan123" },
                    { new Guid("e49ed8e2-81f1-48d0-b267-3fb03363ad6d"), 0, new DateTime(2024, 5, 22, 12, 17, 1, 119, DateTimeKind.Local).AddTicks(1101), "7a144d76-d3b3-47a7-9931-812c10676b70", new DateTime(2024, 5, 22, 12, 17, 1, 119, DateTimeKind.Local).AddTicks(1102), "esrefyildiz@gmail.com", false, "Esref", 2, "Yildiz", false, null, "ESREFYILDIZ@GMAIL.COM", "ESREFYILDIZ123", "AQAAAAIAAYagAAAAEGNlYKswHerhwmhRujWk57xA61mEWqX8z/lN8A3GjrKIX9MVqSqvo90K1tgoE+/NZQ==", null, false, "719b6588-4b6e-4675-a656-f94da7a4d251", false, "esrefyildiz123" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedOn", "Description", "EndDate", "ProjectName", "StartDate" },
                values: new object[,]
                {
                    { new Guid("28a4a276-ebd2-49d4-82ff-1f376e2f75d3"), new DateTime(2024, 5, 22, 12, 17, 1, 799, DateTimeKind.Local).AddTicks(9291), "A project to create a blog site", new DateTime(2024, 6, 21, 12, 17, 1, 799, DateTimeKind.Local).AddTicks(9281), "Blog Site Project", new DateTime(2024, 5, 22, 12, 17, 1, 799, DateTimeKind.Local).AddTicks(9279) },
                    { new Guid("3d5b3566-7a48-492c-bdb1-6f8aa9a78399"), new DateTime(2024, 5, 22, 12, 17, 1, 799, DateTimeKind.Local).AddTicks(9301), "A project to develop a stock tracking system", new DateTime(2024, 7, 21, 12, 17, 1, 799, DateTimeKind.Local).AddTicks(9300), "Stock Tracking Project", new DateTime(2024, 5, 22, 12, 17, 1, 799, DateTimeKind.Local).AddTicks(9299) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("50c62541-0e9f-4a87-a0c0-451e9cf5e978"), new Guid("0a4e1516-cf00-4dd0-bda3-a7887288341a") },
                    { new Guid("219e3246-85e6-434b-996b-89b1622a11dc"), new Guid("7e1e388c-406f-41f7-a887-d9d3ebf8115c") },
                    { new Guid("85ba69ed-8512-497c-8a74-e1bf9250fd3b"), new Guid("a499d983-6a13-4f79-9164-3c5b6526904b") },
                    { new Guid("e45116ee-78c3-4aaa-b298-3369e7d38b03"), new Guid("e49ed8e2-81f1-48d0-b267-3fb03363ad6d") }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "CreatedOn", "ProjectId", "Title" },
                values: new object[,]
                {
                    { new Guid("1fb86ad4-2114-41bf-930b-c745136e1e93"), new DateTime(2024, 5, 22, 12, 17, 1, 799, DateTimeKind.Local).AddTicks(9564), new Guid("3d5b3566-7a48-492c-bdb1-6f8aa9a78399"), "Front-end board" },
                    { new Guid("62d2ab63-362c-4dd3-b10c-ba1292c2b5a1"), new DateTime(2024, 5, 22, 12, 17, 1, 799, DateTimeKind.Local).AddTicks(9568), new Guid("3d5b3566-7a48-492c-bdb1-6f8aa9a78399"), "Back-end board" }
                });

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "CreatedOn", "Date", "Description", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("873c4ef1-ffb4-416e-841c-f9e23f555c64"), 500.00m, new DateTime(2024, 5, 22, 12, 17, 1, 800, DateTimeKind.Local).AddTicks(82), new DateTime(2024, 5, 22, 12, 17, 1, 800, DateTimeKind.Local).AddTicks(82), "Sample cost", new Guid("28a4a276-ebd2-49d4-82ff-1f376e2f75d3") },
                    { new Guid("a9d153f5-0de0-4c52-b6f8-f8869868abe9"), 200.00m, new DateTime(2024, 5, 22, 12, 17, 1, 800, DateTimeKind.Local).AddTicks(183), new DateTime(2024, 5, 22, 12, 17, 1, 800, DateTimeKind.Local).AddTicks(182), "Sample cost", new Guid("3d5b3566-7a48-492c-bdb1-6f8aa9a78399") }
                });

            migrationBuilder.InsertData(
                table: "ProjectUserAssociations",
                columns: new[] { "ProjectId", "UserId" },
                values: new object[,]
                {
                    { new Guid("28a4a276-ebd2-49d4-82ff-1f376e2f75d3"), new Guid("a499d983-6a13-4f79-9164-3c5b6526904b") },
                    { new Guid("3d5b3566-7a48-492c-bdb1-6f8aa9a78399"), new Guid("0a4e1516-cf00-4dd0-bda3-a7887288341a") },
                    { new Guid("3d5b3566-7a48-492c-bdb1-6f8aa9a78399"), new Guid("a499d983-6a13-4f79-9164-3c5b6526904b") },
                    { new Guid("3d5b3566-7a48-492c-bdb1-6f8aa9a78399"), new Guid("ad362efa-1370-412f-8ba4-5239e656ed44") },
                    { new Guid("3d5b3566-7a48-492c-bdb1-6f8aa9a78399"), new Guid("bec26585-1799-4174-8505-af3ecf7fb985") },
                    { new Guid("3d5b3566-7a48-492c-bdb1-6f8aa9a78399"), new Guid("e49ed8e2-81f1-48d0-b267-3fb03363ad6d") }
                });

            migrationBuilder.InsertData(
                table: "BoardUserAssociations",
                columns: new[] { "AppUserId", "BoardId" },
                values: new object[,]
                {
                    { new Guid("ad362efa-1370-412f-8ba4-5239e656ed44"), new Guid("1fb86ad4-2114-41bf-930b-c745136e1e93") },
                    { new Guid("bec26585-1799-4174-8505-af3ecf7fb985"), new Guid("1fb86ad4-2114-41bf-930b-c745136e1e93") },
                    { new Guid("e49ed8e2-81f1-48d0-b267-3fb03363ad6d"), new Guid("1fb86ad4-2114-41bf-930b-c745136e1e93") }
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "StageName" },
                values: new object[,]
                {
                    { new Guid("47503214-fd8f-4315-b161-4b78bd4d8d65"), new Guid("1fb86ad4-2114-41bf-930b-c745136e1e93"), new DateTime(2024, 5, 22, 12, 17, 1, 799, DateTimeKind.Local).AddTicks(9636), "Planning stage for the stock tracking project", "Supplier Page" },
                    { new Guid("8f3adfb2-8951-4123-a165-ce9fa1680fe5"), new Guid("1fb86ad4-2114-41bf-930b-c745136e1e93"), new DateTime(2024, 5, 22, 12, 17, 1, 799, DateTimeKind.Local).AddTicks(9632), "Design stage for the blog site project", "Home Page" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CreatedOn", "Description", "DueDate", "Priority", "StageId", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("5ba51cc1-e57d-4d72-99c9-41ab7e481963"), new DateTime(2024, 5, 22, 12, 17, 1, 799, DateTimeKind.Local).AddTicks(9958), "Analyze requirements for the stock tracking project", new DateTime(2024, 6, 5, 12, 17, 1, 799, DateTimeKind.Local).AddTicks(9957), 1, new Guid("8f3adfb2-8951-4123-a165-ce9fa1680fe5"), new DateTime(2024, 5, 22, 12, 17, 1, 799, DateTimeKind.Local).AddTicks(9956), "Requirement Analysis" },
                    { new Guid("8f0b48e1-5909-44c4-834c-0833905e7368"), new DateTime(2024, 5, 22, 12, 17, 1, 799, DateTimeKind.Local).AddTicks(9949), "Design user interface for the blog site", new DateTime(2024, 5, 29, 12, 17, 1, 799, DateTimeKind.Local).AddTicks(9946), 0, new Guid("47503214-fd8f-4315-b161-4b78bd4d8d65"), new DateTime(2024, 5, 22, 12, 17, 1, 799, DateTimeKind.Local).AddTicks(9946), "Design UI" },
                    { new Guid("afc20432-a348-46f7-bad0-3e1b7fc22c5b"), new DateTime(2024, 5, 22, 12, 17, 1, 799, DateTimeKind.Local).AddTicks(9965), "Depend job", new DateTime(2024, 6, 5, 12, 17, 1, 799, DateTimeKind.Local).AddTicks(9964), 2, new Guid("8f3adfb2-8951-4123-a165-ce9fa1680fe5"), new DateTime(2024, 5, 22, 12, 17, 1, 799, DateTimeKind.Local).AddTicks(9962), "Depend job" }
                });

            migrationBuilder.InsertData(
                table: "Dependencies",
                columns: new[] { "Id", "CreatedOn", "DependsOnJobId", "JobId" },
                values: new object[] { new Guid("12d4713a-bed7-4aa5-beed-bce7604670e4"), new DateTime(2024, 5, 22, 12, 17, 1, 800, DateTimeKind.Local).AddTicks(36), new Guid("5ba51cc1-e57d-4d72-99c9-41ab7e481963"), new Guid("afc20432-a348-46f7-bad0-3e1b7fc22c5b") });

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
