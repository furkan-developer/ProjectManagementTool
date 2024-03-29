using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectManagement.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class createbaseentities : Migration
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
                name: "ProjectUserAssociation",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUserAssociation", x => new { x.ProjectId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ProjectUserAssociation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUserAssociation_Projects_ProjectId",
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
                    { new Guid("2a9ba7a8-70ed-4328-9ca2-ad02f19a25fc"), null, new DateTime(2024, 3, 29, 12, 7, 32, 717, DateTimeKind.Local).AddTicks(706), "Project User", "PROJECT-USER" },
                    { new Guid("5000e059-d22d-45ff-9fda-6e1c6ddd713a"), null, new DateTime(2024, 3, 29, 12, 7, 32, 717, DateTimeKind.Local).AddTicks(689), "Admin", "ADMIN" },
                    { new Guid("75e5efee-8bed-43a4-b035-50c547827b44"), null, new DateTime(2024, 3, 29, 12, 7, 32, 717, DateTimeKind.Local).AddTicks(703), "User", "USER" },
                    { new Guid("b448a029-79b6-4c74-adb7-c674252232ae"), null, new DateTime(2024, 3, 29, 12, 7, 32, 717, DateTimeKind.Local).AddTicks(701), "Project Manager", "PROJECT-MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("040b4803-d368-498c-b39a-24e00fc11646"), 0, new DateTime(2024, 3, 29, 12, 7, 32, 717, DateTimeKind.Local).AddTicks(883), "f5790064-34e7-428d-8ffc-034b16e97b28", new DateTime(2024, 3, 29, 12, 7, 32, 717, DateTimeKind.Local).AddTicks(883), "ayseyildiz@gmail.com", false, "Ayse", 2, "Yildiz", false, null, "AYSEYILDIZ@GMAIL.COM", "AYSEYILDIZ123", "AQAAAAIAAYagAAAAEAJ4KyUqDQrYMsnZpiRDOaH0CPN0/hqB3b9+Lo2d7rOyO09kHHrMxZLjwRkOoc4pow==", null, false, "6276dbba-8ee2-42f7-b375-02fc3bc48ed0", false, "ayseyildiz123" },
                    { new Guid("5de56315-2f1d-43fe-a048-af5eebc55224"), 0, new DateTime(2024, 3, 29, 12, 7, 32, 717, DateTimeKind.Local).AddTicks(869), "fe68ef41-54c7-4f83-a502-b41b973566c3", new DateTime(2024, 3, 29, 12, 7, 32, 717, DateTimeKind.Local).AddTicks(869), "admin@gmail.com", false, "Furkan", 1, "Aydin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEOv3eVfzxeULgdqgVYciHlzQUA+p2qj5U7r8jpxMSUiVwZoPwYUZ2Oyxx5S55emXvA==", null, false, "a557942a-dbec-4787-84dc-d1a52dbc95e4", false, "admin" },
                    { new Guid("85661ea0-f42b-486c-8e94-d7b1c47e0479"), 0, new DateTime(2024, 3, 29, 12, 7, 32, 717, DateTimeKind.Local).AddTicks(877), "e4fd91b1-285c-440e-a367-2b6fdde8ec22", new DateTime(2024, 3, 29, 12, 7, 32, 717, DateTimeKind.Local).AddTicks(877), "aliyildiz@gmail.com", false, "Ali", 1, "Yildiz ", false, null, "ALIYILDIZ@GMAIL.COM", "ALIYILDIZ123", "AQAAAAIAAYagAAAAEPfZ1/UZaivU1MShlg0X2q+JEQWxjkm0ETkVbJYMTZEw3TV0xsMiABDH0uEff6FFfA==", null, false, "9baf8822-efdf-45bb-9be2-eccc1b09a058", false, "aliyildiz123" },
                    { new Guid("a50d95be-ff44-48ed-a783-bf3eb335b4fb"), 0, new DateTime(2024, 3, 29, 12, 7, 32, 717, DateTimeKind.Local).AddTicks(888), "307e90ba-391e-4d5b-afe5-c82030123657", new DateTime(2024, 3, 29, 12, 7, 32, 717, DateTimeKind.Local).AddTicks(889), "esrefyildiz@gmail.com", false, "Esref", 2, "Yildiz", false, null, "ESREFYILDIZ@GMAIL.COM", "ESREFYILDIZ123", "AQAAAAIAAYagAAAAEPZVzE0tsxnL2Tn/FEUW3VZXPblPTmvue2G6c3xDtCSZHPLs5jJCTIS+exqNgaxRXQ==", null, false, "a90c6d63-2b80-463e-9473-5de94a3b8817", false, "esrefyildiz123" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedOn", "Description", "EndDate", "ProjectName", "StartDate", "Status" },
                values: new object[,]
                {
                    { new Guid("29be38b8-7068-4759-a282-ef566b2a4978"), new DateTime(2024, 3, 29, 12, 7, 33, 22, DateTimeKind.Local).AddTicks(8764), "A project to create a blog site", new DateTime(2024, 4, 28, 12, 7, 33, 22, DateTimeKind.Local).AddTicks(8759), "Blog Site Project", new DateTime(2024, 3, 29, 12, 7, 33, 22, DateTimeKind.Local).AddTicks(8758), "InProgress" },
                    { new Guid("e955869b-0ab1-4eb3-a89b-4598680e86b1"), new DateTime(2024, 3, 29, 12, 7, 33, 22, DateTimeKind.Local).AddTicks(8773), "A project to develop a stock tracking system", new DateTime(2024, 5, 28, 12, 7, 33, 22, DateTimeKind.Local).AddTicks(8772), "Stock Tracking Project", new DateTime(2024, 3, 29, 12, 7, 33, 22, DateTimeKind.Local).AddTicks(8772), "Planning" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("75e5efee-8bed-43a4-b035-50c547827b44"), new Guid("040b4803-d368-498c-b39a-24e00fc11646") },
                    { new Guid("5000e059-d22d-45ff-9fda-6e1c6ddd713a"), new Guid("5de56315-2f1d-43fe-a048-af5eebc55224") },
                    { new Guid("b448a029-79b6-4c74-adb7-c674252232ae"), new Guid("85661ea0-f42b-486c-8e94-d7b1c47e0479") },
                    { new Guid("2a9ba7a8-70ed-4328-9ca2-ad02f19a25fc"), new Guid("a50d95be-ff44-48ed-a783-bf3eb335b4fb") }
                });

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "CreatedOn", "Date", "Description", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("2a861c30-05a9-4eea-a543-d862e139d668"), 500.00m, new DateTime(2024, 3, 29, 12, 7, 33, 23, DateTimeKind.Local).AddTicks(1729), new DateTime(2024, 3, 29, 12, 7, 33, 23, DateTimeKind.Local).AddTicks(1728), "Sample cost", new Guid("29be38b8-7068-4759-a282-ef566b2a4978") },
                    { new Guid("d3294dd7-9609-4760-a972-3317b1364e2f"), 200.00m, new DateTime(2024, 3, 29, 12, 7, 33, 23, DateTimeKind.Local).AddTicks(1838), new DateTime(2024, 3, 29, 12, 7, 33, 23, DateTimeKind.Local).AddTicks(1837), "Sample cost", new Guid("e955869b-0ab1-4eb3-a89b-4598680e86b1") }
                });

            migrationBuilder.InsertData(
                table: "ProjectUserAssociation",
                columns: new[] { "ProjectId", "UserId" },
                values: new object[,]
                {
                    { new Guid("29be38b8-7068-4759-a282-ef566b2a4978"), new Guid("85661ea0-f42b-486c-8e94-d7b1c47e0479") },
                    { new Guid("29be38b8-7068-4759-a282-ef566b2a4978"), new Guid("a50d95be-ff44-48ed-a783-bf3eb335b4fb") },
                    { new Guid("e955869b-0ab1-4eb3-a89b-4598680e86b1"), new Guid("040b4803-d368-498c-b39a-24e00fc11646") },
                    { new Guid("e955869b-0ab1-4eb3-a89b-4598680e86b1"), new Guid("85661ea0-f42b-486c-8e94-d7b1c47e0479") }
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "CreatedOn", "Description", "ProjectId", "StageName" },
                values: new object[,]
                {
                    { new Guid("bda3c392-acdb-4f9d-9375-abda2189633f"), new DateTime(2024, 3, 29, 12, 7, 33, 22, DateTimeKind.Local).AddTicks(8889), "Design stage for the blog site project", new Guid("29be38b8-7068-4759-a282-ef566b2a4978"), "Design" },
                    { new Guid("f91bc255-ef4c-48eb-a877-eb4916505d90"), new DateTime(2024, 3, 29, 12, 7, 33, 22, DateTimeKind.Local).AddTicks(8893), "Planning stage for the stock tracking project", new Guid("e955869b-0ab1-4eb3-a89b-4598680e86b1"), "Planning" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "AssignedTo", "CreatedOn", "Description", "DueDate", "Priority", "ProjectId", "StageId", "StartDate", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("4147dea3-1ef7-439e-b6eb-a1a5ae9e6876"), "John Doe", new DateTime(2024, 3, 29, 12, 7, 33, 23, DateTimeKind.Local).AddTicks(1615), "Analyze requirements for the stock tracking project", new DateTime(2024, 4, 12, 12, 7, 33, 23, DateTimeKind.Local).AddTicks(1614), 2, new Guid("e955869b-0ab1-4eb3-a89b-4598680e86b1"), new Guid("bda3c392-acdb-4f9d-9375-abda2189633f"), new DateTime(2024, 3, 29, 12, 7, 33, 23, DateTimeKind.Local).AddTicks(1613), "InProgress", "Requirement Analysis" },
                    { new Guid("696060cc-bf69-4ee3-8b92-a737c34c34fa"), "John Doe", new DateTime(2024, 3, 29, 12, 7, 33, 23, DateTimeKind.Local).AddTicks(1620), "Depend job", new DateTime(2024, 4, 12, 12, 7, 33, 23, DateTimeKind.Local).AddTicks(1619), 2, new Guid("e955869b-0ab1-4eb3-a89b-4598680e86b1"), new Guid("bda3c392-acdb-4f9d-9375-abda2189633f"), new DateTime(2024, 3, 29, 12, 7, 33, 23, DateTimeKind.Local).AddTicks(1618), "Pending", "Depend job" },
                    { new Guid("debee053-3b83-4275-9e4d-151c4a959a25"), "John Doe", new DateTime(2024, 3, 29, 12, 7, 33, 23, DateTimeKind.Local).AddTicks(1606), "Design user interface for the blog site", new DateTime(2024, 4, 5, 12, 7, 33, 23, DateTimeKind.Local).AddTicks(1602), 1, new Guid("29be38b8-7068-4759-a282-ef566b2a4978"), new Guid("f91bc255-ef4c-48eb-a877-eb4916505d90"), new DateTime(2024, 3, 29, 12, 7, 33, 23, DateTimeKind.Local).AddTicks(1601), "ToDo", "Design UI" }
                });

            migrationBuilder.InsertData(
                table: "Dependencies",
                columns: new[] { "Id", "CreatedOn", "DependsOnJobId", "JobId" },
                values: new object[] { new Guid("58a9ea69-1b4c-4c7f-861c-bf29747a12e6"), new DateTime(2024, 3, 29, 12, 7, 33, 23, DateTimeKind.Local).AddTicks(1679), new Guid("4147dea3-1ef7-439e-b6eb-a1a5ae9e6876"), new Guid("696060cc-bf69-4ee3-8b92-a737c34c34fa") });

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
                name: "IX_ProjectUserAssociation_UserId",
                table: "ProjectUserAssociation",
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
                name: "ProjectUserAssociation");

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
