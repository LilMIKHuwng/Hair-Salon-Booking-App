using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HairSalon.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("45c9d538-0cca-4c7d-a7a0-329b437414ec"), new Guid("0294c6d3-efbb-4a49-8435-e28626ee69bb") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("81209bce-2db1-42f4-9f16-2a5c3f9d37ff"), new Guid("03e9d7d7-0885-432d-ad8b-29fbccee8459") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("81209bce-2db1-42f4-9f16-2a5c3f9d37ff"), new Guid("062611dc-eb12-42f8-b486-a2c760a52508") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("81209bce-2db1-42f4-9f16-2a5c3f9d37ff"), new Guid("17da4035-1fa5-4031-b01d-7d30e0349d6b") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("81209bce-2db1-42f4-9f16-2a5c3f9d37ff"), new Guid("525eab5d-ddaf-4fed-a806-e11914bcb058") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("28a82f7f-5cd5-4824-8548-8fda9d2db39f"), new Guid("57e33e85-fe57-43cf-8d88-265cd2e0d452") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("81209bce-2db1-42f4-9f16-2a5c3f9d37ff"), new Guid("a778ee87-323e-4a19-9fe6-9cd03bd83721") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("131955e3-dd13-4986-8493-38653b009d6c"), new Guid("e16d419f-b188-495a-a819-298133659592") });

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "08b9528c-a989-4cdd-96ed-ce8af614c7b5");

            migrationBuilder.DeleteData(
                table: "ComboAppointment",
                keyColumn: "Id",
                keyValue: "512043c5-7a00-4cbb-a3e3-c329b2d84b6c");

            migrationBuilder.DeleteData(
                table: "ComboAppointment",
                keyColumn: "Id",
                keyValue: "a5474511-59f4-4640-b9ad-710da0ce8acd");

            migrationBuilder.DeleteData(
                table: "ComboAppointment",
                keyColumn: "Id",
                keyValue: "b14e7b0b-3415-4ab4-a0fe-bafb52f440cf");

            migrationBuilder.DeleteData(
                table: "ComboServices",
                keyColumn: "Id",
                keyValue: "4ac739d22c3c40aeb536b7a2630db74b");

            migrationBuilder.DeleteData(
                table: "ComboServices",
                keyColumn: "Id",
                keyValue: "5cd0f6a6333f47e28a04037b293663e9");

            migrationBuilder.DeleteData(
                table: "ComboServices",
                keyColumn: "Id",
                keyValue: "77bd38c1c273478596abaf2330e7c261");

            migrationBuilder.DeleteData(
                table: "ComboServices",
                keyColumn: "Id",
                keyValue: "7b6275f3de1841e89132da0d452d24e2");

            migrationBuilder.DeleteData(
                table: "ComboServices",
                keyColumn: "Id",
                keyValue: "a200a81a8cdd4b4a9a7d2d4c73a4f01f");

            migrationBuilder.DeleteData(
                table: "ComboServices",
                keyColumn: "Id",
                keyValue: "d77b400ea1f9489db7a5d24c71d185ec");

            migrationBuilder.DeleteData(
                table: "SalaryPayments",
                keyColumn: "Id",
                keyValue: "5532995a-356f-4e96-bdff-6472051de036");

            migrationBuilder.DeleteData(
                table: "ServiceAppointments",
                keyColumn: "Id",
                keyValue: "ec91fa84-e6d3-488e-a19f-eac6f81ee436");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "0da23fad-27bd-4b51-a283-7fb57b2804d7");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "90cc844d-7ce9-48d1-9e2d-d428db305045");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("131955e3-dd13-4986-8493-38653b009d6c"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("28a82f7f-5cd5-4824-8548-8fda9d2db39f"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("45c9d538-0cca-4c7d-a7a0-329b437414ec"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("81209bce-2db1-42f4-9f16-2a5c3f9d37ff"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("062611dc-eb12-42f8-b486-a2c760a52508"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("17da4035-1fa5-4031-b01d-7d30e0349d6b"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("525eab5d-ddaf-4fed-a806-e11914bcb058"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "3d984ab5-bbb8-4021-8734-603290f4e565");

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "551475b8-32f5-4eda-bb27-0c9d7e411ec5");

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "9da3831b-abca-453a-b919-21b86d483e98");

            migrationBuilder.DeleteData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: "23fca8cf-6fe9-4171-b4f5-39329e9fbb6d");

            migrationBuilder.DeleteData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: "86d9be6c-c729-44d3-a4ec-8bd8cbd28d45");

            migrationBuilder.DeleteData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: "baff6c51-76b1-446a-a78e-0081f4860471");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "02518d1c-7d66-4830-9510-8ae7d8ac0cf6");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "0f768ca2-ee78-4cf3-931b-7cb9e4772ccc");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "0f832951-e748-4921-8f37-867a5128c8c6");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "1350eec1-79a3-40e5-8b3d-1418ac6fe088");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "82d5574c-2f97-47d2-b890-6aa4de5bbd53");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "c9269dfd-81e3-4324-a682-d02bf0c562bd");

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("0294c6d3-efbb-4a49-8435-e28626ee69bb"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("03e9d7d7-0885-432d-ad8b-29fbccee8459"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("57e33e85-fe57-43cf-8d88-265cd2e0d452"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("a778ee87-323e-4a19-9fe6-9cd03bd83721"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("e16d419f-b188-495a-a819-298133659592"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: "b3c2c051-b588-40cc-a07b-e24d41428dfe");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "3ca7b09b-06fa-4e22-ab99-d2a16cd2f18d");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "638b294f-75e8-49b1-9481-9db4bb65689a");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "b564bb25-a7e5-45bc-8289-406f905a1cdc");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "d67b1f8a-b606-4b9a-9788-13f75f149ff2");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionStatus",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionNo",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ResponseCode",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CardType",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BankTranNo",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BankCode",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("09853424-1cb8-4487-9041-5f851921c056"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 56, 487, DateTimeKind.Unspecified).AddTicks(4705), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 56, 487, DateTimeKind.Unspecified).AddTicks(4705), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" },
                    { new Guid("6838dbfe-36ba-4fb9-83c8-c0eceaa077da"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 56, 487, DateTimeKind.Unspecified).AddTicks(4699), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 56, 487, DateTimeKind.Unspecified).AddTicks(4699), new TimeSpan(0, 0, 0, 0, 0)), "Manager", "MANAGER" },
                    { new Guid("90a9df13-f757-42ab-861b-82083b35f305"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 56, 487, DateTimeKind.Unspecified).AddTicks(4702), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 56, 487, DateTimeKind.Unspecified).AddTicks(4703), new TimeSpan(0, 0, 0, 0, 0)), "Stylist", "STYLIST" },
                    { new Guid("9f43d74c-4aab-470d-add5-7c6952679c37"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 56, 487, DateTimeKind.Unspecified).AddTicks(4694), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 56, 487, DateTimeKind.Unspecified).AddTicks(4695), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "TimeCombo", "TotalPrice" },
                values: new object[,]
                {
                    { "945a76d2-f7d7-4d56-a11f-04866e096f2d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2239), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2240), new TimeSpan(0, 0, 0, 0, 0)), "Deluxe Hair Combo", 120, 80000.00m },
                    { "bc8b504f-a34b-46dd-8946-97a17d33d89c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2243), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2243), new TimeSpan(0, 0, 0, 0, 0)), "Ultimate Hair & Beard Combo", 150, 120000.00m },
                    { "f12e2ffc-4267-4650-a8a8-2e949b13085d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2235), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2236), new TimeSpan(0, 0, 0, 0, 0)), "Basic Hair Combo", 60, 40000.00m }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "OpenTime", "ShopEmail", "ShopPhone", "Title" },
                values: new object[] { "9987b8c0-63c1-45e0-b145-4bf62385c331", "123 Main St, Cityville", new TimeSpan(0, 19, 0, 0, 0), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1762), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1763), new TimeSpan(0, 0, 0, 0, 0)), "Salon A", new TimeSpan(0, 9, 0, 0, 0), "contact@salona.com", "123-456-7890", "Best Hair Salon in Town" });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Bank", "BankAccount", "BankAccountName", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Firstname", "LastUpdatedBy", "LastUpdatedTime", "Lastname", "Point" },
                values: new object[,]
                {
                    { "2e7f07ef-feb4-41d9-94e5-25e54e744c29", "Bank A", "123456789", "John Doe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 56, 487, DateTimeKind.Unspecified).AddTicks(5056), new TimeSpan(0, 0, 0, 0, 0)), null, null, "John", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 56, 487, DateTimeKind.Unspecified).AddTicks(5056), new TimeSpan(0, 0, 0, 0, 0)), "Doe", 100 },
                    { "3dd73682-1bcd-4587-81b2-5bc0c97c66a8", "Bank c", "123456798", "Dev Nguyen", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 56, 487, DateTimeKind.Unspecified).AddTicks(5070), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dev", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 56, 487, DateTimeKind.Unspecified).AddTicks(5070), new TimeSpan(0, 0, 0, 0, 0)), "Nguyen", 0 },
                    { "a5773370-5534-41f2-a6c6-ef64463eb425", "Bank D", "123456987", "Dan Tran", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 56, 487, DateTimeKind.Unspecified).AddTicks(5074), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dan", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 56, 487, DateTimeKind.Unspecified).AddTicks(5075), new TimeSpan(0, 0, 0, 0, 0)), "Tran", 0 },
                    { "faf44095-4294-45f1-a776-ff7cec25e076", "Bank B", "987654321", "Jane Smith", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 56, 487, DateTimeKind.Unspecified).AddTicks(5065), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jane", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 56, 487, DateTimeKind.Unspecified).AddTicks(5066), new TimeSpan(0, 0, 0, 0, 0)), "Smith", 150 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "E_Wallet", "Email", "EmailConfirmed", "LastUpdatedBy", "LastUpdatedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OtpCode", "OtpCodeResetPassword", "OtpExpiration", "OtpExpirationResetPassword", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserInfoId", "UserName" },
                values: new object[,]
                {
                    { new Guid("19749a2a-8eaf-4869-8d2d-722c4ee00c5d"), 0, "6a8249b2-ee43-4b32-966a-7bdd16f3cc3c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1330), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "stylist@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1330), new TimeSpan(0, 0, 0, 0, 0)), false, null, "STYLIST@EXAMPLE.COM", "STYLIST@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEMwW+bkCmEW7zI3lmPT45BRh54AYewgg0irW75dgSe6OBCDBPFG2fLtxpGmzgA6u0w==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "a5773370-5534-41f2-a6c6-ef64463eb425", "stylist" },
                    { new Guid("344cdb80-4bca-45eb-8bb0-5dffa18b971c"), 0, "7062201f-ecbb-4d07-bc60-9d4ffb1ae685", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1309), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "admin@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1310), new TimeSpan(0, 0, 0, 0, 0)), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEAU/bS+GLAjF0Aa3j7S7uj6DFyJZbqPxRJwcaH4eEHxTLyWQAcrT0QCz701uYoAEuA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "2e7f07ef-feb4-41d9-94e5-25e54e744c29", "admin" },
                    { new Guid("4e91514b-f26f-4b67-903f-b6eb06774f3e"), 0, "029261e2-fd77-451a-a9b0-659501fef165", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1449), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user5@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1450), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEBQCSAvo7QbUkm4BFdei4nsprWPNy/PDCkru6kQEtahKbtNqFMJGKF4y8NsPYlXLfg==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "a5773370-5534-41f2-a6c6-ef64463eb425", "user5" },
                    { new Guid("587d1bca-4221-42c6-9db4-8b1ae205a472"), 0, "0b45901e-41dd-438e-ab1b-186254f306ce", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1442), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user4@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1443), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEEU62vX88fFgC9w4ODqasW1aVZAKjWXL2C5m4zh7r6KhLEyKmEYsHGRphbpDM55cEA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "3dd73682-1bcd-4587-81b2-5bc0c97c66a8", "user4" },
                    { new Guid("5c5def45-73a6-4b29-96f1-425993be0487"), 0, "abb38c61-f69d-4b46-a18e-35b27272806f", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1317), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1319), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAELBfLkmJP0H/kAGxmM6A/gbFvEPq/j6kZY2B6ttPxq3Xd78F1mnOJR0ydpEUybpKJw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "faf44095-4294-45f1-a776-ff7cec25e076", "user" },
                    { new Guid("6023c826-d0a3-44da-b157-82b70da4415f"), 0, "e8122749-b232-493c-b1ff-778cb2c10a59", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1325), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "manager@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1325), new TimeSpan(0, 0, 0, 0, 0)), false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEKxPJk23Oq93ZdLISQf6RttcyGeir7kFwxkpdah+XBbjxSFVqn7YhrtG1O5250N9EA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "3dd73682-1bcd-4587-81b2-5bc0c97c66a8", "manager" },
                    { new Guid("c71e6bfa-04b1-4816-9192-aa40b53ccf3d"), 0, "91136ff7-0d77-46f0-a627-4f671b1c30c5", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1335), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user2@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1335), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAELsJfCIlqD3XQxzQNyMMdbp2sK4LlcLMxZGgDn4+fa9KDq05JQHrSsFg6cvCtydKSw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "2e7f07ef-feb4-41d9-94e5-25e54e744c29", "user2" },
                    { new Guid("ecf79a7b-3fa1-421c-81a5-f42269412dbf"), 0, "9a8b472b-be38-4c00-b2f0-eb5081feba94", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1339), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user3@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1341), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER3@EXAMPLE.COM", "USER3@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAELvXHioFuvVbSPyj3p6jEPu3w23sc4RznaFxBkwFpDsemxAYXD/bY6pR5kvmBe8vUw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "faf44095-4294-45f1-a776-ff7cec25e076", "user3" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Name", "Price", "ShopId", "TimeService", "Type" },
                values: new object[,]
                {
                    { "10f8fdc3-1ae5-403b-b6ad-7a70985ee4f6", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1857), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A professional hair styling service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1857), new TimeSpan(0, 0, 0, 0, 0)), "Hair Styling", 20000.00m, "9987b8c0-63c1-45e0-b145-4bf62385c331", 45, "Hair" },
                    { "21485bd2-d2fb-440c-bfbd-d8a3c7f8637f", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1845), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A stylish haircut to refresh your look.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1846), new TimeSpan(0, 0, 0, 0, 0)), "Hair Cut", 25000.00m, "9987b8c0-63c1-45e0-b145-4bf62385c331", 30, "Hair" },
                    { "2789c27c-dac3-4a9b-9f66-2d3673b0e9e1", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1874), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A soothing scalp treatment.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1874), new TimeSpan(0, 0, 0, 0, 0)), "Scalp Treatment", 45000.00m, "9987b8c0-63c1-45e0-b145-4bf62385c331", 40, "Hair" },
                    { "9ebe3407-c1f0-414f-bebd-be57d87ce33b", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1863), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A neat beard trimming service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1863), new TimeSpan(0, 0, 0, 0, 0)), "Beard Trim", 15000.00m, "9987b8c0-63c1-45e0-b145-4bf62385c331", 20, "Beard" },
                    { "a91b0bb8-a94e-41c8-a169-0acb9d3c086a", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1850), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A complete hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1850), new TimeSpan(0, 0, 0, 0, 0)), "Hair Coloring", 50000.00m, "9987b8c0-63c1-45e0-b145-4bf62385c331", 30, "Hair" },
                    { "a96183da-e58d-4a81-a904-90dd5045118a", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1870), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A rejuvenating facial service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1871), new TimeSpan(0, 0, 0, 0, 0)), "Facial", 40000.00m, "9987b8c0-63c1-45e0-b145-4bf62385c331", 50, "Skin" },
                    { "cbd014ac-3e74-42a1-ab5f-ff50b9014562", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1853), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A premium hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1854), new TimeSpan(0, 0, 0, 0, 0)), "Premium Hair Coloring", 100000.00m, "9987b8c0-63c1-45e0-b145-4bf62385c331", 60, "Hair" },
                    { "f7b9488d-a9e7-47ab-a6d4-eff9f57c1720", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1867), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A clean and smooth shaving service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1867), new TimeSpan(0, 0, 0, 0, 0)), "Shave", 12000.00m, "9987b8c0-63c1-45e0-b145-4bf62385c331", 15, "Beard" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { new Guid("90a9df13-f757-42ab-861b-82083b35f305"), new Guid("19749a2a-8eaf-4869-8d2d-722c4ee00c5d"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1645), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1646), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9f43d74c-4aab-470d-add5-7c6952679c37"), new Guid("344cdb80-4bca-45eb-8bb0-5dffa18b971c"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1625), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1626), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("09853424-1cb8-4487-9041-5f851921c056"), new Guid("4e91514b-f26f-4b67-903f-b6eb06774f3e"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1664), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1665), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("09853424-1cb8-4487-9041-5f851921c056"), new Guid("587d1bca-4221-42c6-9db4-8b1ae205a472"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1653), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1662), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("09853424-1cb8-4487-9041-5f851921c056"), new Guid("5c5def45-73a6-4b29-96f1-425993be0487"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1629), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1640), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6838dbfe-36ba-4fb9-83c8-c0eceaa077da"), new Guid("6023c826-d0a3-44da-b157-82b70da4415f"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1643), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1643), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("09853424-1cb8-4487-9041-5f851921c056"), new Guid("c71e6bfa-04b1-4816-9192-aa40b53ccf3d"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1648), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1648), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("09853424-1cb8-4487-9041-5f851921c056"), new Guid("ecf79a7b-3fa1-421c-81a5-f42269412dbf"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1650), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1651), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PointsEarned", "StatusForAppointment", "StylistId", "TotalAmount", "TotalTime", "UserId" },
                values: new object[,]
                {
                    { "4e056879-12e3-47bd-ad3a-acd29575df5b", new DateTime(2024, 10, 23, 14, 48, 57, 137, DateTimeKind.Utc).AddTicks(1996), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1997), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1997), new TimeSpan(0, 0, 0, 0, 0)), 15, "Scheduled", new Guid("19749a2a-8eaf-4869-8d2d-722c4ee00c5d"), 65000.00m, 75, new Guid("6023c826-d0a3-44da-b157-82b70da4415f") },
                    { "53d593d1-ab6a-4cbf-96db-755800e9af57", new DateTime(2024, 10, 22, 14, 48, 57, 137, DateTimeKind.Utc).AddTicks(1977), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1990), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(1991), new TimeSpan(0, 0, 0, 0, 0)), 10, "Pending", new Guid("5c5def45-73a6-4b29-96f1-425993be0487"), 100000.00m, 0, new Guid("344cdb80-4bca-45eb-8bb0-5dffa18b971c") },
                    { "6237d32c-346b-4377-b688-102b5206f742", new DateTime(2024, 10, 24, 14, 48, 57, 137, DateTimeKind.Utc).AddTicks(2006), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2007), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2007), new TimeSpan(0, 0, 0, 0, 0)), 12, "Pending", new Guid("19749a2a-8eaf-4869-8d2d-722c4ee00c5d"), 200000.00m, 45, new Guid("c71e6bfa-04b1-4816-9192-aa40b53ccf3d") },
                    { "fab64eae-27da-432a-ad63-43a03ac640ed", new DateTime(2024, 10, 25, 14, 48, 57, 137, DateTimeKind.Utc).AddTicks(2034), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2035), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2036), new TimeSpan(0, 0, 0, 0, 0)), 20, "Completed", new Guid("19749a2a-8eaf-4869-8d2d-722c4ee00c5d"), 150000.00m, 90, new Guid("587d1bca-4221-42c6-9db4-8b1ae205a472") }
                });

            migrationBuilder.InsertData(
                table: "ComboServices",
                columns: new[] { "Id", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[,]
                {
                    { "0eb332e535cf48ef9471f5e2b176bd27", "bc8b504f-a34b-46dd-8946-97a17d33d89c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2313), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2314), new TimeSpan(0, 0, 0, 0, 0)), "f7b9488d-a9e7-47ab-a6d4-eff9f57c1720" },
                    { "50facb409f8743fda5f25a73699a074b", "945a76d2-f7d7-4d56-a11f-04866e096f2d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2301), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2302), new TimeSpan(0, 0, 0, 0, 0)), "10f8fdc3-1ae5-403b-b6ad-7a70985ee4f6" },
                    { "7b9098e551c44a20bd3c577db7102b17", "945a76d2-f7d7-4d56-a11f-04866e096f2d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2297), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2297), new TimeSpan(0, 0, 0, 0, 0)), "cbd014ac-3e74-42a1-ab5f-ff50b9014562" },
                    { "96f8697c48a74c5a866adc33f157d2a7", "f12e2ffc-4267-4650-a8a8-2e949b13085d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2293), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2293), new TimeSpan(0, 0, 0, 0, 0)), "a91b0bb8-a94e-41c8-a169-0acb9d3c086a" },
                    { "d50157e5309d465186203344874e9009", "f12e2ffc-4267-4650-a8a8-2e949b13085d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2288), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2289), new TimeSpan(0, 0, 0, 0, 0)), "21485bd2-d2fb-440c-bfbd-d8a3c7f8637f" },
                    { "ff1e5724a76040f584b56f9035d40d48", "bc8b504f-a34b-46dd-8946-97a17d33d89c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2307), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2308), new TimeSpan(0, 0, 0, 0, 0)), "9ebe3407-c1f0-414f-bebd-be57d87ce33b" }
                });

            migrationBuilder.InsertData(
                table: "SalaryPayments",
                columns: new[] { "Id", "BaseSalary", "BonusSalary", "CreatedBy", "CreatedTime", "DayOffNoPermitted", "DayOffPermitted", "DeductedSalary", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentDate", "UserId" },
                values: new object[] { "b016c5a4-3972-47e5-ac32-9914bb7afce7", 2000.00m, 0m, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2178), new TimeSpan(0, 0, 0, 0, 0)), 0, 0, 0m, null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2178), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Utc).AddTicks(2177), new Guid("344cdb80-4bca-45eb-8bb0-5dffa18b971c") });

            migrationBuilder.InsertData(
                table: "ComboAppointment",
                columns: new[] { "Id", "AppointmentId", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { "7f8fab83-2fc8-4112-bc5c-61f0be372857", "4e056879-12e3-47bd-ad3a-acd29575df5b", "945a76d2-f7d7-4d56-a11f-04866e096f2d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2387), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2387), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "843db089-ecd9-4eff-9d53-e9212cfc9dd2", "6237d32c-346b-4377-b688-102b5206f742", "bc8b504f-a34b-46dd-8946-97a17d33d89c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2392), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2392), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "95724be9-f9f0-49ff-86ac-8aedb4d123a6", "53d593d1-ab6a-4cbf-96db-755800e9af57", "f12e2ffc-4267-4650-a8a8-2e949b13085d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2383), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2384), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ServiceAppointments",
                columns: new[] { "Id", "AppointmentId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[] { "a7e12682-52fa-498f-a598-7e851b5be7a1", "53d593d1-ab6a-4cbf-96db-755800e9af57", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2134), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Basic haircut", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 14, 48, 57, 137, DateTimeKind.Unspecified).AddTicks(2134), new TimeSpan(0, 0, 0, 0, 0)), "21485bd2-d2fb-440c-bfbd-d8a3c7f8637f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("90a9df13-f757-42ab-861b-82083b35f305"), new Guid("19749a2a-8eaf-4869-8d2d-722c4ee00c5d") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9f43d74c-4aab-470d-add5-7c6952679c37"), new Guid("344cdb80-4bca-45eb-8bb0-5dffa18b971c") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("09853424-1cb8-4487-9041-5f851921c056"), new Guid("4e91514b-f26f-4b67-903f-b6eb06774f3e") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("09853424-1cb8-4487-9041-5f851921c056"), new Guid("587d1bca-4221-42c6-9db4-8b1ae205a472") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("09853424-1cb8-4487-9041-5f851921c056"), new Guid("5c5def45-73a6-4b29-96f1-425993be0487") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6838dbfe-36ba-4fb9-83c8-c0eceaa077da"), new Guid("6023c826-d0a3-44da-b157-82b70da4415f") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("09853424-1cb8-4487-9041-5f851921c056"), new Guid("c71e6bfa-04b1-4816-9192-aa40b53ccf3d") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("09853424-1cb8-4487-9041-5f851921c056"), new Guid("ecf79a7b-3fa1-421c-81a5-f42269412dbf") });

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "fab64eae-27da-432a-ad63-43a03ac640ed");

            migrationBuilder.DeleteData(
                table: "ComboAppointment",
                keyColumn: "Id",
                keyValue: "7f8fab83-2fc8-4112-bc5c-61f0be372857");

            migrationBuilder.DeleteData(
                table: "ComboAppointment",
                keyColumn: "Id",
                keyValue: "843db089-ecd9-4eff-9d53-e9212cfc9dd2");

            migrationBuilder.DeleteData(
                table: "ComboAppointment",
                keyColumn: "Id",
                keyValue: "95724be9-f9f0-49ff-86ac-8aedb4d123a6");

            migrationBuilder.DeleteData(
                table: "ComboServices",
                keyColumn: "Id",
                keyValue: "0eb332e535cf48ef9471f5e2b176bd27");

            migrationBuilder.DeleteData(
                table: "ComboServices",
                keyColumn: "Id",
                keyValue: "50facb409f8743fda5f25a73699a074b");

            migrationBuilder.DeleteData(
                table: "ComboServices",
                keyColumn: "Id",
                keyValue: "7b9098e551c44a20bd3c577db7102b17");

            migrationBuilder.DeleteData(
                table: "ComboServices",
                keyColumn: "Id",
                keyValue: "96f8697c48a74c5a866adc33f157d2a7");

            migrationBuilder.DeleteData(
                table: "ComboServices",
                keyColumn: "Id",
                keyValue: "d50157e5309d465186203344874e9009");

            migrationBuilder.DeleteData(
                table: "ComboServices",
                keyColumn: "Id",
                keyValue: "ff1e5724a76040f584b56f9035d40d48");

            migrationBuilder.DeleteData(
                table: "SalaryPayments",
                keyColumn: "Id",
                keyValue: "b016c5a4-3972-47e5-ac32-9914bb7afce7");

            migrationBuilder.DeleteData(
                table: "ServiceAppointments",
                keyColumn: "Id",
                keyValue: "a7e12682-52fa-498f-a598-7e851b5be7a1");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "2789c27c-dac3-4a9b-9f66-2d3673b0e9e1");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "a96183da-e58d-4a81-a904-90dd5045118a");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("09853424-1cb8-4487-9041-5f851921c056"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("6838dbfe-36ba-4fb9-83c8-c0eceaa077da"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("90a9df13-f757-42ab-861b-82083b35f305"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f43d74c-4aab-470d-add5-7c6952679c37"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("4e91514b-f26f-4b67-903f-b6eb06774f3e"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("587d1bca-4221-42c6-9db4-8b1ae205a472"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ecf79a7b-3fa1-421c-81a5-f42269412dbf"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "4e056879-12e3-47bd-ad3a-acd29575df5b");

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "53d593d1-ab6a-4cbf-96db-755800e9af57");

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "6237d32c-346b-4377-b688-102b5206f742");

            migrationBuilder.DeleteData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: "945a76d2-f7d7-4d56-a11f-04866e096f2d");

            migrationBuilder.DeleteData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: "bc8b504f-a34b-46dd-8946-97a17d33d89c");

            migrationBuilder.DeleteData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: "f12e2ffc-4267-4650-a8a8-2e949b13085d");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "10f8fdc3-1ae5-403b-b6ad-7a70985ee4f6");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "21485bd2-d2fb-440c-bfbd-d8a3c7f8637f");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "9ebe3407-c1f0-414f-bebd-be57d87ce33b");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "a91b0bb8-a94e-41c8-a169-0acb9d3c086a");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "cbd014ac-3e74-42a1-ab5f-ff50b9014562");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "f7b9488d-a9e7-47ab-a6d4-eff9f57c1720");

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("19749a2a-8eaf-4869-8d2d-722c4ee00c5d"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("344cdb80-4bca-45eb-8bb0-5dffa18b971c"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("5c5def45-73a6-4b29-96f1-425993be0487"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("6023c826-d0a3-44da-b157-82b70da4415f"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("c71e6bfa-04b1-4816-9192-aa40b53ccf3d"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: "9987b8c0-63c1-45e0-b145-4bf62385c331");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "2e7f07ef-feb4-41d9-94e5-25e54e744c29");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "3dd73682-1bcd-4587-81b2-5bc0c97c66a8");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "a5773370-5534-41f2-a6c6-ef64463eb425");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "faf44095-4294-45f1-a776-ff7cec25e076");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionStatus",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TransactionNo",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ResponseCode",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardType",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BankTranNo",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BankCode",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("131955e3-dd13-4986-8493-38653b009d6c"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 268, DateTimeKind.Unspecified).AddTicks(4637), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 268, DateTimeKind.Unspecified).AddTicks(4638), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "ADMIN" },
                    { new Guid("28a82f7f-5cd5-4824-8548-8fda9d2db39f"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 268, DateTimeKind.Unspecified).AddTicks(4641), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 268, DateTimeKind.Unspecified).AddTicks(4642), new TimeSpan(0, 0, 0, 0, 0)), "Manager", "MANAGER" },
                    { new Guid("45c9d538-0cca-4c7d-a7a0-329b437414ec"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 268, DateTimeKind.Unspecified).AddTicks(4644), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 268, DateTimeKind.Unspecified).AddTicks(4644), new TimeSpan(0, 0, 0, 0, 0)), "Stylist", "STYLIST" },
                    { new Guid("81209bce-2db1-42f4-9f16-2a5c3f9d37ff"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 268, DateTimeKind.Unspecified).AddTicks(4646), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 268, DateTimeKind.Unspecified).AddTicks(4646), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "TimeCombo", "TotalPrice" },
                values: new object[,]
                {
                    { "23fca8cf-6fe9-4171-b4f5-39329e9fbb6d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9460), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9460), new TimeSpan(0, 0, 0, 0, 0)), "Ultimate Hair & Beard Combo", 150, 120000.00m },
                    { "86d9be6c-c729-44d3-a4ec-8bd8cbd28d45", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9451), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9451), new TimeSpan(0, 0, 0, 0, 0)), "Basic Hair Combo", 60, 40000.00m },
                    { "baff6c51-76b1-446a-a78e-0081f4860471", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9456), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9457), new TimeSpan(0, 0, 0, 0, 0)), "Deluxe Hair Combo", 120, 80000.00m }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "OpenTime", "ShopEmail", "ShopPhone", "Title" },
                values: new object[] { "b3c2c051-b588-40cc-a07b-e24d41428dfe", "123 Main St, Cityville", new TimeSpan(0, 19, 0, 0, 0), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8606), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8607), new TimeSpan(0, 0, 0, 0, 0)), "Salon A", new TimeSpan(0, 9, 0, 0, 0), "contact@salona.com", "123-456-7890", "Best Hair Salon in Town" });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Bank", "BankAccount", "BankAccountName", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Firstname", "LastUpdatedBy", "LastUpdatedTime", "Lastname", "Point" },
                values: new object[,]
                {
                    { "3ca7b09b-06fa-4e22-ab99-d2a16cd2f18d", "Bank A", "123456789", "John Doe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 268, DateTimeKind.Unspecified).AddTicks(4903), new TimeSpan(0, 0, 0, 0, 0)), null, null, "John", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 268, DateTimeKind.Unspecified).AddTicks(4903), new TimeSpan(0, 0, 0, 0, 0)), "Doe", 100 },
                    { "638b294f-75e8-49b1-9481-9db4bb65689a", "Bank c", "123456798", "Dev Nguyen", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 268, DateTimeKind.Unspecified).AddTicks(4912), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dev", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 268, DateTimeKind.Unspecified).AddTicks(4912), new TimeSpan(0, 0, 0, 0, 0)), "Nguyen", 0 },
                    { "b564bb25-a7e5-45bc-8289-406f905a1cdc", "Bank D", "123456987", "Dan Tran", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 268, DateTimeKind.Unspecified).AddTicks(4916), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dan", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 268, DateTimeKind.Unspecified).AddTicks(4919), new TimeSpan(0, 0, 0, 0, 0)), "Tran", 0 },
                    { "d67b1f8a-b606-4b9a-9788-13f75f149ff2", "Bank B", "987654321", "Jane Smith", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 268, DateTimeKind.Unspecified).AddTicks(4908), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jane", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 268, DateTimeKind.Unspecified).AddTicks(4908), new TimeSpan(0, 0, 0, 0, 0)), "Smith", 150 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "E_Wallet", "Email", "EmailConfirmed", "LastUpdatedBy", "LastUpdatedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OtpCode", "OtpCodeResetPassword", "OtpExpiration", "OtpExpirationResetPassword", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserInfoId", "UserName" },
                values: new object[,]
                {
                    { new Guid("0294c6d3-efbb-4a49-8435-e28626ee69bb"), 0, "0b4fe377-43d5-4224-a1d0-a9763789d05c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8216), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "stylist@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8217), new TimeSpan(0, 0, 0, 0, 0)), false, null, "STYLIST@EXAMPLE.COM", "STYLIST@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEL/XbgkULB0sXBCCQZgWshMfjPzFInDXkB9zjrwStoT1de7rC47owayAJG3/7l5GRA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "b564bb25-a7e5-45bc-8289-406f905a1cdc", "stylist" },
                    { new Guid("03e9d7d7-0885-432d-ad8b-29fbccee8459"), 0, "7eb5259c-e38f-44e4-91a5-27fe0b9e9647", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8194), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8198), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEKCqK5RGyyu9XKWiRIcX93AF1CSLit1op4WbxUrwFyKzxsGLqoH1x0WCueE2PqnpRA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "d67b1f8a-b606-4b9a-9788-13f75f149ff2", "user" },
                    { new Guid("062611dc-eb12-42f8-b486-a2c760a52508"), 0, "78056113-5d3f-4229-8657-e927c41f5beb", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8237), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user5@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8238), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEOyWpWky7bz1lw0h7t6HweZGxDGNO1c6HcGqwRZA6KmkRiYThf8H5pAMGVvV5HmDKw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "b564bb25-a7e5-45bc-8289-406f905a1cdc", "user5" },
                    { new Guid("17da4035-1fa5-4031-b01d-7d30e0349d6b"), 0, "9ce34106-9d92-4b2e-96e4-e7aaee162cb7", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8226), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user3@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8227), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER3@EXAMPLE.COM", "USER3@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEPYDo7YZZ0aZHjHrAv1xVIyE4AMcMtdg88d87HGT9cL/SRzHLm+hT9FMNCNNK6qB5g==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "d67b1f8a-b606-4b9a-9788-13f75f149ff2", "user3" },
                    { new Guid("525eab5d-ddaf-4fed-a806-e11914bcb058"), 0, "81008670-7473-44cf-88af-0645cec7285b", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8232), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user4@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8232), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEPFOPVfFO3M0ALq5Mi0Sm4AaTG8HeMYcYWp6Hp+CMLgLyLw4PjzTsagYhL/UJgOlRQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "638b294f-75e8-49b1-9481-9db4bb65689a", "user4" },
                    { new Guid("57e33e85-fe57-43cf-8d88-265cd2e0d452"), 0, "eadf2ae6-973d-46ae-9a7c-012a2a288c37", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8202), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "manager@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8203), new TimeSpan(0, 0, 0, 0, 0)), false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEJsBOjcrAF/pz0waVIEzNTxoO8ngqExS0zkMzNDzc+02vvwT1vV24t/41QtrCABe7g==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "638b294f-75e8-49b1-9481-9db4bb65689a", "manager" },
                    { new Guid("a778ee87-323e-4a19-9fe6-9cd03bd83721"), 0, "3945fb25-f969-4101-b18c-0d82e3881183", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8221), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user2@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8222), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEKTG33S6VBluiXvbHNOtSW+5i39+qAhYMJZ4VT19CBtaUbgJDr57D7Xpb9PIrjFU+Q==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "3ca7b09b-06fa-4e22-ab99-d2a16cd2f18d", "user2" },
                    { new Guid("e16d419f-b188-495a-a819-298133659592"), 0, "ae5193b5-5445-4cc9-9962-cbd7687ab107", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8186), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "admin@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8186), new TimeSpan(0, 0, 0, 0, 0)), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEG4jcm6rx1iVV2FQiFE2h75Asy+yip4+IaoPElnZrBHY2044a5A9hZF4HsT6OH1D9Q==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "3ca7b09b-06fa-4e22-ab99-d2a16cd2f18d", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Name", "Price", "ShopId", "TimeService", "Type" },
                values: new object[,]
                {
                    { "02518d1c-7d66-4830-9510-8ae7d8ac0cf6", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8676), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A complete hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8677), new TimeSpan(0, 0, 0, 0, 0)), "Hair Coloring", 50000.00m, "b3c2c051-b588-40cc-a07b-e24d41428dfe", 30, "Hair" },
                    { "0da23fad-27bd-4b51-a283-7fb57b2804d7", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8694), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A rejuvenating facial service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8694), new TimeSpan(0, 0, 0, 0, 0)), "Facial", 40000.00m, "b3c2c051-b588-40cc-a07b-e24d41428dfe", 50, "Skin" },
                    { "0f768ca2-ee78-4cf3-931b-7cb9e4772ccc", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8671), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A stylish haircut to refresh your look.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8671), new TimeSpan(0, 0, 0, 0, 0)), "Hair Cut", 25000.00m, "b3c2c051-b588-40cc-a07b-e24d41428dfe", 30, "Hair" },
                    { "0f832951-e748-4921-8f37-867a5128c8c6", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8680), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A premium hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8680), new TimeSpan(0, 0, 0, 0, 0)), "Premium Hair Coloring", 100000.00m, "b3c2c051-b588-40cc-a07b-e24d41428dfe", 60, "Hair" },
                    { "1350eec1-79a3-40e5-8b3d-1418ac6fe088", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8690), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A clean and smooth shaving service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8691), new TimeSpan(0, 0, 0, 0, 0)), "Shave", 12000.00m, "b3c2c051-b588-40cc-a07b-e24d41428dfe", 15, "Beard" },
                    { "82d5574c-2f97-47d2-b890-6aa4de5bbd53", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8683), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A professional hair styling service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8684), new TimeSpan(0, 0, 0, 0, 0)), "Hair Styling", 20000.00m, "b3c2c051-b588-40cc-a07b-e24d41428dfe", 45, "Hair" },
                    { "90cc844d-7ce9-48d1-9e2d-d428db305045", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8697), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A soothing scalp treatment.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8697), new TimeSpan(0, 0, 0, 0, 0)), "Scalp Treatment", 45000.00m, "b3c2c051-b588-40cc-a07b-e24d41428dfe", 40, "Hair" },
                    { "c9269dfd-81e3-4324-a682-d02bf0c562bd", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8687), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A neat beard trimming service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8687), new TimeSpan(0, 0, 0, 0, 0)), "Beard Trim", 15000.00m, "b3c2c051-b588-40cc-a07b-e24d41428dfe", 20, "Beard" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { new Guid("45c9d538-0cca-4c7d-a7a0-329b437414ec"), new Guid("0294c6d3-efbb-4a49-8435-e28626ee69bb"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8498), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8499), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("81209bce-2db1-42f4-9f16-2a5c3f9d37ff"), new Guid("03e9d7d7-0885-432d-ad8b-29fbccee8459"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8485), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8492), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("81209bce-2db1-42f4-9f16-2a5c3f9d37ff"), new Guid("062611dc-eb12-42f8-b486-a2c760a52508"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8523), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8524), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("81209bce-2db1-42f4-9f16-2a5c3f9d37ff"), new Guid("17da4035-1fa5-4031-b01d-7d30e0349d6b"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8504), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8504), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("81209bce-2db1-42f4-9f16-2a5c3f9d37ff"), new Guid("525eab5d-ddaf-4fed-a806-e11914bcb058"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8506), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8521), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("28a82f7f-5cd5-4824-8548-8fda9d2db39f"), new Guid("57e33e85-fe57-43cf-8d88-265cd2e0d452"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8495), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8496), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("81209bce-2db1-42f4-9f16-2a5c3f9d37ff"), new Guid("a778ee87-323e-4a19-9fe6-9cd03bd83721"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8501), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8501), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("131955e3-dd13-4986-8493-38653b009d6c"), new Guid("e16d419f-b188-495a-a819-298133659592"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8482), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(8482), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PointsEarned", "StatusForAppointment", "StylistId", "TotalAmount", "TotalTime", "UserId" },
                values: new object[,]
                {
                    { "08b9528c-a989-4cdd-96ed-ce8af614c7b5", new DateTime(2024, 10, 25, 13, 28, 19, 763, DateTimeKind.Utc).AddTicks(9203), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9204), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9204), new TimeSpan(0, 0, 0, 0, 0)), 20, "Completed", new Guid("0294c6d3-efbb-4a49-8435-e28626ee69bb"), 150000.00m, 90, new Guid("525eab5d-ddaf-4fed-a806-e11914bcb058") },
                    { "3d984ab5-bbb8-4021-8734-603290f4e565", new DateTime(2024, 10, 24, 13, 28, 19, 763, DateTimeKind.Utc).AddTicks(9197), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9199), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9199), new TimeSpan(0, 0, 0, 0, 0)), 12, "Pending", new Guid("0294c6d3-efbb-4a49-8435-e28626ee69bb"), 200000.00m, 45, new Guid("a778ee87-323e-4a19-9fe6-9cd03bd83721") },
                    { "551475b8-32f5-4eda-bb27-0c9d7e411ec5", new DateTime(2024, 10, 22, 13, 28, 19, 763, DateTimeKind.Utc).AddTicks(9172), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9183), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9183), new TimeSpan(0, 0, 0, 0, 0)), 10, "Pending", new Guid("03e9d7d7-0885-432d-ad8b-29fbccee8459"), 100000.00m, 0, new Guid("e16d419f-b188-495a-a819-298133659592") },
                    { "9da3831b-abca-453a-b919-21b86d483e98", new DateTime(2024, 10, 23, 13, 28, 19, 763, DateTimeKind.Utc).AddTicks(9188), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9189), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9189), new TimeSpan(0, 0, 0, 0, 0)), 15, "Scheduled", new Guid("0294c6d3-efbb-4a49-8435-e28626ee69bb"), 65000.00m, 75, new Guid("57e33e85-fe57-43cf-8d88-265cd2e0d452") }
                });

            migrationBuilder.InsertData(
                table: "ComboServices",
                columns: new[] { "Id", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[,]
                {
                    { "4ac739d22c3c40aeb536b7a2630db74b", "baff6c51-76b1-446a-a78e-0081f4860471", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9512), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9513), new TimeSpan(0, 0, 0, 0, 0)), "82d5574c-2f97-47d2-b890-6aa4de5bbd53" },
                    { "5cd0f6a6333f47e28a04037b293663e9", "baff6c51-76b1-446a-a78e-0081f4860471", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9507), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9507), new TimeSpan(0, 0, 0, 0, 0)), "0f832951-e748-4921-8f37-867a5128c8c6" },
                    { "77bd38c1c273478596abaf2330e7c261", "86d9be6c-c729-44d3-a4ec-8bd8cbd28d45", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9499), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9499), new TimeSpan(0, 0, 0, 0, 0)), "0f768ca2-ee78-4cf3-931b-7cb9e4772ccc" },
                    { "7b6275f3de1841e89132da0d452d24e2", "23fca8cf-6fe9-4171-b4f5-39329e9fbb6d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9522), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9522), new TimeSpan(0, 0, 0, 0, 0)), "1350eec1-79a3-40e5-8b3d-1418ac6fe088" },
                    { "a200a81a8cdd4b4a9a7d2d4c73a4f01f", "23fca8cf-6fe9-4171-b4f5-39329e9fbb6d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9516), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9516), new TimeSpan(0, 0, 0, 0, 0)), "c9269dfd-81e3-4324-a682-d02bf0c562bd" },
                    { "d77b400ea1f9489db7a5d24c71d185ec", "86d9be6c-c729-44d3-a4ec-8bd8cbd28d45", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9503), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9503), new TimeSpan(0, 0, 0, 0, 0)), "02518d1c-7d66-4830-9510-8ae7d8ac0cf6" }
                });

            migrationBuilder.InsertData(
                table: "SalaryPayments",
                columns: new[] { "Id", "BaseSalary", "BonusSalary", "CreatedBy", "CreatedTime", "DayOffNoPermitted", "DayOffPermitted", "DeductedSalary", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentDate", "UserId" },
                values: new object[] { "5532995a-356f-4e96-bdff-6472051de036", 2000.00m, 0m, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9399), new TimeSpan(0, 0, 0, 0, 0)), 0, 0, 0m, null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9399), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Utc).AddTicks(9398), new Guid("e16d419f-b188-495a-a819-298133659592") });

            migrationBuilder.InsertData(
                table: "ComboAppointment",
                columns: new[] { "Id", "AppointmentId", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { "512043c5-7a00-4cbb-a3e3-c329b2d84b6c", "3d984ab5-bbb8-4021-8734-603290f4e565", "23fca8cf-6fe9-4171-b4f5-39329e9fbb6d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9599), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9600), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "a5474511-59f4-4640-b9ad-710da0ce8acd", "551475b8-32f5-4eda-bb27-0c9d7e411ec5", "86d9be6c-c729-44d3-a4ec-8bd8cbd28d45", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9593), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9593), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "b14e7b0b-3415-4ab4-a0fe-bafb52f440cf", "9da3831b-abca-453a-b919-21b86d483e98", "baff6c51-76b1-446a-a78e-0081f4860471", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9596), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9597), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ServiceAppointments",
                columns: new[] { "Id", "AppointmentId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[] { "ec91fa84-e6d3-488e-a19f-eac6f81ee436", "551475b8-32f5-4eda-bb27-0c9d7e411ec5", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9298), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Basic haircut", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 13, 28, 19, 763, DateTimeKind.Unspecified).AddTicks(9298), new TimeSpan(0, 0, 0, 0, 0)), "0f768ca2-ee78-4cf3-931b-7cb9e4772ccc" });
        }
    }
}
