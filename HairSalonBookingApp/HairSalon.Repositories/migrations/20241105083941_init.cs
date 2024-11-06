using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HairSalon.Repositories.migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                    { new Guid("28e68c49-6fb2-421f-908c-aadfaf78ca2b"), null, "System", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 39, 542, DateTimeKind.Unspecified).AddTicks(382), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 39, 542, DateTimeKind.Unspecified).AddTicks(383), new TimeSpan(0, 0, 0, 0, 0)), "Stylist", "STYLIST" },
                    { new Guid("911d7dbf-90c3-4daa-9f9b-26fef3d76ea1"), null, "System", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 39, 542, DateTimeKind.Unspecified).AddTicks(375), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 39, 542, DateTimeKind.Unspecified).AddTicks(375), new TimeSpan(0, 0, 0, 0, 0)), "Admin", "ADMIN" },
                    { new Guid("c82ef01f-ec6f-4c75-82f4-37362f87433e"), null, "System", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 39, 542, DateTimeKind.Unspecified).AddTicks(379), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 39, 542, DateTimeKind.Unspecified).AddTicks(379), new TimeSpan(0, 0, 0, 0, 0)), "Manager", "MANAGER" },
                    { new Guid("e62f5f29-f4bd-4983-81b7-71801d31c954"), null, "System", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 39, 542, DateTimeKind.Unspecified).AddTicks(385), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 39, 542, DateTimeKind.Unspecified).AddTicks(386), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "ComboImage", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "TimeCombo", "TotalPrice" },
                values: new object[,]
                {
                    { "8f543b61-d82f-4d9f-a5d0-d3745c075ada", null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8876), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8876), new TimeSpan(0, 0, 0, 0, 0)), "Basic Hair Combo", 60, 40000.00m },
                    { "e1f1e843-5d44-467f-8f75-95aecbc238c6", null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8891), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8891), new TimeSpan(0, 0, 0, 0, 0)), "Deluxe Hair Combo", 120, 80000.00m },
                    { "ecab9686-3128-42d3-b048-aadae4643ced", null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8894), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8895), new TimeSpan(0, 0, 0, 0, 0)), "Ultimate Hair & Beard Combo", 150, 120000.00m }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "Name", "OpenTime", "ShopEmail", "ShopImage", "ShopPhone", "Title" },
                values: new object[] { "243daa06-14ab-457e-b852-e0c77544f803", "123 Main St, Cityville", new TimeSpan(0, 19, 0, 0, 0), "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7561), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7561), new TimeSpan(0, 0, 0, 0, 0)), "Salon A", new TimeSpan(0, 9, 0, 0, 0), "contact@salona.com", null, "123-456-7890", "Best Hair Salon in Town" });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Bank", "BankAccount", "BankAccountName", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Firstname", "LastUpdatedBy", "LastUpdatedTime", "Lastname", "Point" },
                values: new object[,]
                {
                    { "26e27df5-2eb6-49cf-8004-1260482736c4", "Bank c", "123456798", "Dev Nguyen", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 39, 542, DateTimeKind.Unspecified).AddTicks(642), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dev", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 39, 542, DateTimeKind.Unspecified).AddTicks(643), new TimeSpan(0, 0, 0, 0, 0)), "Nguyen", 0 },
                    { "48a1d020-8348-4342-833a-fb2f96503ab8", "Bank D", "123456987", "Dan Tran", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 39, 542, DateTimeKind.Unspecified).AddTicks(647), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dan", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 39, 542, DateTimeKind.Unspecified).AddTicks(647), new TimeSpan(0, 0, 0, 0, 0)), "Tran", 0 },
                    { "761173f9-f22e-4e72-8bf2-b2ed82a3a655", "Bank B", "987654321", "Jane Smith", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 39, 542, DateTimeKind.Unspecified).AddTicks(635), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jane", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 39, 542, DateTimeKind.Unspecified).AddTicks(635), new TimeSpan(0, 0, 0, 0, 0)), "Smith", 150 },
                    { "b4c01700-8e6e-47dd-a135-9b0e12df28f7", "Bank A", "123456789", "John Doe", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 39, 542, DateTimeKind.Unspecified).AddTicks(629), new TimeSpan(0, 0, 0, 0, 0)), null, null, "John", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 39, 542, DateTimeKind.Unspecified).AddTicks(630), new TimeSpan(0, 0, 0, 0, 0)), "Doe", 100 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "E_Wallet", "Email", "EmailConfirmed", "LastUpdatedBy", "LastUpdatedTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OtpCode", "OtpCodeResetPassword", "OtpExpiration", "OtpExpirationResetPassword", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserImage", "UserInfoId", "UserName" },
                values: new object[,]
                {
                    { new Guid("06145882-a461-4db9-aadb-1821c8d2f47d"), 0, "e39ce56e-4583-40fd-b245-be8e28fddd92", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7107), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user2@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7107), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAENy8THdmnF7shdEqJufB3jBe0BKfhv7XJDCPp508y4oD75IUagM9klDwiU1gvQEyHQ==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "b4c01700-8e6e-47dd-a135-9b0e12df28f7", "user2" },
                    { new Guid("0bd4faf3-019d-4d81-b013-dc0c6a4c5c86"), 0, "495fad26-64da-4d97-a09a-d3d4582b9c6a", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7101), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "stylist@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7101), new TimeSpan(0, 0, 0, 0, 0)), false, null, "STYLIST@EXAMPLE.COM", "STYLIST@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEAOf4V/jCCu021Osf89OAfXZh4OpZ/BSeh8kMzFLtXkt10F/YzERte/4bTT0b660Tw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "48a1d020-8348-4342-833a-fb2f96503ab8", "stylist" },
                    { new Guid("0e6aa063-0539-4c59-a2f6-34fe46e24cf0"), 0, "7930488c-0c89-409c-9e04-b360fb64ead7", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7111), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user3@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7113), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER3@EXAMPLE.COM", "USER3@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEFrRh+gZaxqBwGuBkI9EiMGM0ObF1WenK6Jqv2tp25ic98uOJ5vrbluiTYer8fcZrg==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "761173f9-f22e-4e72-8bf2-b2ed82a3a655", "user3" },
                    { new Guid("1eb285d2-6913-4d4a-8087-d16432a9d4e1"), 0, "272d468f-07ef-4e27-bc42-b8cffef96a69", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7088), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7090), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEDSFHGnPb9uUSBh7LyjDD9I0eNgLybHYCn4OPdYxVO3PuzuIZ+jhH07cckN2HN6ggw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "761173f9-f22e-4e72-8bf2-b2ed82a3a655", "user" },
                    { new Guid("333d1684-fc3c-4d31-88e8-da337ab9d1ff"), 0, "f9605d75-0b3d-4348-91ba-b96a3e16b36d", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7096), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "manager@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7096), new TimeSpan(0, 0, 0, 0, 0)), false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEDegILOoKk9URvK5fPfomADlQAfmBtlMq5ezcWZCzonQf2AMHqnBzY1bGW+CaSRljA==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "26e27df5-2eb6-49cf-8004-1260482736c4", "manager" },
                    { new Guid("60defcd1-5dcc-4d23-b42c-8a2c6a207f80"), 0, "956d73ba-44b9-4524-bfeb-c84e2552d5cd", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7117), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user4@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7117), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEAyGlM4r5Dzb8Sf5CTr/NBkvZVz3JwbBzcsFAcOWxf7m0J2TRdn6OPhIje797Ea0Og==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "26e27df5-2eb6-49cf-8004-1260482736c4", "user4" },
                    { new Guid("6ccbf19b-1e6e-4688-8314-58aaf693f7f4"), 0, "4b9e2b52-2a1a-4c9a-8571-1686d63bb831", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7078), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "admin@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7079), new TimeSpan(0, 0, 0, 0, 0)), false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEJZ2dzsApnbD54pNkJ8TAyTYDpR/A48Zbo+FilAxylWPxI4Rr37xLVXsJmWguEhyZg==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "b4c01700-8e6e-47dd-a135-9b0e12df28f7", "admin" },
                    { new Guid("d0df8c7b-b8fe-4c58-b255-959f4d9f4626"), 0, "5c7aa11e-b649-4806-b071-e3fcd1a8ef41", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7122), new TimeSpan(0, 0, 0, 0, 0)), null, null, 0m, "user5@example.com", true, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7122), new TimeSpan(0, 0, 0, 0, 0)), false, null, "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", null, null, null, null, "", "AQAAAAIAAYagAAAAEFNI4R3od7nBj8CF1tgUootzPsG6XA3o06N1cWME1eMwQ+paNkuppqnHIjxyRS1+aw==", null, false, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "48a1d020-8348-4342-833a-fb2f96503ab8", "user5" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "LastUpdatedBy", "LastUpdatedTime", "Name", "Price", "ServiceImage", "ShopId", "TimeService", "Type" },
                values: new object[,]
                {
                    { "0d7fb8b4-d4de-4b36-98d1-2982e499aaf4", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8720), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A stylish haircut to refresh your look.", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8720), new TimeSpan(0, 0, 0, 0, 0)), "Hair Cut", 25000.00m, null, "243daa06-14ab-457e-b852-e0c77544f803", 30, "Hair" },
                    { "10f54908-9d8a-4744-ad0e-ede89b5ddeaf", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8736), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A neat beard trimming service.", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8737), new TimeSpan(0, 0, 0, 0, 0)), "Beard Trim", 15000.00m, null, "243daa06-14ab-457e-b852-e0c77544f803", 20, "Beard" },
                    { "32cc148d-e69d-44b7-84a8-3ea5bf0c4f99", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8729), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A premium hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8729), new TimeSpan(0, 0, 0, 0, 0)), "Premium Hair Coloring", 100000.00m, null, "243daa06-14ab-457e-b852-e0c77544f803", 60, "Hair" },
                    { "53d7e913-bae2-49aa-81cf-987376163807", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8733), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A professional hair styling service.", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8733), new TimeSpan(0, 0, 0, 0, 0)), "Hair Styling", 20000.00m, null, "243daa06-14ab-457e-b852-e0c77544f803", 45, "Hair" },
                    { "5b05af43-b348-4333-8cfd-ad6080c36991", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8751), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A soothing scalp treatment.", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8751), new TimeSpan(0, 0, 0, 0, 0)), "Scalp Treatment", 45000.00m, null, "243daa06-14ab-457e-b852-e0c77544f803", 40, "Hair" },
                    { "6368021d-810f-4555-8dbf-c5863c651fa9", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8740), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A clean and smooth shaving service.", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8740), new TimeSpan(0, 0, 0, 0, 0)), "Shave", 12000.00m, null, "243daa06-14ab-457e-b852-e0c77544f803", 15, "Beard" },
                    { "928cf13d-7758-400c-a415-f5cfedd72ee8", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8725), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A complete hair coloring service.", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8725), new TimeSpan(0, 0, 0, 0, 0)), "Hair Coloring", 50000.00m, null, "243daa06-14ab-457e-b852-e0c77544f803", 30, "Hair" },
                    { "bb142c0e-88bb-400d-a65a-7ef94df2d30f", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8747), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A rejuvenating facial service.", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8747), new TimeSpan(0, 0, 0, 0, 0)), "Facial", 40000.00m, null, "243daa06-14ab-457e-b852-e0c77544f803", 50, "Skin" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { new Guid("e62f5f29-f4bd-4983-81b7-71801d31c954"), new Guid("06145882-a461-4db9-aadb-1821c8d2f47d"), "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7346), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7347), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("28e68c49-6fb2-421f-908c-aadfaf78ca2b"), new Guid("0bd4faf3-019d-4d81-b013-dc0c6a4c5c86"), "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7343), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7344), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e62f5f29-f4bd-4983-81b7-71801d31c954"), new Guid("0e6aa063-0539-4c59-a2f6-34fe46e24cf0"), "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7349), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7350), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e62f5f29-f4bd-4983-81b7-71801d31c954"), new Guid("1eb285d2-6913-4d4a-8087-d16432a9d4e1"), "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7272), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7336), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c82ef01f-ec6f-4c75-82f4-37362f87433e"), new Guid("333d1684-fc3c-4d31-88e8-da337ab9d1ff"), "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7340), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7340), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e62f5f29-f4bd-4983-81b7-71801d31c954"), new Guid("60defcd1-5dcc-4d23-b42c-8a2c6a207f80"), "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7450), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7458), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("911d7dbf-90c3-4daa-9f9b-26fef3d76ea1"), new Guid("6ccbf19b-1e6e-4688-8314-58aaf693f7f4"), "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7269), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7269), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e62f5f29-f4bd-4983-81b7-71801d31c954"), new Guid("d0df8c7b-b8fe-4c58-b255-959f4d9f4626"), "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7460), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(7461), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ComboServices",
                columns: new[] { "Id", "ComboId", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "ServiceId" },
                values: new object[,]
                {
                    { "72f093a547b24a789c304a4e9f80253a", "ecab9686-3128-42d3-b048-aadae4643ced", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(9053), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(9054), new TimeSpan(0, 0, 0, 0, 0)), "6368021d-810f-4555-8dbf-c5863c651fa9" },
                    { "7f4d0c0ce6404376ae60b2a9b3120002", "e1f1e843-5d44-467f-8f75-95aecbc238c6", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(9005), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(9005), new TimeSpan(0, 0, 0, 0, 0)), "32cc148d-e69d-44b7-84a8-3ea5bf0c4f99" },
                    { "983573e47326445f838b884a0ed8cba9", "ecab9686-3128-42d3-b048-aadae4643ced", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(9049), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(9050), new TimeSpan(0, 0, 0, 0, 0)), "10f54908-9d8a-4744-ad0e-ede89b5ddeaf" },
                    { "a585956487a24671936eddd1543f406b", "8f543b61-d82f-4d9f-a5d0-d3745c075ada", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(9000), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(9001), new TimeSpan(0, 0, 0, 0, 0)), "928cf13d-7758-400c-a415-f5cfedd72ee8" },
                    { "c79980b61b71423db7b3fb7679d8d8eb", "e1f1e843-5d44-467f-8f75-95aecbc238c6", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(9011), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(9011), new TimeSpan(0, 0, 0, 0, 0)), "53d7e913-bae2-49aa-81cf-987376163807" },
                    { "d457663a14eb4ee0ae98639f777477d4", "8f543b61-d82f-4d9f-a5d0-d3745c075ada", "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8996), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8996), new TimeSpan(0, 0, 0, 0, 0)), "0d7fb8b4-d4de-4b36-98d1-2982e499aaf4" }
                });

            migrationBuilder.InsertData(
                table: "SalaryPayments",
                columns: new[] { "Id", "BaseSalary", "BonusSalary", "CreatedBy", "CreatedTime", "DayOffNoPermitted", "DayOffPermitted", "DeductedSalary", "DeletedBy", "DeletedTime", "LastUpdatedBy", "LastUpdatedTime", "PaymentDate", "UserId" },
                values: new object[] { "bdb8fac5-33a7-495c-9743-f303ec02fd03", 2000.00m, 0m, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8816), new TimeSpan(0, 0, 0, 0, 0)), 0, 0, 0m, null, null, "SeedData", new DateTimeOffset(new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Unspecified).AddTicks(8817), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2024, 11, 5, 8, 39, 40, 38, DateTimeKind.Utc).AddTicks(8815), new Guid("6ccbf19b-1e6e-4688-8314-58aaf693f7f4") });

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
