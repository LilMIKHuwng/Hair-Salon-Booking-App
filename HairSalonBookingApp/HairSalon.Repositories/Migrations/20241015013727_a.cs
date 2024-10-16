using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HairSalon.Repositories.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015013727_a.cs
    public partial class a : Migration
========
    public partial class Init : Migration
>>>>>>>> 64db2f0003b14369df89b20a6c4a70d3cbf9ee19:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015021652_Init.cs
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
                name: "Combo",
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
                    table.PrimaryKey("PK_Combo", x => x.Id);
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
                name: "ComboService",
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
                    table.PrimaryKey("PK_ComboService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComboService_Combo_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboService_Services_ServiceId",
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
                        name: "FK_ComboAppointment_Combo_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combo",
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
<<<<<<<< HEAD:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015013727_a.cs
                    { new Guid("150b9d4c-9ba9-4074-9963-7bf7aa9386cc"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 225, DateTimeKind.Unspecified).AddTicks(6284), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 225, DateTimeKind.Unspecified).AddTicks(6284), new TimeSpan(0, 0, 0, 0, 0)), "Stylist", "STYLIST" },
                    { new Guid("5709a2ac-fe76-4d0a-8a71-c6c24d93ddb8"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 225, DateTimeKind.Unspecified).AddTicks(6267), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 225, DateTimeKind.Unspecified).AddTicks(6267), new TimeSpan(0, 0, 0, 0, 0)), "Manager", "MANAGER" },
                    { new Guid("bc2f6e6e-bcec-4a9a-9b4c-74f38558e8a3"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 225, DateTimeKind.Unspecified).AddTicks(6263), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 225, DateTimeKind.Unspecified).AddTicks(6264), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "ADMIN" },
                    { new Guid("e852ac56-7d17-49b1-b6fd-ef635390fef0"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 225, DateTimeKind.Unspecified).AddTicks(6287), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 225, DateTimeKind.Unspecified).AddTicks(6287), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" }
========
                    { new Guid("039c47a9-ecee-4fe1-aab1-e55b12e18530"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 51, 611, DateTimeKind.Unspecified).AddTicks(2729), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 51, 611, DateTimeKind.Unspecified).AddTicks(2729), new TimeSpan(0, 0, 0, 0, 0)), "Stylist", "STYLIST" },
                    { new Guid("3d65d8ae-52b3-4db4-af82-b8407fb73cb9"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 51, 611, DateTimeKind.Unspecified).AddTicks(2725), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 51, 611, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 0, 0, 0, 0)), "Manager", "MANAGER" },
                    { new Guid("787785ae-44c3-4a3c-a555-de8f141244f9"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 51, 611, DateTimeKind.Unspecified).AddTicks(2721), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 51, 611, DateTimeKind.Unspecified).AddTicks(2721), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "ADMIN" },
                    { new Guid("d0a24015-be57-48a9-b20f-388edaf452ff"), null, "System", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 51, 611, DateTimeKind.Unspecified).AddTicks(2732), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 51, 611, DateTimeKind.Unspecified).AddTicks(2732), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Combo",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "TimeCombo", "TotalPrice" },
                values: new object[,]
                {
                    { "9f8a5f33-b268-4756-ae38-68b9ee6eaf49", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1667), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1667), new TimeSpan(0, 0, 0, 0, 0)), "Basic Hair Combo", 60, 40000.00m },
                    { "ab5b12c4-8772-47c8-99fd-f692675ec072", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1670), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1671), new TimeSpan(0, 0, 0, 0, 0)), "Deluxe Hair Combo", 120, 80000.00m },
                    { "edee2a14-6b0c-470b-8cc7-57e78691ef67", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1675), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1676), new TimeSpan(0, 0, 0, 0, 0)), "Ultimate Hair & Beard Combo", 150, 120000.00m }
>>>>>>>> 64db2f0003b14369df89b20a6c4a70d3cbf9ee19:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015021652_Init.cs
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "OpenTime", "ShopEmail", "ShopPhone", "Title" },
<<<<<<<< HEAD:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015013727_a.cs
                values: new object[] { "d6850d37-7dd9-46ee-a3f9-17173fb9a918", "123 Main St, Cityville", new TimeSpan(0, 19, 0, 0, 0), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5401), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5402), new TimeSpan(0, 0, 0, 0, 0)), "Salon A", new TimeSpan(0, 9, 0, 0, 0), "contact@salona.com", "123-456-7890", "Best Hair Salon in Town" });
