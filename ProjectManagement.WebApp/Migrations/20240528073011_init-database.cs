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
                    { new Guid("76fb22f4-6e8d-42cf-9693-0af1d2b0180e"), null, new DateTime(2024, 5, 28, 10, 30, 9, 506, DateTimeKind.Local).AddTicks(7806), "admin", "ADMIN" },
                    { new Guid("a5acdb31-47b7-4a48-8e45-9042cc7b91a2"), null, new DateTime(2024, 5, 28, 10, 30, 9, 506, DateTimeKind.Local).AddTicks(7826), "user", "USER" },
                    { new Guid("c029b901-6b4d-4528-b8d8-6d29f6f6ea9b"), null, new DateTime(2024, 5, 28, 10, 30, 9, 506, DateTimeKind.Local).AddTicks(7822), "project-manager", "PROJECT-MANAGER" },
                    { new Guid("c8bd4ca3-220f-4d11-8f38-8fb71500f279"), null, new DateTime(2024, 5, 28, 10, 30, 9, 506, DateTimeKind.Local).AddTicks(7829), "project-user", "PROJECT-USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("03f5e372-39a2-4e36-b34a-1a0830d1262a"), 0, new DateTime(2024, 5, 28, 10, 30, 9, 506, DateTimeKind.Local).AddTicks(8376), "6655acca-8190-44ad-8c2d-a87f804282a0", new DateTime(2024, 5, 28, 10, 30, 9, 506, DateTimeKind.Local).AddTicks(8376), "aliyildiz@gmail.com", false, "Ali", 1, "Yildiz ", false, null, "ALIYILDIZ@GMAIL.COM", "ALIYILDIZ123", "AQAAAAIAAYagAAAAENUQP2two63rQ40nz8S0LI+7Q15TPSGzoZV1R9F6UnMe5UC98BgoFPb+SkV6Lv2ylA==", null, false, "a5b4d684-026a-4a29-89d4-1a074bd38460", false, "aliyildiz123" },
                    { new Guid("0ad2acad-1619-4992-b977-4a5daf90a614"), 0, new DateTime(2024, 5, 28, 10, 30, 9, 506, DateTimeKind.Local).AddTicks(8422), "ace24aed-5d38-4bf5-8a6e-6d885e7cc301", new DateTime(2024, 5, 28, 10, 30, 9, 506, DateTimeKind.Local).AddTicks(8423), "firatcanyanan@gmail.com", false, "Firat Can", 1, "Yanan", false, null, "FIRATCANYANAN@GMAIL.COM", "FIRATCANYANAN123", "AQAAAAIAAYagAAAAEJL3UHrb8vOq0H/tG5aEXdSbwGANEvChnL7UmzawkMd77nt6yAJDdhzd2H9yIpgEpA==", null, false, "ea88d5f0-8197-486a-9c12-ace4b6664e00", false, "firatcanyanan123" },
                    { new Guid("1a2f9943-50bc-40ad-bff8-a7a20d22cb32"), 0, new DateTime(2024, 5, 28, 10, 30, 9, 506, DateTimeKind.Local).AddTicks(8404), "d85bc7fa-e1d8-4572-a621-d97120ab016e", new DateTime(2024, 5, 28, 10, 30, 9, 506, DateTimeKind.Local).AddTicks(8405), "esrefyildiz@gmail.com", false, "Esref", 2, "Yildiz", false, null, "ESREFYILDIZ@GMAIL.COM", "ESREFYILDIZ123", "AQAAAAIAAYagAAAAELSzkQ0Q8WxpfwLx2j5yD0xzQ/vYIlLEN6tndS7/b1snw06GS/VTSV7V3VBjdYmY9Q==", null, false, "c492c864-e027-4435-83ce-4a2ba220fc5b", false, "esrefyildiz123" },
                    { new Guid("2afbd0dc-6e7c-4f95-8573-b88451832861"), 0, new DateTime(2024, 5, 28, 10, 30, 9, 506, DateTimeKind.Local).AddTicks(8352), "33b06a61-6daa-44a5-8ce4-91aa6f24d337", new DateTime(2024, 5, 28, 10, 30, 9, 506, DateTimeKind.Local).AddTicks(8353), "admin@gmail.com", false, "Furkan", 1, "Aydin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEPN+Yalz5e8jGdPA+5jRbYKPWqlVU/AAnW+h8RSZxAgQNyrmqvPlDX/u5rSYV4A+BQ==", null, false, "998b9193-6ec6-4fbd-bca5-45f1469fc392", false, "admin" },
                    { new Guid("420a7c24-87a7-4ca0-be30-c754fda31bf9"), 0, new DateTime(2024, 5, 28, 10, 30, 9, 506, DateTimeKind.Local).AddTicks(8396), "0b028e71-8f59-4678-aa3e-781f5b1ca017", new DateTime(2024, 5, 28, 10, 30, 9, 506, DateTimeKind.Local).AddTicks(8397), "ayseyildiz@gmail.com", false, "Ayse", 2, "Yildiz", false, null, "AYSEYILDIZ@GMAIL.COM", "AYSEYILDIZ123", "AQAAAAIAAYagAAAAEDkF8D3Arem+AjiufmF0lAZfVK0rfLNFg7zOWlr4xTx9m36/ZnK0Bw6Y6soKSW6rSA==", null, false, "5dfe1b65-8e97-49a0-9332-869acd477cf3", false, "ayseyildiz123" },
                    { new Guid("dc8ab12a-68fb-468a-a766-e5e7da7f7260"), 0, new DateTime(2024, 5, 28, 10, 30, 9, 506, DateTimeKind.Local).AddTicks(8412), "77f36f32-fe30-470c-8cd2-7f1b44c6d05d", new DateTime(2024, 5, 28, 10, 30, 9, 506, DateTimeKind.Local).AddTicks(8413), "furkanaydin@gmail.com", false, "Furkan", 1, "Aydin", false, null, "FURKANAYDIN@GMAIL.COM", "FURKANAYDIN123", "AQAAAAIAAYagAAAAED6ZNoIvEwhWaInCsGHcwOq5bT6B8/azt3AdpXrqLioeZYaPl7951f51eEilNcRVew==", null, false, "bd854ec8-f897-48f4-b798-496661fdf7ff", false, "furkanaydin123" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedOn", "Description", "EndDate", "ProjectName", "StartDate" },
                values: new object[,]
                {
                    { new Guid("4a316be8-ab81-4847-a201-13fc064c9bb6"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5235), "Yeni bir ürünün pazarlama stratejisinin oluşturulması", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pazarlama Kampanyası", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("729b0c34-08f7-4370-a9c6-4e3a9230f166"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5214), "A project to create a blog site", new DateTime(2024, 6, 27, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5206), "Blog Site Project", new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5205) },
                    { new Guid("796454b0-df51-4632-b939-67e684481bdb"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5228), "Bir yazılım ürününün geliştirilmesi", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılım Projesi", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ada1db72-e2e4-4090-9123-5287ca0c4c63"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5221), "A project to develop a stock tracking system", new DateTime(2024, 7, 27, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5220), "Stock Tracking Project", new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5219) },
                    { new Guid("d7268817-9b98-4cea-8d90-8d30b6116eb3"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5239), "Yeni bir ürünün tasarım sürecinin yürütülmesi", new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yeni Ürün Tasarımı", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("c029b901-6b4d-4528-b8d8-6d29f6f6ea9b"), new Guid("03f5e372-39a2-4e36-b34a-1a0830d1262a") },
                    { new Guid("c8bd4ca3-220f-4d11-8f38-8fb71500f279"), new Guid("0ad2acad-1619-4992-b977-4a5daf90a614") },
                    { new Guid("c8bd4ca3-220f-4d11-8f38-8fb71500f279"), new Guid("1a2f9943-50bc-40ad-bff8-a7a20d22cb32") },
                    { new Guid("76fb22f4-6e8d-42cf-9693-0af1d2b0180e"), new Guid("2afbd0dc-6e7c-4f95-8573-b88451832861") },
                    { new Guid("c8bd4ca3-220f-4d11-8f38-8fb71500f279"), new Guid("420a7c24-87a7-4ca0-be30-c754fda31bf9") },
                    { new Guid("c8bd4ca3-220f-4d11-8f38-8fb71500f279"), new Guid("dc8ab12a-68fb-468a-a766-e5e7da7f7260") }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "CreatedOn", "ProjectId", "Title" },
                values: new object[,]
                {
                    { new Guid("2ab3fa67-0253-407e-b9eb-6c7dd83d15a0"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5515), new Guid("ada1db72-e2e4-4090-9123-5287ca0c4c63"), "Front-end board" },
                    { new Guid("e0b826b6-ca39-4aaf-a312-5c57dfd41b23"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5520), new Guid("ada1db72-e2e4-4090-9123-5287ca0c4c63"), "Back-end board" },
                    { new Guid("e14ee853-2d2e-4dfc-b3f8-4672151389bd"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5525), new Guid("796454b0-df51-4632-b939-67e684481bdb"), "Geliştirme" },
                    { new Guid("e48423ba-141b-4894-8a30-ad0224d537bc"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5522), new Guid("796454b0-df51-4632-b939-67e684481bdb"), "Analiz" }
                });

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "CreatedOn", "Date", "Description", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("b1d06cf9-0b4f-40c9-8415-cb64337ff289"), 500.00m, new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(6022), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(6021), "Sample cost", new Guid("729b0c34-08f7-4370-a9c6-4e3a9230f166") },
                    { new Guid("e0f75ca4-5922-4e1c-a801-badb66d9df67"), 200.00m, new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(6082), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(6081), "Sample cost", new Guid("ada1db72-e2e4-4090-9123-5287ca0c4c63") }
                });

            migrationBuilder.InsertData(
                table: "ProjectUserAssociations",
                columns: new[] { "ProjectId", "UserId" },
                values: new object[,]
                {
                    { new Guid("729b0c34-08f7-4370-a9c6-4e3a9230f166"), new Guid("03f5e372-39a2-4e36-b34a-1a0830d1262a") },
                    { new Guid("796454b0-df51-4632-b939-67e684481bdb"), new Guid("03f5e372-39a2-4e36-b34a-1a0830d1262a") },
                    { new Guid("796454b0-df51-4632-b939-67e684481bdb"), new Guid("dc8ab12a-68fb-468a-a766-e5e7da7f7260") },
                    { new Guid("ada1db72-e2e4-4090-9123-5287ca0c4c63"), new Guid("03f5e372-39a2-4e36-b34a-1a0830d1262a") },
                    { new Guid("ada1db72-e2e4-4090-9123-5287ca0c4c63"), new Guid("0ad2acad-1619-4992-b977-4a5daf90a614") },
                    { new Guid("ada1db72-e2e4-4090-9123-5287ca0c4c63"), new Guid("1a2f9943-50bc-40ad-bff8-a7a20d22cb32") },
                    { new Guid("ada1db72-e2e4-4090-9123-5287ca0c4c63"), new Guid("420a7c24-87a7-4ca0-be30-c754fda31bf9") },
                    { new Guid("ada1db72-e2e4-4090-9123-5287ca0c4c63"), new Guid("dc8ab12a-68fb-468a-a766-e5e7da7f7260") }
                });

            migrationBuilder.InsertData(
                table: "BoardUserAssociations",
                columns: new[] { "AppUserId", "BoardId" },
                values: new object[,]
                {
                    { new Guid("0ad2acad-1619-4992-b977-4a5daf90a614"), new Guid("2ab3fa67-0253-407e-b9eb-6c7dd83d15a0") },
                    { new Guid("1a2f9943-50bc-40ad-bff8-a7a20d22cb32"), new Guid("2ab3fa67-0253-407e-b9eb-6c7dd83d15a0") },
                    { new Guid("dc8ab12a-68fb-468a-a766-e5e7da7f7260"), new Guid("2ab3fa67-0253-407e-b9eb-6c7dd83d15a0") }
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "StageName" },
                values: new object[,]
                {
                    { new Guid("0ddb9cd1-3c8a-4820-b9cf-6a1350c57917"), new Guid("e14ee853-2d2e-4dfc-b3f8-4672151389bd"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5627), "Geliştirme aşaması için tasarım aşaması", "Tasarım" },
                    { new Guid("420c7020-5cbe-42d0-8d3d-dad93c32503c"), new Guid("e14ee853-2d2e-4dfc-b3f8-4672151389bd"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5639), "Geliştirme aşaması için test aşaması", "Test" },
                    { new Guid("43d5c2fd-177b-49b2-aa6a-af99bc8939d6"), new Guid("e14ee853-2d2e-4dfc-b3f8-4672151389bd"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5630), "Geliştirme aşaması için kodlama aşaması", "Kodlama" },
                    { new Guid("a0de56bc-2336-4166-a08d-6e53721e5d36"), new Guid("e14ee853-2d2e-4dfc-b3f8-4672151389bd"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5624), "Geliştirme aşaması için analiz aşaması", "Analiz" },
                    { new Guid("c45d2652-7d1b-4e8a-b817-598f2397a6c8"), new Guid("2ab3fa67-0253-407e-b9eb-6c7dd83d15a0"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5617), "Planning stage for the stock tracking project", "Supplier Page" },
                    { new Guid("dc875141-5dbf-467e-8c5b-fd3abf8bb221"), new Guid("2ab3fa67-0253-407e-b9eb-6c7dd83d15a0"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5610), "Design stage for the blog site project", "Home Page" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CreatedOn", "Description", "DueDate", "Priority", "StageId", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("06b8f036-71cd-4742-b837-2339cebe3e77"), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kullanıcı arayüzünün ön uç (frontend) bileşenlerinin geliştirilmesi ve entegrasyon testlerinin yapılması", new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("43d5c2fd-177b-49b2-aa6a-af99bc8939d6"), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frontend komponent geliştirme" },
                    { new Guid("0ccf3a4c-b13e-45c1-986d-94fda1b8a856"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5757), "Depend job", new DateTime(2024, 6, 11, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5756), 2, new Guid("dc875141-5dbf-467e-8c5b-fd3abf8bb221"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5755), "Depend job" },
                    { new Guid("16f200b7-defc-4416-8dc1-09b4d5978baf"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5866), "Mevcut sistem ve iş süreçlerinin detaylı bir şekilde incelenmesi", new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("a0de56bc-2336-4166-a08d-6e53721e5d36"), new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mevcut sistem analizi" },
                    { new Guid("17cc2b0b-1669-4fa6-95c6-a8ea59e3790a"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın arka uç (backend) API'larının geliştirilmesi ve test edilmesi", new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("43d5c2fd-177b-49b2-aa6a-af99bc8939d6"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Backend API geliştirme" },
                    { new Guid("19d0a077-c41e-4e71-980e-8383d45c4be9"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kullanıcı arayüzünün revize edilmesi ve geliştirilmiş bir versiyonunun hazırlanması", new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("0ddb9cd1-3c8a-4820-b9cf-6a1350c57917"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arayüz tasarım revizyonu" },
                    { new Guid("1aaac5ba-40e7-4917-81de-8d635d7160ef"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5887), "Kullanılacak renklerin ve renk paletinin belirlenmesi", new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("0ddb9cd1-3c8a-4820-b9cf-6a1350c57917"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arayüz tasarımı için renk paletinin belirlenmesi" },
                    { new Guid("231ce421-7ccf-4145-be51-e00f0713cb6a"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5901), "Kullanıcı arayüzünde kullanılacak animasyonların hazırlanması ve uygulanması", new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("0ddb9cd1-3c8a-4820-b9cf-6a1350c57917"), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arayüz animasyonlarının hazırlanması" },
                    { new Guid("2d35681d-2073-4bd8-8065-69413bedf698"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın prototipinin tasarlanması ve kullanıcı geri bildirimlerinin alınması", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("0ddb9cd1-3c8a-4820-b9cf-6a1350c57917"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prototip tasarımı" },
                    { new Guid("2fcadfb0-7e02-4400-b5c7-2248fb2cf669"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5751), "Analyze requirements for the stock tracking project", new DateTime(2024, 6, 11, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5750), 1, new Guid("dc875141-5dbf-467e-8c5b-fd3abf8bb221"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5749), "Requirement Analysis" },
                    { new Guid("4dc0e73d-efbe-441d-880e-6d5c390eb90d"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Müşteri ile bir araya gelerek yazılım gereksinimlerinin detaylı bir şekilde incelenmesi", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("a0de56bc-2336-4166-a08d-6e53721e5d36"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Müşteri toplantısı ve gereksinimlerin belirlenmesi" },
                    { new Guid("8367c574-7552-4c3b-bf0a-53b54f6e8753"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5741), "Design user interface for the blog site", new DateTime(2024, 6, 4, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5739), 0, new Guid("c45d2652-7d1b-4e8a-b817-598f2397a6c8"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5738), "Design UI" },
                    { new Guid("ae38e42e-b5af-4cc8-8d15-b171807a9e91"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5892), "Kullanıcı arayüzünün kullanılabilirliğinin test edilmesi ve geri bildirimlerin alınması", new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("0ddb9cd1-3c8a-4820-b9cf-6a1350c57917"), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arayüzün kullanılabilirlik testlerinin yapılması" },
                    { new Guid("b7c66623-82b1-4497-9830-4a803d8b6321"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5873), "Müşteri gereksinimlerinin toplanması ve analiz edilmesi", new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("a0de56bc-2336-4166-a08d-6e53721e5d36"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Müşteri ihtiyaçlarının belirlenmesi" },
                    { new Guid("bba0d7f4-3479-4983-812a-62dfbf7fce32"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın işlevsel gereksinimlerinin ayrıntılı bir şekilde belirlenmesi", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("a0de56bc-2336-4166-a08d-6e53721e5d36"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fonksiyonel gereksinimlerin belirlenmesi" },
                    { new Guid("bde2d258-4c86-459f-88d9-f5d4f0f2b599"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5883), "Yazılımın kullanıcı arayüzü tasarımının ilk mockup'ları oluşturulması", new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("0ddb9cd1-3c8a-4820-b9cf-6a1350c57917"), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kullanıcı arayüzünün mockup'larının hazırlanması" },
                    { new Guid("c1618ffb-52a1-4d9b-8207-1bcab7aac751"), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın test edilmesi için birinci aşama test senaryolarının hazırlanması", new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("420c7020-5cbe-42d0-8d3d-dad93c32503c"), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Birinci aşama test senaryolarının hazırlanması" },
                    { new Guid("c3e7e194-fa5f-45ac-829f-47c3550229c4"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5896), "Tasarım aşamasında alınan geri bildirimler doğrultusunda gerekli revizyonların yapılması", new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("0ddb9cd1-3c8a-4820-b9cf-6a1350c57917"), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tasarım revizyonu" },
                    { new Guid("ed2f4959-6caa-40dd-83c9-a9cf21560443"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5878), "Yapılan analiz çalışmalarının sonuçlarının detaylı bir şekilde dokümante edilmesi", new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("a0de56bc-2336-4166-a08d-6e53721e5d36"), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analiz sonuçlarının dokümantasyonu" },
                    { new Guid("f4228397-4833-4175-895d-15c40af2dccf"), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılımın farklı bileşenlerinin bir araya getirilerek sistem entegrasyon testlerinin yapılması", new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("420c7020-5cbe-42d0-8d3d-dad93c32503c"), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sistem entegrasyon testlerinin yapılması" }
                });

            migrationBuilder.InsertData(
                table: "Dependencies",
                columns: new[] { "Id", "CreatedOn", "DependsOnJobId", "JobId" },
                values: new object[] { new Guid("a418e767-f008-47ab-8570-75cfde065ae3"), new DateTime(2024, 5, 28, 10, 30, 10, 115, DateTimeKind.Local).AddTicks(5977), new Guid("2fcadfb0-7e02-4400-b5c7-2248fb2cf669"), new Guid("0ccf3a4c-b13e-45c1-986d-94fda1b8a856") });

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
