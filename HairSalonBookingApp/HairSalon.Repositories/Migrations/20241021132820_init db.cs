using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HairSalon.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ef771032-1100-4c80-a77c-d7f9e879f040"), new Guid("3baa7d4d-dc7e-479a-be8e-cc559442f828") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e1c0eb61-7bc6-4cf0-b312-3c7c28d24fe7"), new Guid("4d517999-edb2-4f0e-955f-2e7f2a17f508") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e1c0eb61-7bc6-4cf0-b312-3c7c28d24fe7"), new Guid("6bb036e4-96d6-4389-b533-6d1df7079751") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e1c0eb61-7bc6-4cf0-b312-3c7c28d24fe7"), new Guid("7fd84878-0fd3-4580-8a98-7de739727dda") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e1c0eb61-7bc6-4cf0-b312-3c7c28d24fe7"), new Guid("877001c0-9d4b-4754-aa5f-07106bb8e6bd") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2fb2d48a-e5b6-48aa-bdb6-6907b56d783b"), new Guid("b096433c-ae5b-4309-976b-1608ed9ae1af") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e1c0eb61-7bc6-4cf0-b312-3c7c28d24fe7"), new Guid("c45d27a3-16dc-423e-8053-b28901c55d5b") });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("227fec0d-f53c-42b6-82ad-e15df1a8ed43"), new Guid("cf2447d5-a2fb-4cbc-81dc-ed45d41fa612") });

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "48076a2c-bb88-46be-a83a-df3dbcbd980e");

            migrationBuilder.DeleteData(
                table: "ComboAppointment",
                keyColumn: "Id",
                keyValue: "36b64576-a08c-4673-af93-c846ef2997fc");

            migrationBuilder.DeleteData(
                table: "ComboAppointment",
                keyColumn: "Id",
                keyValue: "5c068831-a3d3-4b70-8ee4-39f5b67f4368");

            migrationBuilder.DeleteData(
                table: "ComboAppointment",
                keyColumn: "Id",
                keyValue: "87011eff-af16-4d7c-85d3-a80b7a225041");

            migrationBuilder.DeleteData(
                table: "ComboServices",
                keyColumn: "Id",
                keyValue: "393fa0cac05944b79c585967e77742bb");

            migrationBuilder.DeleteData(
                table: "ComboServices",
                keyColumn: "Id",
                keyValue: "5ddd8987e32e4e878d20f553ccd7e8f6");

            migrationBuilder.DeleteData(
                table: "ComboServices",
                keyColumn: "Id",
                keyValue: "80231901502d48d6a254d57647391870");

            migrationBuilder.DeleteData(
                table: "ComboServices",
                keyColumn: "Id",
                keyValue: "929e09e3cbd046a6ad5a0bac0b8c1ad1");

            migrationBuilder.DeleteData(
                table: "ComboServices",
                keyColumn: "Id",
                keyValue: "af4191c24844407fb8d33f03062537a6");

            migrationBuilder.DeleteData(
                table: "ComboServices",
                keyColumn: "Id",
                keyValue: "b71750eb11e14b209c8a036c4f1357f5");

            migrationBuilder.DeleteData(
                table: "SalaryPayments",
                keyColumn: "Id",
                keyValue: "9e0c7faa-ccf6-4e69-827c-1464cecf0f69");

            migrationBuilder.DeleteData(
                table: "ServiceAppointments",
                keyColumn: "Id",
                keyValue: "4a1b785b-4f05-4122-90c6-b353497e05f9");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "d1cac269-b1ba-40fa-872a-9831ca65d4a0");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "fedb88e2-6983-49dd-85b1-053cd7dfe9d9");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("227fec0d-f53c-42b6-82ad-e15df1a8ed43"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("2fb2d48a-e5b6-48aa-bdb6-6907b56d783b"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1c0eb61-7bc6-4cf0-b312-3c7c28d24fe7"));

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("ef771032-1100-4c80-a77c-d7f9e879f040"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d517999-edb2-4f0e-955f-2e7f2a17f508"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("6bb036e4-96d6-4389-b533-6d1df7079751"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("877001c0-9d4b-4754-aa5f-07106bb8e6bd"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "1822ad2f-e7f9-4f6e-9708-b980df3709f2");

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "4b8caf53-608d-4075-95a6-a53d878e2bc9");

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: "8286ea02-510f-40b5-9ce9-e67d108468e5");

            migrationBuilder.DeleteData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: "013902fa-5fc6-485f-bcd0-69a484732c7e");

            migrationBuilder.DeleteData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: "38a79635-6157-47aa-9b28-e5d3e7eff6e3");

            migrationBuilder.DeleteData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: "95720557-910d-4579-8bb7-3228d38f8628");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "3fa93e27-1054-411c-980e-f33e9c575a6b");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "52fcc534-607b-4082-8a23-40fe92d05e9f");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "81d97236-0023-472e-86e0-50d90d120541");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "8c876d9e-5ea1-4216-a0bf-b366522cca3e");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "a7a3a6ba-5fe5-4724-9246-e6f3be700c9e");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: "db7b9307-0342-4ec5-b3c9-04b1ab342397");

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("3baa7d4d-dc7e-479a-be8e-cc559442f828"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("7fd84878-0fd3-4580-8a98-7de739727dda"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("b096433c-ae5b-4309-976b-1608ed9ae1af"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("c45d27a3-16dc-423e-8053-b28901c55d5b"));

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("cf2447d5-a2fb-4cbc-81dc-ed45d41fa612"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: "4e3b5203-bc00-4f1e-b835-4cc9913fdc97");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "2baad9ac-86bf-4c8b-92a6-92118226c44d");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "34cd45fe-7783-4f0f-bc58-855822f8139f");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "9de1a42c-acb7-40e6-8cac-094f418cfa5c");

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: "cc456b57-9033-4732-9ba6-f7a4ae4895bf");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("227fec0d-f53c-42b6-82ad-e15df1a8ed43"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 18, 480, DateTimeKind.Unspecified).AddTicks(9053), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 18, 480, DateTimeKind.Unspecified).AddTicks(9054), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "ADMIN" },
                    { new Guid("2fb2d48a-e5b6-48aa-bdb6-6907b56d783b"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 18, 480, DateTimeKind.Unspecified).AddTicks(9063), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 18, 480, DateTimeKind.Unspecified).AddTicks(9063), new TimeSpan(0, 0, 0, 0, 0)), "Stylist", "STYLIST" },
                    { new Guid("e1c0eb61-7bc6-4cf0-b312-3c7c28d24fe7"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 18, 480, DateTimeKind.Unspecified).AddTicks(9066), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 18, 480, DateTimeKind.Unspecified).AddTicks(9067), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" },
                    { new Guid("ef771032-1100-4c80-a77c-d7f9e879f040"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 18, 480, DateTimeKind.Unspecified).AddTicks(9059), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 18, 480, DateTimeKind.Unspecified).AddTicks(9060), new TimeSpan(0, 0, 0, 0, 0)), "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "TimeCombo", "TotalPrice" },
                values: new object[,]
                {
                    { "013902fa-5fc6-485f-bcd0-69a484732c7e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1017), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1018), new TimeSpan(0, 0, 0, 0, 0)), "Deluxe Hair Combo", 120, 80000.00m },
                    { "38a79635-6157-47aa-9b28-e5d3e7eff6e3", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1008), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1009), new TimeSpan(0, 0, 0, 0, 0)), "Basic Hair Combo", 60, 40000.00m },
                    { "95720557-910d-4579-8bb7-3228d38f8628", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1026), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1027), new TimeSpan(0, 0, 0, 0, 0)), "Ultimate Hair & Beard Combo", 150, 120000.00m }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "OpenTime", "ShopEmail", "ShopPhone", "Title" },
                values: new object[] { "4e3b5203-bc00-4f1e-b835-4cc9913fdc97", "123 Main St, Cityville", new TimeSpan(0, 19, 0, 0, 0), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(8376), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(8377), new TimeSpan(0, 0, 0, 0, 0)), "Salon A", new TimeSpan(0, 9, 0, 0, 0), "contact@salona.com", "123-456-7890", "Best Hair Salon in Town" });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Bank", "BankAccount", "BankAccountName", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Firstname", "LastUpdatedBy", "LastUpdatedTime", "Lastname", "Point" },
                values: new object[,]
                {
                    { "2baad9ac-86bf-4c8b-92a6-92118226c44d", "Bank A", "123456789", "John Doe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 18, 480, DateTimeKind.Unspecified).AddTicks(9500), new TimeSpan(0, 0, 0, 0, 0)), null, null, "John", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 18, 480, DateTimeKind.Unspecified).AddTicks(9501), new TimeSpan(0, 0, 0, 0, 0)), "Doe", 100 },
                    { "34cd45fe-7783-4f0f-bc58-855822f8139f", "Bank c", "123456798", "Dev Nguyen", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 18, 480, DateTimeKind.Unspecified).AddTicks(9548), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dev", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 18, 480, DateTimeKind.Unspecified).AddTicks(9549), new TimeSpan(0, 0, 0, 0, 0)), "Nguyen", 0 },
                    { "9de1a42c-acb7-40e6-8cac-094f418cfa5c", "Bank D", "123456987", "Dan Tran", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 18, 480, DateTimeKind.Unspecified).AddTicks(9556), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dan", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 18, 480, DateTimeKind.Unspecified).AddTicks(9557), new TimeSpan(0, 0, 0, 0, 0)), "Tran", 0 },
                    { "cc456b57-9033-4732-9ba6-f7a4ae4895bf", "Bank B", "987654321", "Jane Smith", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 18, 480, DateTimeKind.Unspecified).AddTicks(9542), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jane", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 18, 480, DateTimeKind.Unspecified).AddTicks(9543), new TimeSpan(0, 0, 0, 0, 0)), "Smith", 150 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "E_Wallet", "Email", "EmailConfirmed", "LastUpdatedBy", "LastUpdatedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OtpCode", "OtpCodeResetPassword", "OtpExpiration", "OtpExpirationResetPassword", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserInfoId", "UserName" },
                values: new object[,]
                {
                    { new Guid("3baa7d4d-dc7e-479a-be8e-cc559442f828"), 0, "b2b74cb6-16f1-43be-9714-5e111e212566", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7454), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "manager@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7455), new TimeSpan(0, 0, 0, 0, 0)), false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEAKsKAX9REmrqw+w6frz7DJiLrezL56AelyzQIwRqBoCL4/2AiWytB4WGnN+OigfWA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "34cd45fe-7783-4f0f-bc58-855822f8139f", "manager" },
                    { new Guid("4d517999-edb2-4f0e-955f-2e7f2a17f508"), 0, "5fa1957b-3614-4adc-ac1d-b308dc8aa5cd", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7531), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user5@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7533), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEAgvz0gfG7phaIsao+5GTM9aLJIaZRGKi2Fxd1qbq6Ue584g/HZgWtkLshu8goZErw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "9de1a42c-acb7-40e6-8cac-094f418cfa5c", "user5" },
                    { new Guid("6bb036e4-96d6-4389-b533-6d1df7079751"), 0, "ada32119-7b6a-4d6e-8412-f4f57c0e205d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7518), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user4@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7519), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEFGIrYG1N4tf6TEXZ9bYjixVOTQRCNzNIi0nrD8zO3UfZ3EdxmOBUzzZQEdJh3V80g==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "34cd45fe-7783-4f0f-bc58-855822f8139f", "user4" },
                    { new Guid("7fd84878-0fd3-4580-8a98-7de739727dda"), 0, "4446db88-385a-48bf-a5b9-a94160fe3693", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7486), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user2@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7487), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEEaEv/IQ94HhJcJFudcllICn9hKakr1//rtlEaKfCorEHfcAW7+otmsm0RoMpcSfOg==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "2baad9ac-86bf-4c8b-92a6-92118226c44d", "user2" },
                    { new Guid("877001c0-9d4b-4754-aa5f-07106bb8e6bd"), 0, "2f8ff878-d20a-4343-8deb-5f35ee1af0a7", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7502), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user3@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7503), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER3@EXAMPLE.COM", "USER3@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEFWgfr0lYVDIi0k2EqWEf+fsfoLyaavdyDeH2kFapH/wtGUWMsLutqU6FK+oc4FeTg==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "cc456b57-9033-4732-9ba6-f7a4ae4895bf", "user3" },
                    { new Guid("b096433c-ae5b-4309-976b-1608ed9ae1af"), 0, "a07e6406-9929-48a1-90d0-337cbb9d9741", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7471), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "stylist@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7472), new TimeSpan(0, 0, 0, 0, 0)), false, null, "STYLIST@EXAMPLE.COM", "STYLIST@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAELNc08QsjJbRXk+jTS7yMhXxoUOxMFFr8ztqVQYrgd/KHWKUYtQszitERcurHqsEbA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "9de1a42c-acb7-40e6-8cac-094f418cfa5c", "stylist" },
                    { new Guid("c45d27a3-16dc-423e-8053-b28901c55d5b"), 0, "90d299e2-09b9-4fb4-a1a6-d99727f978ad", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7437), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7438), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEAwHMtLctSiu8wS8VmIUI2GuQXMfc437ufONcPOCWjSsUvq67jb/Iqz75hCkw6EZsA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "cc456b57-9033-4732-9ba6-f7a4ae4895bf", "user" },
                    { new Guid("cf2447d5-a2fb-4cbc-81dc-ed45d41fa612"), 0, "21b92168-04f0-4f80-b936-390289485017", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7397), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "admin@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7398), new TimeSpan(0, 0, 0, 0, 0)), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEKtWEJGTOnUslo3N3aTMFHH4aWRor8eboGtoVRcZQY3wRT7ulQ+F0oktXSsqU0PTcw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "2baad9ac-86bf-4c8b-92a6-92118226c44d", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Name", "Price", "ShopId", "TimeService", "Type" },
                values: new object[,]
                {
                    { "3fa93e27-1054-411c-980e-f33e9c575a6b", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(387), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A premium hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(390), new TimeSpan(0, 0, 0, 0, 0)), "Premium Hair Coloring", 100000.00m, "4e3b5203-bc00-4f1e-b835-4cc9913fdc97", 60, "Hair" },
                    { "52fcc534-607b-4082-8a23-40fe92d05e9f", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(365), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A stylish haircut to refresh your look.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(366), new TimeSpan(0, 0, 0, 0, 0)), "Hair Cut", 25000.00m, "4e3b5203-bc00-4f1e-b835-4cc9913fdc97", 30, "Hair" },
                    { "81d97236-0023-472e-86e0-50d90d120541", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(418), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A clean and smooth shaving service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(420), new TimeSpan(0, 0, 0, 0, 0)), "Shave", 12000.00m, "4e3b5203-bc00-4f1e-b835-4cc9913fdc97", 15, "Beard" },
                    { "8c876d9e-5ea1-4216-a0bf-b366522cca3e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(398), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A professional hair styling service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(399), new TimeSpan(0, 0, 0, 0, 0)), "Hair Styling", 20000.00m, "4e3b5203-bc00-4f1e-b835-4cc9913fdc97", 45, "Hair" },
                    { "a7a3a6ba-5fe5-4724-9246-e6f3be700c9e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(377), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A complete hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(379), new TimeSpan(0, 0, 0, 0, 0)), "Hair Coloring", 50000.00m, "4e3b5203-bc00-4f1e-b835-4cc9913fdc97", 30, "Hair" },
                    { "d1cac269-b1ba-40fa-872a-9831ca65d4a0", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(427), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A rejuvenating facial service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(428), new TimeSpan(0, 0, 0, 0, 0)), "Facial", 40000.00m, "4e3b5203-bc00-4f1e-b835-4cc9913fdc97", 50, "Skin" },
                    { "db7b9307-0342-4ec5-b3c9-04b1ab342397", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(407), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A neat beard trimming service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(409), new TimeSpan(0, 0, 0, 0, 0)), "Beard Trim", 15000.00m, "4e3b5203-bc00-4f1e-b835-4cc9913fdc97", 20, "Beard" },
                    { "fedb88e2-6983-49dd-85b1-053cd7dfe9d9", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(436), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A soothing scalp treatment.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(437), new TimeSpan(0, 0, 0, 0, 0)), "Scalp Treatment", 45000.00m, "4e3b5203-bc00-4f1e-b835-4cc9913fdc97", 40, "Hair" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { new Guid("ef771032-1100-4c80-a77c-d7f9e879f040"), new Guid("3baa7d4d-dc7e-479a-be8e-cc559442f828"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7978), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7979), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e1c0eb61-7bc6-4cf0-b312-3c7c28d24fe7"), new Guid("4d517999-edb2-4f0e-955f-2e7f2a17f508"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(8034), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(8035), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e1c0eb61-7bc6-4cf0-b312-3c7c28d24fe7"), new Guid("6bb036e4-96d6-4389-b533-6d1df7079751"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(8014), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(8026), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e1c0eb61-7bc6-4cf0-b312-3c7c28d24fe7"), new Guid("7fd84878-0fd3-4580-8a98-7de739727dda"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7996), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7997), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e1c0eb61-7bc6-4cf0-b312-3c7c28d24fe7"), new Guid("877001c0-9d4b-4754-aa5f-07106bb8e6bd"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(8006), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(8008), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2fb2d48a-e5b6-48aa-bdb6-6907b56d783b"), new Guid("b096433c-ae5b-4309-976b-1608ed9ae1af"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7987), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7989), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e1c0eb61-7bc6-4cf0-b312-3c7c28d24fe7"), new Guid("c45d27a3-16dc-423e-8053-b28901c55d5b"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7817), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7967), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("227fec0d-f53c-42b6-82ad-e15df1a8ed43"), new Guid("cf2447d5-a2fb-4cbc-81dc-ed45d41fa612"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7808), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 302, DateTimeKind.Unspecified).AddTicks(7809), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PointsEarned", "StatusForAppointment", "StylistId", "TotalAmount", "TotalTime", "UserId" },
                values: new object[,]
                {
                    { "1822ad2f-e7f9-4f6e-9708-b980df3709f2", new DateTime(2024, 10, 21, 6, 56, 19, 303, DateTimeKind.Utc).AddTicks(699), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(701), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(702), new TimeSpan(0, 0, 0, 0, 0)), 12, "Pending", new Guid("b096433c-ae5b-4309-976b-1608ed9ae1af"), 200000.00m, 45, new Guid("7fd84878-0fd3-4580-8a98-7de739727dda") },
                    { "48076a2c-bb88-46be-a83a-df3dbcbd980e", new DateTime(2024, 10, 22, 6, 56, 19, 303, DateTimeKind.Utc).AddTicks(712), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(714), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(715), new TimeSpan(0, 0, 0, 0, 0)), 20, "Completed", new Guid("b096433c-ae5b-4309-976b-1608ed9ae1af"), 150000.00m, 90, new Guid("6bb036e4-96d6-4389-b533-6d1df7079751") },
                    { "4b8caf53-608d-4075-95a6-a53d878e2bc9", new DateTime(2024, 10, 20, 6, 56, 19, 303, DateTimeKind.Utc).AddTicks(677), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(679), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(679), new TimeSpan(0, 0, 0, 0, 0)), 15, "Scheduled", new Guid("b096433c-ae5b-4309-976b-1608ed9ae1af"), 65000.00m, 75, new Guid("3baa7d4d-dc7e-479a-be8e-cc559442f828") },
                    { "8286ea02-510f-40b5-9ce9-e67d108468e5", new DateTime(2024, 10, 19, 6, 56, 19, 303, DateTimeKind.Utc).AddTicks(652), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(664), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(665), new TimeSpan(0, 0, 0, 0, 0)), 10, "Pending", new Guid("c45d27a3-16dc-423e-8053-b28901c55d5b"), 100000.00m, 0, new Guid("cf2447d5-a2fb-4cbc-81dc-ed45d41fa612") }
                });

            migrationBuilder.InsertData(
                table: "ComboServices",
                columns: new[] { "Id", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[,]
                {
                    { "393fa0cac05944b79c585967e77742bb", "38a79635-6157-47aa-9b28-e5d3e7eff6e3", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1126), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1127), new TimeSpan(0, 0, 0, 0, 0)), "52fcc534-607b-4082-8a23-40fe92d05e9f" },
                    { "5ddd8987e32e4e878d20f553ccd7e8f6", "38a79635-6157-47aa-9b28-e5d3e7eff6e3", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1136), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1137), new TimeSpan(0, 0, 0, 0, 0)), "a7a3a6ba-5fe5-4724-9246-e6f3be700c9e" },
                    { "80231901502d48d6a254d57647391870", "013902fa-5fc6-485f-bcd0-69a484732c7e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1159), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1160), new TimeSpan(0, 0, 0, 0, 0)), "8c876d9e-5ea1-4216-a0bf-b366522cca3e" },
                    { "929e09e3cbd046a6ad5a0bac0b8c1ad1", "95720557-910d-4579-8bb7-3228d38f8628", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1168), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1169), new TimeSpan(0, 0, 0, 0, 0)), "db7b9307-0342-4ec5-b3c9-04b1ab342397" },
                    { "af4191c24844407fb8d33f03062537a6", "013902fa-5fc6-485f-bcd0-69a484732c7e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1149), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1150), new TimeSpan(0, 0, 0, 0, 0)), "3fa93e27-1054-411c-980e-f33e9c575a6b" },
                    { "b71750eb11e14b209c8a036c4f1357f5", "95720557-910d-4579-8bb7-3228d38f8628", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1181), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1182), new TimeSpan(0, 0, 0, 0, 0)), "81d97236-0023-472e-86e0-50d90d120541" }
                });

            migrationBuilder.InsertData(
                table: "SalaryPayments",
                columns: new[] { "Id", "BaseSalary", "BonusSalary", "CreatedBy", "CreatedTime", "DayOffNoPermitted", "DayOffPermitted", "DeductedSalary", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentDate", "UserId" },
                values: new object[] { "9e0c7faa-ccf6-4e69-827c-1464cecf0f69", 2000.00m, 0m, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(920), new TimeSpan(0, 0, 0, 0, 0)), 0, 0, 0m, null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(920), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Utc).AddTicks(918), new Guid("cf2447d5-a2fb-4cbc-81dc-ed45d41fa612") });

            migrationBuilder.InsertData(
                table: "ComboAppointment",
                columns: new[] { "Id", "AppointmentId", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { "36b64576-a08c-4673-af93-c846ef2997fc", "8286ea02-510f-40b5-9ce9-e67d108468e5", "38a79635-6157-47aa-9b28-e5d3e7eff6e3", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1308), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1309), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "5c068831-a3d3-4b70-8ee4-39f5b67f4368", "4b8caf53-608d-4075-95a6-a53d878e2bc9", "013902fa-5fc6-485f-bcd0-69a484732c7e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1316), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1316), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "87011eff-af16-4d7c-85d3-a80b7a225041", "1822ad2f-e7f9-4f6e-9708-b980df3709f2", "95720557-910d-4579-8bb7-3228d38f8628", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1323), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(1323), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ServiceAppointments",
                columns: new[] { "Id", "AppointmentId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[] { "4a1b785b-4f05-4122-90c6-b353497e05f9", "8286ea02-510f-40b5-9ce9-e67d108468e5", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(847), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Basic haircut", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 18, 6, 56, 19, 303, DateTimeKind.Unspecified).AddTicks(848), new TimeSpan(0, 0, 0, 0, 0)), "52fcc534-607b-4082-8a23-40fe92d05e9f" });
        }
    }
}
