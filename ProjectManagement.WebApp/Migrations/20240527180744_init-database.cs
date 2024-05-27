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
                    { new Guid("0558e2ce-7c3c-4f4e-900e-c46819de108d"), null, new DateTime(2024, 5, 27, 21, 7, 42, 382, DateTimeKind.Local).AddTicks(8673), "project-manager", "PROJECT-MANAGER" },
                    { new Guid("65425581-71e8-40de-a852-3ea5ce0032a5"), null, new DateTime(2024, 5, 27, 21, 7, 42, 382, DateTimeKind.Local).AddTicks(8684), "user", "USER" },
                    { new Guid("94d3c7f4-a23a-4b67-8f66-4265d08dab6f"), null, new DateTime(2024, 5, 27, 21, 7, 42, 382, DateTimeKind.Local).AddTicks(8654), "admin", "ADMIN" },
                    { new Guid("e9045d95-a2f8-4e8c-9039-6187fc100ac0"), null, new DateTime(2024, 5, 27, 21, 7, 42, 382, DateTimeKind.Local).AddTicks(8686), "project-user", "PROJECT-USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("105b6464-3f2c-452d-80b4-4563767eb06d"), 0, new DateTime(2024, 5, 27, 21, 7, 42, 382, DateTimeKind.Local).AddTicks(9029), "4e7b7b00-5f29-49d4-8a4d-40027d4f071c", new DateTime(2024, 5, 27, 21, 7, 42, 382, DateTimeKind.Local).AddTicks(9030), "firatcanyanan@gmail.com", false, "Firat Can", 1, "Yanan", false, null, "FIRATCANYANAN@GMAIL.COM", "FIRATCANYANAN123", "AQAAAAIAAYagAAAAEOJTEPpt4boZnc4IJHOZEWgfSh7pVSZArH2xd1YwecPUbUj/zGoVSjyQus2/AvsQ5Q==", null, false, "0b503e0b-b7e3-43f1-8981-dffd86405272", false, "firatcanyanan123" },
                    { new Guid("655a0904-4cd2-493f-9aa0-c9ed9dff1312"), 0, new DateTime(2024, 5, 27, 21, 7, 42, 382, DateTimeKind.Local).AddTicks(8976), "9a874edf-5300-4172-a883-fcf61a24aea5", new DateTime(2024, 5, 27, 21, 7, 42, 382, DateTimeKind.Local).AddTicks(8977), "admin@gmail.com", false, "Furkan", 1, "Aydin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAECPkeORCq9aUzgBWvO6ifdxh+Aofk4bg61xNM26asjHt8jhUPkyBg9IxGTrV8draPA==", null, false, "72c50e59-062b-4685-ab3a-47fd100dbbf3", false, "admin" },
                    { new Guid("66674da9-980e-454f-8213-c6c919e3d457"), 0, new DateTime(2024, 5, 27, 21, 7, 42, 382, DateTimeKind.Local).AddTicks(9023), "1fa5e29b-f761-4377-94b0-19a5f1f460bd", new DateTime(2024, 5, 27, 21, 7, 42, 382, DateTimeKind.Local).AddTicks(9023), "furkanaydin@gmail.com", false, "Furkan", 1, "Aydin", false, null, "FURKANAYDIN@GMAIL.COM", "FURKANAYDIN123", "AQAAAAIAAYagAAAAEONreJPIu0PmDQ+uAqfzWm2Ic4bBC1rKZ6tkZC+/gix+dFFX2PvQgY/9quN8yCe5NQ==", null, false, "73c5ce33-2d28-4e57-a6a4-56594ecc6cb4", false, "furkanaydin123" },
                    { new Guid("89e482fd-3289-41ce-ae7a-35bad31c1c7c"), 0, new DateTime(2024, 5, 27, 21, 7, 42, 382, DateTimeKind.Local).AddTicks(9016), "e5ad6c55-079f-42e5-a006-2e4d631f6c82", new DateTime(2024, 5, 27, 21, 7, 42, 382, DateTimeKind.Local).AddTicks(9016), "esrefyildiz@gmail.com", false, "Esref", 2, "Yildiz", false, null, "ESREFYILDIZ@GMAIL.COM", "ESREFYILDIZ123", "AQAAAAIAAYagAAAAEL33gmjratdwHTdt3D7IqSZwmys9vk1U3UCFwOBONSi821eCJ16W+EI1Pr1xquDnAA==", null, false, "1575edf6-5051-4d3c-9371-ffce5fe32183", false, "esrefyildiz123" },
                    { new Guid("aad030d4-6578-44b2-bffa-d0616abdb45c"), 0, new DateTime(2024, 5, 27, 21, 7, 42, 382, DateTimeKind.Local).AddTicks(9005), "423627a8-aa86-4efc-85c8-a6790f1111cf", new DateTime(2024, 5, 27, 21, 7, 42, 382, DateTimeKind.Local).AddTicks(9005), "ayseyildiz@gmail.com", false, "Ayse", 2, "Yildiz", false, null, "AYSEYILDIZ@GMAIL.COM", "AYSEYILDIZ123", "AQAAAAIAAYagAAAAENNRdSLMQv60yQ0fHvlh2o96xji/lULVJf2O6tbgOU1bvH/F/GTs8S5ABt59DgVfpg==", null, false, "9c2ea385-4c61-430e-b83e-059d26e30187", false, "ayseyildiz123" },
                    { new Guid("b2eff7ac-6381-4a7a-8e42-54c5dbb8d312"), 0, new DateTime(2024, 5, 27, 21, 7, 42, 382, DateTimeKind.Local).AddTicks(8997), "409d03ef-dd28-4d05-92ac-da528fe922c9", new DateTime(2024, 5, 27, 21, 7, 42, 382, DateTimeKind.Local).AddTicks(8997), "aliyildiz@gmail.com", false, "Ali", 1, "Yildiz ", false, null, "ALIYILDIZ@GMAIL.COM", "ALIYILDIZ123", "AQAAAAIAAYagAAAAEIvgEUcrAVn/HgDHrL45PgQSoBcX9TfoM8+MvaauYHbDYr7GJWzzjcJXZk9uqwKe8A==", null, false, "85dc24a6-5ede-46dd-9bcf-81a522b81e24", false, "aliyildiz123" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedOn", "Description", "EndDate", "ProjectName", "StartDate" },
                values: new object[,]
                {
                    { new Guid("52f1292d-18eb-48df-a22e-7fd0afe30831"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(3773), "A project to develop a stock tracking system", new DateTime(2024, 7, 26, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(3771), "Stock Tracking Project", new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(3770) },
                    { new Guid("691c1291-9124-4e83-b6f7-ff4b11b47f03"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(3763), "A project to create a blog site", new DateTime(2024, 6, 26, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(3753), "Blog Site Project", new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(3751) },
                    { new Guid("699e36ef-8d0c-4008-8c4c-8ffad20fa3d2"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(3782), "Bir yazılım ürününün geliştirilmesi", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılım Projesi", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("729d735a-e2a6-462d-acb0-ce02ea5b7c27"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(3794), "Yeni bir ürünün pazarlama stratejisinin oluşturulması", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pazarlama Kampanyası", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e8c3f28d-b909-42f0-8135-a4020cda13aa"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(3801), "Yeni bir ürünün tasarım sürecinin yürütülmesi", new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yeni Ürün Tasarımı", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("94d3c7f4-a23a-4b67-8f66-4265d08dab6f"), new Guid("655a0904-4cd2-493f-9aa0-c9ed9dff1312") },
                    { new Guid("e9045d95-a2f8-4e8c-9039-6187fc100ac0"), new Guid("89e482fd-3289-41ce-ae7a-35bad31c1c7c") },
                    { new Guid("65425581-71e8-40de-a852-3ea5ce0032a5"), new Guid("aad030d4-6578-44b2-bffa-d0616abdb45c") },
                    { new Guid("0558e2ce-7c3c-4f4e-900e-c46819de108d"), new Guid("b2eff7ac-6381-4a7a-8e42-54c5dbb8d312") }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "CreatedOn", "ProjectId", "Title" },
                values: new object[,]
                {
                    { new Guid("5f5337e0-a0e8-43de-b9a7-bcad47b753c0"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4280), new Guid("52f1292d-18eb-48df-a22e-7fd0afe30831"), "Back-end board" },
                    { new Guid("66b7f8f4-fb35-4a32-a4e7-541e16b28c05"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4290), new Guid("699e36ef-8d0c-4008-8c4c-8ffad20fa3d2"), "Geliştirme" },
                    { new Guid("7a805655-e58a-4fb8-952d-9116359558ac"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4285), new Guid("699e36ef-8d0c-4008-8c4c-8ffad20fa3d2"), "Analiz" },
                    { new Guid("813e33b6-b648-4ac0-8e45-85dd3ac2841c"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4274), new Guid("52f1292d-18eb-48df-a22e-7fd0afe30831"), "Front-end board" }
                });

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "CreatedOn", "Date", "Description", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("b4fd3b14-de29-44a3-87f1-1094896ad434"), 200.00m, new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(5120), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(5119), "Sample cost", new Guid("52f1292d-18eb-48df-a22e-7fd0afe30831") },
                    { new Guid("d1d77b0d-fd34-42a7-83ee-cc45fa6c258e"), 500.00m, new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(5028), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(5026), "Sample cost", new Guid("691c1291-9124-4e83-b6f7-ff4b11b47f03") }
                });

            migrationBuilder.InsertData(
                table: "ProjectUserAssociations",
                columns: new[] { "ProjectId", "UserId" },
                values: new object[,]
                {
                    { new Guid("52f1292d-18eb-48df-a22e-7fd0afe30831"), new Guid("105b6464-3f2c-452d-80b4-4563767eb06d") },
                    { new Guid("52f1292d-18eb-48df-a22e-7fd0afe30831"), new Guid("66674da9-980e-454f-8213-c6c919e3d457") },
                    { new Guid("52f1292d-18eb-48df-a22e-7fd0afe30831"), new Guid("89e482fd-3289-41ce-ae7a-35bad31c1c7c") },
                    { new Guid("52f1292d-18eb-48df-a22e-7fd0afe30831"), new Guid("aad030d4-6578-44b2-bffa-d0616abdb45c") },
                    { new Guid("52f1292d-18eb-48df-a22e-7fd0afe30831"), new Guid("b2eff7ac-6381-4a7a-8e42-54c5dbb8d312") },
                    { new Guid("691c1291-9124-4e83-b6f7-ff4b11b47f03"), new Guid("b2eff7ac-6381-4a7a-8e42-54c5dbb8d312") },
                    { new Guid("699e36ef-8d0c-4008-8c4c-8ffad20fa3d2"), new Guid("66674da9-980e-454f-8213-c6c919e3d457") },
                    { new Guid("699e36ef-8d0c-4008-8c4c-8ffad20fa3d2"), new Guid("b2eff7ac-6381-4a7a-8e42-54c5dbb8d312") }
                });

            migrationBuilder.InsertData(
                table: "BoardUserAssociations",
                columns: new[] { "AppUserId", "BoardId" },
                values: new object[,]
                {
                    { new Guid("105b6464-3f2c-452d-80b4-4563767eb06d"), new Guid("813e33b6-b648-4ac0-8e45-85dd3ac2841c") },
                    { new Guid("66674da9-980e-454f-8213-c6c919e3d457"), new Guid("813e33b6-b648-4ac0-8e45-85dd3ac2841c") },
                    { new Guid("89e482fd-3289-41ce-ae7a-35bad31c1c7c"), new Guid("813e33b6-b648-4ac0-8e45-85dd3ac2841c") }
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "StageName" },
                values: new object[,]
                {
                    { new Guid("1dc8baef-f113-4da4-92ca-bd9f0b1c66e3"), new Guid("66b7f8f4-fb35-4a32-a4e7-541e16b28c05"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4430), "Geliştirme aşaması için kodlama aşaması", "Kodlama" },
                    { new Guid("2671d8c9-420a-4051-999d-4e089a70b976"), new Guid("66b7f8f4-fb35-4a32-a4e7-541e16b28c05"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4442), "Geliştirme aşaması için test aşaması", "Test" },
                    { new Guid("65755f17-8b0d-47ab-a29f-56684d91679a"), new Guid("813e33b6-b648-4ac0-8e45-85dd3ac2841c"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4400), "Design stage for the blog site project", "Home Page" },
                    { new Guid("6f128f72-b658-4419-b7e0-62997b51e1d9"), new Guid("66b7f8f4-fb35-4a32-a4e7-541e16b28c05"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4426), "Geliştirme aşaması için tasarım aşaması", "Tasarım" },
                    { new Guid("e660d97f-aec5-4d9b-9f39-28d5777aa025"), new Guid("66b7f8f4-fb35-4a32-a4e7-541e16b28c05"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4420), "Geliştirme aşaması için analiz aşaması", "Analiz" },
                    { new Guid("ee9280c0-da7e-438d-8ecd-21daf862a877"), new Guid("813e33b6-b648-4ac0-8e45-85dd3ac2841c"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4409), "Planning stage for the stock tracking project", "Supplier Page" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CreatedOn", "Description", "DueDate", "Priority", "StageId", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("20700244-3622-4e82-96d5-ccae594d79e7"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4619), "Depend job", new DateTime(2024, 6, 10, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4618), 2, new Guid("65755f17-8b0d-47ab-a29f-56684d91679a"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4617), "Depend job" },
                    { new Guid("32c7a1b5-7727-4186-a0ec-59306f9764a4"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4793), "Yapılan analiz çalışmalarının sonuçlarının detaylı bir şekilde dokümante edilmesi", new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("e660d97f-aec5-4d9b-9f39-28d5777aa025"), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analiz sonuçlarının dokümantasyonu" },
                    { new Guid("558cfd99-24a0-42c7-8396-a325f2ea24db"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın işlevsel gereksinimlerinin ayrıntılı bir şekilde belirlenmesi", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("e660d97f-aec5-4d9b-9f39-28d5777aa025"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fonksiyonel gereksinimlerin belirlenmesi" },
                    { new Guid("62831d4e-bb33-426c-a36d-20b6e99924b7"), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kullanıcı arayüzünün ön uç (frontend) bileşenlerinin geliştirilmesi ve entegrasyon testlerinin yapılması", new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("1dc8baef-f113-4da4-92ca-bd9f0b1c66e3"), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frontend komponent geliştirme" },
                    { new Guid("64a99c55-398c-4dba-a237-9ebcdd0846fb"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4825), "Kullanıcı arayüzünde kullanılacak animasyonların hazırlanması ve uygulanması", new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("6f128f72-b658-4419-b7e0-62997b51e1d9"), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arayüz animasyonlarının hazırlanması" },
                    { new Guid("65741ce5-b798-4a8a-bdf2-71b7d53e01ac"), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın farklı bileşenlerinin bir araya getirilerek sistem entegrasyon testlerinin yapılması", new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("2671d8c9-420a-4051-999d-4e089a70b976"), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sistem entegrasyon testlerinin yapılması" },
                    { new Guid("66fe3391-5a73-4bc9-bfdc-2fbfa57cb182"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Müşteri ile bir araya gelerek yazılım gereksinimlerinin detaylı bir şekilde incelenmesi", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("e660d97f-aec5-4d9b-9f39-28d5777aa025"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Müşteri toplantısı ve gereksinimlerin belirlenmesi" },
                    { new Guid("7bbd51d7-a128-4c55-9a7b-3d91331dabf0"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4812), "Kullanıcı arayüzünün kullanılabilirliğinin test edilmesi ve geri bildirimlerin alınması", new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("6f128f72-b658-4419-b7e0-62997b51e1d9"), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arayüzün kullanılabilirlik testlerinin yapılması" },
                    { new Guid("82737806-25cf-4e2e-9295-951a5c12b0ea"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın arka uç (backend) API'larının geliştirilmesi ve test edilmesi", new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("1dc8baef-f113-4da4-92ca-bd9f0b1c66e3"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Backend API geliştirme" },
                    { new Guid("b16e3796-db53-4a80-82e3-e1aafb6b709b"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4773), "Mevcut sistem ve iş süreçlerinin detaylı bir şekilde incelenmesi", new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("e660d97f-aec5-4d9b-9f39-28d5777aa025"), new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mevcut sistem analizi" },
                    { new Guid("b3901f80-643e-4dfd-845d-c449bb11c7fd"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4799), "Yazılımın kullanıcı arayüzü tasarımının ilk mockup'ları oluşturulması", new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("6f128f72-b658-4419-b7e0-62997b51e1d9"), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kullanıcı arayüzünün mockup'larının hazırlanması" },
                    { new Guid("bc347b93-7c21-4a2f-8fdb-f0b9d4497186"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4806), "Kullanılacak renklerin ve renk paletinin belirlenmesi", new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("6f128f72-b658-4419-b7e0-62997b51e1d9"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arayüz tasarımı için renk paletinin belirlenmesi" },
                    { new Guid("c1e9bcfe-4fc5-4365-a82d-44ec32f569de"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4610), "Analyze requirements for the stock tracking project", new DateTime(2024, 6, 10, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4608), 1, new Guid("65755f17-8b0d-47ab-a29f-56684d91679a"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4607), "Requirement Analysis" },
                    { new Guid("cff4aa72-a546-41c6-bad6-25fe352b7af6"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4819), "Tasarım aşamasında alınan geri bildirimler doğrultusunda gerekli revizyonların yapılması", new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("6f128f72-b658-4419-b7e0-62997b51e1d9"), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tasarım revizyonu" },
                    { new Guid("d1e9dd41-aa65-4b54-bcb5-30460b1a7236"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4786), "Müşteri gereksinimlerinin toplanması ve analiz edilmesi", new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("e660d97f-aec5-4d9b-9f39-28d5777aa025"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Müşteri ihtiyaçlarının belirlenmesi" },
                    { new Guid("db738ce5-9193-413e-9895-6eac2e486c79"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kullanıcı arayüzünün revize edilmesi ve geliştirilmiş bir versiyonunun hazırlanması", new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("6f128f72-b658-4419-b7e0-62997b51e1d9"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arayüz tasarım revizyonu" },
                    { new Guid("ecb1ac74-7d07-479a-ba2d-866424eeebb3"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4597), "Design user interface for the blog site", new DateTime(2024, 6, 3, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4593), 0, new Guid("ee9280c0-da7e-438d-8ecd-21daf862a877"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4592), "Design UI" },
                    { new Guid("f874fdb7-b8d0-43cb-8d3f-d2d250bba44b"), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın test edilmesi için birinci aşama test senaryolarının hazırlanması", new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("2671d8c9-420a-4051-999d-4e089a70b976"), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Birinci aşama test senaryolarının hazırlanması" },
                    { new Guid("f9d56a2f-3b39-4d14-816e-680d13ec62dd"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın prototipinin tasarlanması ve kullanıcı geri bildirimlerinin alınması", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("6f128f72-b658-4419-b7e0-62997b51e1d9"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prototip tasarımı" }
                });

            migrationBuilder.InsertData(
                table: "Dependencies",
                columns: new[] { "Id", "CreatedOn", "DependsOnJobId", "JobId" },
                values: new object[] { new Guid("be3e89b5-d0ae-4b39-8d62-876b6e1d7097"), new DateTime(2024, 5, 27, 21, 7, 42, 932, DateTimeKind.Local).AddTicks(4960), new Guid("c1e9bcfe-4fc5-4365-a82d-44ec32f569de"), new Guid("20700244-3622-4e82-96d5-ccae594d79e7") });

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
