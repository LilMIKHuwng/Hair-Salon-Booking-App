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
                    { new Guid("0aa401eb-53cb-49fe-b81a-725c008d20c2"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 315, DateTimeKind.Unspecified).AddTicks(1584), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 315, DateTimeKind.Unspecified).AddTicks(1584), new TimeSpan(0, 0, 0, 0, 0)), "Manager", "MANAGER" },
                    { new Guid("bdf26ea4-6b9e-4c52-93fb-f34708b03899"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 315, DateTimeKind.Unspecified).AddTicks(1589), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 315, DateTimeKind.Unspecified).AddTicks(1590), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" },
                    { new Guid("ca44649e-a2a5-465e-8e72-055710203f8b"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 315, DateTimeKind.Unspecified).AddTicks(1580), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 315, DateTimeKind.Unspecified).AddTicks(1580), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "ADMIN" },
                    { new Guid("ee27f0c7-4eda-40f4-8fbb-d7d6e3169444"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 315, DateTimeKind.Unspecified).AddTicks(1587), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 315, DateTimeKind.Unspecified).AddTicks(1587), new TimeSpan(0, 0, 0, 0, 0)), "Stylist", "STYLIST" }
                });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "TimeCombo", "TotalPrice" },
                values: new object[,]
                {
                    { "4f5e5e3e-19a3-402b-a587-a6716c14520c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4643), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4644), new TimeSpan(0, 0, 0, 0, 0)), "Deluxe Hair Combo", 120, 80000.00m },
                    { "521c7f3d-ac9e-4254-9471-1de1c7a19e2d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 0, 0, 0, 0)), "Basic Hair Combo", 60, 40000.00m },
                    { "d5f72e68-bd4f-4940-aa53-9c989ac80225", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4648), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4648), new TimeSpan(0, 0, 0, 0, 0)), "Ultimate Hair & Beard Combo", 150, 120000.00m }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "OpenTime", "ShopEmail", "ShopPhone", "Title" },
                values: new object[] { "3d1fdae1-4839-4429-8343-d1d4f7f3c518", "123 Main St, Cityville", new TimeSpan(0, 19, 0, 0, 0), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4193), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4194), new TimeSpan(0, 0, 0, 0, 0)), "Salon A", new TimeSpan(0, 9, 0, 0, 0), "contact@salona.com", "123-456-7890", "Best Hair Salon in Town" });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Bank", "BankAccount", "BankAccountName", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Firstname", "LastUpdatedBy", "LastUpdatedTime", "Lastname", "Point" },
                values: new object[,]
                {
                    { "573d062e-15a9-48e7-82a9-016078164cf9", "Bank c", "123456798", "Dev Nguyen", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 315, DateTimeKind.Unspecified).AddTicks(2462), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dev", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 315, DateTimeKind.Unspecified).AddTicks(2463), new TimeSpan(0, 0, 0, 0, 0)), "Nguyen", 0 },
                    { "c07359aa-83cb-4f2a-9bc3-952b4a24bb2c", "Bank D", "123456987", "Dan Tran", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 315, DateTimeKind.Unspecified).AddTicks(2467), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dan", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 315, DateTimeKind.Unspecified).AddTicks(2468), new TimeSpan(0, 0, 0, 0, 0)), "Tran", 0 },
                    { "e8151bc2-d0bf-433b-8af4-7a35fe465c68", "Bank B", "987654321", "Jane Smith", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 315, DateTimeKind.Unspecified).AddTicks(2458), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jane", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 315, DateTimeKind.Unspecified).AddTicks(2459), new TimeSpan(0, 0, 0, 0, 0)), "Smith", 150 },
                    { "ebcb88c3-9b38-40b9-a476-35d83753085e", "Bank A", "123456789", "John Doe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 315, DateTimeKind.Unspecified).AddTicks(2453), new TimeSpan(0, 0, 0, 0, 0)), null, null, "John", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 315, DateTimeKind.Unspecified).AddTicks(2453), new TimeSpan(0, 0, 0, 0, 0)), "Doe", 100 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "E_Wallet", "Email", "EmailConfirmed", "LastUpdatedBy", "LastUpdatedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OtpCode", "OtpCodeResetPassword", "OtpExpiration", "OtpExpirationResetPassword", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserInfoId", "UserName" },
                values: new object[,]
                {
                    { new Guid("0cf28aae-3061-4256-9c61-566ce261f791"), 0, "b96e663d-f99a-4d19-a2cd-36e139339e52", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3251), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "admin@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3252), new TimeSpan(0, 0, 0, 0, 0)), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEGyLScEly2X2LAp5dPYzYKQuz/Sfj2vZQjMRNdXf+LSeN6HJYHnX9zHAqh/IysHNMg==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "ebcb88c3-9b38-40b9-a476-35d83753085e", "admin" },
                    { new Guid("17a02095-a6a4-495d-b592-19cb8d14aca6"), 0, "b59ed5af-8b48-424a-b8ee-fad502ad858d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3290), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user2@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3291), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEAU56cLYcoQ0316HG/xL/Ms7gMEQWr3qletEVifUmVHORXYFlfxa0poZNpMr2VW5CA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "ebcb88c3-9b38-40b9-a476-35d83753085e", "user2" },
                    { new Guid("74143991-b8e0-48cb-bbe7-b7141b425728"), 0, "9237b1a8-3aa9-48ff-a1e7-4b7d8346a0e4", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3260), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3260), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEGRbUROcs7QwkXJimTKJ8Vm7JNJ+qj4buDRvfVrzisDCVWJnz3xXUbfKbFqDx7TRxw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "e8151bc2-d0bf-433b-8af4-7a35fe465c68", "user" },
                    { new Guid("a1836847-6285-4951-8941-d013c08845b1"), 0, "dc94d09a-8826-48fe-b0ec-2c6774c61d24", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3268), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "manager@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3269), new TimeSpan(0, 0, 0, 0, 0)), false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEEG78MwYyN6kg7qOj3Q12Dd9Y3ip260CV1PL3zfEbi2zbfvJgTA4XZZ8joRKcqq4KQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "573d062e-15a9-48e7-82a9-016078164cf9", "manager" },
                    { new Guid("b0556388-498f-482f-ae9d-0d7c63d8891f"), 0, "3034bbc6-8fe8-42c8-9157-445b159f9472", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3306), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user5@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3307), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEMqtNOdLxCVeHlPgMs44+MeJElu/vhw98WvhORTdJQwY6zi+31jI8STUMTu/eyTsBg==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "c07359aa-83cb-4f2a-9bc3-952b4a24bb2c", "user5" },
                    { new Guid("b0d1fc24-d4bb-42dc-a990-8122b9b63cc3"), 0, "398e3ac0-7748-4b3c-aed8-650d0bc00aa3", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3302), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user4@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3303), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEBu5Ppi2l93psPANlm/WHoaBlP4MHH3kIp52PP+3uSWSfis/RpQ3gXE0vkk7wJrc4Q==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "573d062e-15a9-48e7-82a9-016078164cf9", "user4" },
                    { new Guid("bb27e4b6-d190-4070-9046-ab88ac2d3003"), 0, "9f105be0-ae64-4458-9ddd-785f393cf646", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3274), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "stylist@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3275), new TimeSpan(0, 0, 0, 0, 0)), false, null, "STYLIST@EXAMPLE.COM", "STYLIST@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEGjeUkmIRVv5XiaGMjir0BK9s+eCVKz6U24Nftt+MH3Q2uR/kJvuMPfbxE/C6jwXUw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "c07359aa-83cb-4f2a-9bc3-952b4a24bb2c", "stylist" },
                    { new Guid("d5d77ed7-e6c1-4727-9a13-29ba600395e7"), 0, "18fb6cf2-ec93-49bf-92a5-db1a7ca3b04a", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3296), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user3@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3296), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER3@EXAMPLE.COM", "USER3@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEGXp5PzUQ5kmQgMGgzkf6dUs/GEgK0v+20/ChrKxC+wZ7bCYnRO/Cxd/QlT9KtEebQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "e8151bc2-d0bf-433b-8af4-7a35fe465c68", "user3" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Name", "Price", "ShopId", "TimeService", "Type" },
                values: new object[,]
                {
                    { "0c634666-59f8-4a74-a238-20048dd1720e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4287), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A professional hair styling service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4288), new TimeSpan(0, 0, 0, 0, 0)), "Hair Styling", 20000.00m, "3d1fdae1-4839-4429-8343-d1d4f7f3c518", 45, "Hair" },
                    { "4e0aea2d-9e7f-4ad9-a800-a1e66014f606", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4305), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A soothing scalp treatment.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4305), new TimeSpan(0, 0, 0, 0, 0)), "Scalp Treatment", 45000.00m, "3d1fdae1-4839-4429-8343-d1d4f7f3c518", 40, "Hair" },
                    { "80c4598c-f987-4e09-86ef-80e5f095e801", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4301), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A rejuvenating facial service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4302), new TimeSpan(0, 0, 0, 0, 0)), "Facial", 40000.00m, "3d1fdae1-4839-4429-8343-d1d4f7f3c518", 50, "Skin" },
                    { "80d28287-a11e-4357-93a0-d452941ac60e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4297), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A clean and smooth shaving service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4298), new TimeSpan(0, 0, 0, 0, 0)), "Shave", 12000.00m, "3d1fdae1-4839-4429-8343-d1d4f7f3c518", 15, "Beard" },
                    { "84f022e2-f398-4d63-aa62-9c02b033d91d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4282), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A premium hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4284), new TimeSpan(0, 0, 0, 0, 0)), "Premium Hair Coloring", 100000.00m, "3d1fdae1-4839-4429-8343-d1d4f7f3c518", 60, "Hair" },
                    { "94e00848-0b0b-4c46-8a70-965ae2ec49a1", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4292), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A neat beard trimming service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4293), new TimeSpan(0, 0, 0, 0, 0)), "Beard Trim", 15000.00m, "3d1fdae1-4839-4429-8343-d1d4f7f3c518", 20, "Beard" },
                    { "b6310336-d763-466a-826c-a7111f7e7b11", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4271), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A stylish haircut to refresh your look.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4272), new TimeSpan(0, 0, 0, 0, 0)), "Hair Cut", 25000.00m, "3d1fdae1-4839-4429-8343-d1d4f7f3c518", 30, "Hair" },
                    { "b9c5de55-b56f-4be2-ba51-317d0106392a", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4275), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A complete hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4277), new TimeSpan(0, 0, 0, 0, 0)), "Hair Coloring", 50000.00m, "3d1fdae1-4839-4429-8343-d1d4f7f3c518", 30, "Hair" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { new Guid("ca44649e-a2a5-465e-8e72-055710203f8b"), new Guid("0cf28aae-3061-4256-9c61-566ce261f791"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3950), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3950), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("bdf26ea4-6b9e-4c52-93fb-f34708b03899"), new Guid("17a02095-a6a4-495d-b592-19cb8d14aca6"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3981), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3981), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("bdf26ea4-6b9e-4c52-93fb-f34708b03899"), new Guid("74143991-b8e0-48cb-bbe7-b7141b425728"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3953), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3970), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("0aa401eb-53cb-49fe-b81a-725c008d20c2"), new Guid("a1836847-6285-4951-8941-d013c08845b1"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3972), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3973), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("bdf26ea4-6b9e-4c52-93fb-f34708b03899"), new Guid("b0556388-498f-482f-ae9d-0d7c63d8891f"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4082), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4082), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("bdf26ea4-6b9e-4c52-93fb-f34708b03899"), new Guid("b0d1fc24-d4bb-42dc-a990-8122b9b63cc3"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4072), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4079), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ee27f0c7-4eda-40f4-8fbb-d7d6e3169444"), new Guid("bb27e4b6-d190-4070-9046-ab88ac2d3003"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3977), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3978), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("bdf26ea4-6b9e-4c52-93fb-f34708b03899"), new Guid("d5d77ed7-e6c1-4727-9a13-29ba600395e7"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3986), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(3990), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PointsEarned", "StatusForAppointment", "StylistId", "TotalAmount", "TotalTime", "UserId" },
                values: new object[,]
                {
                    { "7aed9436-d85d-4039-aee2-d10c0b724e6a", new DateTime(2024, 10, 22, 6, 35, 43, 863, DateTimeKind.Utc).AddTicks(4396), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4404), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4405), new TimeSpan(0, 0, 0, 0, 0)), 10, "Pending", new Guid("74143991-b8e0-48cb-bbe7-b7141b425728"), 100000.00m, 0, new Guid("0cf28aae-3061-4256-9c61-566ce261f791") },
                    { "7cfddae8-52a6-4f35-8f24-f62e34afe01a", new DateTime(2024, 10, 25, 6, 35, 43, 863, DateTimeKind.Utc).AddTicks(4424), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4424), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4425), new TimeSpan(0, 0, 0, 0, 0)), 20, "Completed", new Guid("bb27e4b6-d190-4070-9046-ab88ac2d3003"), 150000.00m, 90, new Guid("b0d1fc24-d4bb-42dc-a990-8122b9b63cc3") },
                    { "d96c67c0-a20f-477f-8d5e-f1e8b13b2801", new DateTime(2024, 10, 24, 6, 35, 43, 863, DateTimeKind.Utc).AddTicks(4419), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4420), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4420), new TimeSpan(0, 0, 0, 0, 0)), 12, "Pending", new Guid("bb27e4b6-d190-4070-9046-ab88ac2d3003"), 200000.00m, 45, new Guid("17a02095-a6a4-495d-b592-19cb8d14aca6") },
                    { "e2cd2e81-67a7-4647-bcd7-30bc9acbd3d6", new DateTime(2024, 10, 23, 6, 35, 43, 863, DateTimeKind.Utc).AddTicks(4409), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4410), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4411), new TimeSpan(0, 0, 0, 0, 0)), 15, "Scheduled", new Guid("bb27e4b6-d190-4070-9046-ab88ac2d3003"), 65000.00m, 75, new Guid("a1836847-6285-4951-8941-d013c08845b1") }
                });

            migrationBuilder.InsertData(
                table: "ComboServices",
                columns: new[] { "Id", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[,]
                {
                    { "5b48ebcef9c745cead810fd2564061fc", "d5f72e68-bd4f-4940-aa53-9c989ac80225", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4708), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4708), new TimeSpan(0, 0, 0, 0, 0)), "80d28287-a11e-4357-93a0-d452941ac60e" },
                    { "62180be2eb294cca83bd31b11f1b238f", "d5f72e68-bd4f-4940-aa53-9c989ac80225", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4703), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4704), new TimeSpan(0, 0, 0, 0, 0)), "94e00848-0b0b-4c46-8a70-965ae2ec49a1" },
                    { "7c4de4c51cb247fea239788b5b3924ca", "521c7f3d-ac9e-4254-9471-1de1c7a19e2d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4685), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4686), new TimeSpan(0, 0, 0, 0, 0)), "b6310336-d763-466a-826c-a7111f7e7b11" },
                    { "9dc8269be3644709bf17beae33a9942a", "521c7f3d-ac9e-4254-9471-1de1c7a19e2d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4689), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4690), new TimeSpan(0, 0, 0, 0, 0)), "b9c5de55-b56f-4be2-ba51-317d0106392a" },
                    { "a4abd818de6c4ac78b55409aa164bdf8", "4f5e5e3e-19a3-402b-a587-a6716c14520c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4700), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4700), new TimeSpan(0, 0, 0, 0, 0)), "0c634666-59f8-4a74-a238-20048dd1720e" },
                    { "d4585d5246764fccb214e76e1c7fef8f", "4f5e5e3e-19a3-402b-a587-a6716c14520c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4694), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4695), new TimeSpan(0, 0, 0, 0, 0)), "84f022e2-f398-4d63-aa62-9c02b033d91d" }
                });

            migrationBuilder.InsertData(
                table: "SalaryPayments",
                columns: new[] { "Id", "BaseSalary", "BonusSalary", "CreatedBy", "CreatedTime", "DayOffNoPermitted", "DayOffPermitted", "DeductedSalary", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentDate", "UserId" },
                values: new object[] { "bf029763-c0a2-4c8e-8988-63e8063bb27d", 2000.00m, 0m, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4549), new TimeSpan(0, 0, 0, 0, 0)), 0, 0, 0m, null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4549), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Utc).AddTicks(4548), new Guid("0cf28aae-3061-4256-9c61-566ce261f791") });

            migrationBuilder.InsertData(
                table: "ComboAppointment",
                columns: new[] { "Id", "AppointmentId", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { "00033b3f-d108-46fc-9281-c4415d5fb073", "e2cd2e81-67a7-4647-bcd7-30bc9acbd3d6", "4f5e5e3e-19a3-402b-a587-a6716c14520c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4784), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4784), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "499d8141-cb9e-48e5-bba0-37c1e50f2b6b", "d96c67c0-a20f-477f-8d5e-f1e8b13b2801", "d5f72e68-bd4f-4940-aa53-9c989ac80225", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4787), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4788), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "972b90bc-0dbb-4285-b60b-316cf2d4e7e8", "7aed9436-d85d-4039-aee2-d10c0b724e6a", "521c7f3d-ac9e-4254-9471-1de1c7a19e2d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4780), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4781), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ServiceAppointments",
                columns: new[] { "Id", "AppointmentId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[] { "9339045d-5d01-4b75-8786-840bab535bfa", "7aed9436-d85d-4039-aee2-d10c0b724e6a", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4514), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Basic haircut", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 21, 6, 35, 43, 863, DateTimeKind.Unspecified).AddTicks(4514), new TimeSpan(0, 0, 0, 0, 0)), "b6310336-d763-466a-826c-a7111f7e7b11" });

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
