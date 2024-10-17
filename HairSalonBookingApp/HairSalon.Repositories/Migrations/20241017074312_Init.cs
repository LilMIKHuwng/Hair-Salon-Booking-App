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
                    { new Guid("0fe13ead-b74e-4e66-ad14-7a7be8610cca"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 10, 657, DateTimeKind.Unspecified).AddTicks(4200), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 10, 657, DateTimeKind.Unspecified).AddTicks(4200), new TimeSpan(0, 0, 0, 0, 0)), "Manager", "MANAGER" },
                    { new Guid("679c4c1c-2043-40e5-97e8-8f8f4cef10f2"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 10, 657, DateTimeKind.Unspecified).AddTicks(4206), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 10, 657, DateTimeKind.Unspecified).AddTicks(4206), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" },
                    { new Guid("cc4583a4-bbc7-48bc-9a5c-d7754987697f"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 10, 657, DateTimeKind.Unspecified).AddTicks(4203), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 10, 657, DateTimeKind.Unspecified).AddTicks(4203), new TimeSpan(0, 0, 0, 0, 0)), "Stylist", "STYLIST" },
                    { new Guid("ef76ea1f-d468-4a3d-84e0-dba8c6db112a"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 10, 657, DateTimeKind.Unspecified).AddTicks(4196), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 10, 657, DateTimeKind.Unspecified).AddTicks(4196), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "TimeCombo", "TotalPrice" },
                values: new object[,]
                {
                    { "1b91ec9a-873c-4480-b3c6-34f63c185dc6", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8676), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8676), new TimeSpan(0, 0, 0, 0, 0)), "Ultimate Hair & Beard Combo", 150, 120000.00m },
                    { "a4fb118b-2cde-446c-9644-ceab9a753ebe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8672), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8672), new TimeSpan(0, 0, 0, 0, 0)), "Deluxe Hair Combo", 120, 80000.00m },
                    { "defb9dba-9a40-46d8-8c67-f2b74930c18a", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8667), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8668), new TimeSpan(0, 0, 0, 0, 0)), "Basic Hair Combo", 60, 40000.00m }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "OpenTime", "ShopEmail", "ShopPhone", "Title" },
                values: new object[] { "775feb1b-1250-44ed-b743-038796a9c0f1", "123 Main St, Cityville", new TimeSpan(0, 19, 0, 0, 0), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8234), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8234), new TimeSpan(0, 0, 0, 0, 0)), "Salon A", new TimeSpan(0, 9, 0, 0, 0), "contact@salona.com", "123-456-7890", "Best Hair Salon in Town" });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Bank", "BankAccount", "BankAccountName", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Firstname", "LastUpdatedBy", "LastUpdatedTime", "Lastname", "Point" },
                values: new object[,]
                {
                    { "5f94a718-7506-499d-b0dd-3b7ecc7b62e3", "Bank B", "987654321", "Jane Smith", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 10, 657, DateTimeKind.Unspecified).AddTicks(4439), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jane", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 10, 657, DateTimeKind.Unspecified).AddTicks(4439), new TimeSpan(0, 0, 0, 0, 0)), "Smith", 150 },
                    { "b8d7ecb1-704b-41b0-a31d-77191c563c8b", "Bank c", "123456798", "Dev Nguyen", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 10, 657, DateTimeKind.Unspecified).AddTicks(4444), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dev", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 10, 657, DateTimeKind.Unspecified).AddTicks(4444), new TimeSpan(0, 0, 0, 0, 0)), "Nguyen", 0 },
                    { "dbb06f69-3010-40c4-b5b4-dfb4e3953d88", "Bank D", "123456987", "Dan Tran", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 10, 657, DateTimeKind.Unspecified).AddTicks(4448), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dan", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 10, 657, DateTimeKind.Unspecified).AddTicks(4449), new TimeSpan(0, 0, 0, 0, 0)), "Tran", 0 },
                    { "e0c835ed-a12a-4698-b9a9-230f420661b9", "Bank A", "123456789", "John Doe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 10, 657, DateTimeKind.Unspecified).AddTicks(4429), new TimeSpan(0, 0, 0, 0, 0)), null, null, "John", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 10, 657, DateTimeKind.Unspecified).AddTicks(4431), new TimeSpan(0, 0, 0, 0, 0)), "Doe", 100 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Email", "EmailConfirmed", "LastUpdatedBy", "LastUpdatedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OtpCode", "OtpCodeResetPassword", "OtpExpiration", "OtpExpirationResetPassword", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserInfoId", "UserName" },
                values: new object[,]
                {
                    { new Guid("1d386078-fef5-43f1-a2aa-4b5a7f35687b"), 0, "a5c36bb6-4bc1-44b7-ba5e-5596a3673f67", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(7757), new TimeSpan(0, 0, 0, 0, 0)), null, null, "manager@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(7758), new TimeSpan(0, 0, 0, 0, 0)), false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAENqQ4S8xmRIC/SWUyoh6OdSw4EAdxX5REpFNsBRiRshkvK+A7ma8vumZ8s5qZ6HQcQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "b8d7ecb1-704b-41b0-a31d-77191c563c8b", "manager" },
                    { new Guid("2f02e595-ec22-4c42-844d-7b78d1fae73c"), 0, "8ff04285-19e2-4997-baf2-1b1182ce3292", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(7850), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user2@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(7850), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEO3SHwJ9ubftHIDyvuTpPvHxwzyTn1B1y0zUQ7IRfBxvM56rZXNvr3iGW0uBZZARFA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "e0c835ed-a12a-4698-b9a9-230f420661b9", "user2" },
                    { new Guid("a6c182e2-d373-401f-b400-ac6b7e7ebbd2"), 0, "f306277c-197c-4e98-bdb9-d5c5d27c7d32", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(7871), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user5@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(7872), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEM9Q/RcSF/AJ70K397FnX8Sa1AZAYJPA8ron/Kgj4PiOspbhLtRe2uuL1fT7RlVqgw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "dbb06f69-3010-40c4-b5b4-dfb4e3953d88", "user5" },
                    { new Guid("b08f57e8-a17a-4a23-85e7-6656fb7fe923"), 0, "a247a19e-ed2e-4f1d-9bda-be33f177a0f4", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(7762), new TimeSpan(0, 0, 0, 0, 0)), null, null, "stylist@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(7763), new TimeSpan(0, 0, 0, 0, 0)), false, null, "STYLIST@EXAMPLE.COM", "STYLIST@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEBYLMMHrAWFXJYsKEIFQOXt+7+dG6CqmxeuStz3/BboO8J8HeV+0lq/J111/l1HUkA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "dbb06f69-3010-40c4-b5b4-dfb4e3953d88", "stylist" },
                    { new Guid("b32de590-bfcb-41e8-863b-a7b88b6adb13"), 0, "0507a10b-29e9-4077-abdb-a6a78b30c38b", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(7866), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user4@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(7867), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEO1JJHu3kiPL+iSLqXne62kl5CPQ21lCdU/fewMIZkmBDpxmcfij3Vj6WJXPsMyn0A==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "b8d7ecb1-704b-41b0-a31d-77191c563c8b", "user4" },
                    { new Guid("dd200405-a388-4a08-a14f-3c1e797f0c42"), 0, "0c82dceb-14d3-4cc1-8f7f-f60fa4cee63c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(7751), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(7752), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEFu7EMvjkOlZg5gqKwJt27zv3FR0hsEsFlMT0X8kf1YN7dAffALB7YDruv6EJdy0rg==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "5f94a718-7506-499d-b0dd-3b7ecc7b62e3", "user" },
                    { new Guid("ea1f730b-dc3a-4dcc-bb16-b11bf246d775"), 0, "008dce94-6dc0-433f-b067-d21f8e965dda", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(7855), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user3@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(7857), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER3@EXAMPLE.COM", "USER3@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEGdXo3giiL447SFJqoWK+pOb+UY5KOCJIXYh3CcXtRGLCjd400v8KmdIoJLE669jmQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "5f94a718-7506-499d-b0dd-3b7ecc7b62e3", "user3" },
                    { new Guid("fa959cba-ca0a-4369-a97b-beefdd16adec"), 0, "0cceb4e7-2961-4cba-8678-c227d5f2da4f", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(7741), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(7742), new TimeSpan(0, 0, 0, 0, 0)), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEAzSW/+rJgV3BPIIU0DgE3vMWEW1XD6XuLF2JaANkS4V6v93SshbaibRooGzD2G3Yw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "e0c835ed-a12a-4698-b9a9-230f420661b9", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Name", "Price", "ShopId", "TimeService", "Type" },
                values: new object[,]
                {
                    { "03e93dbc-6179-4b74-b8d2-6d91578345ce", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8332), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A neat beard trimming service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8333), new TimeSpan(0, 0, 0, 0, 0)), "Beard Trim", 15000.00m, "775feb1b-1250-44ed-b743-038796a9c0f1", 20, "Beard" },
                    { "133d8a22-91b9-4d5c-a420-cbcc2b93738b", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8337), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A clean and smooth shaving service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8337), new TimeSpan(0, 0, 0, 0, 0)), "Shave", 12000.00m, "775feb1b-1250-44ed-b743-038796a9c0f1", 15, "Beard" },
                    { "62c919be-b234-4bc6-9dcf-674c99084529", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8324), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A professional hair styling service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8324), new TimeSpan(0, 0, 0, 0, 0)), "Hair Styling", 20000.00m, "775feb1b-1250-44ed-b743-038796a9c0f1", 45, "Hair" },
                    { "76758206-adce-462d-be7b-fedb96235fb6", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8342), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A rejuvenating facial service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8343), new TimeSpan(0, 0, 0, 0, 0)), "Facial", 40000.00m, "775feb1b-1250-44ed-b743-038796a9c0f1", 50, "Skin" },
                    { "7a4d2ab3-a1ec-4b30-85ae-d85d33346c5e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8310), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A stylish haircut to refresh your look.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8311), new TimeSpan(0, 0, 0, 0, 0)), "Hair Cut", 25000.00m, "775feb1b-1250-44ed-b743-038796a9c0f1", 30, "Hair" },
                    { "7d1259e9-b32a-4736-8351-eb2cc6527ce3", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8315), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A complete hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8316), new TimeSpan(0, 0, 0, 0, 0)), "Hair Coloring", 50000.00m, "775feb1b-1250-44ed-b743-038796a9c0f1", 30, "Hair" },
                    { "f6faf1e6-5286-4c90-9e55-538ced5ec08d", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8350), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A soothing scalp treatment.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8350), new TimeSpan(0, 0, 0, 0, 0)), "Scalp Treatment", 45000.00m, "775feb1b-1250-44ed-b743-038796a9c0f1", 40, "Hair" },
                    { "fac38a2a-5c79-4ef5-add5-b13c675919f8", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8320), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A premium hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8320), new TimeSpan(0, 0, 0, 0, 0)), "Premium Hair Coloring", 100000.00m, "775feb1b-1250-44ed-b743-038796a9c0f1", 60, "Hair" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { new Guid("0fe13ead-b74e-4e66-ad14-7a7be8610cca"), new Guid("1d386078-fef5-43f1-a2aa-4b5a7f35687b"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8109), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8109), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("679c4c1c-2043-40e5-97e8-8f8f4cef10f2"), new Guid("2f02e595-ec22-4c42-844d-7b78d1fae73c"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8116), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8117), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("679c4c1c-2043-40e5-97e8-8f8f4cef10f2"), new Guid("a6c182e2-d373-401f-b400-ac6b7e7ebbd2"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8136), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8137), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cc4583a4-bbc7-48bc-9a5c-d7754987697f"), new Guid("b08f57e8-a17a-4a23-85e7-6656fb7fe923"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8112), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8113), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("679c4c1c-2043-40e5-97e8-8f8f4cef10f2"), new Guid("b32de590-bfcb-41e8-863b-a7b88b6adb13"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8125), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8134), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("679c4c1c-2043-40e5-97e8-8f8f4cef10f2"), new Guid("dd200405-a388-4a08-a14f-3c1e797f0c42"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8093), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8105), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("679c4c1c-2043-40e5-97e8-8f8f4cef10f2"), new Guid("ea1f730b-dc3a-4dcc-bb16-b11bf246d775"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8120), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8123), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ef76ea1f-d468-4a3d-84e0-dba8c6db112a"), new Guid("fa959cba-ca0a-4369-a97b-beefdd16adec"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8089), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8090), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PointsEarned", "StatusForAppointment", "StylistId", "TotalAmount", "TotalTime", "UserId" },
                values: new object[,]
                {
                    { "4f45d107-016e-4eec-b771-76227225a2d4", new DateTime(2024, 10, 20, 7, 43, 11, 234, DateTimeKind.Utc).AddTicks(8484), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8485), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8485), new TimeSpan(0, 0, 0, 0, 0)), 12, "Pending", new Guid("b08f57e8-a17a-4a23-85e7-6656fb7fe923"), 200000.00m, 45, new Guid("2f02e595-ec22-4c42-844d-7b78d1fae73c") },
                    { "b8b5df76-5417-40ce-9499-8ac16f8ad40d", new DateTime(2024, 10, 21, 7, 43, 11, 234, DateTimeKind.Utc).AddTicks(8490), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8490), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8491), new TimeSpan(0, 0, 0, 0, 0)), 20, "Completed", new Guid("b08f57e8-a17a-4a23-85e7-6656fb7fe923"), 150000.00m, 90, new Guid("b32de590-bfcb-41e8-863b-a7b88b6adb13") },
                    { "bbe2e6bc-4792-436f-a1a5-8f68e99cebe6", new DateTime(2024, 10, 18, 7, 43, 11, 234, DateTimeKind.Utc).AddTicks(8458), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8467), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8468), new TimeSpan(0, 0, 0, 0, 0)), 10, "Pending", new Guid("dd200405-a388-4a08-a14f-3c1e797f0c42"), 100000.00m, 0, new Guid("fa959cba-ca0a-4369-a97b-beefdd16adec") },
                    { "d1937793-0aa7-41bf-9e5e-1ef1da919cf5", new DateTime(2024, 10, 19, 7, 43, 11, 234, DateTimeKind.Utc).AddTicks(8472), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8473), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8474), new TimeSpan(0, 0, 0, 0, 0)), 15, "Scheduled", new Guid("b08f57e8-a17a-4a23-85e7-6656fb7fe923"), 65000.00m, 75, new Guid("1d386078-fef5-43f1-a2aa-4b5a7f35687b") }
                });

            migrationBuilder.InsertData(
                table: "ComboServices",
                columns: new[] { "Id", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[,]
                {
                    { "12fd386fc5d841b8b58c88b878f76c7d", "defb9dba-9a40-46d8-8c67-f2b74930c18a", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8716), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8716), new TimeSpan(0, 0, 0, 0, 0)), "7a4d2ab3-a1ec-4b30-85ae-d85d33346c5e" },
                    { "487849226ae54b2e9962bb02747115af", "defb9dba-9a40-46d8-8c67-f2b74930c18a", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8721), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8721), new TimeSpan(0, 0, 0, 0, 0)), "7d1259e9-b32a-4736-8351-eb2cc6527ce3" },
                    { "4c4c61c22228493db2df0a76a5300130", "1b91ec9a-873c-4480-b3c6-34f63c185dc6", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8744), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8745), new TimeSpan(0, 0, 0, 0, 0)), "133d8a22-91b9-4d5c-a420-cbcc2b93738b" },
                    { "d4f9d9c9de8a4d76ae8c19f51642a4e5", "a4fb118b-2cde-446c-9644-ceab9a753ebe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8730), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8730), new TimeSpan(0, 0, 0, 0, 0)), "62c919be-b234-4bc6-9dcf-674c99084529" },
                    { "edfba8cc77374fce9ea0eb4d5c4871bb", "1b91ec9a-873c-4480-b3c6-34f63c185dc6", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8736), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8737), new TimeSpan(0, 0, 0, 0, 0)), "03e93dbc-6179-4b74-b8d2-6d91578345ce" },
                    { "f67d8808506140119cb30e3e51acd3cf", "a4fb118b-2cde-446c-9644-ceab9a753ebe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8725), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8726), new TimeSpan(0, 0, 0, 0, 0)), "fac38a2a-5c79-4ef5-add5-b13c675919f8" }
                });

            migrationBuilder.InsertData(
                table: "SalaryPayments",
                columns: new[] { "Id", "BaseSalary", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentDate", "UserId" },
                values: new object[] { "86b1422f-b616-485f-bc6f-5c3afd25dc3b", 2000.00m, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8622), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8622), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Utc).AddTicks(8621), new Guid("fa959cba-ca0a-4369-a97b-beefdd16adec") });

            migrationBuilder.InsertData(
                table: "ComboAppointment",
                columns: new[] { "Id", "AppointmentId", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { "26a96eaf-b213-49df-9ee0-28a922aab5a5", "4f45d107-016e-4eec-b771-76227225a2d4", "1b91ec9a-873c-4480-b3c6-34f63c185dc6", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8830), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8830), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "4931daee-d3a3-4343-8110-e410e0e4c15e", "bbe2e6bc-4792-436f-a1a5-8f68e99cebe6", "defb9dba-9a40-46d8-8c67-f2b74930c18a", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8819), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8820), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "c53bed63-04e5-4bf6-9f8a-dd19d2ccf1d1", "d1937793-0aa7-41bf-9e5e-1ef1da919cf5", "a4fb118b-2cde-446c-9644-ceab9a753ebe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8824), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8824), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ServiceAppointments",
                columns: new[] { "Id", "AppointmentId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[] { "d59d16b1-7919-4885-a0c7-ffe0514f7530", "bbe2e6bc-4792-436f-a1a5-8f68e99cebe6", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8581), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Basic haircut", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 17, 7, 43, 11, 234, DateTimeKind.Unspecified).AddTicks(8581), new TimeSpan(0, 0, 0, 0, 0)), "7a4d2ab3-a1ec-4b30-85ae-d85d33346c5e" });

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
