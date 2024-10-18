using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HairSalon.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
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
                    BankCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankTranNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
