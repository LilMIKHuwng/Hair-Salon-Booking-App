using Microsoft.EntityFrameworkCore;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Repositories.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace HairSalon.Repositories.Context
{

    public class DatabaseContext : IdentityDbContext<ApplicationUsers, ApplicationRoles, Guid,
        ApplicationUserClaims, ApplicationUserRoles, ApplicationUserLogins, ApplicationRoleClaims, ApplicationUserTokens>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        // user
        public virtual DbSet<ApplicationUsers> ApplicationUsers => Set<ApplicationUsers>();
        public virtual DbSet<ApplicationRoles> ApplicationRoles => Set<ApplicationRoles>();
        public virtual DbSet<ApplicationUserClaims> ApplicationUserClaims => Set<ApplicationUserClaims>();
        public virtual DbSet<ApplicationUserRoles> ApplicationUserRoles => Set<ApplicationUserRoles>();
        public virtual DbSet<ApplicationUserLogins> ApplicationUserLogins => Set<ApplicationUserLogins>();
        public virtual DbSet<ApplicationRoleClaims> ApplicationRoleClaims => Set<ApplicationRoleClaims>();
        public virtual DbSet<ApplicationUserTokens> ApplicationUserTokens => Set<ApplicationUserTokens>();

        public virtual DbSet<UserInfo> UserInfos => Set<UserInfo>();
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<SalaryPayment> SalaryPayments { get; set; }
        public virtual DbSet<ServiceAppointment> ServiceAppointments { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Stylist)
                .WithMany()
                .HasForeignKey(a => a.StylistId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUserLogins>()
                .HasKey(login => new { login.UserId, login.LoginProvider, login.ProviderKey });

            modelBuilder.Entity<ApplicationUserRoles>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
                userRole.HasOne(ur => ur.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });

            modelBuilder.Entity<ApplicationUserTokens>()
                .HasKey(token => new { token.UserId, token.LoginProvider, token.Name });
            /*============================            SEED DATA            =================================*/

            // 1. ApplicationRoles
            var roleIdAdmin = Guid.NewGuid();
            var roleIdUser = Guid.NewGuid();
            var roleIdStylist = Guid.NewGuid();
            var roleIdManager = Guid.NewGuid();

            modelBuilder.Entity<ApplicationRoles>().HasData(
                new ApplicationRoles
                {
                    Id = roleIdAdmin,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    CreatedBy = "System",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ApplicationRoles
                {
                    Id = roleIdManager,
                    Name = "Manager",
                    NormalizedName = "MANAGER",
                    CreatedBy = "System",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ApplicationRoles
                {
                    Id = roleIdStylist,
                    Name = "Stylist",
                    NormalizedName = "STYLIST",
                    CreatedBy = "System",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ApplicationRoles
                {
                    Id = roleIdUser,
                    Name = "User",
                    NormalizedName = "USER",
                    CreatedBy = "System",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                }
            );

            // 2. UserInfo
            var userInfoId1 = Guid.NewGuid().ToString();
            var userInfoId2 = Guid.NewGuid().ToString();

            modelBuilder.Entity<UserInfo>().HasData(
                new UserInfo
                {
                    Id = userInfoId1,
                    Firstname = "John",
                    Lastname = "Doe",
                    BankAccount = "123456789",
                    BankAccountName = "John Doe",
                    Bank = "Bank A",
                    Point = 100,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new UserInfo
                {
                    Id = userInfoId2,
                    Firstname = "Jane",
                    Lastname = "Smith",
                    BankAccount = "987654321",
                    BankAccountName = "Jane Smith",
                    Bank = "Bank B",
                    Point = 150,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                }
            );

            // 3. ApplicationUsers
            var passwordHasher = new PasswordHasher<ApplicationUsers>();
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();

            var adminUser = new ApplicationUsers { Id = userId1 };
            var normalUser = new ApplicationUsers { Id = userId2 };

            // Hash passwords
            var adminPasswordHash = passwordHasher.HashPassword(adminUser, "123");
            var userPasswordHash = passwordHasher.HashPassword(normalUser, "123");

            modelBuilder.Entity<ApplicationUsers>().HasData(
                new ApplicationUsers
                {
                    Id = userId1,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = adminPasswordHash,
                    UserInfoId = userInfoId1,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ApplicationUsers
                {
                    Id = userId2,
                    UserName = "user",
                    NormalizedUserName = "USER@EXAMPLE.COM",
                    Email = "user@example.com",
                    NormalizedEmail = "USER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = userPasswordHash,
                    UserInfoId = userInfoId2,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                }
            );

            // 4. ApplicationUserRoles
            modelBuilder.Entity<ApplicationUserRoles>().HasData(
                new ApplicationUserRoles
                {
                    UserId = userId1,
                    RoleId = roleIdAdmin,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ApplicationUserRoles
                {
                    UserId = userId2,
                    RoleId = roleIdUser,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                }
            );

            // 5. Shop
            var shopId = Guid.NewGuid().ToString();

            modelBuilder.Entity<Shop>().HasData(
            new Shop
            {
                Id = shopId,
                Name = "Salon A",
                Address = "123 Main St, Cityville",
                ShopEmail = "contact@salona.com",
                ShopPhone = "123-456-7890",
                OpenTime = new TimeSpan(9, 0, 0), // 09:00 AM
                CloseTime = new TimeSpan(19, 0, 0), // 07:00 PM
                Title = "Best Hair Salon in Town",
                CreatedBy = "SeedData",
                LastUpdatedBy = "SeedData",
                CreatedTime = DateTimeOffset.UtcNow,
                LastUpdatedTime = DateTimeOffset.UtcNow
            });

            // 6. Service
            var serviceId1 = Guid.NewGuid().ToString();
            var serviceId2 = Guid.NewGuid().ToString();

            modelBuilder.Entity<Service>().HasData(
                new Service
                {
                    Id = serviceId1,
                    Name = "Hair Cut",
                    Type = "Hair",
                    Price = 25.00m,
                    Description = "A stylish haircut to refresh your look.",
                    ShopId = shopId,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new Service
                {
                    Id = serviceId2,
                    Name = "Hair Coloring",
                    Type = "Hair",
                    Price = 50.00m,
                    Description = "A complete hair coloring service.",
                    ShopId = shopId,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                }
            );

            // 7. Appointment
            var appointmentId = Guid.NewGuid().ToString();

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = appointmentId,
                    UserId = userId1,
                    StylistId = userId2,
                    StatusForAppointment = "Scheduled",
                    PointsEarned = 10,
                    AppointmentDate = DateTime.UtcNow.AddDays(1),
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                }
            );

            // 8. Payment
            var paymentId = Guid.NewGuid().ToString();

            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = paymentId,
                    AppointmentId = appointmentId,
                    TotalAmount = 100.00m,
                    PaymentTime = DateTime.UtcNow,
                    PaymentMethod = "Credit Card",
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                }
            );

            // 9. ServiceAppointment
            var serviceAppointmentId = Guid.NewGuid().ToString();

            modelBuilder.Entity<ServiceAppointment>().HasData(
                new ServiceAppointment
                {
                    Id = serviceAppointmentId,
                    ServiceId = serviceId1,
                    AppointmentId = appointmentId,
                    Description = "Basic haircut",
                    Rate = 5,
                    Comment = "Excellent service!",
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                }
            );

            // 10. SalaryPayment
            var salaryPaymentId = Guid.NewGuid().ToString();

            modelBuilder.Entity<SalaryPayment>().HasData(
                new SalaryPayment
                {
                    Id = salaryPaymentId,
                    UserId = userId1,
                    BaseSalary = 2000.00m,
                    PaymentDate = DateTime.UtcNow,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                }
            );
        }
    }
}