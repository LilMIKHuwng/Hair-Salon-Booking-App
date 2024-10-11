using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HairSalon.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserLogins", x => new { x.UserId, x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShopEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShopPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OpenTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CloseTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ShopId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserInfoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    OtpCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtpExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OtpCodeResetPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtpExpirationResetPassword = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_UserInfos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserRoles_ApplicationRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ApplicationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRoles_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StylistId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StatusForAppointment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PointsEarned = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_ApplicationUsers_StylistId",
                        column: x => x.StylistId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryPayments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryPayments_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppointmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaymentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceAppointments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppointmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceAppointments_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceAppointments_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRoles_RoleId",
                table: "ApplicationUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_UserInfoId",
                table: "ApplicationUsers",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_StylistId",
                table: "Appointments",
                column: "StylistId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_AppointmentId",
                table: "Payments",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryPayments_UserId",
                table: "SalaryPayments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAppointments_AppointmentId",
                table: "ServiceAppointments",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAppointments_ServiceId",
                table: "ServiceAppointments",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ShopId",
                table: "Services",
                column: "ShopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationRoleClaims");

            migrationBuilder.DropTable(
                name: "ApplicationUserClaims");

            migrationBuilder.DropTable(
                name: "ApplicationUserLogins");

            migrationBuilder.DropTable(
                name: "ApplicationUserRoles");

            migrationBuilder.DropTable(
                name: "ApplicationUserTokens");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "SalaryPayments");

            migrationBuilder.DropTable(
                name: "ServiceAppointments");

            migrationBuilder.DropTable(
                name: "ApplicationRoles");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "UserInfos");
        }
    }
}