========
                values: new object[] { "c0fbd35c-94db-45a2-b2fb-49508e785679", "123 Main St, Cityville", new TimeSpan(0, 19, 0, 0, 0), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1160), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1160), new TimeSpan(0, 0, 0, 0, 0)), "Salon A", new TimeSpan(0, 9, 0, 0, 0), "contact@salona.com", "123-456-7890", "Best Hair Salon in Town" });
>>>>>>>> 64db2f0003b14369df89b20a6c4a70d3cbf9ee19:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015021652_Init.cs

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Bank", "BankAccount", "BankAccountName", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Firstname", "LastUpdatedBy", "LastUpdatedTime", "Lastname", "Point" },
                values: new object[,]
                {
<<<<<<<< HEAD:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015013727_a.cs
                    { "056d1615-b523-4fbf-a21c-42fa5895bd03", "Bank A", "123456789", "John Doe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 225, DateTimeKind.Unspecified).AddTicks(6489), new TimeSpan(0, 0, 0, 0, 0)), null, null, "John", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 225, DateTimeKind.Unspecified).AddTicks(6490), new TimeSpan(0, 0, 0, 0, 0)), "Doe", 100 },
                    { "4f2d6114-7a78-4f85-9720-b6ded6acde7c", "Bank D", "123456987", "Dan Tran", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 225, DateTimeKind.Unspecified).AddTicks(6502), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dan", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 225, DateTimeKind.Unspecified).AddTicks(6502), new TimeSpan(0, 0, 0, 0, 0)), "Tran", 0 },
                    { "86f2a60f-287b-422e-b64c-68c7548619b5", "Bank B", "987654321", "Jane Smith", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 225, DateTimeKind.Unspecified).AddTicks(6494), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jane", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 225, DateTimeKind.Unspecified).AddTicks(6495), new TimeSpan(0, 0, 0, 0, 0)), "Smith", 150 },
                    { "89c47c34-16ba-4cf9-9a01-87dcf495a415", "Bank c", "123456798", "Dev Nguyen", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 225, DateTimeKind.Unspecified).AddTicks(6498), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dev", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 225, DateTimeKind.Unspecified).AddTicks(6498), new TimeSpan(0, 0, 0, 0, 0)), "Nguyen", 0 }
========
                    { "3aa7be16-a0ca-4b33-a36f-e0c94aefde5c", "Bank B", "987654321", "Jane Smith", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 51, 611, DateTimeKind.Unspecified).AddTicks(3036), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jane", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 51, 611, DateTimeKind.Unspecified).AddTicks(3037), new TimeSpan(0, 0, 0, 0, 0)), "Smith", 150 },
                    { "887fc517-d0e5-459f-a966-d8c38346f934", "Bank D", "123456987", "Dan Tran", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 51, 611, DateTimeKind.Unspecified).AddTicks(3044), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dan", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 51, 611, DateTimeKind.Unspecified).AddTicks(3045), new TimeSpan(0, 0, 0, 0, 0)), "Tran", 0 },
                    { "91b532c1-760b-43ac-a973-b49f9ba83390", "Bank A", "123456789", "John Doe", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 51, 611, DateTimeKind.Unspecified).AddTicks(3031), new TimeSpan(0, 0, 0, 0, 0)), null, null, "John", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 51, 611, DateTimeKind.Unspecified).AddTicks(3031), new TimeSpan(0, 0, 0, 0, 0)), "Doe", 100 },
                    { "fb3a1633-5750-41bd-974f-7693be92db69", "Bank c", "123456798", "Dev Nguyen", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 51, 611, DateTimeKind.Unspecified).AddTicks(3040), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dev", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 51, 611, DateTimeKind.Unspecified).AddTicks(3041), new TimeSpan(0, 0, 0, 0, 0)), "Nguyen", 0 }
