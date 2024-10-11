using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HairSalon.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
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
                    { new Guid("7550a149-dfed-4189-8458-0575ea523790"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 242, DateTimeKind.Unspecified).AddTicks(7311), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 242, DateTimeKind.Unspecified).AddTicks(7311), new TimeSpan(0, 0, 0, 0, 0)), "Stylist", "STYLIST" },
                    { new Guid("80e5cdd5-ab86-4fb8-ad0a-78ae185d3e3d"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 242, DateTimeKind.Unspecified).AddTicks(7308), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 242, DateTimeKind.Unspecified).AddTicks(7309), new TimeSpan(0, 0, 0, 0, 0)), "Manager", "MANAGER" },
                    { new Guid("c8c4f852-0087-4e33-b6a2-8718f70a9191"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 242, DateTimeKind.Unspecified).AddTicks(7314), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 242, DateTimeKind.Unspecified).AddTicks(7317), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" },
                    { new Guid("d9a2587d-156e-4c32-a335-b007b86ac3e3"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 242, DateTimeKind.Unspecified).AddTicks(7304), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 242, DateTimeKind.Unspecified).AddTicks(7305), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "OpenTime", "ShopEmail", "ShopPhone", "Title" },
                values: new object[] { "680ec4a0-a167-4ba8-9759-303156425d5a", "123 Main St, Cityville", new TimeSpan(0, 19, 0, 0, 0), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(539), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(540), new TimeSpan(0, 0, 0, 0, 0)), "Salon A", new TimeSpan(0, 9, 0, 0, 0), "contact@salona.com", "123-456-7890", "Best Hair Salon in Town" });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Bank", "BankAccount", "BankAccountName", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Firstname", "LastUpdatedBy", "LastUpdatedTime", "Lastname", "Point" },
                values: new object[,]
                {
                    { "59d4d5db-56c0-4aaf-bff3-c12adcdf2cc9", "Bank D", "123456987", "Dan Tran", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 242, DateTimeKind.Unspecified).AddTicks(7517), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dan", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 242, DateTimeKind.Unspecified).AddTicks(7518), new TimeSpan(0, 0, 0, 0, 0)), "Tran", 0 },
                    { "9abf129f-fde3-477f-8a6b-eba6076290a2", "Bank c", "123456798", "Dev Nguyen", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 242, DateTimeKind.Unspecified).AddTicks(7512), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dev", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 242, DateTimeKind.Unspecified).AddTicks(7513), new TimeSpan(0, 0, 0, 0, 0)), "Nguyen", 0 },
                    { "e1736c18-5fb4-47f9-8c78-a0ad181522cd", "Bank A", "123456789", "John Doe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 242, DateTimeKind.Unspecified).AddTicks(7491), new TimeSpan(0, 0, 0, 0, 0)), null, null, "John", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 242, DateTimeKind.Unspecified).AddTicks(7491), new TimeSpan(0, 0, 0, 0, 0)), "Doe", 100 },
                    { "ed35ece2-a750-4185-9a0a-319f8b291da7", "Bank B", "987654321", "Jane Smith", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 242, DateTimeKind.Unspecified).AddTicks(7503), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jane", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 242, DateTimeKind.Unspecified).AddTicks(7504), new TimeSpan(0, 0, 0, 0, 0)), "Smith", 150 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Email", "EmailConfirmed", "LastUpdatedBy", "LastUpdatedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OtpCode", "OtpCodeResetPassword", "OtpExpiration", "OtpExpirationResetPassword", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserInfoId", "UserName" },
                values: new object[,]
                {
                    { new Guid("14531250-f61b-4c8f-ac63-af3fb601dde8"), 0, "892609e3-01c9-42e8-9b4d-8cd67e54de14", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(332), new TimeSpan(0, 0, 0, 0, 0)), null, null, "stylist@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(333), new TimeSpan(0, 0, 0, 0, 0)), false, null, "STYLIST@EXAMPLE.COM", "STYLIST@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEKonbMvUW743xtGrt/wK3BfLQMM36CnM5S2xYYK+4WBetLgemXSp5Y3azg7wPILsgA==", null, false, null, false, "59d4d5db-56c0-4aaf-bff3-c12adcdf2cc9", "stylist" },
                    { new Guid("73dfa22d-7fcb-4875-a3f0-ebf38d52de99"), 0, "c0a667d6-ecb4-4543-b7fb-228f4e1d345d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(326), new TimeSpan(0, 0, 0, 0, 0)), null, null, "manager@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(327), new TimeSpan(0, 0, 0, 0, 0)), false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEMb58ASYK7qZ9HhkGq4voV/mnJTNKMXznMru+pbhCdzqzQeHLEz9fGvk178RnJBr+Q==", null, false, null, false, "9abf129f-fde3-477f-8a6b-eba6076290a2", "manager" },
                    { new Guid("b1d0d03d-5605-4579-a1e3-78adc0befb40"), 0, "37e01cc2-e64d-45ed-8adc-831e93516859", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(280), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(280), new TimeSpan(0, 0, 0, 0, 0)), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEMsQq+dcpmu9KoJMPgTZQ1/ppdRhFuYq9C+iBAt7XWOC/rZZbHJAM6x6pJ+0imaohw==", null, false, null, false, "e1736c18-5fb4-47f9-8c78-a0ad181522cd", "admin" },
                    { new Guid("e3f150cc-301a-4fa0-b778-3c1c01b12a72"), 0, "2c9bacbe-579e-44c5-9540-c3314803c372", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(319), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(320), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEF2F1yaSubq+OEMoOJP49g+4uVEyRyWcJ0PdTMgo+OYWfbsOb7ikbJe8w426tp9IhQ==", null, false, null, false, "ed35ece2-a750-4185-9a0a-319f8b291da7", "user" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Name", "Price", "ShopId", "Type" },
                values: new object[,]
                {
                    { "2be55422-7da2-4708-a5f9-b452ac86a404", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(651), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A complete hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(652), new TimeSpan(0, 0, 0, 0, 0)), "Hair Coloring", 50000.00m, "680ec4a0-a167-4ba8-9759-303156425d5a", "Hair" },
                    { "b7a5c664-69b4-4025-a2a2-05f808ca4134", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(657), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A premium hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(657), new TimeSpan(0, 0, 0, 0, 0)), "Premium Hair Coloring", 100000.00m, "680ec4a0-a167-4ba8-9759-303156425d5a", "Hair" },
                    { "d9d18af4-24cc-48b5-98d3-006ac901b1a5", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(638), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A stylish haircut to refresh your look.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(642), new TimeSpan(0, 0, 0, 0, 0)), "Hair Cut", 25000.00m, "680ec4a0-a167-4ba8-9759-303156425d5a", "Hair" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { new Guid("7550a149-dfed-4189-8458-0575ea523790"), new Guid("14531250-f61b-4c8f-ac63-af3fb601dde8"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(469), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(470), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("80e5cdd5-ab86-4fb8-ad0a-78ae185d3e3d"), new Guid("73dfa22d-7fcb-4875-a3f0-ebf38d52de99"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(466), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(466), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d9a2587d-156e-4c32-a335-b007b86ac3e3"), new Guid("b1d0d03d-5605-4579-a1e3-78adc0befb40"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(457), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(457), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c8c4f852-0087-4e33-b6a2-8718f70a9191"), new Guid("e3f150cc-301a-4fa0-b778-3c1c01b12a72"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(462), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(462), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PointsEarned", "StatusForAppointment", "StylistId", "UserId" },
                values: new object[] { "e0309ceb-ed0c-4afc-a01a-c2b5536125fd", new DateTime(2024, 10, 12, 2, 28, 47, 554, DateTimeKind.Utc).AddTicks(710), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(731), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(732), new TimeSpan(0, 0, 0, 0, 0)), 10, "Scheduled", new Guid("e3f150cc-301a-4fa0-b778-3c1c01b12a72"), new Guid("b1d0d03d-5605-4579-a1e3-78adc0befb40") });

            migrationBuilder.InsertData(
                table: "SalaryPayments",
                columns: new[] { "Id", "BaseSalary", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentDate", "UserId" },
                values: new object[] { "b1e0444f-2ca8-4740-ac3f-a28ca09ec25b", 2000.00m, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(889), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(889), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Utc).AddTicks(888), new Guid("b1d0d03d-5605-4579-a1e3-78adc0befb40") });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "AppointmentId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentMethod", "PaymentTime", "TotalAmount" },
                values: new object[] { "3618453b-0f62-4b23-a653-c672b4d704f1", "e0309ceb-ed0c-4afc-a01a-c2b5536125fd", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(795), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(796), new TimeSpan(0, 0, 0, 0, 0)), "Credit Card", new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Utc).AddTicks(794), 100.00m });

            migrationBuilder.InsertData(
                table: "ServiceAppointments",
                columns: new[] { "Id", "AppointmentId", "Comment", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Rate", "ServiceId" },
                values: new object[] { "cd5e72eb-0a84-4ac3-8f27-0c4f7642e7bf", "e0309ceb-ed0c-4afc-a01a-c2b5536125fd", "Excellent service!", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(836), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Basic haircut", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 11, 2, 28, 47, 554, DateTimeKind.Unspecified).AddTicks(844), new TimeSpan(0, 0, 0, 0, 0)), 5, "d9d18af4-24cc-48b5-98d3-006ac901b1a5" });

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
