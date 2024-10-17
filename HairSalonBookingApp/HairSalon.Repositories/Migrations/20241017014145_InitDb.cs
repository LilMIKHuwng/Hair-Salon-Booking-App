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
                    { new Guid("630e7cc1-e6c2-468d-b8b9-91b6d6ec273e"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 141, DateTimeKind.Unspecified).AddTicks(7982), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 141, DateTimeKind.Unspecified).AddTicks(7982), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" },
                    { new Guid("771bc8f2-0910-4f46-811f-fda6eaeed910"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 141, DateTimeKind.Unspecified).AddTicks(7972), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 141, DateTimeKind.Unspecified).AddTicks(7973), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "ADMIN" },
                    { new Guid("7bd07a69-9724-4692-9f6c-667c1e392221"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 141, DateTimeKind.Unspecified).AddTicks(7979), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 141, DateTimeKind.Unspecified).AddTicks(7979), new TimeSpan(0, 0, 0, 0, 0)), "Stylist", "STYLIST" },
                    { new Guid("8967647d-21e6-4b18-b795-290a472bccbe"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 141, DateTimeKind.Unspecified).AddTicks(7976), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 141, DateTimeKind.Unspecified).AddTicks(7976), new TimeSpan(0, 0, 0, 0, 0)), "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "TimeCombo", "TotalPrice" },
                values: new object[,]
                {
                    { "0af98061-e76a-4a99-a4a0-9101c04f2f34", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6188), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6189), new TimeSpan(0, 0, 0, 0, 0)), "Ultimate Hair & Beard Combo", 150, 120000.00m },
                    { "87863cb6-cfd7-43f0-a797-fac9b4d68644", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6177), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6178), new TimeSpan(0, 0, 0, 0, 0)), "Basic Hair Combo", 60, 40000.00m },
                    { "dec6caba-784a-4e5e-8d32-d9ace416e254", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6183), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6184), new TimeSpan(0, 0, 0, 0, 0)), "Deluxe Hair Combo", 120, 80000.00m }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "OpenTime", "ShopEmail", "ShopPhone", "Title" },
                values: new object[] { "a9759f40-8adb-44eb-a1cb-83f81c17fddd", "123 Main St, Cityville", new TimeSpan(0, 19, 0, 0, 0), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5767), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5768), new TimeSpan(0, 0, 0, 0, 0)), "Salon A", new TimeSpan(0, 9, 0, 0, 0), "contact@salona.com", "123-456-7890", "Best Hair Salon in Town" });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Bank", "BankAccount", "BankAccountName", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Firstname", "LastUpdatedBy", "LastUpdatedTime", "Lastname", "Point" },
                values: new object[,]
                {
                    { "1e07e798-2c73-4ec0-8d30-7e0a09de16a0", "Bank c", "123456798", "Dev Nguyen", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 141, DateTimeKind.Unspecified).AddTicks(8268), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dev", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 141, DateTimeKind.Unspecified).AddTicks(8268), new TimeSpan(0, 0, 0, 0, 0)), "Nguyen", 0 },
                    { "48783111-155a-402d-85e4-e8199d711239", "Bank D", "123456987", "Dan Tran", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 141, DateTimeKind.Unspecified).AddTicks(8274), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dan", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 141, DateTimeKind.Unspecified).AddTicks(8274), new TimeSpan(0, 0, 0, 0, 0)), "Tran", 0 },
                    { "bbe4a9eb-330a-4f8f-9822-fb59a7ef0942", "Bank B", "987654321", "Jane Smith", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 141, DateTimeKind.Unspecified).AddTicks(8262), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jane", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 141, DateTimeKind.Unspecified).AddTicks(8262), new TimeSpan(0, 0, 0, 0, 0)), "Smith", 150 },
                    { "e099bc77-bb3d-4a11-9a1e-fea7c072b7ac", "Bank A", "123456789", "John Doe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 141, DateTimeKind.Unspecified).AddTicks(8255), new TimeSpan(0, 0, 0, 0, 0)), null, null, "John", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 141, DateTimeKind.Unspecified).AddTicks(8256), new TimeSpan(0, 0, 0, 0, 0)), "Doe", 100 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Email", "EmailConfirmed", "LastUpdatedBy", "LastUpdatedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OtpCode", "OtpCodeResetPassword", "OtpExpiration", "OtpExpirationResetPassword", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserInfoId", "UserName" },
                values: new object[,]
                {
                    { new Guid("2cc273ad-7508-494b-9171-7b095c3e023c"), 0, "ccfadbaf-aae8-47a8-a908-58746eb1d6c8", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5498), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user4@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5499), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEOJCg4R7gIcGxz88MlohPsntlYAp0XNFDzSDxT8V0XknNBIFsed2UMHZfwBLJkVU1A==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "1e07e798-2c73-4ec0-8d30-7e0a09de16a0", "user4" },
                    { new Guid("383e62b3-f6c5-4dc4-940e-6f569b442b22"), 0, "bcdf6fa3-9cea-4a77-a0f7-ba5a0127178e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5479), new TimeSpan(0, 0, 0, 0, 0)), null, null, "stylist@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5479), new TimeSpan(0, 0, 0, 0, 0)), false, null, "STYLIST@EXAMPLE.COM", "STYLIST@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEDHF2x4/1SrFzoBuz7dHo/4rVBtDp/5hiQ3bwUGEogspGue2mfI9z4G6317SUNNkwQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "48783111-155a-402d-85e4-e8199d711239", "stylist" },
                    { new Guid("57beccf6-cf46-4794-a4b3-994b92204854"), 0, "3a3c455f-6382-4c92-8e5e-ef5ed0757b90", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5455), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5456), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEAYxcs/qjO7ndfZmXlsWsvTKkM2rJjrJa+t/o3WmAR1/mrrKPDI1jnQTnYeD88fS7A==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "bbe4a9eb-330a-4f8f-9822-fb59a7ef0942", "user" },
                    { new Guid("7c081849-3f31-4e4b-834a-8735e4f4b0a0"), 0, "d2fbec46-7ba1-4e55-a359-4a915f54f15e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5447), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5448), new TimeSpan(0, 0, 0, 0, 0)), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEGDXX3l2RVwU38AAGZRsk6+CcmykNKQUbcsru51PRnERD0gnEsTymZUVt0J0hRQDVQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "e099bc77-bb3d-4a11-9a1e-fea7c072b7ac", "admin" },
                    { new Guid("a71b6433-7283-468a-8452-c54f4f129a8a"), 0, "22853509-8366-4d2f-aee2-c6bfadbfb558", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5460), new TimeSpan(0, 0, 0, 0, 0)), null, null, "manager@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5461), new TimeSpan(0, 0, 0, 0, 0)), false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEGQqrq39xOlomCnxAtkNPO4XuN2bCCP22fYxQqtqr2wD3fVzFeG428vqVvcQMbjJKA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "1e07e798-2c73-4ec0-8d30-7e0a09de16a0", "manager" },
                    { new Guid("adf3c124-a370-47d7-a01c-2d0dddae785f"), 0, "2a81eb42-50be-4c4d-baea-8529b0807aa8", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5492), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user3@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5493), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER3@EXAMPLE.COM", "USER3@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEKdlnU+MflnbuVuFg7e9zqTBl+PkwjBT1fKnvBY0E+TMJK6X8I1wLULPeid93p758w==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "bbe4a9eb-330a-4f8f-9822-fb59a7ef0942", "user3" },
                    { new Guid("e38d3cd6-2bc1-400a-a003-15a93af2ab73"), 0, "aae84214-0f22-457d-8751-bfa3a40be723", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5504), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user5@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5504), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEDiG1XkG7zV8qhzd5LnA7Hnp3tJbQWL/cC0cY8vC0QJbl1ges5jWn9d6I+BL75ut5w==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "48783111-155a-402d-85e4-e8199d711239", "user5" },
                    { new Guid("f268a997-1117-4405-ab1b-82cec5b316b7"), 0, "ee8fe39c-2b1d-4238-9b62-4ffe36b69c16", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5486), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user2@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5486), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEKfTYtExavE3LH1w9R408bpzhsQ0rbshaAbg7HJ/Ma0vOjzu5TypRcaYBKa4SQxgNQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "e099bc77-bb3d-4a11-9a1e-fea7c072b7ac", "user2" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Name", "Price", "ShopId", "TimeService", "Type" },
                values: new object[,]
                {
                    { "0192b203-8f26-4f60-bc46-9ecaa391a00c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5907), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A soothing scalp treatment.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5908), new TimeSpan(0, 0, 0, 0, 0)), "Scalp Treatment", 45000.00m, "a9759f40-8adb-44eb-a1cb-83f81c17fddd", 40, "Hair" },
                    { "28d7fc84-2dbe-4c98-957d-9462a5b097a4", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5903), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A rejuvenating facial service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5904), new TimeSpan(0, 0, 0, 0, 0)), "Facial", 40000.00m, "a9759f40-8adb-44eb-a1cb-83f81c17fddd", 50, "Skin" },
                    { "417c5df3-8bbc-4023-80bb-d31daeb32459", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5882), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A complete hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5883), new TimeSpan(0, 0, 0, 0, 0)), "Hair Coloring", 50000.00m, "a9759f40-8adb-44eb-a1cb-83f81c17fddd", 30, "Hair" },
                    { "6fba1826-3a2f-4afd-a88e-e355b9c7431b", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5891), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A professional hair styling service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5892), new TimeSpan(0, 0, 0, 0, 0)), "Hair Styling", 20000.00m, "a9759f40-8adb-44eb-a1cb-83f81c17fddd", 45, "Hair" },
                    { "9b2d0b8b-91b7-43bc-b470-c34d00f9ef9f", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5876), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A stylish haircut to refresh your look.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5876), new TimeSpan(0, 0, 0, 0, 0)), "Hair Cut", 25000.00m, "a9759f40-8adb-44eb-a1cb-83f81c17fddd", 30, "Hair" },
                    { "b0b8f7a2-93bf-4f71-be48-1d4913dcaee7", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5887), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A premium hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5887), new TimeSpan(0, 0, 0, 0, 0)), "Premium Hair Coloring", 100000.00m, "a9759f40-8adb-44eb-a1cb-83f81c17fddd", 60, "Hair" },
                    { "dd1a8eb0-bbe5-4a13-82aa-ba22a98801bd", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5895), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A neat beard trimming service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5896), new TimeSpan(0, 0, 0, 0, 0)), "Beard Trim", 15000.00m, "a9759f40-8adb-44eb-a1cb-83f81c17fddd", 20, "Beard" },
                    { "ea3aa935-51a1-4162-be1a-41d9415c3b2c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5899), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A clean and smooth shaving service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5900), new TimeSpan(0, 0, 0, 0, 0)), "Shave", 12000.00m, "a9759f40-8adb-44eb-a1cb-83f81c17fddd", 15, "Beard" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { new Guid("630e7cc1-e6c2-468d-b8b9-91b6d6ec273e"), new Guid("2cc273ad-7508-494b-9171-7b095c3e023c"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5657), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5667), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7bd07a69-9724-4692-9f6c-667c1e392221"), new Guid("383e62b3-f6c5-4dc4-940e-6f569b442b22"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5645), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5647), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("630e7cc1-e6c2-468d-b8b9-91b6d6ec273e"), new Guid("57beccf6-cf46-4794-a4b3-994b92204854"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5630), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5639), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("771bc8f2-0910-4f46-811f-fda6eaeed910"), new Guid("7c081849-3f31-4e4b-834a-8735e4f4b0a0"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5626), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5626), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8967647d-21e6-4b18-b795-290a472bccbe"), new Guid("a71b6433-7283-468a-8452-c54f4f129a8a"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5642), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5643), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("630e7cc1-e6c2-468d-b8b9-91b6d6ec273e"), new Guid("adf3c124-a370-47d7-a01c-2d0dddae785f"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5654), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5654), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("630e7cc1-e6c2-468d-b8b9-91b6d6ec273e"), new Guid("e38d3cd6-2bc1-400a-a003-15a93af2ab73"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5669), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5669), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("630e7cc1-e6c2-468d-b8b9-91b6d6ec273e"), new Guid("f268a997-1117-4405-ab1b-82cec5b316b7"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5649), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5650), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PointsEarned", "StatusForAppointment", "StylistId", "TotalAmount", "TotalTime", "UserId" },
                values: new object[,]
                {
                    { "56301dc4-a5c5-4379-860b-487bacca7e2c", new DateTime(2024, 10, 21, 1, 41, 44, 755, DateTimeKind.Utc).AddTicks(6024), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6025), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6025), new TimeSpan(0, 0, 0, 0, 0)), 20, "Completed", new Guid("383e62b3-f6c5-4dc4-940e-6f569b442b22"), 150000.00m, 90, new Guid("2cc273ad-7508-494b-9171-7b095c3e023c") },
                    { "7a40daaf-be47-4bb4-959a-97fd70ea5e9e", new DateTime(2024, 10, 20, 1, 41, 44, 755, DateTimeKind.Utc).AddTicks(6019), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6019), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6020), new TimeSpan(0, 0, 0, 0, 0)), 12, "Pending", new Guid("383e62b3-f6c5-4dc4-940e-6f569b442b22"), 200000.00m, 45, new Guid("f268a997-1117-4405-ab1b-82cec5b316b7") },
                    { "86e8cc1a-e1a4-4d9b-bde0-47a58a26a800", new DateTime(2024, 10, 19, 1, 41, 44, 755, DateTimeKind.Utc).AddTicks(6004), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6005), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6005), new TimeSpan(0, 0, 0, 0, 0)), 15, "Scheduled", new Guid("383e62b3-f6c5-4dc4-940e-6f569b442b22"), 65000.00m, 75, new Guid("a71b6433-7283-468a-8452-c54f4f129a8a") },
                    { "a11bb5d6-e21f-4182-845f-cf6540af9bd4", new DateTime(2024, 10, 18, 1, 41, 44, 755, DateTimeKind.Utc).AddTicks(5982), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(5999), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6000), new TimeSpan(0, 0, 0, 0, 0)), 10, "Pending", new Guid("57beccf6-cf46-4794-a4b3-994b92204854"), 100000.00m, 0, new Guid("7c081849-3f31-4e4b-834a-8735e4f4b0a0") }
                });

            migrationBuilder.InsertData(
                table: "ComboServices",
                columns: new[] { "Id", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[,]
                {
                    { "14ff5ccd0ccf4d328d6210a2d26e2bd1", "87863cb6-cfd7-43f0-a797-fac9b4d68644", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6223), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6224), new TimeSpan(0, 0, 0, 0, 0)), "9b2d0b8b-91b7-43bc-b470-c34d00f9ef9f" },
                    { "7257651abb534d6992921b8f7c70cd10", "87863cb6-cfd7-43f0-a797-fac9b4d68644", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6228), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6228), new TimeSpan(0, 0, 0, 0, 0)), "417c5df3-8bbc-4023-80bb-d31daeb32459" },
                    { "b5718ee030d94527b3b6c3116699092c", "0af98061-e76a-4a99-a4a0-9101c04f2f34", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6249), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6249), new TimeSpan(0, 0, 0, 0, 0)), "dd1a8eb0-bbe5-4a13-82aa-ba22a98801bd" },
                    { "d6630710d25842b6b3cd9a7e4fc22fd1", "dec6caba-784a-4e5e-8d32-d9ace416e254", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6245), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6245), new TimeSpan(0, 0, 0, 0, 0)), "6fba1826-3a2f-4afd-a88e-e355b9c7431b" },
                    { "e983dfa08b3e4ad8a48a98302403212e", "dec6caba-784a-4e5e-8d32-d9ace416e254", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6239), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6239), new TimeSpan(0, 0, 0, 0, 0)), "b0b8f7a2-93bf-4f71-be48-1d4913dcaee7" },
                    { "fd7cb3887d974a88969d1d331876cc8a", "0af98061-e76a-4a99-a4a0-9101c04f2f34", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6255), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6256), new TimeSpan(0, 0, 0, 0, 0)), "ea3aa935-51a1-4162-be1a-41d9415c3b2c" }
                });

            migrationBuilder.InsertData(
                table: "SalaryPayments",
                columns: new[] { "Id", "BaseSalary", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentDate", "UserId" },
                values: new object[] { "227c0763-5274-4508-aab8-891237d85db6", 2000.00m, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6134), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6134), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Utc).AddTicks(6133), new Guid("7c081849-3f31-4e4b-834a-8735e4f4b0a0") });

            migrationBuilder.InsertData(
                table: "ComboAppointment",
                columns: new[] { "Id", "AppointmentId", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { "0d5b01be-e9a3-4868-acc7-2535f7682db3", "7a40daaf-be47-4bb4-959a-97fd70ea5e9e", "0af98061-e76a-4a99-a4a0-9101c04f2f34", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6335), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6336), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "96e3d62b-248b-47e7-88df-05527a73bfa2", "86e8cc1a-e1a4-4d9b-bde0-47a58a26a800", "dec6caba-784a-4e5e-8d32-d9ace416e254", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6332), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6332), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "f891c631-4542-4942-b566-b07c218a1237", "a11bb5d6-e21f-4182-845f-cf6540af9bd4", "87863cb6-cfd7-43f0-a797-fac9b4d68644", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6328), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6328), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ServiceAppointments",
                columns: new[] { "Id", "AppointmentId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[] { "ce50000a-202d-45e6-9cb2-20cf01c19154", "a11bb5d6-e21f-4182-845f-cf6540af9bd4", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6101), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Basic haircut", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 1, 41, 44, 755, DateTimeKind.Unspecified).AddTicks(6102), new TimeSpan(0, 0, 0, 0, 0)), "9b2d0b8b-91b7-43bc-b470-c34d00f9ef9f" });

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