>>>>>>>> 64db2f0003b14369df89b20a6c4a70d3cbf9ee19:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015021652_Init.cs
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Email", "EmailConfirmed", "LastUpdatedBy", "LastUpdatedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OtpCode", "OtpCodeResetPassword", "OtpExpiration", "OtpExpirationResetPassword", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserInfoId", "UserName" },
                values: new object[,]
                {
<<<<<<<< HEAD:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015013727_a.cs
                    { new Guid("1729c1ec-db19-47b7-9018-6cb7175c55b6"), 0, "ad50b25f-49e3-4deb-8302-d37d302aa0a3", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5097), new TimeSpan(0, 0, 0, 0, 0)), null, null, "stylist@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5098), new TimeSpan(0, 0, 0, 0, 0)), false, null, "STYLIST@EXAMPLE.COM", "STYLIST@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEF7mhcsUW5/yKM0naHoi4whSL4twkkQjy/TfX0w4fcniYMa3rHB+EzPFtxe1neBEng==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "4f2d6114-7a78-4f85-9720-b6ded6acde7c", "stylist" },
                    { new Guid("4547024d-0933-453a-ba37-30009d6014aa"), 0, "6fbfa24a-a150-498b-b47b-aa17c7a93d5e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5084), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5085), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEE8eX3cu2XdjC7v0xc6dsmdQ1EdmKHJvHPB/Walt52unyP6ZqM3q1+5i8sh9T6PQ9g==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "86f2a60f-287b-422e-b64c-68c7548619b5", "user" },
                    { new Guid("57e3afa0-b8b0-4607-9673-b1baccbef275"), 0, "ca9aba74-7a27-41e0-a906-27343bd3d7c0", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5091), new TimeSpan(0, 0, 0, 0, 0)), null, null, "manager@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5092), new TimeSpan(0, 0, 0, 0, 0)), false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEIyxF6rmxprm4hjwlWkMrrJg+Roq71EzMXJq5fHU2v2UQlMMs1CbyS1jVGhUZ0g9zA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "89c47c34-16ba-4cf9-9a01-87dcf495a415", "manager" },
                    { new Guid("c99bca32-d253-449c-87e5-817504108039"), 0, "5dd85d21-7965-4cc4-b744-f56a0c8c6ddf", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5049), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5050), new TimeSpan(0, 0, 0, 0, 0)), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEB1F6iyE9R8iwXiK41xUBhplJnKU4jH/v4baZYnUYlP38rf55kjQpc/WoqVw6TzxEQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "056d1615-b523-4fbf-a21c-42fa5895bd03", "admin" }
