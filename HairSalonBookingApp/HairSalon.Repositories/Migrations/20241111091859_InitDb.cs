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
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_ApplicationUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_ApplicationUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    { new Guid("2a3f1086-2094-43d6-82c9-630f849a01f8"), null, "System", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 58, 597, DateTimeKind.Unspecified).AddTicks(6419), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 58, 597, DateTimeKind.Unspecified).AddTicks(6420), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "ADMIN" },
                    { new Guid("c12e6d1a-709e-40a8-8f51-790a776c793e"), null, "System", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 58, 597, DateTimeKind.Unspecified).AddTicks(6434), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 58, 597, DateTimeKind.Unspecified).AddTicks(6435), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" },
                    { new Guid("d16a919b-5cb9-492e-940d-c7f032cc5b04"), null, "System", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 58, 597, DateTimeKind.Unspecified).AddTicks(6425), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 58, 597, DateTimeKind.Unspecified).AddTicks(6425), new TimeSpan(0, 0, 0, 0, 0)), "Manager", "MANAGER" },
                    { new Guid("d8cbbe8f-e6a0-42df-9521-ec1533e0f56c"), null, "System", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 58, 597, DateTimeKind.Unspecified).AddTicks(6430), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 58, 597, DateTimeKind.Unspecified).AddTicks(6430), new TimeSpan(0, 0, 0, 0, 0)), "Stylist", "STYLIST" }
                });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "ComboImage", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "TimeCombo", "TotalPrice" },
                values: new object[,]
                {
                    { "7929bc91-ce9a-4e13-8ece-9a538b65e800", null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6644), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6645), new TimeSpan(0, 0, 0, 0, 0)), "Basic Hair Combo", 60, 40000.00m },
                    { "a005049d-5b57-4d40-a4d7-5e5f0220d0b4", null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6663), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6663), new TimeSpan(0, 0, 0, 0, 0)), "Ultimate Hair & Beard Combo", 150, 120000.00m },
                    { "cd59634e-c39c-4a3b-bf88-898ed8f9ad76", null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6658), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6659), new TimeSpan(0, 0, 0, 0, 0)), "Deluxe Hair Combo", 120, 80000.00m }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "OpenTime", "ShopEmail", "ShopImage", "ShopPhone", "Title" },
                values: new object[] { "418dcdc4-cbb8-4b52-bd46-91e90b2f8730", "123 Main St, Cityville", new TimeSpan(0, 19, 0, 0, 0), "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6272), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6272), new TimeSpan(0, 0, 0, 0, 0)), "Salon A", new TimeSpan(0, 9, 0, 0, 0), "contact@salona.com", null, "123-456-7890", "Best Hair Salon in Town" });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Bank", "BankAccount", "BankAccountName", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Firstname", "LastUpdatedBy", "LastUpdatedTime", "Lastname", "Point" },
                values: new object[,]
                {
                    { "0e505ca4-b326-4429-82a5-ae2ce4aaca31", "Bank D", "123456987", "Dan Tran", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 58, 597, DateTimeKind.Unspecified).AddTicks(6799), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dan", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 58, 597, DateTimeKind.Unspecified).AddTicks(6799), new TimeSpan(0, 0, 0, 0, 0)), "Tran", 0 },
                    { "1076e7b1-b572-4fb1-824a-37b24a56db82", "Bank A", "123456789", "John Doe", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 58, 597, DateTimeKind.Unspecified).AddTicks(6778), new TimeSpan(0, 0, 0, 0, 0)), null, null, "John", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 58, 597, DateTimeKind.Unspecified).AddTicks(6779), new TimeSpan(0, 0, 0, 0, 0)), "Doe", 100 },
                    { "69025ec8-2c67-499f-beab-3f97bc112f50", "Bank c", "123456798", "Dev Nguyen", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 58, 597, DateTimeKind.Unspecified).AddTicks(6792), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dev", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 58, 597, DateTimeKind.Unspecified).AddTicks(6793), new TimeSpan(0, 0, 0, 0, 0)), "Nguyen", 0 },
                    { "93aa14fe-790a-4c26-bd75-4d113db754d0", "Bank B", "987654321", "Jane Smith", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 58, 597, DateTimeKind.Unspecified).AddTicks(6785), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jane", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 58, 597, DateTimeKind.Unspecified).AddTicks(6786), new TimeSpan(0, 0, 0, 0, 0)), "Smith", 150 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "E_Wallet", "Email", "EmailConfirmed", "LastUpdatedBy", "LastUpdatedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OtpCode", "OtpCodeResetPassword", "OtpExpiration", "OtpExpirationResetPassword", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserImage", "UserInfoId", "UserName" },
                values: new object[,]
                {
                    { new Guid("1dc79f22-e7cb-4d20-a9d0-6caee0613557"), 0, "41ec3fe1-0039-4640-9128-ae7855a6b979", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(5978), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user5@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(5978), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEKWoMUjU8GWblpfGNUQykvyN7c2kxh41MKNAm1N5atbxlIAaPp21iGyWyD5GuSbL/w==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "0e505ca4-b326-4429-82a5-ae2ce4aaca31", "user5" },
                    { new Guid("68db6694-5b99-42b9-95d1-42db049c97e0"), 0, "1cf5146d-9e22-46ff-97ac-c682a5f1edf8", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(5874), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "stylist@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(5875), new TimeSpan(0, 0, 0, 0, 0)), false, null, "STYLIST@EXAMPLE.COM", "STYLIST@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAED06czFNPB+dnFSsLlLeaXO3JbvAVilPl0Vw5dVmsqAE1if8BIbFRsocC37dDwNGRw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "0e505ca4-b326-4429-82a5-ae2ce4aaca31", "stylist" },
                    { new Guid("7651cbc7-1404-498a-b667-a0e77a7c9105"), 0, "3f614acc-7be6-4b3a-ae7f-2041d7ab1a32", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(5969), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user3@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(5970), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER3@EXAMPLE.COM", "USER3@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAENsbYOy+R7MUJvv0uhtu7ZDLwmlJtRGYTGUpP7uVXG7lXikVktvWio50+ZL6LcR88Q==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "93aa14fe-790a-4c26-bd75-4d113db754d0", "user3" },
                    { new Guid("977d70f5-9e7b-412b-8ec0-af037f18579c"), 0, "42150a7d-b405-448b-9465-a7ef98c395a7", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(5857), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "admin@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(5858), new TimeSpan(0, 0, 0, 0, 0)), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEEo1jIx83wTcofn5ie6njux9Rh11muNj5sYmNypALIvLgIPsF8lVGwgxQtMsQulSTQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "1076e7b1-b572-4fb1-824a-37b24a56db82", "admin" },
                    { new Guid("af74f4bd-4c10-41ac-9432-fafc11cdf2d0"), 0, "134b2927-cb24-4b41-88fb-d53b497bd05d", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(5864), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(5865), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAENnAo75ckkZwY2vj2L3fbgVwKgWNxKbcSfwZHtMqbNO12e7nBQsbE9DNdxfM6m3M8Q==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "93aa14fe-790a-4c26-bd75-4d113db754d0", "user" },
                    { new Guid("b24908c6-d517-4323-bf4f-342373b06420"), 0, "89cf27e8-b05b-4051-85b6-e6498b314458", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(5974), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user4@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(5974), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEPkMp5lwXhq8Si9Ru3URIkrsQVPkOLkjUd6hiHZwx0S1GHN1oJOUxhTOjS/JFXA40Q==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "69025ec8-2c67-499f-beab-3f97bc112f50", "user4" },
                    { new Guid("cd8687a8-21d5-45a3-8f77-3945b4d33518"), 0, "309f4582-395e-4ca3-a75d-9ed3394b7968", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(5869), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "manager@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(5870), new TimeSpan(0, 0, 0, 0, 0)), false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEH+2DvPF+n/ivKZM1xI4JzjcVdTBmQr8V9865kmH460MD/J/9FPh/2ad/0hawDxhaQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "69025ec8-2c67-499f-beab-3f97bc112f50", "manager" },
                    { new Guid("d107d955-51e4-42f1-b3ef-11d26ecf41f7"), 0, "070c0dca-4664-4b33-b687-339a4801adf7", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(5879), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user2@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(5879), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEN9AS36Q7tzboNHHri5i8cO4dGOBJOtQtA8wGwSwPUf0Yg2yJ51cdv4wNVDCcvJ1Ww==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "1076e7b1-b572-4fb1-824a-37b24a56db82", "user2" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Name", "Price", "ServiceImage", "ShopId", "TimeService", "Type" },
                values: new object[,]
                {
                    { "0673731c-dec6-4d73-b325-e48ed330f4b2", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6364), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A clean and smooth shaving service.", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6364), new TimeSpan(0, 0, 0, 0, 0)), "Shave", 12000.00m, null, "418dcdc4-cbb8-4b52-bd46-91e90b2f8730", 15, "Beard" },
                    { "3bdb1910-4947-471d-80ee-59ab235fd237", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6369), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A rejuvenating facial service.", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 0, 0, 0, 0)), "Facial", 40000.00m, null, "418dcdc4-cbb8-4b52-bd46-91e90b2f8730", 50, "Skin" },
                    { "48aee084-6727-4ad3-8255-db18b5ed73c7", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6348), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A complete hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6349), new TimeSpan(0, 0, 0, 0, 0)), "Hair Coloring", 50000.00m, null, "418dcdc4-cbb8-4b52-bd46-91e90b2f8730", 30, "Hair" },
                    { "726942cf-9aa2-4ffc-b689-6f903f5d659d", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6373), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A soothing scalp treatment.", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6373), new TimeSpan(0, 0, 0, 0, 0)), "Scalp Treatment", 45000.00m, null, "418dcdc4-cbb8-4b52-bd46-91e90b2f8730", 40, "Hair" },
                    { "9b4aeb49-1950-48da-8681-2a357eb7dcfe", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6343), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A stylish haircut to refresh your look.", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6344), new TimeSpan(0, 0, 0, 0, 0)), "Hair Cut", 25000.00m, null, "418dcdc4-cbb8-4b52-bd46-91e90b2f8730", 30, "Hair" },
                    { "9cb38743-127a-4f06-8ace-0635ef676d9a", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6356), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A professional hair styling service.", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6356), new TimeSpan(0, 0, 0, 0, 0)), "Hair Styling", 20000.00m, null, "418dcdc4-cbb8-4b52-bd46-91e90b2f8730", 45, "Hair" },
                    { "c270abaf-dc20-411f-998c-0fa290805fee", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6352), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A premium hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6352), new TimeSpan(0, 0, 0, 0, 0)), "Premium Hair Coloring", 100000.00m, null, "418dcdc4-cbb8-4b52-bd46-91e90b2f8730", 60, "Hair" },
                    { "f591d4f8-5c00-4d74-859f-38f7b4e36111", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6360), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A neat beard trimming service.", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6361), new TimeSpan(0, 0, 0, 0, 0)), "Beard Trim", 15000.00m, null, "418dcdc4-cbb8-4b52-bd46-91e90b2f8730", 20, "Beard" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { new Guid("c12e6d1a-709e-40a8-8f51-790a776c793e"), new Guid("1dc79f22-e7cb-4d20-a9d0-6caee0613557"), "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6195), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6195), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d8cbbe8f-e6a0-42df-9521-ec1533e0f56c"), new Guid("68db6694-5b99-42b9-95d1-42db049c97e0"), "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6178), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6179), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c12e6d1a-709e-40a8-8f51-790a776c793e"), new Guid("7651cbc7-1404-498a-b667-a0e77a7c9105"), "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6183), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6184), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2a3f1086-2094-43d6-82c9-630f849a01f8"), new Guid("977d70f5-9e7b-412b-8ec0-af037f18579c"), "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6097), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6098), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c12e6d1a-709e-40a8-8f51-790a776c793e"), new Guid("af74f4bd-4c10-41ac-9432-fafc11cdf2d0"), "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6101), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6173), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c12e6d1a-709e-40a8-8f51-790a776c793e"), new Guid("b24908c6-d517-4323-bf4f-342373b06420"), "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6187), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6192), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d16a919b-5cb9-492e-940d-c7f032cc5b04"), new Guid("cd8687a8-21d5-45a3-8f77-3945b4d33518"), "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6176), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6176), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c12e6d1a-709e-40a8-8f51-790a776c793e"), new Guid("d107d955-51e4-42f1-b3ef-11d26ecf41f7"), "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6181), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6181), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ComboServices",
                columns: new[] { "Id", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[,]
                {
                    { "006ae7a620d84cb7a4af455c4a60241f", "a005049d-5b57-4d40-a4d7-5e5f0220d0b4", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6770), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6770), new TimeSpan(0, 0, 0, 0, 0)), "f591d4f8-5c00-4d74-859f-38f7b4e36111" },
                    { "2d48addb98d848c3b2e3e3536d699c87", "cd59634e-c39c-4a3b-bf88-898ed8f9ad76", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6760), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6761), new TimeSpan(0, 0, 0, 0, 0)), "c270abaf-dc20-411f-998c-0fa290805fee" },
                    { "47849d3137f54247be17b27bf8947735", "cd59634e-c39c-4a3b-bf88-898ed8f9ad76", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6766), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6766), new TimeSpan(0, 0, 0, 0, 0)), "9cb38743-127a-4f06-8ace-0635ef676d9a" },
                    { "6fe6f802182c4040882cd636b2fa60db", "7929bc91-ce9a-4e13-8ece-9a538b65e800", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6752), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6752), new TimeSpan(0, 0, 0, 0, 0)), "9b4aeb49-1950-48da-8681-2a357eb7dcfe" },
                    { "d30dfe7478494c28b9841ff2e88982d5", "a005049d-5b57-4d40-a4d7-5e5f0220d0b4", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6774), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6775), new TimeSpan(0, 0, 0, 0, 0)), "0673731c-dec6-4d73-b325-e48ed330f4b2" },
                    { "f757faa86c3441728b734f055b5e0800", "7929bc91-ce9a-4e13-8ece-9a538b65e800", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6756), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6757), new TimeSpan(0, 0, 0, 0, 0)), "48aee084-6727-4ad3-8255-db18b5ed73c7" }
                });

            migrationBuilder.InsertData(
                table: "SalaryPayments",
                columns: new[] { "Id", "BaseSalary", "BonusSalary", "CreatedBy", "CreatedTime", "DayOffNoPermitted", "DayOffPermitted", "DeductedSalary", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentDate", "UserId" },
                values: new object[] { "80544a64-780b-44c3-b3c5-c2986529e088", 2000.00m, 0m, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6580), new TimeSpan(0, 0, 0, 0, 0)), 0, 0, 0m, null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Unspecified).AddTicks(6581), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2024, 11, 11, 9, 18, 59, 274, DateTimeKind.Utc).AddTicks(6579), new Guid("977d70f5-9e7b-412b-8ec0-af037f18579c") });

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
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

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
                name: "Messages");

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
