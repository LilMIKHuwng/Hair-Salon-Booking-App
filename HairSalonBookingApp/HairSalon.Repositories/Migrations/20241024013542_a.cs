using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HairSalon.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
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
                name: "Combos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TimeCombo = table.Column<int>(type: "int", nullable: false),
                    ComboImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.Id);
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
                    ShopImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    TimeService = table.Column<int>(type: "int", nullable: false),
                    ServiceImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    E_Wallet = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    UserInfoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
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
                name: "ComboServices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComboId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComboServices_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
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
                    TotalTime = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
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
                    DayOffPermitted = table.Column<int>(type: "int", nullable: false),
                    DayOffNoPermitted = table.Column<int>(type: "int", nullable: false),
                    DeductedSalary = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    BonusSalary = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
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
                name: "ComboAppointment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComboId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.PrimaryKey("PK_ComboAppointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComboAppointment_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboAppointment_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppointmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
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
                    BankCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankTranNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    { new Guid("49e2fccc-8c72-4fe6-8018-a305a44217a3"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 41, 535, DateTimeKind.Unspecified).AddTicks(2723), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 41, 535, DateTimeKind.Unspecified).AddTicks(2723), new TimeSpan(0, 0, 0, 0, 0)), "Manager", "MANAGER" },
                    { new Guid("5ea515eb-fba4-493a-ba71-28447268c4ba"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 41, 535, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 41, 535, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 0, 0, 0, 0)), "Stylist", "STYLIST" },
                    { new Guid("831af259-cb7f-493e-9d63-cddda8cc3970"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 41, 535, DateTimeKind.Unspecified).AddTicks(2728), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 41, 535, DateTimeKind.Unspecified).AddTicks(2729), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" },
                    { new Guid("e7480fbf-05f7-4284-a1c9-37fb3d518f8e"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 41, 535, DateTimeKind.Unspecified).AddTicks(2719), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 41, 535, DateTimeKind.Unspecified).AddTicks(2719), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "ComboImage", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "TimeCombo", "TotalPrice" },
                values: new object[,]
                {
                    { "160f2d9b-aec4-4d80-bc19-ccab6e27339e", null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6376), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6377), new TimeSpan(0, 0, 0, 0, 0)), "Deluxe Hair Combo", 120, 80000.00m },
                    { "19de2185-ff50-4486-973b-23011126e3c9", null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6380), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6380), new TimeSpan(0, 0, 0, 0, 0)), "Ultimate Hair & Beard Combo", 150, 120000.00m },
                    { "9f0a12d7-f31e-4692-9505-6297f9ef007d", null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6368), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6369), new TimeSpan(0, 0, 0, 0, 0)), "Basic Hair Combo", 60, 40000.00m }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "OpenTime", "ShopEmail", "ShopImage", "ShopPhone", "Title" },
                values: new object[] { "dec13fcd-79eb-4e0f-9572-e24415cf3b92", "123 Main St, Cityville", new TimeSpan(0, 19, 0, 0, 0), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6149), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6149), new TimeSpan(0, 0, 0, 0, 0)), "Salon A", new TimeSpan(0, 9, 0, 0, 0), "contact@salona.com", null, "123-456-7890", "Best Hair Salon in Town" });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Bank", "BankAccount", "BankAccountName", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Firstname", "LastUpdatedBy", "LastUpdatedTime", "Lastname", "Point" },
                values: new object[,]
                {
                    { "5c0b9b5a-75a5-4369-94ae-ee830d8d16c3", "Bank c", "123456798", "Dev Nguyen", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 41, 535, DateTimeKind.Unspecified).AddTicks(2930), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dev", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 41, 535, DateTimeKind.Unspecified).AddTicks(2930), new TimeSpan(0, 0, 0, 0, 0)), "Nguyen", 0 },
                    { "72da83ed-7a5c-402c-974e-4c71bdae3567", "Bank D", "123456987", "Dan Tran", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 41, 535, DateTimeKind.Unspecified).AddTicks(2934), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dan", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 41, 535, DateTimeKind.Unspecified).AddTicks(2935), new TimeSpan(0, 0, 0, 0, 0)), "Tran", 0 },
                    { "a3ad96c8-a7df-4764-896f-f5e24f778963", "Bank A", "123456789", "John Doe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 41, 535, DateTimeKind.Unspecified).AddTicks(2920), new TimeSpan(0, 0, 0, 0, 0)), null, null, "John", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 41, 535, DateTimeKind.Unspecified).AddTicks(2920), new TimeSpan(0, 0, 0, 0, 0)), "Doe", 100 },
                    { "c852ae78-77ed-416c-a984-5650e99dab09", "Bank B", "987654321", "Jane Smith", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 41, 535, DateTimeKind.Unspecified).AddTicks(2925), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jane", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 41, 535, DateTimeKind.Unspecified).AddTicks(2925), new TimeSpan(0, 0, 0, 0, 0)), "Smith", 150 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "E_Wallet", "Email", "EmailConfirmed", "LastUpdatedBy", "LastUpdatedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OtpCode", "OtpCodeResetPassword", "OtpExpiration", "OtpExpirationResetPassword", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserImage", "UserInfoId", "UserName" },
                values: new object[,]
                {
                    { new Guid("15493fec-51d5-4ec7-b714-9cc7a41aa4b0"), 0, "2d5ec81f-a02b-410b-8854-699689da3a4c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(5897), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user3@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(5897), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER3@EXAMPLE.COM", "USER3@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEH3x0+ndgRbQV6bQPgV8zEd6Py6u6LvW4osbLjkgfuAmW8onWDDSkB/ErJ2Hh2at+Q==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "c852ae78-77ed-416c-a984-5650e99dab09", "user3" },
                    { new Guid("1e2a2b96-2db9-44d0-ad3e-f8e4c31e92e7"), 0, "fe2c0e49-dd73-4407-8d8e-ff85127c3184", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(5814), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "manager@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(5814), new TimeSpan(0, 0, 0, 0, 0)), false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEHLPv5u7CMpybjCNKTeU1gfbi+IG+LPQ1n+0YbctBVve0acZW3YsPS9SRBMzfNFe+w==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "5c0b9b5a-75a5-4369-94ae-ee830d8d16c3", "manager" },
                    { new Guid("8111b228-86d7-4fc8-a616-1995a67d1a00"), 0, "5c9accc0-af82-4e8a-b138-c85a37a2dd0d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(5886), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "stylist@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(5887), new TimeSpan(0, 0, 0, 0, 0)), false, null, "STYLIST@EXAMPLE.COM", "STYLIST@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEObxKfctCFCTKRI+wI5Zsx4X2BQp23AeHDW2XigMkcoVZSPocDKNXMz3qA+FgiPP+A==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "72da83ed-7a5c-402c-974e-4c71bdae3567", "stylist" },
                    { new Guid("91d314d2-cd40-4f8c-a922-ed42ccec5c1d"), 0, "d75641df-7e48-4bfb-84ce-515253c747a4", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(5906), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user5@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(5907), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEDIg6HM8Nlq2ryc92pKMLwa6WCDukTL1kK4E6mYeA+slv+e0a6FsJq3PQ/si9yRO9A==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "72da83ed-7a5c-402c-974e-4c71bdae3567", "user5" },
                    { new Guid("a5280c92-fa80-44f5-8b0f-7e9f0b70349d"), 0, "406dda95-b6d5-4553-825d-ff99af6dac9e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(5892), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user2@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(5893), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEAK0NWfaNgGGhoxi8QAemdf/JquA+o1S2rGMJsqy3ITXxMS9GYYhTKxUsKJBD0WXIw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "a3ad96c8-a7df-4764-896f-f5e24f778963", "user2" },
                    { new Guid("a6495b07-26d5-4b20-af3c-ebaffb01a243"), 0, "2f7cdda3-ed25-4540-b8c9-948d784b67db", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEA4EWMOm5ckOq3CwGBHBnFDkLeO71p2aSnmv4BWMihwEFuQ2M5uCcswNZM1YcuzmVQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "c852ae78-77ed-416c-a984-5650e99dab09", "user" },
                    { new Guid("bb9cb21d-cbf9-471a-b3dc-3bfaefb1c09d"), 0, "5fe8d08b-e63e-4a09-9f79-a19336338eaa", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(5799), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "admin@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(5800), new TimeSpan(0, 0, 0, 0, 0)), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEFWD2PANZk95Bl+Ebi16KkM69538iWzjIaEtrhOszAop8stcZYFcmMNiq0GRhpDdvA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "a3ad96c8-a7df-4764-896f-f5e24f778963", "admin" },
                    { new Guid("d85b8ff0-10db-49fb-a77b-36b068cb4418"), 0, "57914f8a-1af7-482c-aca0-2096531bd7ad", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(5901), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user4@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(5902), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEGDCSjVqHPR5IYVXuGrdeeGm1tGjE4phyN7OEZKNY0jVj4QMSDcRXhQmjZRsQZpY0Q==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "5c0b9b5a-75a5-4369-94ae-ee830d8d16c3", "user4" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Name", "Price", "ServiceImage", "ShopId", "TimeService", "Type" },
                values: new object[,]
                {
                    { "1d95dbdc-13da-48fc-956b-adad5e534575", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6228), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A professional hair styling service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6229), new TimeSpan(0, 0, 0, 0, 0)), "Hair Styling", 20000.00m, null, "dec13fcd-79eb-4e0f-9572-e24415cf3b92", 45, "Hair" },
                    { "6156bd94-3a47-4f63-8e4e-95659953306c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6244), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A soothing scalp treatment.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6245), new TimeSpan(0, 0, 0, 0, 0)), "Scalp Treatment", 45000.00m, null, "dec13fcd-79eb-4e0f-9572-e24415cf3b92", 40, "Hair" },
                    { "6861ae97-c6da-4b81-b0fb-72ea2dcbc447", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6224), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A premium hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6225), new TimeSpan(0, 0, 0, 0, 0)), "Premium Hair Coloring", 100000.00m, null, "dec13fcd-79eb-4e0f-9572-e24415cf3b92", 60, "Hair" },
                    { "756c863b-bae2-43c4-b8b5-51145dc2073d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6241), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A rejuvenating facial service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6241), new TimeSpan(0, 0, 0, 0, 0)), "Facial", 40000.00m, null, "dec13fcd-79eb-4e0f-9572-e24415cf3b92", 50, "Skin" },
                    { "89506c9b-d6e4-4759-9cb1-0af2102ef1ca", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6212), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A stylish haircut to refresh your look.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6214), new TimeSpan(0, 0, 0, 0, 0)), "Hair Cut", 25000.00m, null, "dec13fcd-79eb-4e0f-9572-e24415cf3b92", 30, "Hair" },
                    { "a12f8f92-ec9d-409e-a262-bb1083b1f9d4", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6236), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A clean and smooth shaving service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6237), new TimeSpan(0, 0, 0, 0, 0)), "Shave", 12000.00m, null, "dec13fcd-79eb-4e0f-9572-e24415cf3b92", 15, "Beard" },
                    { "bb9ed6c6-4d8e-49c7-9e40-2acff71ae965", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6233), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A neat beard trimming service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6233), new TimeSpan(0, 0, 0, 0, 0)), "Beard Trim", 15000.00m, null, "dec13fcd-79eb-4e0f-9572-e24415cf3b92", 20, "Beard" },
                    { "ea5b1890-5ebe-4b86-9813-6e964a874acb", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6220), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A complete hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6221), new TimeSpan(0, 0, 0, 0, 0)), "Hair Coloring", 50000.00m, null, "dec13fcd-79eb-4e0f-9572-e24415cf3b92", 30, "Hair" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { new Guid("831af259-cb7f-493e-9d63-cddda8cc3970"), new Guid("15493fec-51d5-4ec7-b714-9cc7a41aa4b0"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6046), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6047), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("49e2fccc-8c72-4fe6-8018-a305a44217a3"), new Guid("1e2a2b96-2db9-44d0-ad3e-f8e4c31e92e7"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6037), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6037), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5ea515eb-fba4-493a-ba71-28447268c4ba"), new Guid("8111b228-86d7-4fc8-a616-1995a67d1a00"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6040), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6040), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("831af259-cb7f-493e-9d63-cddda8cc3970"), new Guid("91d314d2-cd40-4f8c-a922-ed42ccec5c1d"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6058), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6058), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("831af259-cb7f-493e-9d63-cddda8cc3970"), new Guid("a5280c92-fa80-44f5-8b0f-7e9f0b70349d"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6044), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6044), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("831af259-cb7f-493e-9d63-cddda8cc3970"), new Guid("a6495b07-26d5-4b20-af3c-ebaffb01a243"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6025), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6034), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e7480fbf-05f7-4284-a1c9-37fb3d518f8e"), new Guid("bb9cb21d-cbf9-471a-b3dc-3bfaefb1c09d"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6022), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6023), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("831af259-cb7f-493e-9d63-cddda8cc3970"), new Guid("d85b8ff0-10db-49fb-a77b-36b068cb4418"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6049), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6056), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ComboServices",
                columns: new[] { "Id", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[,]
                {
                    { "3048b8198449428b8942675a4ec61a3c", "160f2d9b-aec4-4d80-bc19-ccab6e27339e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6475), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6475), new TimeSpan(0, 0, 0, 0, 0)), "6861ae97-c6da-4b81-b0fb-72ea2dcbc447" },
                    { "88d257d17df44c6e84ee3bbe2d930b2f", "19de2185-ff50-4486-973b-23011126e3c9", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6485), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6485), new TimeSpan(0, 0, 0, 0, 0)), "bb9ed6c6-4d8e-49c7-9e40-2acff71ae965" },
                    { "93e275c384f04615bd10ca8de6577400", "19de2185-ff50-4486-973b-23011126e3c9", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6489), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6490), new TimeSpan(0, 0, 0, 0, 0)), "a12f8f92-ec9d-409e-a262-bb1083b1f9d4" },
                    { "ce063431b2344dffa0801b1c36269fe5", "9f0a12d7-f31e-4692-9505-6297f9ef007d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6470), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6471), new TimeSpan(0, 0, 0, 0, 0)), "ea5b1890-5ebe-4b86-9813-6e964a874acb" },
                    { "d2126fe484bf478897dddaa3c800736f", "9f0a12d7-f31e-4692-9505-6297f9ef007d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6466), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6466), new TimeSpan(0, 0, 0, 0, 0)), "89506c9b-d6e4-4759-9cb1-0af2102ef1ca" },
                    { "d9cecd6bf98b458795dfd8c4552919f0", "160f2d9b-aec4-4d80-bc19-ccab6e27339e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6479), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6479), new TimeSpan(0, 0, 0, 0, 0)), "1d95dbdc-13da-48fc-956b-adad5e534575" }
                });

            migrationBuilder.InsertData(
                table: "SalaryPayments",
                columns: new[] { "Id", "BaseSalary", "BonusSalary", "CreatedBy", "CreatedTime", "DayOffNoPermitted", "DayOffPermitted", "DeductedSalary", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentDate", "UserId" },
                values: new object[] { "4a596617-e789-47a4-b7c7-e5b7d706cc19", 2000.00m, 0m, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6324), new TimeSpan(0, 0, 0, 0, 0)), 0, 0, 0m, null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Unspecified).AddTicks(6324), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2024, 10, 24, 1, 35, 42, 51, DateTimeKind.Utc).AddTicks(6323), new Guid("bb9cb21d-cbf9-471a-b3dc-3bfaefb1c09d") });

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
                name: "IX_ComboAppointment_AppointmentId",
                table: "ComboAppointment",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboAppointment_ComboId",
                table: "ComboAppointment",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboServices_ComboId",
                table: "ComboServices",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboServices_ServiceId",
                table: "ComboServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_AppointmentId",
                table: "Feedbacks",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_AppointmentId",
                table: "Payments",
                column: "AppointmentId",
                unique: true);

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
                name: "ComboAppointment");

            migrationBuilder.DropTable(
                name: "ComboServices");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "SalaryPayments");

            migrationBuilder.DropTable(
                name: "ServiceAppointments");

            migrationBuilder.DropTable(
                name: "ApplicationRoles");

            migrationBuilder.DropTable(
                name: "Combos");

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
