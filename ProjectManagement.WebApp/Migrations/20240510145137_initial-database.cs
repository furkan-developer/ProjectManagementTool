using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectManagement.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class initialdatabase : Migration
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
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stages_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
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
                    AssignedTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedOn", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5b51828b-0cd4-46d3-bdbe-0e09351c6f1f"), null, new DateTime(2024, 5, 10, 17, 51, 37, 180, DateTimeKind.Local).AddTicks(7875), "user", "USER" },
                    { new Guid("9e86c716-36c1-4dbc-b078-5ed78a44f77a"), null, new DateTime(2024, 5, 10, 17, 51, 37, 180, DateTimeKind.Local).AddTicks(7873), "project-manager", "PROJECT-MANAGER" },
                    { new Guid("a9a1f0ff-08f0-475c-85e4-2f0bfcc9bc72"), null, new DateTime(2024, 5, 10, 17, 51, 37, 180, DateTimeKind.Local).AddTicks(7860), "admin", "ADMIN" },
                    { new Guid("cbc88acf-85aa-445f-aa71-498bd23f82e3"), null, new DateTime(2024, 5, 10, 17, 51, 37, 180, DateTimeKind.Local).AddTicks(7876), "project-user", "PROJECT-USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("301d66e8-ed2b-47b4-972e-469156fd0a3e"), 0, new DateTime(2024, 5, 10, 17, 51, 37, 180, DateTimeKind.Local).AddTicks(8019), "0d9c6642-18a1-4eb0-9739-0dda0eb8ff28", new DateTime(2024, 5, 10, 17, 51, 37, 180, DateTimeKind.Local).AddTicks(8020), "aliyildiz@gmail.com", false, "Ali", 1, "Yildiz ", false, null, "ALIYILDIZ@GMAIL.COM", "ALIYILDIZ123", "AQAAAAIAAYagAAAAEGRfmyOQskjdcj2V6gtuUAlKdv7C1ibNPZyeeL6siwHVsUOqVbHo8OZSnt7wbTzjcQ==", null, false, "88fcb0ce-8b5c-441c-b15c-aaaad5b02c31", false, "aliyildiz123" },
                    { new Guid("4aefbce4-2e4c-4846-af89-b8be2a24f382"), 0, new DateTime(2024, 5, 10, 17, 51, 37, 180, DateTimeKind.Local).AddTicks(8028), "2d1720a5-3fd1-439e-a937-a1a7fac98527", new DateTime(2024, 5, 10, 17, 51, 37, 180, DateTimeKind.Local).AddTicks(8029), "ayseyildiz@gmail.com", false, "Ayse", 2, "Yildiz", false, null, "AYSEYILDIZ@GMAIL.COM", "AYSEYILDIZ123", "AQAAAAIAAYagAAAAEGGMbDeiBH47Jl3eW2eeHfgbVX3IofULz8FGHijZn0It7ZSVxHrgLjkfZ3jmIt50PQ==", null, false, "dc8227e5-d394-4a6b-818e-6924da3436f9", false, "ayseyildiz123" },
                    { new Guid("53399c6e-bafd-4562-9f97-9faeee2556b0"), 0, new DateTime(2024, 5, 10, 17, 51, 37, 180, DateTimeKind.Local).AddTicks(8012), "d38846c0-be78-4b87-89d6-6c5050a19116", new DateTime(2024, 5, 10, 17, 51, 37, 180, DateTimeKind.Local).AddTicks(8012), "admin@gmail.com", false, "Furkan", 1, "Aydin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEIO5crOR5QQVAxZKos5O0Zcj9CYp5bZa6nnlndaQbTJ00GU+MeAx/vKQqnlr1/iUJg==", null, false, "97db5818-caaa-43c5-b55e-811254e9c944", false, "admin" },
                    { new Guid("6275a2bf-80b2-48ed-bb8d-859bf38d22a8"), 0, new DateTime(2024, 5, 10, 17, 51, 37, 180, DateTimeKind.Local).AddTicks(8035), "7dbd38c7-ca8d-4af8-94cd-f076707dd3d7", new DateTime(2024, 5, 10, 17, 51, 37, 180, DateTimeKind.Local).AddTicks(8036), "esrefyildiz@gmail.com", false, "Esref", 2, "Yildiz", false, null, "ESREFYILDIZ@GMAIL.COM", "ESREFYILDIZ123", "AQAAAAIAAYagAAAAEKB8Ym56Pu89xQeVtXPNAvC9rImcioQzbV3xswfzbsQS5PDmOJshfFEno/QHwByhog==", null, false, "d566e8d0-0789-467a-9792-d673ab7775e0", false, "esrefyildiz123" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedOn", "Description", "EndDate", "ProjectName", "StartDate", "Status" },
                values: new object[,]
                {
                    { new Guid("a0faa350-a775-43e9-9e81-7efd508391eb"), new DateTime(2024, 5, 10, 17, 51, 37, 485, DateTimeKind.Local).AddTicks(8119), "A project to develop a stock tracking system", new DateTime(2024, 7, 9, 17, 51, 37, 485, DateTimeKind.Local).AddTicks(8118), "Stock Tracking Project", new DateTime(2024, 5, 10, 17, 51, 37, 485, DateTimeKind.Local).AddTicks(8117), "Planning" },
                    { new Guid("e6e94437-0399-4f7c-bd58-0ec785e05dc7"), new DateTime(2024, 5, 10, 17, 51, 37, 485, DateTimeKind.Local).AddTicks(8113), "A project to create a blog site", new DateTime(2024, 6, 9, 17, 51, 37, 485, DateTimeKind.Local).AddTicks(8107), "Blog Site Project", new DateTime(2024, 5, 10, 17, 51, 37, 485, DateTimeKind.Local).AddTicks(8106), "InProgress" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("9e86c716-36c1-4dbc-b078-5ed78a44f77a"), new Guid("301d66e8-ed2b-47b4-972e-469156fd0a3e") },
                    { new Guid("5b51828b-0cd4-46d3-bdbe-0e09351c6f1f"), new Guid("4aefbce4-2e4c-4846-af89-b8be2a24f382") },
                    { new Guid("a9a1f0ff-08f0-475c-85e4-2f0bfcc9bc72"), new Guid("53399c6e-bafd-4562-9f97-9faeee2556b0") },
                    { new Guid("cbc88acf-85aa-445f-aa71-498bd23f82e3"), new Guid("6275a2bf-80b2-48ed-bb8d-859bf38d22a8") }
                });

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "CreatedOn", "Date", "Description", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("d75a2d47-f8a0-4c88-b76c-d70bda25cf25"), 200.00m, new DateTime(2024, 5, 10, 17, 51, 37, 486, DateTimeKind.Local).AddTicks(734), new DateTime(2024, 5, 10, 17, 51, 37, 486, DateTimeKind.Local).AddTicks(733), "Sample cost", new Guid("a0faa350-a775-43e9-9e81-7efd508391eb") },
                    { new Guid("e250b40c-cf2b-4ea0-a94f-60a2bd4d31f4"), 500.00m, new DateTime(2024, 5, 10, 17, 51, 37, 486, DateTimeKind.Local).AddTicks(578), new DateTime(2024, 5, 10, 17, 51, 37, 486, DateTimeKind.Local).AddTicks(574), "Sample cost", new Guid("e6e94437-0399-4f7c-bd58-0ec785e05dc7") }
                });

            migrationBuilder.InsertData(
                table: "ProjectUserAssociations",
                columns: new[] { "ProjectId", "UserId" },
                values: new object[,]
                {
                    { new Guid("a0faa350-a775-43e9-9e81-7efd508391eb"), new Guid("301d66e8-ed2b-47b4-972e-469156fd0a3e") },
                    { new Guid("a0faa350-a775-43e9-9e81-7efd508391eb"), new Guid("4aefbce4-2e4c-4846-af89-b8be2a24f382") },
                    { new Guid("e6e94437-0399-4f7c-bd58-0ec785e05dc7"), new Guid("301d66e8-ed2b-47b4-972e-469156fd0a3e") },
                    { new Guid("e6e94437-0399-4f7c-bd58-0ec785e05dc7"), new Guid("6275a2bf-80b2-48ed-bb8d-859bf38d22a8") }
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "CreatedOn", "Description", "ProjectId", "StageName" },
                values: new object[,]
                {
                    { new Guid("1f443988-6e3e-4ca2-b58b-4792516fdc1d"), new DateTime(2024, 5, 10, 17, 51, 37, 485, DateTimeKind.Local).AddTicks(8225), "Planning stage for the stock tracking project", new Guid("a0faa350-a775-43e9-9e81-7efd508391eb"), "Planning" },
                    { new Guid("ac30d0c1-95a9-4995-8c21-3b83f67f0830"), new DateTime(2024, 5, 10, 17, 51, 37, 485, DateTimeKind.Local).AddTicks(8221), "Design stage for the blog site project", new Guid("e6e94437-0399-4f7c-bd58-0ec785e05dc7"), "Design" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "AssignedTo", "CreatedOn", "Description", "DueDate", "Priority", "ProjectId", "StageId", "StartDate", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("4a180b37-2388-4054-8a12-cd90f886fc0f"), "John Doe", new DateTime(2024, 5, 10, 17, 51, 37, 486, DateTimeKind.Local).AddTicks(316), "Design user interface for the blog site", new DateTime(2024, 5, 17, 17, 51, 37, 486, DateTimeKind.Local).AddTicks(313), 1, new Guid("e6e94437-0399-4f7c-bd58-0ec785e05dc7"), new Guid("1f443988-6e3e-4ca2-b58b-4792516fdc1d"), new DateTime(2024, 5, 10, 17, 51, 37, 486, DateTimeKind.Local).AddTicks(312), "ToDo", "Design UI" },
                    { new Guid("4d8c9cb9-aab7-4238-b2a4-c24130533cdf"), "John Doe", new DateTime(2024, 5, 10, 17, 51, 37, 486, DateTimeKind.Local).AddTicks(324), "Analyze requirements for the stock tracking project", new DateTime(2024, 5, 24, 17, 51, 37, 486, DateTimeKind.Local).AddTicks(323), 2, new Guid("a0faa350-a775-43e9-9e81-7efd508391eb"), new Guid("ac30d0c1-95a9-4995-8c21-3b83f67f0830"), new DateTime(2024, 5, 10, 17, 51, 37, 486, DateTimeKind.Local).AddTicks(323), "InProgress", "Requirement Analysis" },
                    { new Guid("f696993f-d602-4225-9d1a-c5569319009e"), "John Doe", new DateTime(2024, 5, 10, 17, 51, 37, 486, DateTimeKind.Local).AddTicks(329), "Depend job", new DateTime(2024, 5, 24, 17, 51, 37, 486, DateTimeKind.Local).AddTicks(328), 2, new Guid("a0faa350-a775-43e9-9e81-7efd508391eb"), new Guid("ac30d0c1-95a9-4995-8c21-3b83f67f0830"), new DateTime(2024, 5, 10, 17, 51, 37, 486, DateTimeKind.Local).AddTicks(328), "Pending", "Depend job" }
                });

            migrationBuilder.InsertData(
                table: "Dependencies",
                columns: new[] { "Id", "CreatedOn", "DependsOnJobId", "JobId" },
                values: new object[] { new Guid("24a744b8-31d9-439c-ae85-2d4aa0bb561b"), new DateTime(2024, 5, 10, 17, 51, 37, 486, DateTimeKind.Local).AddTicks(438), new Guid("4d8c9cb9-aab7-4238-b2a4-c24130533cdf"), new Guid("f696993f-d602-4225-9d1a-c5569319009e") });

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
                name: "IX_Costs_ProjectId",
                table: "Costs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependencies_JobId",
                table: "Dependencies",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ProjectId",
                table: "Jobs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_StageId",
                table: "Jobs",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUserAssociations_UserId",
                table: "ProjectUserAssociations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_ProjectId",
                table: "Stages",
                column: "ProjectId");
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
                name: "Costs");

            migrationBuilder.DropTable(
                name: "Dependencies");

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
                name: "Projects");
        }
    }
}