========
                    { new Guid("0a8f7238-610b-471f-8fd3-c77f52658fb4"), 0, "ee9ac7cb-c481-4405-8db9-008cd062cfea", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(753), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user2@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(754), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEBe1b+TxH/ZtvFhh+kH/gqo0cpV6uPZ/nUy+t4nR0Y/0WMZlv5c2Vjck95wpaWdF/A==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "91b532c1-760b-43ac-a973-b49f9ba83390", "user2" },
                    { new Guid("15aa9aad-7a09-4a8d-8bf6-d2ed2c2d34b9"), 0, "b0bee18b-5f4e-4741-9f45-6bdaa8c90cb1", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(770), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user3@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(771), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER3@EXAMPLE.COM", "USER3@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEE7uzSzZt+wyVUttR8c8wenWA/Uuf7fDRzjp/RlEnHuAQ9pJReE2E9wqiw4xFqFhdQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "3aa7be16-a0ca-4b33-a36f-e0c94aefde5c", "user3" },
                    { new Guid("3f7a795e-f11a-4e90-928f-54bace78a98c"), 0, "28281410-6545-4c48-b7e7-a3202eec4b8c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(744), new TimeSpan(0, 0, 0, 0, 0)), null, null, "manager@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(744), new TimeSpan(0, 0, 0, 0, 0)), false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEIeUis79wABwJx0n86NQ/ZnY7mfEgea9QlsQCX6KEMksHE6QabproQDw/HkeXkz0BA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "fb3a1633-5750-41bd-974f-7693be92db69", "manager" },
                    { new Guid("54e42b5a-3409-49cc-90b9-078e07ac77ee"), 0, "34f8adf3-865b-4298-8b9b-278159c5c0a8", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(748), new TimeSpan(0, 0, 0, 0, 0)), null, null, "stylist@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(750), new TimeSpan(0, 0, 0, 0, 0)), false, null, "STYLIST@EXAMPLE.COM", "STYLIST@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEFJg+CleZxdAO++C0FAUcom0Ir+Y5Hy8rXlEatQqIIjODwEE35lWyNOkFqam2k8F2g==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "887fc517-d0e5-459f-a966-d8c38346f934", "stylist" },
                    { new Guid("60a11eff-a12e-4b4e-bbdc-818247216cf1"), 0, "6c2ec2e2-9fbb-49fe-9bed-bdad3c7bffd2", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(726), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(727), new TimeSpan(0, 0, 0, 0, 0)), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEJ9ptmIlhq4HvGVrXHHiA0ZfdQtTm1g8GWWyf4+whbxg+b/+U1TbmlfoHgO83NO+Xg==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "91b532c1-760b-43ac-a973-b49f9ba83390", "admin" },
                    { new Guid("becff166-897b-47fe-850f-bab15978bf09"), 0, "6fac0b0e-0286-4656-99cd-e6e472cc8d4c", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(775), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user4@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(775), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEFDt6mvJ6QYaxwiPURKU4ZqzcEZ+MTUg4i0a0EY53D2FWyL0H6SxdTpeZfW5mJd0uw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "fb3a1633-5750-41bd-974f-7693be92db69", "user4" },
                    { new Guid("c38d8387-de5d-4198-a878-348e3a4e9add"), 0, "cff46247-471b-4f43-815e-947de0067d47", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(778), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user5@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(780), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEK+D0taZEutuQjT8MhByex/n4GgFF/axxr0UbkfUuo+UuxGXjw/rXLBexLChEjU81Q==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "887fc517-d0e5-459f-a966-d8c38346f934", "user5" },
                    { new Guid("e9206cc8-6bc5-4e17-98ae-2ab4441b8d61"), 0, "4b787c88-a23e-43e2-9397-edbda8830605", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(739), new TimeSpan(0, 0, 0, 0, 0)), null, null, "user@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(739), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEOySd9KcrVkGtExFgI1MJAS2gWV+GYATCIaXB8Zl0lsgipgV6MdoUXwsyUFkqg567A==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, "3aa7be16-a0ca-4b33-a36f-e0c94aefde5c", "user" }
>>>>>>>> 64db2f0003b14369df89b20a6c4a70d3cbf9ee19:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015021652_Init.cs
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Name", "Price", "ShopId", "TimeService", "Type" },
                values: new object[,]
                {
<<<<<<<< HEAD:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015013727_a.cs
                    { "245155dc-ac77-4a5b-ad74-6f7c94a8c94b", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5491), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A premium hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5491), new TimeSpan(0, 0, 0, 0, 0)), "Premium Hair Coloring", 100000.00m, "d6850d37-7dd9-46ee-a3f9-17173fb9a918", 60, "Hair" },
                    { "dba2b4bd-185d-45b5-ab00-ee5703639883", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5487), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A complete hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5487), new TimeSpan(0, 0, 0, 0, 0)), "Hair Coloring", 50000.00m, "d6850d37-7dd9-46ee-a3f9-17173fb9a918", 30, "Hair" },
                    { "e7220e6b-f330-4731-8ad9-0f2bd7bec109", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5478), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A stylish haircut to refresh your look.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5482), new TimeSpan(0, 0, 0, 0, 0)), "Hair Cut", 25000.00m, "d6850d37-7dd9-46ee-a3f9-17173fb9a918", 30, "Hair" }
