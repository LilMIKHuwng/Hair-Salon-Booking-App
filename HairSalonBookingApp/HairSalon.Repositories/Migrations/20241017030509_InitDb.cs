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
                    { new Guid("9bcc4473-dff4-4358-81ea-39404a960479"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 398, DateTimeKind.Unspecified).AddTicks(368), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 398, DateTimeKind.Unspecified).AddTicks(368), new TimeSpan(0, 0, 0, 0, 0)), "Manager", "MANAGER" },
                    { new Guid("b9069ec4-6430-49ec-be73-b797ecf1b4b7"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 398, DateTimeKind.Unspecified).AddTicks(371), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 398, DateTimeKind.Unspecified).AddTicks(371), new TimeSpan(0, 0, 0, 0, 0)), "Stylist", "STYLIST" },
                    { new Guid("ba0cd0ed-6630-43c6-a487-4f6501ad5a60"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 398, DateTimeKind.Unspecified).AddTicks(374), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 398, DateTimeKind.Unspecified).AddTicks(374), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" },
                    { new Guid("ec924079-aa3f-47e6-a901-a9eaf1c3fa93"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 398, DateTimeKind.Unspecified).AddTicks(364), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 398, DateTimeKind.Unspecified).AddTicks(364), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "TimeCombo", "TotalPrice" },
                values: new object[,]
                {
                    { "4c2aaf27-b1cf-45bc-b77f-0fa3a5a1f5ad", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2903), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2903), new TimeSpan(0, 0, 0, 0, 0)), "Deluxe Hair Combo", 120, 80000.00m },
                    { "64482758-f76f-4385-ad2c-92e66fa80350", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2906), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2906), new TimeSpan(0, 0, 0, 0, 0)), "Ultimate Hair & Beard Combo", 150, 120000.00m },
                    { "698dd9be-d4eb-4c02-8e7a-6013ff9a975c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2899), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 0, 0, 0, 0)), "Basic Hair Combo", 60, 40000.00m }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "OpenTime", "ShopEmail", "ShopPhone", "Title" },
                values: new object[] { "921e4e11-cbd3-4639-a856-e7bb0a18ac78", "123 Main St, Cityville", new TimeSpan(0, 19, 0, 0, 0), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2489), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2489), new TimeSpan(0, 0, 0, 0, 0)), "Salon A", new TimeSpan(0, 9, 0, 0, 0), "contact@salona.com", "123-456-7890", "Best Hair Salon in Town" });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Bank", "BankAccount", "BankAccountName", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Firstname", "LastUpdatedBy", "LastUpdatedTime", "Lastname", "Point" },
                values: new object[,]
                {
                    { "2d84948e-320e-41ff-a824-54e254c4e330", "Bank A", "123456789", "John Doe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 398, DateTimeKind.Unspecified).AddTicks(561), new TimeSpan(0, 0, 0, 0, 0)), null, null, "John", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 398, DateTimeKind.Unspecified).AddTicks(562), new TimeSpan(0, 0, 0, 0, 0)), "Doe", 100 },
                    { "42c5adb7-37c9-4b6f-9e19-0d1942455998", "Bank B", "987654321", "Jane Smith", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 398, DateTimeKind.Unspecified).AddTicks(566), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jane", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 398, DateTimeKind.Unspecified).AddTicks(566), new TimeSpan(0, 0, 0, 0, 0)), "Smith", 150 },
                    { "543e207a-b6a0-4767-916b-a2da90a96ee6", "Bank c", "123456798", "Dev Nguyen", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 398, DateTimeKind.Unspecified).AddTicks(569), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dev", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 398, DateTimeKind.Unspecified).AddTicks(570), new TimeSpan(0, 0, 0, 0, 0)), "Nguyen", 0 },
                    { "87dbe142-21dc-4e38-b666-8a2d56df47b5", "Bank D", "123456987", "Dan Tran", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 398, DateTimeKind.Unspecified).AddTicks(576), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dan", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 398, DateTimeKind.Unspecified).AddTicks(576), new TimeSpan(0, 0, 0, 0, 0)), "Tran", 0 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Email", "EmailConfirmed", "LastUpdatedBy", "LastUpdatedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OtpCode", "OtpCodeResetPassword", "OtpExpiration", "OtpExpirationResetPassword", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserInfoId", "UserName" },
                values: new object[,]
                {
                    { new Guid("035648b1-86e7-48d7-bef0-2dabe80cf43a"), 0, "67653d94-a355-4ea2-a2b9-31e34d558047", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(1964), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user5@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(1964), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEE7X9zLZ5uvz/2Xr/V30Ecn2tfmiTvYfGc1qpaEFhdjk+Tx3rYWeKpu/APgD9aylSw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "87dbe142-21dc-4e38-b666-8a2d56df47b5", "user5" },
                    { new Guid("2347f3e0-dfb0-4af2-b544-b1f8bdfa3a36"), 0, "827c7c7a-92c7-46b6-a4f1-34888f92af26", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(1938), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user4@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(1938), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEM4lSje+dKkANbxQaUpdsS8SqPzBt4RBX0zIc4UmCDDo9DnIuGi+AMrWWLD7qpdQRQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "543e207a-b6a0-4767-916b-a2da90a96ee6", "user4" },
                    { new Guid("2f137226-6ff8-45fb-915e-a31f222911eb"), 0, "9c163226-b5c7-4c90-ab99-f8fe8f778eaf", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(1926), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user2@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(1926), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEHA5Ea3by+zlWD4dUJ/pQOyDvKaUONDal413i3oM98P27scPoYvj07WbCOhAv28obw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "2d84948e-320e-41ff-a824-54e254c4e330", "user2" },
                    { new Guid("3484c78a-952a-4599-8d86-a0fecc2b3fc4"), 0, "53d42b2f-1d3a-45ca-9f17-334f80d4bde5", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(1921), new TimeSpan(0, 0, 0, 0, 0)), null, null, "stylist@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(1921), new TimeSpan(0, 0, 0, 0, 0)), false, null, "STYLIST@EXAMPLE.COM", "STYLIST@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEPfb3zGpai1dYKgyxflEz0z9SrFPGjqcbKYerjsDHqJ/tM7WNvCUHclp9bpUilTucA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "87dbe142-21dc-4e38-b666-8a2d56df47b5", "stylist" },
                    { new Guid("600fd090-08a0-483f-a84c-894b31406b92"), 0, "b3c74717-2eef-4b02-b7a5-32e2192f7769", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(1916), new TimeSpan(0, 0, 0, 0, 0)), null, null, "manager@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(1916), new TimeSpan(0, 0, 0, 0, 0)), false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAELGgtfX3g4Lc4/jDshc9+YOrXV+FWg5BFMC9wSdxrRZyCpuW0WzyIiABsATkY+D1bg==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "543e207a-b6a0-4767-916b-a2da90a96ee6", "manager" },
                    { new Guid("b1cf643a-508a-4361-b81d-455671651601"), 0, "7a727a55-75d0-4bf7-a706-5ccb3df89510", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(1903), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(1904), new TimeSpan(0, 0, 0, 0, 0)), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEOK4OxD9XmagjV/D56b2gRt+ppWJBinWZXH1Keom/MmnU7pftY6RF36yhgow+/yJXw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "2d84948e-320e-41ff-a824-54e254c4e330", "admin" },
                    { new Guid("b499912d-e3fe-4436-a365-dc4ce5bcd326"), 0, "a97e8d81-8356-4ced-9820-0418dfadb0ea", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(1911), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(1912), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEIFmrEvDf3rXK7HXH6zVS3XbflbKDB5E4642NXcceRtuamIy220HnlOVziAB/lF2zA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "42c5adb7-37c9-4b6f-9e19-0d1942455998", "user" },
                    { new Guid("ca640313-1435-4707-bbfe-814dec8aba72"), 0, "df9ddd33-a605-403e-8fb1-e3da40146388", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(1934), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user3@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(1934), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER3@EXAMPLE.COM", "USER3@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAECuA33ilrze6P/81VGmUHXPWncPpzs8R8dRXBAYBIYmEvoK+XF7oPyhw6Tp/PqimMw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "42c5adb7-37c9-4b6f-9e19-0d1942455998", "user3" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Name", "Price", "ShopId", "TimeService", "Type" },
                values: new object[,]
                {
                    { "110355f4-86b3-4086-90bc-ec4020c2ece1", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2566), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A stylish haircut to refresh your look.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2566), new TimeSpan(0, 0, 0, 0, 0)), "Hair Cut", 25000.00m, "921e4e11-cbd3-4639-a856-e7bb0a18ac78", 30, "Hair" },
                    { "2a7d2b59-45de-4274-a9b8-612e263ccbdf", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2574), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A premium hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2574), new TimeSpan(0, 0, 0, 0, 0)), "Premium Hair Coloring", 100000.00m, "921e4e11-cbd3-4639-a856-e7bb0a18ac78", 60, "Hair" },
                    { "4c359962-acdf-4693-bb50-eaa48811e41a", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2587), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A clean and smooth shaving service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2588), new TimeSpan(0, 0, 0, 0, 0)), "Shave", 12000.00m, "921e4e11-cbd3-4639-a856-e7bb0a18ac78", 15, "Beard" },
                    { "5121ecd7-4451-484d-9923-bcf831785de9", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2578), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A professional hair styling service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2578), new TimeSpan(0, 0, 0, 0, 0)), "Hair Styling", 20000.00m, "921e4e11-cbd3-4639-a856-e7bb0a18ac78", 45, "Hair" },
                    { "c407d07c-0be0-48b1-99d7-b2b3c8029cb4", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2591), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A rejuvenating facial service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2591), new TimeSpan(0, 0, 0, 0, 0)), "Facial", 40000.00m, "921e4e11-cbd3-4639-a856-e7bb0a18ac78", 50, "Skin" },
                    { "d5aeda35-b292-4093-ae75-28971aa907e8", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2582), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A neat beard trimming service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2582), new TimeSpan(0, 0, 0, 0, 0)), "Beard Trim", 15000.00m, "921e4e11-cbd3-4639-a856-e7bb0a18ac78", 20, "Beard" },
                    { "eef6d2df-b79c-44ed-983c-5ec961872023", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2596), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A soothing scalp treatment.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2596), new TimeSpan(0, 0, 0, 0, 0)), "Scalp Treatment", 45000.00m, "921e4e11-cbd3-4639-a856-e7bb0a18ac78", 40, "Hair" },
                    { "fd4352b8-cb72-4d05-b692-8bdbee21fff9", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2570), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A complete hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2570), new TimeSpan(0, 0, 0, 0, 0)), "Hair Coloring", 50000.00m, "921e4e11-cbd3-4639-a856-e7bb0a18ac78", 30, "Hair" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { new Guid("ba0cd0ed-6630-43c6-a487-4f6501ad5a60"), new Guid("035648b1-86e7-48d7-bef0-2dabe80cf43a"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2380), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2380), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ba0cd0ed-6630-43c6-a487-4f6501ad5a60"), new Guid("2347f3e0-dfb0-4af2-b544-b1f8bdfa3a36"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2363), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2377), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ba0cd0ed-6630-43c6-a487-4f6501ad5a60"), new Guid("2f137226-6ff8-45fb-915e-a31f222911eb"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2356), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2356), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b9069ec4-6430-49ec-be73-b797ecf1b4b7"), new Guid("3484c78a-952a-4599-8d86-a0fecc2b3fc4"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2353), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2354), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9bcc4473-dff4-4358-81ea-39404a960479"), new Guid("600fd090-08a0-483f-a84c-894b31406b92"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2350), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2350), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ec924079-aa3f-47e6-a901-a9eaf1c3fa93"), new Guid("b1cf643a-508a-4361-b81d-455671651601"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2274), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2275), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ba0cd0ed-6630-43c6-a487-4f6501ad5a60"), new Guid("b499912d-e3fe-4436-a365-dc4ce5bcd326"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2278), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2346), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ba0cd0ed-6630-43c6-a487-4f6501ad5a60"), new Guid("ca640313-1435-4707-bbfe-814dec8aba72"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2359), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2360), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PointsEarned", "StatusForAppointment", "StylistId", "TotalAmount", "TotalTime", "UserId" },
                values: new object[,]
                {
                    { "5523b91d-7489-4a78-8176-7ac53ac39dfe", new DateTime(2024, 10, 19, 3, 5, 8, 934, DateTimeKind.Utc).AddTicks(2683), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2684), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2685), new TimeSpan(0, 0, 0, 0, 0)), 15, "Scheduled", new Guid("3484c78a-952a-4599-8d86-a0fecc2b3fc4"), 65000.00m, 75, new Guid("600fd090-08a0-483f-a84c-894b31406b92") },
                    { "5abcd520-a721-4339-88d0-16a2312a74bb", new DateTime(2024, 10, 18, 3, 5, 8, 934, DateTimeKind.Utc).AddTicks(2667), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2677), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2678), new TimeSpan(0, 0, 0, 0, 0)), 10, "Pending", new Guid("b499912d-e3fe-4436-a365-dc4ce5bcd326"), 100000.00m, 0, new Guid("b1cf643a-508a-4361-b81d-455671651601") },
                    { "93c1c498-e1bf-40ba-9f14-393e4dcc3acd", new DateTime(2024, 10, 21, 3, 5, 8, 934, DateTimeKind.Utc).AddTicks(2699), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2699), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2700), new TimeSpan(0, 0, 0, 0, 0)), 20, "Completed", new Guid("3484c78a-952a-4599-8d86-a0fecc2b3fc4"), 150000.00m, 90, new Guid("2347f3e0-dfb0-4af2-b544-b1f8bdfa3a36") },
                    { "e62e515d-38ed-4314-8118-1184bd0bd6a6", new DateTime(2024, 10, 20, 3, 5, 8, 934, DateTimeKind.Utc).AddTicks(2694), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2695), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2695), new TimeSpan(0, 0, 0, 0, 0)), 12, "Pending", new Guid("3484c78a-952a-4599-8d86-a0fecc2b3fc4"), 200000.00m, 45, new Guid("2f137226-6ff8-45fb-915e-a31f222911eb") }
                });

            migrationBuilder.InsertData(
                table: "ComboServices",
                columns: new[] { "Id", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[,]
                {
                    { "037db33d125644cd932dc7fb8b12602c", "4c2aaf27-b1cf-45bc-b77f-0fa3a5a1f5ad", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2952), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2952), new TimeSpan(0, 0, 0, 0, 0)), "5121ecd7-4451-484d-9923-bcf831785de9" },
                    { "0c696358ca6b4d72b3c9a03db89559ca", "64482758-f76f-4385-ad2c-92e66fa80350", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2955), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2956), new TimeSpan(0, 0, 0, 0, 0)), "d5aeda35-b292-4093-ae75-28971aa907e8" },
                    { "4fe2deb28d7e4b208630b6b41a321fe8", "4c2aaf27-b1cf-45bc-b77f-0fa3a5a1f5ad", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2948), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2948), new TimeSpan(0, 0, 0, 0, 0)), "2a7d2b59-45de-4274-a9b8-612e263ccbdf" },
                    { "55ffe9d6b8fc46439215de75ca92ed55", "64482758-f76f-4385-ad2c-92e66fa80350", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2963), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2964), new TimeSpan(0, 0, 0, 0, 0)), "4c359962-acdf-4693-bb50-eaa48811e41a" },
                    { "99f5cf9024f54ee282ade70d03632da9", "698dd9be-d4eb-4c02-8e7a-6013ff9a975c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2944), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2944), new TimeSpan(0, 0, 0, 0, 0)), "fd4352b8-cb72-4d05-b692-8bdbee21fff9" },
                    { "be91193aa2f842209f155b0d35a64a82", "698dd9be-d4eb-4c02-8e7a-6013ff9a975c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2938), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2938), new TimeSpan(0, 0, 0, 0, 0)), "110355f4-86b3-4086-90bc-ec4020c2ece1" }
                });

            migrationBuilder.InsertData(
                table: "SalaryPayments",
                columns: new[] { "Id", "BaseSalary", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentDate", "UserId" },
                values: new object[] { "06b9bb87-d2ed-4bcf-b8fe-9a1ba8f6e162", 2000.00m, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2843), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2843), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Utc).AddTicks(2842), new Guid("b1cf643a-508a-4361-b81d-455671651601") });

            migrationBuilder.InsertData(
                table: "ComboAppointment",
                columns: new[] { "Id", "AppointmentId", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { "0dcdd0de-9404-421c-92bd-13eeca0843a5", "5abcd520-a721-4339-88d0-16a2312a74bb", "698dd9be-d4eb-4c02-8e7a-6013ff9a975c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(3020), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(3020), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "680c1288-fa2b-4818-afe3-659cac525207", "5523b91d-7489-4a78-8176-7ac53ac39dfe", "4c2aaf27-b1cf-45bc-b77f-0fa3a5a1f5ad", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(3023), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(3024), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "9081ae39-485c-4f37-a929-4ba176526b25", "e62e515d-38ed-4314-8118-1184bd0bd6a6", "64482758-f76f-4385-ad2c-92e66fa80350", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(3026), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(3026), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ServiceAppointments",
                columns: new[] { "Id", "AppointmentId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[] { "7e24c2e1-8715-4f56-9901-8c33c3f33f68", "5abcd520-a721-4339-88d0-16a2312a74bb", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2776), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Basic haircut", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 3, 5, 8, 934, DateTimeKind.Unspecified).AddTicks(2777), new TimeSpan(0, 0, 0, 0, 0)), "110355f4-86b3-4086-90bc-ec4020c2ece1" });

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
