using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectManagement.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class initialdb : Migration
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
                    AssignedTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { new Guid("5d73cc5a-ace9-4b68-9679-435a9f778586"), null, new DateTime(2024, 5, 14, 20, 15, 1, 203, DateTimeKind.Local).AddTicks(6736), "user", "USER" },
                    { new Guid("875ec79f-0081-4320-bbea-851c2de4fe24"), null, new DateTime(2024, 5, 14, 20, 15, 1, 203, DateTimeKind.Local).AddTicks(6721), "admin", "ADMIN" },
                    { new Guid("96e5a4de-0181-4008-83f0-11becab3ce9b"), null, new DateTime(2024, 5, 14, 20, 15, 1, 203, DateTimeKind.Local).AddTicks(6738), "project-user", "PROJECT-USER" },
                    { new Guid("ed3ac3ab-92f8-4a93-a45b-a25f0b4291c9"), null, new DateTime(2024, 5, 14, 20, 15, 1, 203, DateTimeKind.Local).AddTicks(6733), "project-manager", "PROJECT-MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("19fe6394-63c9-4c6b-b4ba-0081a864ac71"), 0, new DateTime(2024, 5, 14, 20, 15, 1, 203, DateTimeKind.Local).AddTicks(6954), "5d28fcd9-edfd-4805-8110-69e7689454cc", new DateTime(2024, 5, 14, 20, 15, 1, 203, DateTimeKind.Local).AddTicks(6955), "admin@gmail.com", false, "Furkan", 1, "Aydin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEO/CWQMy5Sf6NeZ20e3JNgjVLa+XxwpN0cvcVIimkuyo8yxSssZKZL++SgxEaUT78w==", null, false, "6283a492-684d-4f77-8335-8839bf1bf2fd", false, "admin" },
                    { new Guid("1d976577-2553-4c21-b1d9-681f31601d53"), 0, new DateTime(2024, 5, 14, 20, 15, 1, 203, DateTimeKind.Local).AddTicks(6971), "cecb6f4a-7709-4ee9-9c77-5dfce00faa97", new DateTime(2024, 5, 14, 20, 15, 1, 203, DateTimeKind.Local).AddTicks(6972), "ayseyildiz@gmail.com", false, "Ayse", 2, "Yildiz", false, null, "AYSEYILDIZ@GMAIL.COM", "AYSEYILDIZ123", "AQAAAAIAAYagAAAAEAA1yBP6BlvkpcP3xykXdoCYc5zAXXPrExr+E6mnE7clXsuBO9J/ADfk2t4sNfWY1Q==", null, false, "e7ea7f1a-d5c0-4654-b1f9-1fc1b119a517", false, "ayseyildiz123" },
                    { new Guid("33c511d8-05fe-41cf-934a-1f662d685458"), 0, new DateTime(2024, 5, 14, 20, 15, 1, 203, DateTimeKind.Local).AddTicks(6965), "411a419e-a00b-496a-80c6-cfdf01329584", new DateTime(2024, 5, 14, 20, 15, 1, 203, DateTimeKind.Local).AddTicks(6965), "aliyildiz@gmail.com", false, "Ali", 1, "Yildiz ", false, null, "ALIYILDIZ@GMAIL.COM", "ALIYILDIZ123", "AQAAAAIAAYagAAAAEHgFZK6ZcBqB5CDBnYGuHvcjdt46B3f1eWFGWUxZg7Z0nBJYPL7gicsk16vQOl1E6g==", null, false, "c6a12ad0-1fac-4243-ac29-8c4c96554e08", false, "aliyildiz123" },
                    { new Guid("4ba66a92-d3bf-4321-b7a2-f9041635edb7"), 0, new DateTime(2024, 5, 14, 20, 15, 1, 203, DateTimeKind.Local).AddTicks(6977), "5a0adf21-48ce-4153-9bfb-eabdb956894b", new DateTime(2024, 5, 14, 20, 15, 1, 203, DateTimeKind.Local).AddTicks(6978), "esrefyildiz@gmail.com", false, "Esref", 2, "Yildiz", false, null, "ESREFYILDIZ@GMAIL.COM", "ESREFYILDIZ123", "AQAAAAIAAYagAAAAEPwRXppIwx9ReqebiJcfXN4S1ptl9qsmo6EBFmXnXAD8T6yMysnnKACpGTl7fE7Erw==", null, false, "66c93748-fd2e-4c28-8d97-85e1dfbaa080", false, "esrefyildiz123" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedOn", "Description", "EndDate", "ProjectName", "StartDate", "Status" },
                values: new object[,]
                {
                    { new Guid("6bee95c8-59ca-49f5-9a55-196eea3f3675"), new DateTime(2024, 5, 14, 20, 15, 1, 511, DateTimeKind.Local).AddTicks(7838), "A project to create a blog site", new DateTime(2024, 6, 13, 20, 15, 1, 511, DateTimeKind.Local).AddTicks(7832), "Blog Site Project", new DateTime(2024, 5, 14, 20, 15, 1, 511, DateTimeKind.Local).AddTicks(7831), "InProgress" },
                    { new Guid("db141a69-550e-41b6-8b05-6b96bbc401bf"), new DateTime(2024, 5, 14, 20, 15, 1, 511, DateTimeKind.Local).AddTicks(7843), "A project to develop a stock tracking system", new DateTime(2024, 7, 13, 20, 15, 1, 511, DateTimeKind.Local).AddTicks(7842), "Stock Tracking Project", new DateTime(2024, 5, 14, 20, 15, 1, 511, DateTimeKind.Local).AddTicks(7842), "Planning" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("875ec79f-0081-4320-bbea-851c2de4fe24"), new Guid("19fe6394-63c9-4c6b-b4ba-0081a864ac71") },
                    { new Guid("5d73cc5a-ace9-4b68-9679-435a9f778586"), new Guid("1d976577-2553-4c21-b1d9-681f31601d53") },
                    { new Guid("ed3ac3ab-92f8-4a93-a45b-a25f0b4291c9"), new Guid("33c511d8-05fe-41cf-934a-1f662d685458") },
                    { new Guid("96e5a4de-0181-4008-83f0-11becab3ce9b"), new Guid("4ba66a92-d3bf-4321-b7a2-f9041635edb7") }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "CreatedOn", "ProjectId", "Title" },
                values: new object[] { new Guid("3fd76230-4287-460f-bcaf-6adffb1588a4"), new DateTime(2024, 5, 14, 20, 15, 1, 512, DateTimeKind.Local).AddTicks(349), new Guid("db141a69-550e-41b6-8b05-6b96bbc401bf"), "Front-end board" });

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "CreatedOn", "Date", "Description", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("c7035b83-34a8-4db8-9449-a280d1384db9"), 500.00m, new DateTime(2024, 5, 14, 20, 15, 1, 512, DateTimeKind.Local).AddTicks(817), new DateTime(2024, 5, 14, 20, 15, 1, 512, DateTimeKind.Local).AddTicks(803), "Sample cost", new Guid("6bee95c8-59ca-49f5-9a55-196eea3f3675") },
                    { new Guid("ee6f1afd-788a-4ec0-954a-edc2e47c5ce0"), 200.00m, new DateTime(2024, 5, 14, 20, 15, 1, 512, DateTimeKind.Local).AddTicks(867), new DateTime(2024, 5, 14, 20, 15, 1, 512, DateTimeKind.Local).AddTicks(867), "Sample cost", new Guid("db141a69-550e-41b6-8b05-6b96bbc401bf") }
                });

            migrationBuilder.InsertData(
                table: "ProjectUserAssociations",
                columns: new[] { "ProjectId", "UserId" },
                values: new object[,]
                {
                    { new Guid("6bee95c8-59ca-49f5-9a55-196eea3f3675"), new Guid("33c511d8-05fe-41cf-934a-1f662d685458") },
                    { new Guid("6bee95c8-59ca-49f5-9a55-196eea3f3675"), new Guid("4ba66a92-d3bf-4321-b7a2-f9041635edb7") },
                    { new Guid("db141a69-550e-41b6-8b05-6b96bbc401bf"), new Guid("1d976577-2553-4c21-b1d9-681f31601d53") },
                    { new Guid("db141a69-550e-41b6-8b05-6b96bbc401bf"), new Guid("33c511d8-05fe-41cf-934a-1f662d685458") }
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "StageName" },
                values: new object[,]
                {
                    { new Guid("1844ad5e-40e0-4b97-8637-4039e735e79e"), new Guid("3fd76230-4287-460f-bcaf-6adffb1588a4"), new DateTime(2024, 5, 14, 20, 15, 1, 512, DateTimeKind.Local).AddTicks(570), "Design stage for the blog site project", "Home Page" },
                    { new Guid("a868a6c7-3177-46b2-9a60-910798bd12cc"), new Guid("3fd76230-4287-460f-bcaf-6adffb1588a4"), new DateTime(2024, 5, 14, 20, 15, 1, 512, DateTimeKind.Local).AddTicks(574), "Planning stage for the stock tracking project", "Supplier Page" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "AssignedTo", "CreatedOn", "Description", "DueDate", "Priority", "StageId", "StartDate", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("5507f6d8-b8ca-4883-bb97-37525f04b14c"), "John Doe", new DateTime(2024, 5, 14, 20, 15, 1, 512, DateTimeKind.Local).AddTicks(642), "Design user interface for the blog site", new DateTime(2024, 5, 21, 20, 15, 1, 512, DateTimeKind.Local).AddTicks(638), 1, new Guid("a868a6c7-3177-46b2-9a60-910798bd12cc"), new DateTime(2024, 5, 14, 20, 15, 1, 512, DateTimeKind.Local).AddTicks(637), "ToDo", "Design UI" },
                    { new Guid("7f2f5f8e-5f37-479e-9c15-a6612335caa3"), "John Doe", new DateTime(2024, 5, 14, 20, 15, 1, 512, DateTimeKind.Local).AddTicks(655), "Analyze requirements for the stock tracking project", new DateTime(2024, 5, 28, 20, 15, 1, 512, DateTimeKind.Local).AddTicks(654), 2, new Guid("1844ad5e-40e0-4b97-8637-4039e735e79e"), new DateTime(2024, 5, 14, 20, 15, 1, 512, DateTimeKind.Local).AddTicks(653), "InProgress", "Requirement Analysis" },
                    { new Guid("e756f68e-b3bb-471a-8545-09e3994824ec"), "John Doe", new DateTime(2024, 5, 14, 20, 15, 1, 512, DateTimeKind.Local).AddTicks(659), "Depend job", new DateTime(2024, 5, 28, 20, 15, 1, 512, DateTimeKind.Local).AddTicks(658), 2, new Guid("1844ad5e-40e0-4b97-8637-4039e735e79e"), new DateTime(2024, 5, 14, 20, 15, 1, 512, DateTimeKind.Local).AddTicks(658), "Pending", "Depend job" }
                });

            migrationBuilder.InsertData(
                table: "Dependencies",
                columns: new[] { "Id", "CreatedOn", "DependsOnJobId", "JobId" },
                values: new object[] { new Guid("db44dc7d-ed26-4822-8f69-8c228060a43c"), new DateTime(2024, 5, 14, 20, 15, 1, 512, DateTimeKind.Local).AddTicks(751), new Guid("7f2f5f8e-5f37-479e-9c15-a6612335caa3"), new Guid("e756f68e-b3bb-471a-8545-09e3994824ec") });

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