========
                    { "575e88b5-0037-4356-b47a-19327e6d0094", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1230), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A premium hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1230), new TimeSpan(0, 0, 0, 0, 0)), "Premium Hair Coloring", 100000.00m, "c0fbd35c-94db-45a2-b2fb-49508e785679", 60, "Hair" },
                    { "7d1bb8f4-a93b-4f7e-9e99-fd12956c940a", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1278), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A soothing scalp treatment.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1278), new TimeSpan(0, 0, 0, 0, 0)), "Scalp Treatment", 45000.00m, "c0fbd35c-94db-45a2-b2fb-49508e785679", 40, "Hair" },
                    { "beea2cb5-0eaa-4b09-8a53-d81433f16357", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1235), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A professional hair styling service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1236), new TimeSpan(0, 0, 0, 0, 0)), "Hair Styling", 20000.00m, "c0fbd35c-94db-45a2-b2fb-49508e785679", 45, "Hair" },
                    { "bfe8bf8a-7d4f-4d8b-850f-364ac0b8b336", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1222), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A stylish haircut to refresh your look.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1222), new TimeSpan(0, 0, 0, 0, 0)), "Hair Cut", 25000.00m, "c0fbd35c-94db-45a2-b2fb-49508e785679", 30, "Hair" },
                    { "c97f33df-e68d-4de1-95b8-166ebfd1792a", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1271), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A clean and smooth shaving service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1271), new TimeSpan(0, 0, 0, 0, 0)), "Shave", 12000.00m, "c0fbd35c-94db-45a2-b2fb-49508e785679", 15, "Beard" },
                    { "cbd655d2-4091-4678-89d1-96e48a738794", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1274), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A rejuvenating facial service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1275), new TimeSpan(0, 0, 0, 0, 0)), "Facial", 40000.00m, "c0fbd35c-94db-45a2-b2fb-49508e785679", 50, "Skin" },
                    { "efe1cacb-ea54-4fc4-9797-2cac32096327", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1267), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A neat beard trimming service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1267), new TimeSpan(0, 0, 0, 0, 0)), "Beard Trim", 15000.00m, "c0fbd35c-94db-45a2-b2fb-49508e785679", 20, "Beard" },
                    { "fb050434-1e90-46f3-87da-2b1f2ff70ce3", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1226), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A complete hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1226), new TimeSpan(0, 0, 0, 0, 0)), "Hair Coloring", 50000.00m, "c0fbd35c-94db-45a2-b2fb-49508e785679", 30, "Hair" }
>>>>>>>> 64db2f0003b14369df89b20a6c4a70d3cbf9ee19:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015021652_Init.cs
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
<<<<<<<< HEAD:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015013727_a.cs
                    { new Guid("150b9d4c-9ba9-4074-9963-7bf7aa9386cc"), new Guid("1729c1ec-db19-47b7-9018-6cb7175c55b6"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5302), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5302), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e852ac56-7d17-49b1-b6fd-ef635390fef0"), new Guid("4547024d-0933-453a-ba37-30009d6014aa"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5230), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5230), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5709a2ac-fe76-4d0a-8a71-c6c24d93ddb8"), new Guid("57e3afa0-b8b0-4607-9673-b1baccbef275"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5298), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5299), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("bc2f6e6e-bcec-4a9a-9b4c-74f38558e8a3"), new Guid("c99bca32-d253-449c-87e5-817504108039"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5226), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5226), new TimeSpan(0, 0, 0, 0, 0)) }
========
                    { new Guid("d0a24015-be57-48a9-b20f-388edaf452ff"), new Guid("0a8f7238-610b-471f-8fd3-c77f52658fb4"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1044), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1044), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d0a24015-be57-48a9-b20f-388edaf452ff"), new Guid("15aa9aad-7a09-4a8d-8bf6-d2ed2c2d34b9"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1046), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1046), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3d65d8ae-52b3-4db4-af82-b8407fb73cb9"), new Guid("3f7a795e-f11a-4e90-928f-54bace78a98c"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1038), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1038), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("039c47a9-ecee-4fe1-aab1-e55b12e18530"), new Guid("54e42b5a-3409-49cc-90b9-078e07ac77ee"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1041), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1042), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("787785ae-44c3-4a3c-a555-de8f141244f9"), new Guid("60a11eff-a12e-4b4e-bbdc-818247216cf1"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1019), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1019), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d0a24015-be57-48a9-b20f-388edaf452ff"), new Guid("becff166-897b-47fe-850f-bab15978bf09"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1048), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1057), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d0a24015-be57-48a9-b20f-388edaf452ff"), new Guid("c38d8387-de5d-4198-a878-348e3a4e9add"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1059), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1059), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d0a24015-be57-48a9-b20f-388edaf452ff"), new Guid("e9206cc8-6bc5-4e17-98ae-2ab4441b8d61"), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1023), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1035), new TimeSpan(0, 0, 0, 0, 0)) }
