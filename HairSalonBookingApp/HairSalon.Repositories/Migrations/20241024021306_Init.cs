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
                    { new Guid("0ff2faef-1891-450b-a13e-bd7bfbec3b9c"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 59, DateTimeKind.Unspecified).AddTicks(1973), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 59, DateTimeKind.Unspecified).AddTicks(1974), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "ADMIN" },
                    { new Guid("682aa569-a4a0-44f3-9a76-4a5fe31cbd96"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 59, DateTimeKind.Unspecified).AddTicks(1987), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 59, DateTimeKind.Unspecified).AddTicks(1987), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" },
                    { new Guid("a4b5290c-4f9e-41d2-97c2-4ecbd3e729bf"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 59, DateTimeKind.Unspecified).AddTicks(1984), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 59, DateTimeKind.Unspecified).AddTicks(1984), new TimeSpan(0, 0, 0, 0, 0)), "Stylist", "STYLIST" },
                    { new Guid("e4362269-3e56-4bf0-a4a1-5d28a0c0143c"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 59, DateTimeKind.Unspecified).AddTicks(1977), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 59, DateTimeKind.Unspecified).AddTicks(1978), new TimeSpan(0, 0, 0, 0, 0)), "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "ComboImage", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "TimeCombo", "TotalPrice" },
                values: new object[,]
                {
                    { "0b39897e-ab67-4d04-896b-a08b4d6a5a86", null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4439), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4440), new TimeSpan(0, 0, 0, 0, 0)), "Basic Hair Combo", 60, 40000.00m },
                    { "46e286f5-ade3-4534-b85e-bb48bbd2071f", null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4455), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4455), new TimeSpan(0, 0, 0, 0, 0)), "Ultimate Hair & Beard Combo", 150, 120000.00m },
                    { "ff42b448-d7ef-47a5-aee1-9efe73e2ace2", null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4450), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4451), new TimeSpan(0, 0, 0, 0, 0)), "Deluxe Hair Combo", 120, 80000.00m }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "OpenTime", "ShopEmail", "ShopImage", "ShopPhone", "Title" },
                values: new object[] { "a1ae1a30-9dc8-4b84-b855-a8bd8ee7daa9", "123 Main St, Cityville", new TimeSpan(0, 19, 0, 0, 0), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4025), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4026), new TimeSpan(0, 0, 0, 0, 0)), "Salon A", new TimeSpan(0, 9, 0, 0, 0), "contact@salona.com", null, "123-456-7890", "Best Hair Salon in Town" });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Bank", "BankAccount", "BankAccountName", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Firstname", "LastUpdatedBy", "LastUpdatedTime", "Lastname", "Point" },
                values: new object[,]
                {
                    { "8476c69e-287f-4fc5-aa65-e196ff717f8c", "Bank c", "123456798", "Dev Nguyen", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 59, DateTimeKind.Unspecified).AddTicks(2287), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dev", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 59, DateTimeKind.Unspecified).AddTicks(2288), new TimeSpan(0, 0, 0, 0, 0)), "Nguyen", 0 },
                    { "87907a4d-a0a6-453c-9766-99d3bdb4160f", "Bank A", "123456789", "John Doe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 59, DateTimeKind.Unspecified).AddTicks(2276), new TimeSpan(0, 0, 0, 0, 0)), null, null, "John", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 59, DateTimeKind.Unspecified).AddTicks(2277), new TimeSpan(0, 0, 0, 0, 0)), "Doe", 100 },
                    { "a52fac19-a7f3-4e4f-975a-3a37abc0990e", "Bank B", "987654321", "Jane Smith", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 59, DateTimeKind.Unspecified).AddTicks(2282), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jane", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 59, DateTimeKind.Unspecified).AddTicks(2282), new TimeSpan(0, 0, 0, 0, 0)), "Smith", 150 },
                    { "b65b2ac6-5cc5-483c-a1cd-6aa9c7ef778b", "Bank D", "123456987", "Dan Tran", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 59, DateTimeKind.Unspecified).AddTicks(2292), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dan", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 59, DateTimeKind.Unspecified).AddTicks(2293), new TimeSpan(0, 0, 0, 0, 0)), "Tran", 0 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "E_Wallet", "Email", "EmailConfirmed", "LastUpdatedBy", "LastUpdatedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OtpCode", "OtpCodeResetPassword", "OtpExpiration", "OtpExpirationResetPassword", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserImage", "UserInfoId", "UserName" },
                values: new object[,]
                {
                    { new Guid("038930bb-d4ae-4721-ab99-713f7c9881c7"), 0, "7f38d191-43e6-48c7-96cb-4d6c1189ca1d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3300), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "manager@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3301), new TimeSpan(0, 0, 0, 0, 0)), false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAECimaxufZWM3iR9cY/mv/Q4FxhvbaXDdLJIYhtmCrEyo/D8cJ67HfpB+zoHpc0QLuA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "8476c69e-287f-4fc5-aa65-e196ff717f8c", "manager" },
                    { new Guid("3b9627a8-4a22-4812-8e17-9b3f91b06b3c"), 0, "0f3003fd-d7b2-44eb-928b-53419aedc858", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3424), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user5@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3424), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEJb2eHetwCWMpA4mdMD+gQz5GPfiiq0whIolcCi/p2JPwst9AUTskutk3STcAkPlwQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "b65b2ac6-5cc5-483c-a1cd-6aa9c7ef778b", "user5" },
                    { new Guid("4ab73bd9-bc9e-4522-a4fa-85abddcc15d7"), 0, "d7c6cffb-6f5c-4349-bc8c-aa9a777a0dad", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3415), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user3@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3415), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER3@EXAMPLE.COM", "USER3@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEPJpP1uFiC84CxY73tHniYg0NwKw/wlRTn8lgfcVEqt03XJnETa7FL8p9O7Q+RUa9Q==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "a52fac19-a7f3-4e4f-975a-3a37abc0990e", "user3" },
                    { new Guid("4fddf596-aa57-4d4b-9fc8-5eb85d705dd1"), 0, "aa706765-e8cc-4fd9-90fe-3ae0cbd4f376", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3305), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "stylist@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3306), new TimeSpan(0, 0, 0, 0, 0)), false, null, "STYLIST@EXAMPLE.COM", "STYLIST@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEH01xkWadpuVvQ1CUiadibvaJGedwNrLjEySlrGFvxEXb+b8cViVCC7hapCnpsJdrg==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "b65b2ac6-5cc5-483c-a1cd-6aa9c7ef778b", "stylist" },
                    { new Guid("7005b916-bafe-42c9-9827-ea77a48c3f70"), 0, "4696280b-f397-42d0-8e12-d950c8f309d7", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3294), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3295), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAECunVn6fjxgZhiESW3dgBV4/w2XydrL6fYCgXPSJO8PZWJbxhbwpP+eRh9DL/FvnpQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "a52fac19-a7f3-4e4f-975a-3a37abc0990e", "user" },
                    { new Guid("b812bd5b-bad8-4521-95ed-d02f2da09efb"), 0, "e041bfda-5aec-4abf-a2de-161f738e8788", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3285), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "admin@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3286), new TimeSpan(0, 0, 0, 0, 0)), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAELw1l3b3xIeNI4eu8r/ZW6gaSi6X0tsw21A6HlzimF3Bj9I+SUc506EM2bFZioaWaA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "87907a4d-a0a6-453c-9766-99d3bdb4160f", "admin" },
                    { new Guid("c6717cb9-d2b5-4bf1-9e27-d16f27b6f181"), 0, "6f920535-0cab-45e5-a964-308d750ffed8", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3410), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user2@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3410), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEOQUYaXOF8A0PHlUsciO1MQayM2vj/LjsoCxaaBfGCr9pyuLsXl/ogOsw2ONO5xVnA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "87907a4d-a0a6-453c-9766-99d3bdb4160f", "user2" },
                    { new Guid("d8202085-182b-4612-a640-c63e98239bdc"), 0, "843b7a12-2475-47a3-a6ec-55f2fcefc3e0", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3419), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user4@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3420), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEBAvaN/l+wZne64WyDKTpahRBDAdvIILhgmcGno1zkLB0ST1iMqw5v8dBMD2+mOmcg==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "8476c69e-287f-4fc5-aa65-e196ff717f8c", "user4" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Name", "Price", "ServiceImage", "ShopId", "TimeService", "Type" },
                values: new object[,]
                {
                    { "28d526d4-b7cf-490d-b388-b1e2fb641afe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4239), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A soothing scalp treatment.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4240), new TimeSpan(0, 0, 0, 0, 0)), "Scalp Treatment", 45000.00m, null, "a1ae1a30-9dc8-4b84-b855-a8bd8ee7daa9", 40, "Hair" },
                    { "34eb9e1c-0c5f-45e6-a22f-4c4f4588fc4c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4214), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A premium hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4215), new TimeSpan(0, 0, 0, 0, 0)), "Premium Hair Coloring", 100000.00m, null, "a1ae1a30-9dc8-4b84-b855-a8bd8ee7daa9", 60, "Hair" },
                    { "395d38d5-984e-44a6-8149-9427d7227ce3", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4234), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A rejuvenating facial service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4235), new TimeSpan(0, 0, 0, 0, 0)), "Facial", 40000.00m, null, "a1ae1a30-9dc8-4b84-b855-a8bd8ee7daa9", 50, "Skin" },
                    { "6123f265-4cd5-4742-b68d-1950d7fd5ccc", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4205), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A stylish haircut to refresh your look.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4205), new TimeSpan(0, 0, 0, 0, 0)), "Hair Cut", 25000.00m, null, "a1ae1a30-9dc8-4b84-b855-a8bd8ee7daa9", 30, "Hair" },
                    { "cd701013-ea18-4961-b576-062561e69929", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4210), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A complete hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4210), new TimeSpan(0, 0, 0, 0, 0)), "Hair Coloring", 50000.00m, null, "a1ae1a30-9dc8-4b84-b855-a8bd8ee7daa9", 30, "Hair" },
                    { "d8f73fa0-3f18-402a-ba4d-bc411ed2de5b", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4231), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A clean and smooth shaving service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4231), new TimeSpan(0, 0, 0, 0, 0)), "Shave", 12000.00m, null, "a1ae1a30-9dc8-4b84-b855-a8bd8ee7daa9", 15, "Beard" },
                    { "ee11e0b7-18aa-4eb3-b433-c3d44d8788e7", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4219), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A professional hair styling service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4220), new TimeSpan(0, 0, 0, 0, 0)), "Hair Styling", 20000.00m, null, "a1ae1a30-9dc8-4b84-b855-a8bd8ee7daa9", 45, "Hair" },
                    { "f37e2355-71eb-461e-b10d-f1b82b4f010c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4223), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A neat beard trimming service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4224), new TimeSpan(0, 0, 0, 0, 0)), "Beard Trim", 15000.00m, null, "a1ae1a30-9dc8-4b84-b855-a8bd8ee7daa9", 20, "Beard" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { new Guid("e4362269-3e56-4bf0-a4a1-5d28a0c0143c"), new Guid("038930bb-d4ae-4721-ab99-713f7c9881c7"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3609), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3610), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("682aa569-a4a0-44f3-9a76-4a5fe31cbd96"), new Guid("3b9627a8-4a22-4812-8e17-9b3f91b06b3c"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3632), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3632), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("682aa569-a4a0-44f3-9a76-4a5fe31cbd96"), new Guid("4ab73bd9-bc9e-4522-a4fa-85abddcc15d7"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3618), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3619), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a4b5290c-4f9e-41d2-97c2-4ecbd3e729bf"), new Guid("4fddf596-aa57-4d4b-9fc8-5eb85d705dd1"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3613), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3613), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("682aa569-a4a0-44f3-9a76-4a5fe31cbd96"), new Guid("7005b916-bafe-42c9-9827-ea77a48c3f70"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3555), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3606), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("0ff2faef-1891-450b-a13e-bd7bfbec3b9c"), new Guid("b812bd5b-bad8-4521-95ed-d02f2da09efb"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3551), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3552), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("682aa569-a4a0-44f3-9a76-4a5fe31cbd96"), new Guid("c6717cb9-d2b5-4bf1-9e27-d16f27b6f181"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3615), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3616), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("682aa569-a4a0-44f3-9a76-4a5fe31cbd96"), new Guid("d8202085-182b-4612-a640-c63e98239bdc"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3621), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(3629), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ComboServices",
                columns: new[] { "Id", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[,]
                {
                    { "0cf08af41bc6423dac8cfbb3731d4429", "ff42b448-d7ef-47a5-aee1-9efe73e2ace2", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4559), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4560), new TimeSpan(0, 0, 0, 0, 0)), "ee11e0b7-18aa-4eb3-b433-c3d44d8788e7" },
                    { "8d0a792e7ca9454bb24ef4c1faf8db1a", "0b39897e-ab67-4d04-896b-a08b4d6a5a86", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4549), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4549), new TimeSpan(0, 0, 0, 0, 0)), "cd701013-ea18-4961-b576-062561e69929" },
                    { "9b69f588b94f4948b3c3759ead10148d", "46e286f5-ade3-4534-b85e-bb48bbd2071f", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4567), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4568), new TimeSpan(0, 0, 0, 0, 0)), "d8f73fa0-3f18-402a-ba4d-bc411ed2de5b" },
                    { "9c2e97e7e0604e77bf81f89e55bd740e", "0b39897e-ab67-4d04-896b-a08b4d6a5a86", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4544), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4544), new TimeSpan(0, 0, 0, 0, 0)), "6123f265-4cd5-4742-b68d-1950d7fd5ccc" },
                    { "bfc839a0fe1042af95495d1b64fd4cfd", "ff42b448-d7ef-47a5-aee1-9efe73e2ace2", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4555), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4555), new TimeSpan(0, 0, 0, 0, 0)), "34eb9e1c-0c5f-45e6-a22f-4c4f4588fc4c" },
                    { "cf1564bca96442c8b997a691ce54465b", "46e286f5-ade3-4534-b85e-bb48bbd2071f", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4563), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4564), new TimeSpan(0, 0, 0, 0, 0)), "f37e2355-71eb-461e-b10d-f1b82b4f010c" }
                });

            migrationBuilder.InsertData(
                table: "SalaryPayments",
                columns: new[] { "Id", "BaseSalary", "BonusSalary", "CreatedBy", "CreatedTime", "DayOffNoPermitted", "DayOffPermitted", "DeductedSalary", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentDate", "UserId" },
                values: new object[] { "914f27d5-0291-49d9-b889-046cdbb06340", 2000.00m, 0m, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4302), new TimeSpan(0, 0, 0, 0, 0)), 0, 0, 0m, null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Unspecified).AddTicks(4302), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2024, 10, 24, 2, 13, 5, 587, DateTimeKind.Utc).AddTicks(4301), new Guid("b812bd5b-bad8-4521-95ed-d02f2da09efb") });

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
