using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HairSalon.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class addtimeserviceandtotaltimeinappointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("98936739-5b83-49be-a1d0-7e29443b5561"), new Guid("388120ac-8508-4029-bb10-3b9d4d51f43b") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("36ee0524-c0c1-41f6-b12f-339278698420"), new Guid("652488e0-1a92-4141-8857-617eb8da660b") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c3a1348e-9e84-4b09-81e2-95af4781c948"), new Guid("8298f8cb-ddc8-4ec7-99a8-821f26cedc13") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("40d7bb6f-c94b-48bc-bcc3-58ec1209db99"), new Guid("d5d085ff-917b-4538-9925-e9c4ba504073") });

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: "98443058-c030-4200-94d2-da395d7f5bed");

            migrationBuilder.DeleteData(
                table: "SalaryPayments",
                keyColumn: "Id",
                keyValue: "81d15eea-e560-4f7a-b183-46f4cd1960d8");

            migrationBuilder.DeleteData(
                table: "ServiceAppointments",
                keyColumn: "Id",
                keyValue: "e4d3b9e3-78ff-42dc-bb4e-bebdcf38778b");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "35c770d6-9e6b-4d43-a404-18c0bd8b131f");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "75f71575-3d3b-40de-8935-b7e6ab68799f");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("36ee0524-c0c1-41f6-b12f-339278698420"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("40d7bb6f-c94b-48bc-bcc3-58ec1209db99"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("98936739-5b83-49be-a1d0-7e29443b5561"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3a1348e-9e84-4b09-81e2-95af4781c948"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("388120ac-8508-4029-bb10-3b9d4d51f43b"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("d5d085ff-917b-4538-9925-e9c4ba504073"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "5c3aa44b-ba34-4765-ab6b-3f80f8140b09");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "b1d3f6ec-f414-4986-9ef7-8bea9d61c410");

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("652488e0-1a92-4141-8857-617eb8da660b"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("8298f8cb-ddc8-4ec7-99a8-821f26cedc13"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: "5f88a676-71fa-4282-9bc6-098712d64261");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "c3dc7150-e0cb-4aae-b43c-48b30cd53fb8");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "c97d3c58-5bf4-4cbf-bee4-274b7f2f754f");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "17830502-74d7-4b84-b1b2-9157d6328648");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "21f94f31-d041-4309-bb17-0c7fac842f63");

            migrationBuilder.AddColumn<int>(
                name: "TimeService",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalTime",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "TimeService",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "TotalTime",
                table: "Appointments");

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("36ee0524-c0c1-41f6-b12f-339278698420"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 628, DateTimeKind.Unspecified).AddTicks(1264), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 628, DateTimeKind.Unspecified).AddTicks(1266), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "ADMIN" },
                    { new Guid("40d7bb6f-c94b-48bc-bcc3-58ec1209db99"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 628, DateTimeKind.Unspecified).AddTicks(1269), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 628, DateTimeKind.Unspecified).AddTicks(1269), new TimeSpan(0, 0, 0, 0, 0)), "Manager", "MANAGER" },
                    { new Guid("98936739-5b83-49be-a1d0-7e29443b5561"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 628, DateTimeKind.Unspecified).AddTicks(1273), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 628, DateTimeKind.Unspecified).AddTicks(1273), new TimeSpan(0, 0, 0, 0, 0)), "Stylist", "STYLIST" },
                    { new Guid("c3a1348e-9e84-4b09-81e2-95af4781c948"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 628, DateTimeKind.Unspecified).AddTicks(1276), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 628, DateTimeKind.Unspecified).AddTicks(1277), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "OpenTime", "ShopEmail", "ShopPhone", "Title" },
                values: new object[] { "5f88a676-71fa-4282-9bc6-098712d64261", "123 Main St, Cityville", new TimeSpan(0, 19, 0, 0, 0), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2282), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2283), new TimeSpan(0, 0, 0, 0, 0)), "Salon A", new TimeSpan(0, 9, 0, 0, 0), "contact@salona.com", "123-456-7890", "Best Hair Salon in Town" });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Bank", "BankAccount", "BankAccountName", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Firstname", "LastUpdatedBy", "LastUpdatedTime", "Lastname", "Point" },
                values: new object[,]
                {
                    { "17830502-74d7-4b84-b1b2-9157d6328648", "Bank A", "123456789", "John Doe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 628, DateTimeKind.Unspecified).AddTicks(1574), new TimeSpan(0, 0, 0, 0, 0)), null, null, "John", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 628, DateTimeKind.Unspecified).AddTicks(1576), new TimeSpan(0, 0, 0, 0, 0)), "Doe", 100 },
                    { "21f94f31-d041-4309-bb17-0c7fac842f63", "Bank B", "987654321", "Jane Smith", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 628, DateTimeKind.Unspecified).AddTicks(1581), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jane", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 628, DateTimeKind.Unspecified).AddTicks(1581), new TimeSpan(0, 0, 0, 0, 0)), "Smith", 150 },
                    { "c3dc7150-e0cb-4aae-b43c-48b30cd53fb8", "Bank D", "123456987", "Dan Tran", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 628, DateTimeKind.Unspecified).AddTicks(1590), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dan", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 628, DateTimeKind.Unspecified).AddTicks(1591), new TimeSpan(0, 0, 0, 0, 0)), "Tran", 0 },
                    { "c97d3c58-5bf4-4cbf-bee4-274b7f2f754f", "Bank c", "123456798", "Dev Nguyen", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 628, DateTimeKind.Unspecified).AddTicks(1586), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dev", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 628, DateTimeKind.Unspecified).AddTicks(1586), new TimeSpan(0, 0, 0, 0, 0)), "Nguyen", 0 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Email", "EmailConfirmed", "LastUpdatedBy", "LastUpdatedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OtpCode", "OtpCodeResetPassword", "OtpExpiration", "OtpExpirationResetPassword", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserInfoId", "UserName" },
                values: new object[,]
                {
                    { new Guid("388120ac-8508-4029-bb10-3b9d4d51f43b"), 0, "c652aeca-895f-4518-b276-585b53de335b", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2011), new TimeSpan(0, 0, 0, 0, 0)), null, null, "stylist@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2011), new TimeSpan(0, 0, 0, 0, 0)), false, null, "STYLIST@EXAMPLE.COM", "STYLIST@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEOndua5MWeNdu4p5dJgmqr6/8SI6kDCx1LbnvPLDtnT3ytisljnbczczqQ82lKW15Q==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "c3dc7150-e0cb-4aae-b43c-48b30cd53fb8", "stylist" },
                    { new Guid("652488e0-1a92-4141-8857-617eb8da660b"), 0, "9532c8e2-e599-4b83-af86-819fd9796ce7", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(1932), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(1933), new TimeSpan(0, 0, 0, 0, 0)), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEB3SQpmNWI+qlDYGraVn5GQrUP9xWAX5EazRR/KKcOpxLxtgE/hef+clUVGiuO2qFA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "17830502-74d7-4b84-b1b2-9157d6328648", "admin" },
                    { new Guid("8298f8cb-ddc8-4ec7-99a8-821f26cedc13"), 0, "430d2a2e-18ee-479f-a38a-3f1fb487fce0", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(1997), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(1998), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEJLP4Alx+X+Qa+JdAcSYHE6rTjVFwgj/tcTQPn1KhZ+Bt/5eL0sTQKlJA/TmJtdYMg==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "21f94f31-d041-4309-bb17-0c7fac842f63", "user" },
                    { new Guid("d5d085ff-917b-4538-9925-e9c4ba504073"), 0, "9ae2d16f-8e6a-4f79-a449-7d67b47d18ab", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2004), new TimeSpan(0, 0, 0, 0, 0)), null, null, "manager@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2006), new TimeSpan(0, 0, 0, 0, 0)), false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAELSbKp0TOdmXMJ3JnRKPhc93V0A6AFYszChQohO9OKruhsnv5p5brzSmrSMKICJFhw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "c97d3c58-5bf4-4cbf-bee4-274b7f2f754f", "manager" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Name", "Price", "ShopId", "Type" },
                values: new object[,]
                {
                    { "35c770d6-9e6b-4d43-a404-18c0bd8b131f", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2419), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A complete hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2419), new TimeSpan(0, 0, 0, 0, 0)), "Hair Coloring", 50000.00m, "5f88a676-71fa-4282-9bc6-098712d64261", "Hair" },
                    { "75f71575-3d3b-40de-8935-b7e6ab68799f", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2424), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A premium hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2424), new TimeSpan(0, 0, 0, 0, 0)), "Premium Hair Coloring", 100000.00m, "5f88a676-71fa-4282-9bc6-098712d64261", "Hair" },
                    { "b1d3f6ec-f414-4986-9ef7-8bea9d61c410", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2413), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A stylish haircut to refresh your look.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2413), new TimeSpan(0, 0, 0, 0, 0)), "Hair Cut", 25000.00m, "5f88a676-71fa-4282-9bc6-098712d64261", "Hair" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { new Guid("98936739-5b83-49be-a1d0-7e29443b5561"), new Guid("388120ac-8508-4029-bb10-3b9d4d51f43b"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2209), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2209), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("36ee0524-c0c1-41f6-b12f-339278698420"), new Guid("652488e0-1a92-4141-8857-617eb8da660b"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2196), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2198), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c3a1348e-9e84-4b09-81e2-95af4781c948"), new Guid("8298f8cb-ddc8-4ec7-99a8-821f26cedc13"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2201), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2201), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("40d7bb6f-c94b-48bc-bcc3-58ec1209db99"), new Guid("d5d085ff-917b-4538-9925-e9c4ba504073"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2205), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2205), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PointsEarned", "StatusForAppointment", "StylistId", "UserId" },
                values: new object[] { "5c3aa44b-ba34-4765-ab6b-3f80f8140b09", new DateTime(2024, 10, 14, 2, 53, 54, 925, DateTimeKind.Utc).AddTicks(2470), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2503), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2503), new TimeSpan(0, 0, 0, 0, 0)), 10, "Scheduled", new Guid("8298f8cb-ddc8-4ec7-99a8-821f26cedc13"), new Guid("652488e0-1a92-4141-8857-617eb8da660b") });

            migrationBuilder.InsertData(
                table: "SalaryPayments",
                columns: new[] { "Id", "BaseSalary", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentDate", "UserId" },
                values: new object[] { "81d15eea-e560-4f7a-b183-46f4cd1960d8", 2000.00m, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2654), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2654), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Utc).AddTicks(2653), new Guid("652488e0-1a92-4141-8857-617eb8da660b") });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "AppointmentId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentMethod", "PaymentTime", "TotalAmount" },
                values: new object[] { "98443058-c030-4200-94d2-da395d7f5bed", "5c3aa44b-ba34-4765-ab6b-3f80f8140b09", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2593), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2593), new TimeSpan(0, 0, 0, 0, 0)), "Credit Card", new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Utc).AddTicks(2591), 100.00m });

            migrationBuilder.InsertData(
                table: "ServiceAppointments",
                columns: new[] { "Id", "AppointmentId", "Comment", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Rate", "ServiceId" },
                values: new object[] { "e4d3b9e3-78ff-42dc-bb4e-bebdcf38778b", "5c3aa44b-ba34-4765-ab6b-3f80f8140b09", "Excellent service!", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2624), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Basic haircut", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 13, 2, 53, 54, 925, DateTimeKind.Unspecified).AddTicks(2625), new TimeSpan(0, 0, 0, 0, 0)), 5, "b1d3f6ec-f414-4986-9ef7-8bea9d61c410" });
        }
    }
}