>>>>>>>> 64db2f0003b14369df89b20a6c4a70d3cbf9ee19:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015021652_Init.cs
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PointsEarned", "StatusForAppointment", "StylistId", "TotalTime", "UserId" },
<<<<<<<< HEAD:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015013727_a.cs
                values: new object[] { "46715a49-2398-4052-afe0-4ffa102015ce", new DateTime(2024, 10, 16, 1, 37, 27, 468, DateTimeKind.Utc).AddTicks(5544), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5567), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5568), new TimeSpan(0, 0, 0, 0, 0)), 10, "Scheduled", new Guid("4547024d-0933-453a-ba37-30009d6014aa"), 0, new Guid("c99bca32-d253-449c-87e5-817504108039") });
========
                values: new object[,]
                {
                    { "7e6364ee-ceee-48fb-8f6c-dc102c1dbf90", new DateTime(2024, 10, 18, 2, 16, 52, 112, DateTimeKind.Utc).AddTicks(1382), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1383), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1383), new TimeSpan(0, 0, 0, 0, 0)), 12, "Pending", new Guid("54e42b5a-3409-49cc-90b9-078e07ac77ee"), 45, new Guid("0a8f7238-610b-471f-8fd3-c77f52658fb4") },
                    { "ade6ce69-0229-407f-bca0-1b019e0db89e", new DateTime(2024, 10, 16, 2, 16, 52, 112, DateTimeKind.Utc).AddTicks(1359), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1369), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1369), new TimeSpan(0, 0, 0, 0, 0)), 10, "Pending", new Guid("e9206cc8-6bc5-4e17-98ae-2ab4441b8d61"), 0, new Guid("60a11eff-a12e-4b4e-bbdc-818247216cf1") },
                    { "cbf1d996-e475-4f92-8c2f-86b265d8dc1b", new DateTime(2024, 10, 17, 2, 16, 52, 112, DateTimeKind.Utc).AddTicks(1373), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1374), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1374), new TimeSpan(0, 0, 0, 0, 0)), 15, "Scheduled", new Guid("54e42b5a-3409-49cc-90b9-078e07ac77ee"), 75, new Guid("3f7a795e-f11a-4e90-928f-54bace78a98c") },
                    { "f1fc31a4-e315-46c6-bd0a-e69bfbfb531d", new DateTime(2024, 10, 19, 2, 16, 52, 112, DateTimeKind.Utc).AddTicks(1386), "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1387), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1387), new TimeSpan(0, 0, 0, 0, 0)), 20, "Completed", new Guid("54e42b5a-3409-49cc-90b9-078e07ac77ee"), 90, new Guid("becff166-897b-47fe-850f-bab15978bf09") }
                });

            migrationBuilder.InsertData(
                table: "ComboService",
                columns: new[] { "Id", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[,]
                {
                    { "5735bf9782574770903c848c9addc43a", "ab5b12c4-8772-47c8-99fd-f692675ec072", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1762), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1762), new TimeSpan(0, 0, 0, 0, 0)), "575e88b5-0037-4356-b47a-19327e6d0094" },
                    { "a699d220560547b188e332d772075f50", "ab5b12c4-8772-47c8-99fd-f692675ec072", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1767), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1768), new TimeSpan(0, 0, 0, 0, 0)), "beea2cb5-0eaa-4b09-8a53-d81433f16357" },
                    { "b880199c9a754910adab412025975f25", "9f8a5f33-b268-4756-ae38-68b9ee6eaf49", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1754), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1754), new TimeSpan(0, 0, 0, 0, 0)), "bfe8bf8a-7d4f-4d8b-850f-364ac0b8b336" },
                    { "bcd1e3b696a044f0828dae92e2f13f56", "edee2a14-6b0c-470b-8cc7-57e78691ef67", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1771), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1771), new TimeSpan(0, 0, 0, 0, 0)), "efe1cacb-ea54-4fc4-9797-2cac32096327" },
                    { "caf8da97549f480cb728d6586fdcf6ca", "9f8a5f33-b268-4756-ae38-68b9ee6eaf49", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1758), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1758), new TimeSpan(0, 0, 0, 0, 0)), "fb050434-1e90-46f3-87da-2b1f2ff70ce3" },
                    { "de8ae0afbab24fb0b50708c72e92de6e", "edee2a14-6b0c-470b-8cc7-57e78691ef67", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1801), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1802), new TimeSpan(0, 0, 0, 0, 0)), "c97f33df-e68d-4de1-95b8-166ebfd1792a" }
                });
