using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HairSalon.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class addfeedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("07879367-cbe5-40f0-be97-b0b1309724d1"), new Guid("00ceabd6-7499-4082-abaf-db8c73a790aa") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2dec4b44-7d60-405a-9d68-78f201a2c365"), new Guid("936f9482-db3c-456e-8da9-28c0e92cac03") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("83502046-acca-4bc8-97a0-5d92208b2d74"), new Guid("94f1bae3-835e-4057-8b28-9f3b1096b5be") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("29186590-1bf9-4dcd-ae41-d7120c6244f3"), new Guid("95232acf-eb2e-40f5-bd80-ce0589b99af5") });

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: "794be210-6564-4a80-8248-c413e8be4485");

            migrationBuilder.DeleteData(
                table: "SalaryPayments",
                keyColumn: "Id",
                keyValue: "8aec45ed-f3e0-4ce5-b63e-7ea2fed46193");

            migrationBuilder.DeleteData(
                table: "ServiceAppointments",
                keyColumn: "Id",
                keyValue: "6ee38e51-8803-4c03-ab4e-255e32132687");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "a1a5da11-d208-425c-8752-a5fd280b44f1");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "d38a0689-7122-425b-8851-2ff971960f72");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("07879367-cbe5-40f0-be97-b0b1309724d1"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("29186590-1bf9-4dcd-ae41-d7120c6244f3"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("2dec4b44-7d60-405a-9d68-78f201a2c365"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("83502046-acca-4bc8-97a0-5d92208b2d74"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("00ceabd6-7499-4082-abaf-db8c73a790aa"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("95232acf-eb2e-40f5-bd80-ce0589b99af5"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "a05a9612-4e5d-4f73-9c1f-068a6352ecbd");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "b112051b-5370-47ae-a3e6-cdf1d904cbee");

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("936f9482-db3c-456e-8da9-28c0e92cac03"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("94f1bae3-835e-4057-8b28-9f3b1096b5be"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: "a8c22e88-8453-4b6a-91ad-b33521929ac8");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "37b5ad28-3a10-4502-9efb-69473dbc9298");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "6f036bb5-ce7a-4fab-92aa-247a0e9b3fe6");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "2a1aced1-6c92-4d1e-ba55-467824be1693");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "3fa287aa-2f4a-4335-a2b8-a62edde48d00");

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("7db4014e-ef44-4e3b-a41f-e3f073d5b1be"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 17, 908, DateTimeKind.Unspecified).AddTicks(5266), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 17, 908, DateTimeKind.Unspecified).AddTicks(5266), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" },
                    { new Guid("85f06e6b-9cc0-4a0c-9fc1-d09649c78f8a"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 17, 908, DateTimeKind.Unspecified).AddTicks(5257), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 17, 908, DateTimeKind.Unspecified).AddTicks(5257), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "ADMIN" },
                    { new Guid("99494408-60e6-4ca4-b20f-b234b542dbee"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 17, 908, DateTimeKind.Unspecified).AddTicks(5263), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 17, 908, DateTimeKind.Unspecified).AddTicks(5263), new TimeSpan(0, 0, 0, 0, 0)), "Stylist", "STYLIST" },
                    { new Guid("f8b4913b-8b80-4ce9-8903-a375705a7d8f"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 17, 908, DateTimeKind.Unspecified).AddTicks(5260), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 17, 908, DateTimeKind.Unspecified).AddTicks(5261), new TimeSpan(0, 0, 0, 0, 0)), "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "OpenTime", "ShopEmail", "ShopPhone", "Title" },
                values: new object[] { "ec26941f-7da2-407f-8ab9-0967e0aecd04", "123 Main St, Cityville", new TimeSpan(0, 19, 0, 0, 0), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2768), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2768), new TimeSpan(0, 0, 0, 0, 0)), "Salon A", new TimeSpan(0, 9, 0, 0, 0), "contact@salona.com", "123-456-7890", "Best Hair Salon in Town" });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Bank", "BankAccount", "BankAccountName", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Firstname", "LastUpdatedBy", "LastUpdatedTime", "Lastname", "Point" },
                values: new object[,]
                {
                    { "7e104c1b-d95d-4f23-87cd-d123c478974e", "Bank A", "123456789", "John Doe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 17, 908, DateTimeKind.Unspecified).AddTicks(5439), new TimeSpan(0, 0, 0, 0, 0)), null, null, "John", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 17, 908, DateTimeKind.Unspecified).AddTicks(5439), new TimeSpan(0, 0, 0, 0, 0)), "Doe", 100 },
                    { "8b2aed2c-5d13-41ce-83cb-432e147daf87", "Bank B", "987654321", "Jane Smith", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 17, 908, DateTimeKind.Unspecified).AddTicks(5443), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jane", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 17, 908, DateTimeKind.Unspecified).AddTicks(5443), new TimeSpan(0, 0, 0, 0, 0)), "Smith", 150 },
                    { "c56d1832-ca9c-4a45-a0b9-0690b32d5677", "Bank c", "123456798", "Dev Nguyen", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 17, 908, DateTimeKind.Unspecified).AddTicks(5447), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dev", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 17, 908, DateTimeKind.Unspecified).AddTicks(5447), new TimeSpan(0, 0, 0, 0, 0)), "Nguyen", 0 },
                    { "ebce2aa0-ac20-47d2-9c68-b60f069880f4", "Bank D", "123456987", "Dan Tran", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 17, 908, DateTimeKind.Unspecified).AddTicks(5453), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dan", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 17, 908, DateTimeKind.Unspecified).AddTicks(5453), new TimeSpan(0, 0, 0, 0, 0)), "Tran", 0 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Email", "EmailConfirmed", "LastUpdatedBy", "LastUpdatedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OtpCode", "OtpCodeResetPassword", "OtpExpiration", "OtpExpirationResetPassword", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserInfoId", "UserName" },
                values: new object[,]
                {
                    { new Guid("65475c97-6426-4540-8004-e5c53afd5bcb"), 0, "1c690b6e-7685-4410-8f1c-c757cf21343a", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2497), new TimeSpan(0, 0, 0, 0, 0)), null, null, "stylist@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2498), new TimeSpan(0, 0, 0, 0, 0)), false, null, "STYLIST@EXAMPLE.COM", "STYLIST@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEDiY5mFUzdlk5lFiABxmMOLlYJEOhe3IrmqEDSJKg+JI43azLg1nrCynweT6k1HWdg==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "ebce2aa0-ac20-47d2-9c68-b60f069880f4", "stylist" },
                    { new Guid("d2075275-b049-48f8-8bab-70d8f89b9adc"), 0, "429fd4a4-d482-452d-bd6e-c87ba93deeed", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2427), new TimeSpan(0, 0, 0, 0, 0)), null, null, "manager@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2428), new TimeSpan(0, 0, 0, 0, 0)), false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEPGRvjEBdAQ6d5VO78rSvh2DZ8pEvw5MDe9vswVk7uhfnjWAohAGAkDKd2qo+AgHeg==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "c56d1832-ca9c-4a45-a0b9-0690b32d5677", "manager" },
                    { new Guid("dadae461-76b4-45a9-9b5c-33eeb963314e"), 0, "e134cc8b-c867-41b7-b8e6-9c665beaa328", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2405), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2405), new TimeSpan(0, 0, 0, 0, 0)), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEJ/Er2AmmY2wfYsEmwDwMd/QYoEwUR0GywuyYJyKb+L+V2Ff4p2zKiCKJffqEn4BHw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "7e104c1b-d95d-4f23-87cd-d123c478974e", "admin" },
                    { new Guid("ee011522-3afc-42e5-882b-c4e8257a8e65"), 0, "1f3e0ad6-ef4f-4dbb-830d-054ced7e57b7", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2413), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2414), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEHLN3G2xP5qe9oespOKBXqrgs2bf1CTIitsrjJ0+QUIPDXaJuoLe0533gZhtd4rJKQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "8b2aed2c-5d13-41ce-83cb-432e147daf87", "user" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Name", "Price", "ShopId", "TimeService", "Type" },
                values: new object[,]
                {
                    { "04635bcb-d28d-4761-aafa-44d80c68fe3e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2838), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A premium hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2838), new TimeSpan(0, 0, 0, 0, 0)), "Premium Hair Coloring", 100000.00m, "ec26941f-7da2-407f-8ab9-0967e0aecd04", 60, "Hair" },
                    { "087bac02-2c9f-49a6-87ab-d274b6b867ad", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2822), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A stylish haircut to refresh your look.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2830), new TimeSpan(0, 0, 0, 0, 0)), "Hair Cut", 25000.00m, "ec26941f-7da2-407f-8ab9-0967e0aecd04", 30, "Hair" },
                    { "129f1a99-50c9-45e9-86a1-9094c7617e93", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2834), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A complete hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2834), new TimeSpan(0, 0, 0, 0, 0)), "Hair Coloring", 50000.00m, "ec26941f-7da2-407f-8ab9-0967e0aecd04", 30, "Hair" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { new Guid("99494408-60e6-4ca4-b20f-b234b542dbee"), new Guid("65475c97-6426-4540-8004-e5c53afd5bcb"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f8b4913b-8b80-4ce9-8903-a375705a7d8f"), new Guid("d2075275-b049-48f8-8bab-70d8f89b9adc"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2668), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2668), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("85f06e6b-9cc0-4a0c-9fc1-d09649c78f8a"), new Guid("dadae461-76b4-45a9-9b5c-33eeb963314e"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2661), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2662), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7db4014e-ef44-4e3b-a41f-e3f073d5b1be"), new Guid("ee011522-3afc-42e5-882b-c4e8257a8e65"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2664), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2665), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PointsEarned", "StatusForAppointment", "StylistId", "TotalTime", "UserId" },
                values: new object[] { "c9d97669-8f1b-4f69-b808-2cb6135aa568", new DateTime(2024, 10, 14, 12, 8, 18, 170, DateTimeKind.Utc).AddTicks(2888), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2911), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2911), new TimeSpan(0, 0, 0, 0, 0)), 10, "Scheduled", new Guid("ee011522-3afc-42e5-882b-c4e8257a8e65"), 0, new Guid("dadae461-76b4-45a9-9b5c-33eeb963314e") });

            migrationBuilder.InsertData(
                table: "SalaryPayments",
                columns: new[] { "Id", "BaseSalary", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentDate", "UserId" },
                values: new object[] { "6e162cc8-e316-46e4-8c64-22505221e535", 2000.00m, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(3063), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(3063), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Utc).AddTicks(3062), new Guid("dadae461-76b4-45a9-9b5c-33eeb963314e") });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "AppointmentId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentMethod", "PaymentTime", "TotalAmount" },
                values: new object[] { "cadef4d8-060a-4d7a-b845-6312eae954c8", "c9d97669-8f1b-4f69-b808-2cb6135aa568", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2970), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(2970), new TimeSpan(0, 0, 0, 0, 0)), "Credit Card", new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Utc).AddTicks(2969), 100.00m });

            migrationBuilder.InsertData(
                table: "ServiceAppointments",
                columns: new[] { "Id", "AppointmentId", "Comment", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Rate", "ServiceId" },
                values: new object[] { "1ef2bbaf-e8ad-4dea-a141-eff4585667e9", "c9d97669-8f1b-4f69-b808-2cb6135aa568", "Excellent service!", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(3018), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Basic haircut", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 8, 18, 170, DateTimeKind.Unspecified).AddTicks(3022), new TimeSpan(0, 0, 0, 0, 0)), 5, "087bac02-2c9f-49a6-87ab-d274b6b867ad" });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_AppointmentId",
                table: "Feedbacks",
                column: "AppointmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("99494408-60e6-4ca4-b20f-b234b542dbee"), new Guid("65475c97-6426-4540-8004-e5c53afd5bcb") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f8b4913b-8b80-4ce9-8903-a375705a7d8f"), new Guid("d2075275-b049-48f8-8bab-70d8f89b9adc") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("85f06e6b-9cc0-4a0c-9fc1-d09649c78f8a"), new Guid("dadae461-76b4-45a9-9b5c-33eeb963314e") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7db4014e-ef44-4e3b-a41f-e3f073d5b1be"), new Guid("ee011522-3afc-42e5-882b-c4e8257a8e65") });

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: "cadef4d8-060a-4d7a-b845-6312eae954c8");

            migrationBuilder.DeleteData(
                table: "SalaryPayments",
                keyColumn: "Id",
                keyValue: "6e162cc8-e316-46e4-8c64-22505221e535");

            migrationBuilder.DeleteData(
                table: "ServiceAppointments",
                keyColumn: "Id",
                keyValue: "1ef2bbaf-e8ad-4dea-a141-eff4585667e9");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "04635bcb-d28d-4761-aafa-44d80c68fe3e");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "129f1a99-50c9-45e9-86a1-9094c7617e93");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("7db4014e-ef44-4e3b-a41f-e3f073d5b1be"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("85f06e6b-9cc0-4a0c-9fc1-d09649c78f8a"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("99494408-60e6-4ca4-b20f-b234b542dbee"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("f8b4913b-8b80-4ce9-8903-a375705a7d8f"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("65475c97-6426-4540-8004-e5c53afd5bcb"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("d2075275-b049-48f8-8bab-70d8f89b9adc"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "c9d97669-8f1b-4f69-b808-2cb6135aa568");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "087bac02-2c9f-49a6-87ab-d274b6b867ad");

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("dadae461-76b4-45a9-9b5c-33eeb963314e"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ee011522-3afc-42e5-882b-c4e8257a8e65"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: "ec26941f-7da2-407f-8ab9-0967e0aecd04");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "c56d1832-ca9c-4a45-a0b9-0690b32d5677");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "ebce2aa0-ac20-47d2-9c68-b60f069880f4");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "7e104c1b-d95d-4f23-87cd-d123c478974e");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "8b2aed2c-5d13-41ce-83cb-432e147daf87");

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("07879367-cbe5-40f0-be97-b0b1309724d1"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 111, DateTimeKind.Unspecified).AddTicks(6455), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 111, DateTimeKind.Unspecified).AddTicks(6456), new TimeSpan(0, 0, 0, 0, 0)), "Stylist", "STYLIST" },
                    { new Guid("29186590-1bf9-4dcd-ae41-d7120c6244f3"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 111, DateTimeKind.Unspecified).AddTicks(6452), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 111, DateTimeKind.Unspecified).AddTicks(6452), new TimeSpan(0, 0, 0, 0, 0)), "Manager", "MANAGER" },
                    { new Guid("2dec4b44-7d60-405a-9d68-78f201a2c365"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 111, DateTimeKind.Unspecified).AddTicks(6448), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 111, DateTimeKind.Unspecified).AddTicks(6449), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "ADMIN" },
                    { new Guid("83502046-acca-4bc8-97a0-5d92208b2d74"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 111, DateTimeKind.Unspecified).AddTicks(6458), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 111, DateTimeKind.Unspecified).AddTicks(6459), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "OpenTime", "ShopEmail", "ShopPhone", "Title" },
                values: new object[] { "a8c22e88-8453-4b6a-91ad-b33521929ac8", "123 Main St, Cityville", new TimeSpan(0, 19, 0, 0, 0), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1176), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1177), new TimeSpan(0, 0, 0, 0, 0)), "Salon A", new TimeSpan(0, 9, 0, 0, 0), "contact@salona.com", "123-456-7890", "Best Hair Salon in Town" });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Bank", "BankAccount", "BankAccountName", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Firstname", "LastUpdatedBy", "LastUpdatedTime", "Lastname", "Point" },
                values: new object[,]
                {
                    { "2a1aced1-6c92-4d1e-ba55-467824be1693", "Bank A", "123456789", "John Doe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 111, DateTimeKind.Unspecified).AddTicks(6723), new TimeSpan(0, 0, 0, 0, 0)), null, null, "John", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 111, DateTimeKind.Unspecified).AddTicks(6723), new TimeSpan(0, 0, 0, 0, 0)), "Doe", 100 },
                    { "37b5ad28-3a10-4502-9efb-69473dbc9298", "Bank c", "123456798", "Dev Nguyen", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 111, DateTimeKind.Unspecified).AddTicks(6733), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dev", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 111, DateTimeKind.Unspecified).AddTicks(6733), new TimeSpan(0, 0, 0, 0, 0)), "Nguyen", 0 },
                    { "3fa287aa-2f4a-4335-a2b8-a62edde48d00", "Bank B", "987654321", "Jane Smith", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 111, DateTimeKind.Unspecified).AddTicks(6728), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jane", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 111, DateTimeKind.Unspecified).AddTicks(6728), new TimeSpan(0, 0, 0, 0, 0)), "Smith", 150 },
                    { "6f036bb5-ce7a-4fab-92aa-247a0e9b3fe6", "Bank D", "123456987", "Dan Tran", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 111, DateTimeKind.Unspecified).AddTicks(6737), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dan", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 111, DateTimeKind.Unspecified).AddTicks(6738), new TimeSpan(0, 0, 0, 0, 0)), "Tran", 0 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Email", "EmailConfirmed", "LastUpdatedBy", "LastUpdatedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OtpCode", "OtpCodeResetPassword", "OtpExpiration", "OtpExpirationResetPassword", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserInfoId", "UserName" },
                values: new object[,]
                {
                    { new Guid("00ceabd6-7499-4082-abaf-db8c73a790aa"), 0, "f7d844be-55d3-4e56-ac61-013fb4fe215a", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(960), new TimeSpan(0, 0, 0, 0, 0)), null, null, "stylist@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(961), new TimeSpan(0, 0, 0, 0, 0)), false, null, "STYLIST@EXAMPLE.COM", "STYLIST@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEP4NrUWkSDQiRrYOfUNHQNgXzpf2U3G2kYMpPA2o2FxjRAvyEdmGaiq8Uwp5sYR4kw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "6f036bb5-ce7a-4fab-92aa-247a0e9b3fe6", "stylist" },
                    { new Guid("936f9482-db3c-456e-8da9-28c0e92cac03"), 0, "0f6a49b3-3102-494d-8bec-978834124df5", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(903), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(905), new TimeSpan(0, 0, 0, 0, 0)), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAELyi4M/FzA7zkxDbZvlm1YoGq8voFcKEdGcwH8cJtsoV3WBRQzLzxXWGdvbpzQ0xZQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "2a1aced1-6c92-4d1e-ba55-467824be1693", "admin" },
                    { new Guid("94f1bae3-835e-4057-8b28-9f3b1096b5be"), 0, "eac91e2b-4929-48f7-b1df-7556dd756de4", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(949), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(949), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEEC36+3HaNTwcIFTPOdIo0sgJPJ/53deOCvuRIrokfZujxLkx5QEUrKA9WOw+R4IEA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "3fa287aa-2f4a-4335-a2b8-a62edde48d00", "user" },
                    { new Guid("95232acf-eb2e-40f5-bd80-ce0589b99af5"), 0, "e9f46608-34a0-4ae5-9a4c-b62c18c071c6", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(955), new TimeSpan(0, 0, 0, 0, 0)), null, null, "manager@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(956), new TimeSpan(0, 0, 0, 0, 0)), false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAENlOKDwkvto9cEXvSwYK2D8ZP9dvHh7DThcai4Ys1nN5hIK8TeFsdyOE28NzKiHeYQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "37b5ad28-3a10-4502-9efb-69473dbc9298", "manager" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Name", "Price", "ShopId", "TimeService", "Type" },
                values: new object[,]
                {
                    { "a1a5da11-d208-425c-8752-a5fd280b44f1", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1290), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A complete hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1291), new TimeSpan(0, 0, 0, 0, 0)), "Hair Coloring", 50000.00m, "a8c22e88-8453-4b6a-91ad-b33521929ac8", 30, "Hair" },
                    { "b112051b-5370-47ae-a3e6-cdf1d904cbee", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1273), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A stylish haircut to refresh your look.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1278), new TimeSpan(0, 0, 0, 0, 0)), "Hair Cut", 25000.00m, "a8c22e88-8453-4b6a-91ad-b33521929ac8", 30, "Hair" },
                    { "d38a0689-7122-425b-8851-2ff971960f72", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1295), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A premium hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1295), new TimeSpan(0, 0, 0, 0, 0)), "Premium Hair Coloring", 100000.00m, "a8c22e88-8453-4b6a-91ad-b33521929ac8", 60, "Hair" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { new Guid("07879367-cbe5-40f0-be97-b0b1309724d1"), new Guid("00ceabd6-7499-4082-abaf-db8c73a790aa"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1099), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1100), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2dec4b44-7d60-405a-9d68-78f201a2c365"), new Guid("936f9482-db3c-456e-8da9-28c0e92cac03"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1091), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1091), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("83502046-acca-4bc8-97a0-5d92208b2d74"), new Guid("94f1bae3-835e-4057-8b28-9f3b1096b5be"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1094), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1094), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("29186590-1bf9-4dcd-ae41-d7120c6244f3"), new Guid("95232acf-eb2e-40f5-bd80-ce0589b99af5"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1097), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1097), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PointsEarned", "StatusForAppointment", "StylistId", "TotalTime", "UserId" },
                values: new object[] { "a05a9612-4e5d-4f73-9c1f-068a6352ecbd", new DateTime(2024, 10, 14, 12, 5, 9, 406, DateTimeKind.Utc).AddTicks(1346), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1372), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1373), new TimeSpan(0, 0, 0, 0, 0)), 10, "Scheduled", new Guid("94f1bae3-835e-4057-8b28-9f3b1096b5be"), 0, new Guid("936f9482-db3c-456e-8da9-28c0e92cac03") });

            migrationBuilder.InsertData(
                table: "SalaryPayments",
                columns: new[] { "Id", "BaseSalary", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentDate", "UserId" },
                values: new object[] { "8aec45ed-f3e0-4ce5-b63e-7ea2fed46193", 2000.00m, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1536), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1536), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Utc).AddTicks(1535), new Guid("936f9482-db3c-456e-8da9-28c0e92cac03") });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "AppointmentId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentMethod", "PaymentTime", "TotalAmount" },
                values: new object[] { "794be210-6564-4a80-8248-c413e8be4485", "a05a9612-4e5d-4f73-9c1f-068a6352ecbd", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1442), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1442), new TimeSpan(0, 0, 0, 0, 0)), "Credit Card", new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Utc).AddTicks(1441), 100.00m });

            migrationBuilder.InsertData(
                table: "ServiceAppointments",
                columns: new[] { "Id", "AppointmentId", "Comment", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Rate", "ServiceId" },
                values: new object[] { "6ee38e51-8803-4c03-ab4e-255e32132687", "a05a9612-4e5d-4f73-9c1f-068a6352ecbd", "Excellent service!", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1484), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Basic haircut", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 12, 5, 9, 406, DateTimeKind.Unspecified).AddTicks(1488), new TimeSpan(0, 0, 0, 0, 0)), 5, "b112051b-5370-47ae-a3e6-cdf1d904cbee" });
        }
    }
}
