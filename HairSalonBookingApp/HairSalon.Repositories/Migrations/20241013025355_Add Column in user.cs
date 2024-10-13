using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HairSalon.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddColumninuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4a68df10-6812-4385-8d90-1d88746f7c2b"), new Guid("393d525b-d90a-4e24-8682-9f3a0ae5b30a") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3d26d219-6d84-4a68-b9ad-954f8078d94d"), new Guid("5925a17b-b9e5-4e60-b4c8-27b606a03811") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2952161c-ce04-43b7-afc4-cee6ddb1a87d"), new Guid("8c5439fd-af20-44e5-ba2b-0c14d4c5100d") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6db6c39b-65dd-4965-ba1a-a214a25f53f8"), new Guid("da2d861a-18b6-4af4-b6ce-cab83599b318") });

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: "aeaca7d8-bdd0-40b1-993b-da7ab5fea28e");

            migrationBuilder.DeleteData(
                table: "SalaryPayments",
                keyColumn: "Id",
                keyValue: "bfbd151e-a1c2-4ff7-9d26-c5f2c3d5d3e2");

            migrationBuilder.DeleteData(
                table: "ServiceAppointments",
                keyColumn: "Id",
                keyValue: "039db19d-11d6-4473-b32b-3c422e676c1e");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "5fd85e69-9bbc-42b6-8867-d1c6b6801179");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "606c590b-b7dc-4cee-9efb-fbc47b32a232");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("2952161c-ce04-43b7-afc4-cee6ddb1a87d"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("3d26d219-6d84-4a68-b9ad-954f8078d94d"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("4a68df10-6812-4385-8d90-1d88746f7c2b"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("6db6c39b-65dd-4965-ba1a-a214a25f53f8"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("5925a17b-b9e5-4e60-b4c8-27b606a03811"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("da2d861a-18b6-4af4-b6ce-cab83599b318"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "525cd8c2-bcd0-4077-ad70-0e45b73e9076");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "7e9ff88b-8c89-433a-b63a-cf29bee0fda7");

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("393d525b-d90a-4e24-8682-9f3a0ae5b30a"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("8c5439fd-af20-44e5-ba2b-0c14d4c5100d"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: "1d27686a-55a3-4252-a8a7-4b6f51b72b9b");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "2a69e5d0-713e-483a-8326-2974c10e3d92");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "6747dacd-f36a-4dd2-ac40-f0df5b004bea");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "987f7b3d-5240-47c2-bea0-68bca8cfeb79");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "b5e57769-52e5-4dca-8628-04360ee00c45");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "RefreshTokenExpiryTime",
                table: "ApplicationUsers",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "ApplicationUsers");

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2952161c-ce04-43b7-afc4-cee6ddb1a87d"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 263, DateTimeKind.Unspecified).AddTicks(8627), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 263, DateTimeKind.Unspecified).AddTicks(8628), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "ADMIN" },
                    { new Guid("3d26d219-6d84-4a68-b9ad-954f8078d94d"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 263, DateTimeKind.Unspecified).AddTicks(8631), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 263, DateTimeKind.Unspecified).AddTicks(8631), new TimeSpan(0, 0, 0, 0, 0)), "Manager", "MANAGER" },
                    { new Guid("4a68df10-6812-4385-8d90-1d88746f7c2b"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 263, DateTimeKind.Unspecified).AddTicks(8635), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 263, DateTimeKind.Unspecified).AddTicks(8635), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" },
                    { new Guid("6db6c39b-65dd-4965-ba1a-a214a25f53f8"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 263, DateTimeKind.Unspecified).AddTicks(8633), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 263, DateTimeKind.Unspecified).AddTicks(8633), new TimeSpan(0, 0, 0, 0, 0)), "Stylist", "STYLIST" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "OpenTime", "ShopEmail", "ShopPhone", "Title" },
                values: new object[] { "1d27686a-55a3-4252-a8a7-4b6f51b72b9b", "123 Main St, Cityville", new TimeSpan(0, 19, 0, 0, 0), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(8058), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(8059), new TimeSpan(0, 0, 0, 0, 0)), "Salon A", new TimeSpan(0, 9, 0, 0, 0), "contact@salona.com", "123-456-7890", "Best Hair Salon in Town" });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Bank", "BankAccount", "BankAccountName", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Firstname", "LastUpdatedBy", "LastUpdatedTime", "Lastname", "Point" },
                values: new object[,]
                {
                    { "2a69e5d0-713e-483a-8326-2974c10e3d92", "Bank D", "123456987", "Dan Tran", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 263, DateTimeKind.Unspecified).AddTicks(8805), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dan", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 263, DateTimeKind.Unspecified).AddTicks(8805), new TimeSpan(0, 0, 0, 0, 0)), "Tran", 0 },
                    { "6747dacd-f36a-4dd2-ac40-f0df5b004bea", "Bank c", "123456798", "Dev Nguyen", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 263, DateTimeKind.Unspecified).AddTicks(8802), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dev", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 263, DateTimeKind.Unspecified).AddTicks(8802), new TimeSpan(0, 0, 0, 0, 0)), "Nguyen", 0 },
                    { "987f7b3d-5240-47c2-bea0-68bca8cfeb79", "Bank B", "987654321", "Jane Smith", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 263, DateTimeKind.Unspecified).AddTicks(8798), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jane", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 263, DateTimeKind.Unspecified).AddTicks(8799), new TimeSpan(0, 0, 0, 0, 0)), "Smith", 150 },
                    { "b5e57769-52e5-4dca-8628-04360ee00c45", "Bank A", "123456789", "John Doe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 263, DateTimeKind.Unspecified).AddTicks(8793), new TimeSpan(0, 0, 0, 0, 0)), null, null, "John", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 263, DateTimeKind.Unspecified).AddTicks(8794), new TimeSpan(0, 0, 0, 0, 0)), "Doe", 100 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Email", "EmailConfirmed", "LastUpdatedBy", "LastUpdatedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OtpCode", "OtpCodeResetPassword", "OtpExpiration", "OtpExpirationResetPassword", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserInfoId", "UserName" },
                values: new object[,]
                {
                    { new Guid("393d525b-d90a-4e24-8682-9f3a0ae5b30a"), 0, "9b1307a7-a445-4390-a37f-8ce83ab480aa", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(7825), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(7826), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEHUOhsSwdI0w/BLxXhiGUuUN1ArxXL+/Nip1QaNWPJfG2A7M0gTPbn/+HTPq5VIn7Q==", null, false, null, false, "987f7b3d-5240-47c2-bea0-68bca8cfeb79", "user" },
                    { new Guid("5925a17b-b9e5-4e60-b4c8-27b606a03811"), 0, "30e93df1-647c-4018-a1bf-0a82f6f8192e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(7831), new TimeSpan(0, 0, 0, 0, 0)), null, null, "manager@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(7831), new TimeSpan(0, 0, 0, 0, 0)), false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEHJr7haC0OFNgLBE7Ni+1XYwihRYhxRVxW9ry9nY27ImYH3okP95q5nxe/pv1ZwtKw==", null, false, null, false, "6747dacd-f36a-4dd2-ac40-f0df5b004bea", "manager" },
                    { new Guid("8c5439fd-af20-44e5-ba2b-0c14d4c5100d"), 0, "0370ae27-e8cd-45fb-9cc2-3642a67f221d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(7816), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(7817), new TimeSpan(0, 0, 0, 0, 0)), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEDXOVmKvoYYVdpNTU8k45LGc16BRh/GcpbOHaz6ctPiD4k+5uSJiVFlexpvBY4eUZw==", null, false, null, false, "b5e57769-52e5-4dca-8628-04360ee00c45", "admin" },
                    { new Guid("da2d861a-18b6-4af4-b6ce-cab83599b318"), 0, "97bde579-1d7b-4265-b65f-406c447c51d7", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(7835), new TimeSpan(0, 0, 0, 0, 0)), null, null, "stylist@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(7836), new TimeSpan(0, 0, 0, 0, 0)), false, null, "STYLIST@EXAMPLE.COM", "STYLIST@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEFO8MtnBo5kRcBxuLss8VC5vH9mbzcRqmp2smc2c/eEvdGCSUR44IFn2PhkBySsyzg==", null, false, null, false, "2a69e5d0-713e-483a-8326-2974c10e3d92", "stylist" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Name", "Price", "ShopId", "Type" },
                values: new object[,]
                {
                    { "5fd85e69-9bbc-42b6-8867-d1c6b6801179", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(8149), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A premium hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(8149), new TimeSpan(0, 0, 0, 0, 0)), "Premium Hair Coloring", 100000.00m, "1d27686a-55a3-4252-a8a7-4b6f51b72b9b", "Hair" },
                    { "606c590b-b7dc-4cee-9efb-fbc47b32a232", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(8144), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A complete hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(8145), new TimeSpan(0, 0, 0, 0, 0)), "Hair Coloring", 50000.00m, "1d27686a-55a3-4252-a8a7-4b6f51b72b9b", "Hair" },
                    { "7e9ff88b-8c89-433a-b63a-cf29bee0fda7", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(8134), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A stylish haircut to refresh your look.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(8140), new TimeSpan(0, 0, 0, 0, 0)), "Hair Cut", 25000.00m, "1d27686a-55a3-4252-a8a7-4b6f51b72b9b", "Hair" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { new Guid("4a68df10-6812-4385-8d90-1d88746f7c2b"), new Guid("393d525b-d90a-4e24-8682-9f3a0ae5b30a"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(7985), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(7986), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3d26d219-6d84-4a68-b9ad-954f8078d94d"), new Guid("5925a17b-b9e5-4e60-b4c8-27b606a03811"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(7988), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(7989), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2952161c-ce04-43b7-afc4-cee6ddb1a87d"), new Guid("8c5439fd-af20-44e5-ba2b-0c14d4c5100d"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(7982), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(7983), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6db6c39b-65dd-4965-ba1a-a214a25f53f8"), new Guid("da2d861a-18b6-4af4-b6ce-cab83599b318"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(7991), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(7991), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PointsEarned", "StatusForAppointment", "StylistId", "UserId" },
                values: new object[] { "525cd8c2-bcd0-4077-ad70-0e45b73e9076", new DateTime(2024, 10, 12, 2, 38, 4, 490, DateTimeKind.Utc).AddTicks(8270), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(8286), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(8287), new TimeSpan(0, 0, 0, 0, 0)), 10, "Scheduled", new Guid("393d525b-d90a-4e24-8682-9f3a0ae5b30a"), new Guid("8c5439fd-af20-44e5-ba2b-0c14d4c5100d") });

            migrationBuilder.InsertData(
                table: "SalaryPayments",
                columns: new[] { "Id", "BaseSalary", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentDate", "UserId" },
                values: new object[] { "bfbd151e-a1c2-4ff7-9d26-c5f2c3d5d3e2", 2000.00m, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(8446), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(8446), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Utc).AddTicks(8445), new Guid("8c5439fd-af20-44e5-ba2b-0c14d4c5100d") });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "AppointmentId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentMethod", "PaymentTime", "TotalAmount" },
                values: new object[] { "aeaca7d8-bdd0-40b1-993b-da7ab5fea28e", "525cd8c2-bcd0-4077-ad70-0e45b73e9076", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(8348), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(8349), new TimeSpan(0, 0, 0, 0, 0)), "Credit Card", new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Utc).AddTicks(8347), 100.00m });

            migrationBuilder.InsertData(
                table: "ServiceAppointments",
                columns: new[] { "Id", "AppointmentId", "Comment", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Rate", "ServiceId" },
                values: new object[] { "039db19d-11d6-4473-b32b-3c422e676c1e", "525cd8c2-bcd0-4077-ad70-0e45b73e9076", "Excellent service!", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(8402), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Basic haircut", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 38, 4, 490, DateTimeKind.Unspecified).AddTicks(8406), new TimeSpan(0, 0, 0, 0, 0)), 5, "7e9ff88b-8c89-433a-b63a-cf29bee0fda7" });
        }
    }
}
