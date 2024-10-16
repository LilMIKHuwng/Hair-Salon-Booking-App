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
                    { new Guid("183728de-b298-4cb7-bd62-890b17b46200"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 227, DateTimeKind.Unspecified).AddTicks(5161), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 227, DateTimeKind.Unspecified).AddTicks(5161), new TimeSpan(0, 0, 0, 0, 0)), "Manager", "MANAGER" },
                    { new Guid("778a11e2-1f0f-44ee-bc59-8bfd02034b93"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 227, DateTimeKind.Unspecified).AddTicks(5163), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 227, DateTimeKind.Unspecified).AddTicks(5164), new TimeSpan(0, 0, 0, 0, 0)), "Stylist", "STYLIST" },
                    { new Guid("c9658de0-ff16-4906-83cd-10a1fd51e8cf"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 227, DateTimeKind.Unspecified).AddTicks(5166), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 227, DateTimeKind.Unspecified).AddTicks(5166), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" },
                    { new Guid("e2a026fb-6890-429c-a011-ac2162cfffce"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 227, DateTimeKind.Unspecified).AddTicks(5157), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 227, DateTimeKind.Unspecified).AddTicks(5157), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "TimeCombo", "TotalPrice" },
                values: new object[,]
                {
                    { "7847d59d-fe8a-4c24-b4fe-2d8d4ec7aaf9", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(396), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(397), new TimeSpan(0, 0, 0, 0, 0)), "Ultimate Hair & Beard Combo", 150, 120000.00m },
                    { "e2e1d301-a01a-4d64-a623-4a4072766dc9", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(390), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(391), new TimeSpan(0, 0, 0, 0, 0)), "Deluxe Hair Combo", 120, 80000.00m },
                    { "e7b0b40a-1635-4e45-9bf9-81741d67da50", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(383), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(384), new TimeSpan(0, 0, 0, 0, 0)), "Basic Hair Combo", 60, 40000.00m }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "OpenTime", "ShopEmail", "ShopPhone", "Title" },
                values: new object[] { "d240fa7f-b5fc-4c3a-9c99-1510652d421b", "123 Main St, Cityville", new TimeSpan(0, 19, 0, 0, 0), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9276), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9276), new TimeSpan(0, 0, 0, 0, 0)), "Salon A", new TimeSpan(0, 9, 0, 0, 0), "contact@salona.com", "123-456-7890", "Best Hair Salon in Town" });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Bank", "BankAccount", "BankAccountName", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Firstname", "LastUpdatedBy", "LastUpdatedTime", "Lastname", "Point" },
                values: new object[,]
                {
                    { "04c9b811-e327-46b2-9bc8-80385b7f3f9c", "Bank c", "123456798", "Dev Nguyen", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 227, DateTimeKind.Unspecified).AddTicks(5387), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dev", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 227, DateTimeKind.Unspecified).AddTicks(5388), new TimeSpan(0, 0, 0, 0, 0)), "Nguyen", 0 },
                    { "14204963-91f4-427d-b1fd-37aa696e591d", "Bank A", "123456789", "John Doe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 227, DateTimeKind.Unspecified).AddTicks(5377), new TimeSpan(0, 0, 0, 0, 0)), null, null, "John", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 227, DateTimeKind.Unspecified).AddTicks(5378), new TimeSpan(0, 0, 0, 0, 0)), "Doe", 100 },
                    { "b2863d28-7360-4cb9-b24a-d67df5791c87", "Bank D", "123456987", "Dan Tran", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 227, DateTimeKind.Unspecified).AddTicks(5392), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dan", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 227, DateTimeKind.Unspecified).AddTicks(5392), new TimeSpan(0, 0, 0, 0, 0)), "Tran", 0 },
                    { "f58ebf5c-27a8-42bb-9c42-c933885d7189", "Bank B", "987654321", "Jane Smith", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 227, DateTimeKind.Unspecified).AddTicks(5383), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jane", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 227, DateTimeKind.Unspecified).AddTicks(5383), new TimeSpan(0, 0, 0, 0, 0)), "Smith", 150 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Email", "EmailConfirmed", "LastUpdatedBy", "LastUpdatedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OtpCode", "OtpCodeResetPassword", "OtpExpiration", "OtpExpirationResetPassword", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserInfoId", "UserName" },
                values: new object[,]
                {
                    { new Guid("2151db33-e504-46d6-8012-065a63a49c8d"), 0, "1e55993d-5343-44ea-98e9-f0f3d425e9fd", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(7898), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user5@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(7899), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEGDF76C4XlLUwtPAezxS5BwXlbOh598oQYSYDyVfyhaIJNPNlgGIeHVlG6oNOKhEIw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "b2863d28-7360-4cb9-b24a-d67df5791c87", "user5" },
                    { new Guid("27697596-1618-4ca0-bc94-f1a34dbe0405"), 0, "31ccd307-33ab-4048-a6eb-98209d6cf555", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(7819), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user4@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(7820), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAELydZuq+3atHVmXoq3D84zIX/vAcwXu6r8AHf+o+i+li+volvqS++sz/ZNqb00tKAA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "04c9b811-e327-46b2-9bc8-80385b7f3f9c", "user4" },
                    { new Guid("380774d8-6f64-4d1f-b843-057b0921523c"), 0, "9fbcfd36-a378-4ee9-ab8c-298979480873", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(7785), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user3@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(7786), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER3@EXAMPLE.COM", "USER3@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEOHpLH3Ix1yQ81l+FgExTrHOnTFnPniL7JItkTH1uxTwFk8JwMEYexVoxJEWCVFg/g==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "f58ebf5c-27a8-42bb-9c42-c933885d7189", "user3" },
                    { new Guid("66728a2a-9cc7-4980-9698-89b50c035065"), 0, "7aaa30df-23ba-480d-acb3-6e28bfa11b36", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(7697), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(7697), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEPyIfl29gXxNBq7rIV6NVEZPiG7yHcM0LnBOLF9NOVTiAJPZjkP3tNSD/fAIsNKxkA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "f58ebf5c-27a8-42bb-9c42-c933885d7189", "user" },
                    { new Guid("848a4122-8cfc-4306-af6d-e7017795c0ff"), 0, "c83247de-8302-4000-9936-8d3311f21deb", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(7720), new TimeSpan(0, 0, 0, 0, 0)), null, null, "manager@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(7722), new TimeSpan(0, 0, 0, 0, 0)), false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEAZuLLKbHnPLrFIAb4oF5XYaCdRGNDIoX3Zn2aZ/CZ5rCniTkMSWP7JoPvEh74w5ag==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "04c9b811-e327-46b2-9bc8-80385b7f3f9c", "manager" },
                    { new Guid("cbd9e9ed-b24a-46e6-9040-c253c5f808a4"), 0, "fd30031c-bb07-4e28-bb30-e9eff7f8c250", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(7750), new TimeSpan(0, 0, 0, 0, 0)), null, null, "stylist@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(7751), new TimeSpan(0, 0, 0, 0, 0)), false, null, "STYLIST@EXAMPLE.COM", "STYLIST@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEI1UVsVfT3v3uY7PojjvbGUx/ZLwBEeJ1p9IB3fDrt+fjsny1ndjyNb72bAJ6Brv6A==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "b2863d28-7360-4cb9-b24a-d67df5791c87", "stylist" },
                    { new Guid("cdb44c4e-21a5-4246-9146-c32c37e2ed5d"), 0, "c5701fbc-7f49-43d6-a2cb-23b5e66a5210", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(7763), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user2@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(7779), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEBm4YHIwNO87RXtCuRppNkwbhQHvUG4GUr9AgcoNgbuRGl78WTVa8zbDMKc0nREMwQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "14204963-91f4-427d-b1fd-37aa696e591d", "user2" },
                    { new Guid("dabddf9a-1186-41f4-94d1-93a113eacbd3"), 0, "90e2589e-2287-4525-9c7d-ad271e6556a8", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(7589), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(7598), new TimeSpan(0, 0, 0, 0, 0)), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEHNroBT1VKS5067dL5FXbwy58kfZB/CHNLTDII8aCC079VJOM9NZvZGhgSwQnpHjbQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "14204963-91f4-427d-b1fd-37aa696e591d", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Name", "Price", "ShopId", "TimeService", "Type" },
                values: new object[,]
                {
                    { "48a823e6-95b8-488c-bb48-b6cf92bce6d6", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9463), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A neat beard trimming service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9464), new TimeSpan(0, 0, 0, 0, 0)), "Beard Trim", 15000.00m, "d240fa7f-b5fc-4c3a-9c99-1510652d421b", 20, "Beard" },
                    { "7bfe688a-7ec3-4067-abd3-0b22d45c657f", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9434), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A stylish haircut to refresh your look.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9435), new TimeSpan(0, 0, 0, 0, 0)), "Hair Cut", 25000.00m, "d240fa7f-b5fc-4c3a-9c99-1510652d421b", 30, "Hair" },
                    { "9a6d5081-86f9-4965-acbe-d5ba1d06918e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9473), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A clean and smooth shaving service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9478), new TimeSpan(0, 0, 0, 0, 0)), "Shave", 12000.00m, "d240fa7f-b5fc-4c3a-9c99-1510652d421b", 15, "Beard" },
                    { "9f580a35-95ee-42c9-b3e3-e639d6aa3507", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9442), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A complete hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9443), new TimeSpan(0, 0, 0, 0, 0)), "Hair Coloring", 50000.00m, "d240fa7f-b5fc-4c3a-9c99-1510652d421b", 30, "Hair" },
                    { "a195e95b-e66a-4fe1-ae75-8ce380c48336", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9450), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A premium hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9450), new TimeSpan(0, 0, 0, 0, 0)), "Premium Hair Coloring", 100000.00m, "d240fa7f-b5fc-4c3a-9c99-1510652d421b", 60, "Hair" },
                    { "b7fd7d74-e5e6-4df9-8137-6e69e00a13a9", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9484), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A rejuvenating facial service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9485), new TimeSpan(0, 0, 0, 0, 0)), "Facial", 40000.00m, "d240fa7f-b5fc-4c3a-9c99-1510652d421b", 50, "Skin" },
                    { "bfee6a60-31f8-49cc-96d8-547a5fdd51fe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9456), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A professional hair styling service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9457), new TimeSpan(0, 0, 0, 0, 0)), "Hair Styling", 20000.00m, "d240fa7f-b5fc-4c3a-9c99-1510652d421b", 45, "Hair" },
                    { "f9c2cef5-4fd6-4475-a86d-6d61851259a6", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9490), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A soothing scalp treatment.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9491), new TimeSpan(0, 0, 0, 0, 0)), "Scalp Treatment", 45000.00m, "d240fa7f-b5fc-4c3a-9c99-1510652d421b", 40, "Hair" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { new Guid("c9658de0-ff16-4906-83cd-10a1fd51e8cf"), new Guid("2151db33-e504-46d6-8012-065a63a49c8d"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9096), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9097), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c9658de0-ff16-4906-83cd-10a1fd51e8cf"), new Guid("27697596-1618-4ca0-bc94-f1a34dbe0405"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9080), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9092), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c9658de0-ff16-4906-83cd-10a1fd51e8cf"), new Guid("380774d8-6f64-4d1f-b843-057b0921523c"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9076), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9076), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c9658de0-ff16-4906-83cd-10a1fd51e8cf"), new Guid("66728a2a-9cc7-4980-9698-89b50c035065"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9037), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9056), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("183728de-b298-4cb7-bd62-890b17b46200"), new Guid("848a4122-8cfc-4306-af6d-e7017795c0ff"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9061), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9063), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("778a11e2-1f0f-44ee-bc59-8bfd02034b93"), new Guid("cbd9e9ed-b24a-46e6-9040-c253c5f808a4"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9066), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9066), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c9658de0-ff16-4906-83cd-10a1fd51e8cf"), new Guid("cdb44c4e-21a5-4246-9146-c32c37e2ed5d"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9071), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9071), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e2a026fb-6890-429c-a011-ac2162cfffce"), new Guid("dabddf9a-1186-41f4-94d1-93a113eacbd3"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9030), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9030), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PointsEarned", "StatusForAppointment", "StylistId", "TotalAmount", "TotalTime", "UserId" },
                values: new object[,]
                {
                    { "6671723d-ed04-4b0a-ae04-4aad1497f343", new DateTime(2024, 10, 18, 8, 11, 1, 783, DateTimeKind.Utc).AddTicks(9793), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9795), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9796), new TimeSpan(0, 0, 0, 0, 0)), 15, "Scheduled", new Guid("cbd9e9ed-b24a-46e6-9040-c253c5f808a4"), 0m, 75, new Guid("848a4122-8cfc-4306-af6d-e7017795c0ff") },
                    { "82f59c63-0f16-44bf-96e0-b58d54e92e95", new DateTime(2024, 10, 19, 8, 11, 1, 783, DateTimeKind.Utc).AddTicks(9827), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9828), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9829), new TimeSpan(0, 0, 0, 0, 0)), 12, "Pending", new Guid("cbd9e9ed-b24a-46e6-9040-c253c5f808a4"), 0m, 45, new Guid("cdb44c4e-21a5-4246-9146-c32c37e2ed5d") },
                    { "93397df6-4788-4df4-99da-6a84b0ed660c", new DateTime(2024, 10, 20, 8, 11, 1, 783, DateTimeKind.Utc).AddTicks(9835), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9836), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9837), new TimeSpan(0, 0, 0, 0, 0)), 20, "Completed", new Guid("cbd9e9ed-b24a-46e6-9040-c253c5f808a4"), 0m, 90, new Guid("27697596-1618-4ca0-bc94-f1a34dbe0405") },
                    { "9c495fc6-fa89-43d1-bdec-40bef9b79057", new DateTime(2024, 10, 17, 8, 11, 1, 783, DateTimeKind.Utc).AddTicks(9758), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9781), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 783, DateTimeKind.Unspecified).AddTicks(9782), new TimeSpan(0, 0, 0, 0, 0)), 10, "Pending", new Guid("66728a2a-9cc7-4980-9698-89b50c035065"), 0m, 0, new Guid("dabddf9a-1186-41f4-94d1-93a113eacbd3") }
                });

            migrationBuilder.InsertData(
                table: "ComboServices",
                columns: new[] { "Id", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[,]
                {
                    { "03d0f1a5d8314ce8a439683963a1c5a1", "e2e1d301-a01a-4d64-a623-4a4072766dc9", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(506), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(507), new TimeSpan(0, 0, 0, 0, 0)), "a195e95b-e66a-4fe1-ae75-8ce380c48336" },
                    { "14da5894c96a4215940bf202b269912c", "7847d59d-fe8a-4c24-b4fe-2d8d4ec7aaf9", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(525), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(526), new TimeSpan(0, 0, 0, 0, 0)), "48a823e6-95b8-488c-bb48-b6cf92bce6d6" },
                    { "286f7243101a4ee4a9902452a5af35be", "e2e1d301-a01a-4d64-a623-4a4072766dc9", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(516), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(517), new TimeSpan(0, 0, 0, 0, 0)), "bfee6a60-31f8-49cc-96d8-547a5fdd51fe" },
                    { "69ec5ded3a8d4d40a254184d4596af76", "7847d59d-fe8a-4c24-b4fe-2d8d4ec7aaf9", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(568), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(568), new TimeSpan(0, 0, 0, 0, 0)), "9a6d5081-86f9-4965-acbe-d5ba1d06918e" },
                    { "faa351fd28f24fd995d50e9453245ea9", "e7b0b40a-1635-4e45-9bf9-81741d67da50", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(486), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(487), new TimeSpan(0, 0, 0, 0, 0)), "7bfe688a-7ec3-4067-abd3-0b22d45c657f" },
                    { "feade285809f47c387928bfc602aeed5", "e7b0b40a-1635-4e45-9bf9-81741d67da50", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(496), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(497), new TimeSpan(0, 0, 0, 0, 0)), "9f580a35-95ee-42c9-b3e3-e639d6aa3507" }
                });

            migrationBuilder.InsertData(
                table: "SalaryPayments",
                columns: new[] { "Id", "BaseSalary", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentDate", "UserId" },
                values: new object[] { "65985045-e832-4fda-850d-6fbca638ad12", 2000.00m, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(284), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(285), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Utc).AddTicks(283), new Guid("dabddf9a-1186-41f4-94d1-93a113eacbd3") });

            migrationBuilder.InsertData(
                table: "ComboAppointment",
                columns: new[] { "Id", "AppointmentId", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { "1c56f3ef-9246-4a73-8131-97302f4f21c3", "6671723d-ed04-4b0a-ae04-4aad1497f343", "e2e1d301-a01a-4d64-a623-4a4072766dc9", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(881), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(881), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "a3a71d35-82c6-4835-aac4-6ef3de53196d", "9c495fc6-fa89-43d1-bdec-40bef9b79057", "e7b0b40a-1635-4e45-9bf9-81741d67da50", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(875), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(875), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "ade6ebe3-4227-4d31-a962-18f396dbb7d7", "82f59c63-0f16-44bf-96e0-b58d54e92e95", "7847d59d-fe8a-4c24-b4fe-2d8d4ec7aaf9", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(887), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(889), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ServiceAppointments",
                columns: new[] { "Id", "AppointmentId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[] { "851d71a4-af8c-4fb2-9ff6-019ac5fc52ec", "9c495fc6-fa89-43d1-bdec-40bef9b79057", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(126), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Basic haircut", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 16, 8, 11, 1, 784, DateTimeKind.Unspecified).AddTicks(127), new TimeSpan(0, 0, 0, 0, 0)), "7bfe688a-7ec3-4067-abd3-0b22d45c657f" });

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
