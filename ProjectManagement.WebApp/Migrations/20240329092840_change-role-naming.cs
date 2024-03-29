using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectManagement.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class changerolenaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("75e5efee-8bed-43a4-b035-50c547827b44"), new Guid("040b4803-d368-498c-b39a-24e00fc11646") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5000e059-d22d-45ff-9fda-6e1c6ddd713a"), new Guid("5de56315-2f1d-43fe-a048-af5eebc55224") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b448a029-79b6-4c74-adb7-c674252232ae"), new Guid("85661ea0-f42b-486c-8e94-d7b1c47e0479") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2a9ba7a8-70ed-4328-9ca2-ad02f19a25fc"), new Guid("a50d95be-ff44-48ed-a783-bf3eb335b4fb") });

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("2a861c30-05a9-4eea-a543-d862e139d668"));

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("d3294dd7-9609-4760-a972-3317b1364e2f"));

            migrationBuilder.DeleteData(
                table: "Dependencies",
                keyColumn: "Id",
                keyValue: new Guid("58a9ea69-1b4c-4c7f-861c-bf29747a12e6"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("4147dea3-1ef7-439e-b6eb-a1a5ae9e6876"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("debee053-3b83-4275-9e4d-151c4a959a25"));

            migrationBuilder.DeleteData(
                table: "ProjectUserAssociation",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { new Guid("29be38b8-7068-4759-a282-ef566b2a4978"), new Guid("85661ea0-f42b-486c-8e94-d7b1c47e0479") });

            migrationBuilder.DeleteData(
                table: "ProjectUserAssociation",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { new Guid("29be38b8-7068-4759-a282-ef566b2a4978"), new Guid("a50d95be-ff44-48ed-a783-bf3eb335b4fb") });

            migrationBuilder.DeleteData(
                table: "ProjectUserAssociation",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { new Guid("e955869b-0ab1-4eb3-a89b-4598680e86b1"), new Guid("040b4803-d368-498c-b39a-24e00fc11646") });

            migrationBuilder.DeleteData(
                table: "ProjectUserAssociation",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { new Guid("e955869b-0ab1-4eb3-a89b-4598680e86b1"), new Guid("85661ea0-f42b-486c-8e94-d7b1c47e0479") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2a9ba7a8-70ed-4328-9ca2-ad02f19a25fc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5000e059-d22d-45ff-9fda-6e1c6ddd713a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("75e5efee-8bed-43a4-b035-50c547827b44"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b448a029-79b6-4c74-adb7-c674252232ae"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("040b4803-d368-498c-b39a-24e00fc11646"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5de56315-2f1d-43fe-a048-af5eebc55224"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("85661ea0-f42b-486c-8e94-d7b1c47e0479"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a50d95be-ff44-48ed-a783-bf3eb335b4fb"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("696060cc-bf69-4ee3-8b92-a737c34c34fa"));

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: new Guid("f91bc255-ef4c-48eb-a877-eb4916505d90"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("e955869b-0ab1-4eb3-a89b-4598680e86b1"));

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: new Guid("bda3c392-acdb-4f9d-9375-abda2189633f"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("29be38b8-7068-4759-a282-ef566b2a4978"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedOn", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("130fb7c3-67e2-497c-853a-e1fd3ddbd55c"), null, new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1187), "user", "USER" },
                    { new Guid("63d9cc3b-c6ac-48dc-ae6d-b9da6f28744b"), null, new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1173), "admin", "ADMIN" },
                    { new Guid("7023a59e-968c-4a30-9269-29612a6ad2ed"), null, new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1189), "project-user", "PROJECT-USER" },
                    { new Guid("71b83e0d-2a79-46d2-b04d-3cef44ddae9c"), null, new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1185), "project-manager", "PROJECT-MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("2591192c-f0cc-41ee-8f3a-ec0652ec926a"), 0, new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1359), "4809970f-9f2f-4090-8cec-bce38f6a2366", new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1360), "ayseyildiz@gmail.com", false, "Ayse", 2, "Yildiz", false, null, "AYSEYILDIZ@GMAIL.COM", "AYSEYILDIZ123", "AQAAAAIAAYagAAAAEFrRRLOq35FxE4aBZbCBb3sVJmmTOGNrkeLf8E0kfzHqxCbC7Dkh3CYfyhXKaLa7Ow==", null, false, "fba52f14-ac22-4544-8a0f-3ce6b60ce924", false, "ayseyildiz123" },
                    { new Guid("8eb125cc-8df0-4437-966f-fe37baa01cce"), 0, new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1342), "c0cb0ab4-6559-4660-bf47-9ae57effca66", new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1343), "admin@gmail.com", false, "Furkan", 1, "Aydin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEJYeoNuD8bA/8yLSYJ/CRr7PmkGh5sMS7tPqoJ2ulw8Ic31eV3/hA3GM52uhxVyijw==", null, false, "04ae181f-c8f4-47f2-9774-f97b90c73524", false, "admin" },
                    { new Guid("cee52ce3-88c9-4521-8d54-e2602f20adac"), 0, new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1365), "71498616-7281-400f-8853-21d453a00736", new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1366), "esrefyildiz@gmail.com", false, "Esref", 2, "Yildiz", false, null, "ESREFYILDIZ@GMAIL.COM", "ESREFYILDIZ123", "AQAAAAIAAYagAAAAEHd7PBv6/XmjVgQgmwoijA4pBpJ/eNm8VYbQ4XCGsxTNhdmi4NEt1/6L6MFDH2q2XA==", null, false, "b99a7e91-18a7-4fb4-8512-a5b57eaef2c5", false, "esrefyildiz123" },
                    { new Guid("ec8a8eb4-c286-458d-acdc-642d7a7f9140"), 0, new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1350), "86d96d5a-df0d-4610-9219-5951dc861fbb", new DateTime(2024, 3, 29, 12, 28, 39, 355, DateTimeKind.Local).AddTicks(1351), "aliyildiz@gmail.com", false, "Ali", 1, "Yildiz ", false, null, "ALIYILDIZ@GMAIL.COM", "ALIYILDIZ123", "AQAAAAIAAYagAAAAEL8MkyOXXO/3xVXFHgYVRDWZM/nzgjxUzRn+34UWljezttvdWlPH/LIMzM6dZunJcA==", null, false, "9bbfe04e-8d59-44c7-b157-68a9fe3057d8", false, "aliyildiz123" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedOn", "Description", "EndDate", "ProjectName", "StartDate", "Status" },
                values: new object[,]
                {
                    { new Guid("ad77749c-2fd0-46da-9c2f-2e5c08a0a003"), new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(6923), "A project to develop a stock tracking system", new DateTime(2024, 5, 28, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(6922), "Stock Tracking Project", new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(6922), "Planning" },
                    { new Guid("b0841c4f-9735-46aa-8d37-f7006d1e5db6"), new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(6918), "A project to create a blog site", new DateTime(2024, 4, 28, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(6911), "Blog Site Project", new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(6910), "InProgress" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("130fb7c3-67e2-497c-853a-e1fd3ddbd55c"), new Guid("2591192c-f0cc-41ee-8f3a-ec0652ec926a") },
                    { new Guid("63d9cc3b-c6ac-48dc-ae6d-b9da6f28744b"), new Guid("8eb125cc-8df0-4437-966f-fe37baa01cce") },
                    { new Guid("7023a59e-968c-4a30-9269-29612a6ad2ed"), new Guid("cee52ce3-88c9-4521-8d54-e2602f20adac") },
                    { new Guid("71b83e0d-2a79-46d2-b04d-3cef44ddae9c"), new Guid("ec8a8eb4-c286-458d-acdc-642d7a7f9140") }
                });

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "CreatedOn", "Date", "Description", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("0e25dbba-59b7-4945-a324-1843e42ec5bc"), 500.00m, new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9658), new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9657), "Sample cost", new Guid("b0841c4f-9735-46aa-8d37-f7006d1e5db6") },
                    { new Guid("de30b874-4dfd-472c-8830-594534d4c1b3"), 200.00m, new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9714), new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9714), "Sample cost", new Guid("ad77749c-2fd0-46da-9c2f-2e5c08a0a003") }
                });

            migrationBuilder.InsertData(
                table: "ProjectUserAssociation",
                columns: new[] { "ProjectId", "UserId" },
                values: new object[,]
                {
                    { new Guid("ad77749c-2fd0-46da-9c2f-2e5c08a0a003"), new Guid("2591192c-f0cc-41ee-8f3a-ec0652ec926a") },
                    { new Guid("ad77749c-2fd0-46da-9c2f-2e5c08a0a003"), new Guid("ec8a8eb4-c286-458d-acdc-642d7a7f9140") },
                    { new Guid("b0841c4f-9735-46aa-8d37-f7006d1e5db6"), new Guid("cee52ce3-88c9-4521-8d54-e2602f20adac") },
                    { new Guid("b0841c4f-9735-46aa-8d37-f7006d1e5db6"), new Guid("ec8a8eb4-c286-458d-acdc-642d7a7f9140") }
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "CreatedOn", "Description", "ProjectId", "StageName" },
                values: new object[,]
                {
                    { new Guid("14d007b9-1308-4ecb-af53-6229a205818e"), new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9443), "Planning stage for the stock tracking project", new Guid("ad77749c-2fd0-46da-9c2f-2e5c08a0a003"), "Planning" },
                    { new Guid("2195ff14-e525-45c6-ae7b-ba6a3327241a"), new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9440), "Design stage for the blog site project", new Guid("b0841c4f-9735-46aa-8d37-f7006d1e5db6"), "Design" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "AssignedTo", "CreatedOn", "Description", "DueDate", "Priority", "ProjectId", "StageId", "StartDate", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("28103f20-dfe2-4cfa-a2ab-4dd121b5a6dd"), "John Doe", new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9508), "Design user interface for the blog site", new DateTime(2024, 4, 5, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9504), 1, new Guid("b0841c4f-9735-46aa-8d37-f7006d1e5db6"), new Guid("14d007b9-1308-4ecb-af53-6229a205818e"), new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9503), "ToDo", "Design UI" },
                    { new Guid("701cceef-83b3-4103-ab71-7f60a2ea782a"), "John Doe", new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9520), "Depend job", new DateTime(2024, 4, 12, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9519), 2, new Guid("ad77749c-2fd0-46da-9c2f-2e5c08a0a003"), new Guid("2195ff14-e525-45c6-ae7b-ba6a3327241a"), new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9518), "Pending", "Depend job" },
                    { new Guid("ee39d6ac-a605-4c6d-94da-bdc6aeef2aa3"), "John Doe", new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9515), "Analyze requirements for the stock tracking project", new DateTime(2024, 4, 12, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9514), 2, new Guid("ad77749c-2fd0-46da-9c2f-2e5c08a0a003"), new Guid("2195ff14-e525-45c6-ae7b-ba6a3327241a"), new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9513), "InProgress", "Requirement Analysis" }
                });

            migrationBuilder.InsertData(
                table: "Dependencies",
                columns: new[] { "Id", "CreatedOn", "DependsOnJobId", "JobId" },
                values: new object[] { new Guid("ebc99809-cadf-49ce-9ac2-809b55c546e3"), new DateTime(2024, 3, 29, 12, 28, 39, 658, DateTimeKind.Local).AddTicks(9572), new Guid("ee39d6ac-a605-4c6d-94da-bdc6aeef2aa3"), new Guid("701cceef-83b3-4103-ab71-7f60a2ea782a") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("130fb7c3-67e2-497c-853a-e1fd3ddbd55c"), new Guid("2591192c-f0cc-41ee-8f3a-ec0652ec926a") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("63d9cc3b-c6ac-48dc-ae6d-b9da6f28744b"), new Guid("8eb125cc-8df0-4437-966f-fe37baa01cce") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7023a59e-968c-4a30-9269-29612a6ad2ed"), new Guid("cee52ce3-88c9-4521-8d54-e2602f20adac") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("71b83e0d-2a79-46d2-b04d-3cef44ddae9c"), new Guid("ec8a8eb4-c286-458d-acdc-642d7a7f9140") });

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("0e25dbba-59b7-4945-a324-1843e42ec5bc"));

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: new Guid("de30b874-4dfd-472c-8830-594534d4c1b3"));

            migrationBuilder.DeleteData(
                table: "Dependencies",
                keyColumn: "Id",
                keyValue: new Guid("ebc99809-cadf-49ce-9ac2-809b55c546e3"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("28103f20-dfe2-4cfa-a2ab-4dd121b5a6dd"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("ee39d6ac-a605-4c6d-94da-bdc6aeef2aa3"));

            migrationBuilder.DeleteData(
                table: "ProjectUserAssociation",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { new Guid("ad77749c-2fd0-46da-9c2f-2e5c08a0a003"), new Guid("2591192c-f0cc-41ee-8f3a-ec0652ec926a") });

            migrationBuilder.DeleteData(
                table: "ProjectUserAssociation",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { new Guid("ad77749c-2fd0-46da-9c2f-2e5c08a0a003"), new Guid("ec8a8eb4-c286-458d-acdc-642d7a7f9140") });

            migrationBuilder.DeleteData(
                table: "ProjectUserAssociation",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { new Guid("b0841c4f-9735-46aa-8d37-f7006d1e5db6"), new Guid("cee52ce3-88c9-4521-8d54-e2602f20adac") });

            migrationBuilder.DeleteData(
                table: "ProjectUserAssociation",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { new Guid("b0841c4f-9735-46aa-8d37-f7006d1e5db6"), new Guid("ec8a8eb4-c286-458d-acdc-642d7a7f9140") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("130fb7c3-67e2-497c-853a-e1fd3ddbd55c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("63d9cc3b-c6ac-48dc-ae6d-b9da6f28744b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7023a59e-968c-4a30-9269-29612a6ad2ed"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b83e0d-2a79-46d2-b04d-3cef44ddae9c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2591192c-f0cc-41ee-8f3a-ec0652ec926a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8eb125cc-8df0-4437-966f-fe37baa01cce"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cee52ce3-88c9-4521-8d54-e2602f20adac"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec8a8eb4-c286-458d-acdc-642d7a7f9140"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("701cceef-83b3-4103-ab71-7f60a2ea782a"));

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: new Guid("14d007b9-1308-4ecb-af53-6229a205818e"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("ad77749c-2fd0-46da-9c2f-2e5c08a0a003"));

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: new Guid("2195ff14-e525-45c6-ae7b-ba6a3327241a"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("b0841c4f-9735-46aa-8d37-f7006d1e5db6"));

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
        }
    }
}