>>>>>>>> 64db2f0003b14369df89b20a6c4a70d3cbf9ee19:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015021652_Init.cs

            migrationBuilder.InsertData(
                table: "SalaryPayments",
                columns: new[] { "Id", "BaseSalary", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentDate", "UserId" },
<<<<<<<< HEAD:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015013727_a.cs
                values: new object[] { "e10701d9-8a1d-425d-bb57-fdc23752236d", 2000.00m, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5765), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5766), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Utc).AddTicks(5764), new Guid("c99bca32-d253-449c-87e5-817504108039") });
========
                values: new object[] { "b2608f23-70af-4423-9189-6ac07f700c2d", 2000.00m, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1621), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1622), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Utc).AddTicks(1621), new Guid("60a11eff-a12e-4b4e-bbdc-818247216cf1") });

            migrationBuilder.InsertData(
                table: "ComboAppointment",
                columns: new[] { "Id", "AppointmentId", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { "25632c17-f1e4-45c7-92ea-ce1091e67dc6", "7e6364ee-ceee-48fb-8f6c-dc102c1dbf90", "edee2a14-6b0c-470b-8cc7-57e78691ef67", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1851), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1852), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "5bf060e8-9a22-4ad7-a8a3-984678babc57", "cbf1d996-e475-4f92-8c2f-86b265d8dc1b", "ab5b12c4-8772-47c8-99fd-f692675ec072", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1848), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1848), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "ba470be2-8bcd-4fad-969a-7ea9df846770", "ade6ce69-0229-407f-bca0-1b019e0db89e", "9f8a5f33-b268-4756-ae38-68b9ee6eaf49", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1845), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1845), new TimeSpan(0, 0, 0, 0, 0)) }
                });
>>>>>>>> 64db2f0003b14369df89b20a6c4a70d3cbf9ee19:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015021652_Init.cs

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "AppointmentId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentMethod", "PaymentTime", "TotalAmount" },
<<<<<<<< HEAD:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015013727_a.cs
                values: new object[] { "5fa62a89-7aac-443f-8578-a83623f1a2b1", "46715a49-2398-4052-afe0-4ffa102015ce", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5650), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5651), new TimeSpan(0, 0, 0, 0, 0)), "Credit Card", new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Utc).AddTicks(5647), 100.00m });
========
                values: new object[] { "563cdbe3-c639-48ba-9322-acc80d81dbcb", "ade6ce69-0229-407f-bca0-1b019e0db89e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1520), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1520), new TimeSpan(0, 0, 0, 0, 0)), "Credit Card", new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Utc).AddTicks(1519), 100.00m });
>>>>>>>> 64db2f0003b14369df89b20a6c4a70d3cbf9ee19:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015021652_Init.cs

            migrationBuilder.InsertData(
                table: "ServiceAppointments",
                columns: new[] { "Id", "AppointmentId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
<<<<<<<< HEAD:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015013727_a.cs
                values: new object[] { "85b88999-b5ca-49e9-87cb-61571922eae1", "46715a49-2398-4052-afe0-4ffa102015ce", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5708), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Basic haircut", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 1, 37, 27, 468, DateTimeKind.Unspecified).AddTicks(5715), new TimeSpan(0, 0, 0, 0, 0)), "e7220e6b-f330-4731-8ad9-0f2bd7bec109" });
========
                values: new object[] { "c5e986a4-49ce-4f82-b3dd-8dc478cf93aa", "ade6ce69-0229-407f-bca0-1b019e0db89e", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1571), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Basic haircut", "SeedData", new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 52, 112, DateTimeKind.Unspecified).AddTicks(1571), new TimeSpan(0, 0, 0, 0, 0)), "bfe8bf8a-7d4f-4d8b-850f-364ac0b8b336" });
>>>>>>>> 64db2f0003b14369df89b20a6c4a70d3cbf9ee19:HairSalonBookingApp/HairSalon.Repositories/Migrations/20241015021652_Init.cs

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
                name: "IX_ComboService_ComboId",
                table: "ComboService",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboService_ServiceId",
                table: "ComboService",
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
                name: "ComboService");

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
                name: "Combo");

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
