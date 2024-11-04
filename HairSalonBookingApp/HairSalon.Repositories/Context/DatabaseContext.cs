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
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Combo> Combos { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

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

            modelBuilder.Entity<Message>(message =>
            {
                message.HasOne(x => x.Recipient)
                    .WithMany(x => x.MessageReceived)
                    .HasForeignKey(x => x.RecipientId)
                    .OnDelete(DeleteBehavior.Restrict);

                message.HasOne(x => x.Sender)
                    .WithMany(x => x.MessageSent)
                    .HasForeignKey(x => x.SenderId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
                
            
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
            var userInfoId3 = Guid.NewGuid().ToString();
            var userInfoId4 = Guid.NewGuid().ToString();

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
                },
                new UserInfo
                {
                    Id = userInfoId3,
                    Firstname = "Dev",
                    Lastname = "Nguyen",
                    BankAccount = "123456798",
                    BankAccountName = "Dev Nguyen",
                    Bank = "Bank c",
                    Point = 0,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new UserInfo
                {
                    Id = userInfoId4,
                    Firstname = "Dan",
                    Lastname = "Tran",
                    BankAccount = "123456987",
                    BankAccountName = "Dan Tran",
                    Bank = "Bank D",
                    Point = 0,
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
            var userId3 = Guid.NewGuid();
            var userId4 = Guid.NewGuid();
            var userId5 = Guid.NewGuid();
            var userId6 = Guid.NewGuid();
            var userId7 = Guid.NewGuid();
            var userId8 = Guid.NewGuid();

            var adminUser = new ApplicationUsers { Id = userId1 };
            var normalUser = new ApplicationUsers { Id = userId2 };
            var managerUser = new ApplicationUsers { Id = userId3 };
            var stylistUser = new ApplicationUsers { Id = userId4 };
            var additionalUser1 = new ApplicationUsers { Id = userId5 };
            var additionalUser2 = new ApplicationUsers { Id = userId6 };
            var additionalUser3 = new ApplicationUsers { Id = userId7 };
            var additionalUser4 = new ApplicationUsers { Id = userId8 };

            // Hash passwords
            var adminPasswordHash = passwordHasher.HashPassword(adminUser, "123");
            var userPasswordHash = passwordHasher.HashPassword(normalUser, "123");
            var managerPasswordHash = passwordHasher.HashPassword(managerUser, "123");
            var stylistPasswordHash = passwordHasher.HashPassword(stylistUser, "123");
            var additionalUserPasswordHash1 = passwordHasher.HashPassword(additionalUser1, "123");
            var additionalUserPasswordHash2 = passwordHasher.HashPassword(additionalUser2, "123");
            var additionalUserPasswordHash3 = passwordHasher.HashPassword(additionalUser3, "123");
            var additionalUserPasswordHash4 = passwordHasher.HashPassword(additionalUser4, "123");

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
                },
                new ApplicationUsers
                {
                    Id = userId3,
                    UserName = "manager",
                    NormalizedUserName = "MANAGER@EXAMPLE.COM",
                    Email = "manager@example.com",
                    NormalizedEmail = "MANAGER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = managerPasswordHash,
                    UserInfoId = userInfoId3,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ApplicationUsers
                {
                    Id = userId4,
                    UserName = "stylist",
                    NormalizedUserName = "STYLIST@EXAMPLE.COM",
                    Email = "stylist@example.com",
                    NormalizedEmail = "STYLIST@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = stylistPasswordHash,
                    UserInfoId = userInfoId4,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ApplicationUsers
                {
                    Id = userId5,
                    UserName = "user2",
                    NormalizedUserName = "USER2@EXAMPLE.COM",
                    Email = "user2@example.com",
                    NormalizedEmail = "USER2@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = additionalUserPasswordHash1,
                    UserInfoId = userInfoId1,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ApplicationUsers
                {
                    Id = userId6,
                    UserName = "user3",
                    NormalizedUserName = "USER3@EXAMPLE.COM",
                    Email = "user3@example.com",
                    NormalizedEmail = "USER3@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = additionalUserPasswordHash2,
                    UserInfoId = userInfoId2,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ApplicationUsers
                {
                    Id = userId7,
                    UserName = "user4",
                    NormalizedUserName = "USER4@EXAMPLE.COM",
                    Email = "user4@example.com",
                    NormalizedEmail = "USER4@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = additionalUserPasswordHash3,
                    UserInfoId = userInfoId3,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ApplicationUsers
                {
                    Id = userId8,
                    UserName = "user5",
                    NormalizedUserName = "USER5@EXAMPLE.COM",
                    Email = "user5@example.com",
                    NormalizedEmail = "USER5@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = additionalUserPasswordHash4,
                    UserInfoId = userInfoId4,
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
                },
                new ApplicationUserRoles
                {
                    UserId = userId3,
                    RoleId = roleIdManager,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ApplicationUserRoles
                {
                    UserId = userId4,
                    RoleId = roleIdStylist,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ApplicationUserRoles
                {
                    UserId = userId5,
                    RoleId = roleIdUser,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ApplicationUserRoles
                {
                    UserId = userId6,
                    RoleId = roleIdUser,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ApplicationUserRoles
                {
                    UserId = userId7,
                    RoleId = roleIdUser,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ApplicationUserRoles
                {
                    UserId = userId8,
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
            var serviceId3 = Guid.NewGuid().ToString();
            var serviceId4 = Guid.NewGuid().ToString();
            var serviceId5 = Guid.NewGuid().ToString();
            var serviceId6 = Guid.NewGuid().ToString();
            var serviceId7 = Guid.NewGuid().ToString();
            var serviceId8 = Guid.NewGuid().ToString();

            modelBuilder.Entity<Service>().HasData(
                new Service
                {
                    Id = serviceId1,
                    Name = "Hair Cut",
                    Type = "Hair",
                    Price = 25000.00m,
                    Description = "A stylish haircut to refresh your look.",
                    ShopId = shopId,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    TimeService = 30,
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new Service
                {
                    Id = serviceId2,
                    Name = "Hair Coloring",
                    Type = "Hair",
                    Price = 50000.00m,
                    Description = "A complete hair coloring service.",
                    ShopId = shopId,
                    CreatedBy = "SeedData",
                    TimeService = 30,
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new Service
                {
                    Id = serviceId3,
                    Name = "Premium Hair Coloring",
                    Type = "Hair",
                    Price = 100000.00m,
                    Description = "A premium hair coloring service.",
                    ShopId = shopId,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    TimeService = 60,
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new Service
                {
                    Id = serviceId4,
                    Name = "Hair Styling",
                    Type = "Hair",
                    Price = 20000.00m,
                    Description = "A professional hair styling service.",
                    ShopId = shopId,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    TimeService = 45,
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new Service
                {
                    Id = serviceId5,
                    Name = "Beard Trim",
                    Type = "Beard",
                    Price = 15000.00m,
                    Description = "A neat beard trimming service.",
                    ShopId = shopId,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    TimeService = 20,
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new Service
                {
                    Id = serviceId6,
                    Name = "Shave",
                    Type = "Beard",
                    Price = 12000.00m,
                    Description = "A clean and smooth shaving service.",
                    ShopId = shopId,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    TimeService = 15,
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new Service
                {
                    Id = serviceId7,
                    Name = "Facial",
                    Type = "Skin",
                    Price = 40000.00m,
                    Description = "A rejuvenating facial service.",
                    ShopId = shopId,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    TimeService = 50,
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new Service
                {
                    Id = serviceId8,
                    Name = "Scalp Treatment",
                    Type = "Hair",
                    Price = 45000.00m,
                    Description = "A soothing scalp treatment.",
                    ShopId = shopId,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    TimeService = 40,
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                }
            );

            // 7. Appointment
            /*var appointmentId = Guid.NewGuid().ToString();
            var appointmentId1 = Guid.NewGuid().ToString();
            var appointmentId2 = Guid.NewGuid().ToString();
            var appointmentId3 = Guid.NewGuid().ToString();

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = appointmentId,
                    UserId = userId1,
                    StylistId = userId2,
                    StatusForAppointment = "Pending",
                    PointsEarned = 10,
                    AppointmentDate = DateTime.UtcNow.AddDays(1),
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow,
                    TotalAmount = 100000.00m
                },
                new Appointment
                {
                    Id = appointmentId1,
                    UserId = userId3,
                    StylistId = userId4, // Stylist assigned correctly
                    StatusForAppointment = "Scheduled",
                    PointsEarned = 15,
                    TotalTime = 75,
                    AppointmentDate = DateTime.UtcNow.AddDays(2),
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow,
                    TotalAmount = 65000.00m
                },
                new Appointment
                {
                    Id = appointmentId2,
                    UserId = userId5,
                    StylistId = userId4, // Stylist assigned correctly
                    StatusForAppointment = "Pending",
                    PointsEarned = 12,
                    TotalTime = 45,
                    AppointmentDate = DateTime.UtcNow.AddDays(3),
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow,
                    TotalAmount = 200000.00m
                },
                new Appointment
                {
                    Id = appointmentId3,
                    UserId = userId7,
                    StylistId = userId4, // Stylist assigned correctly
                    StatusForAppointment = "Completed",
                    PointsEarned = 20,
                    TotalTime = 90,
                    AppointmentDate = DateTime.UtcNow.AddDays(4),
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow,
                    TotalAmount = 150000.00m
                }
            );*/

            // 8. Payment
            /*var paymentId = Guid.NewGuid().ToString();

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
            );*/

            // 9. ServiceAppointment
            /*var serviceAppointmentId = Guid.NewGuid().ToString();

            modelBuilder.Entity<ServiceAppointment>().HasData(
                new ServiceAppointment
                {
                    Id = serviceAppointmentId,
                    ServiceId = serviceId1,
                    AppointmentId = appointmentId,
                    Description = "Basic haircut",
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                }
            );*/

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

            // 11. Combo
            var comboId1 = Guid.NewGuid().ToString();
            var comboId2 = Guid.NewGuid().ToString();
            var comboId3 = Guid.NewGuid().ToString();

            modelBuilder.Entity<Combo>().HasData(
                new Combo
                {
                    Id = comboId1,
                    Name = "Basic Hair Combo",
                    TotalPrice = 40000.00m,
                    TimeCombo = 60,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new Combo
                {
                    Id = comboId2,
                    Name = "Deluxe Hair Combo",
                    TotalPrice = 80000.00m,
                    TimeCombo = 120,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new Combo
                {
                    Id = comboId3,
                    Name = "Ultimate Hair & Beard Combo",
                    TotalPrice = 120000.00m,
                    TimeCombo = 150,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                }
            );

            // 12. ComboService
            modelBuilder.Entity<ComboServices>().HasData(
                new ComboServices
                {
                    Id = Guid.NewGuid().ToString("N"),
                    ServiceId = serviceId1,
                    ComboId = comboId1,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ComboServices
                {
                    Id = Guid.NewGuid().ToString("N"),
                    ServiceId = serviceId2,
                    ComboId = comboId1,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ComboServices
                {
                    Id = Guid.NewGuid().ToString("N"),
                    ServiceId = serviceId3,
                    ComboId = comboId2,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ComboServices
                {
                    Id = Guid.NewGuid().ToString("N"),
                    ServiceId = serviceId4,
                    ComboId = comboId2,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ComboServices
                {
                    Id = Guid.NewGuid().ToString("N"),
                    ServiceId = serviceId5,
                    ComboId = comboId3,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ComboServices
                {
                    Id = Guid.NewGuid().ToString("N"),
                    ServiceId = serviceId6,
                    ComboId = comboId3,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                }
            );

            // 13. ComboAppointment
            /*var comboAppointmentId1 = Guid.NewGuid().ToString();
            var comboAppointmentId2 = Guid.NewGuid().ToString();
            var comboAppointmentId3 = Guid.NewGuid().ToString();

            modelBuilder.Entity<ComboAppointment>().HasData(
                new ComboAppointment
                {
                    Id = comboAppointmentId1,
                    ComboId = comboId1, // ensure these IDs match your seeded combos
                    AppointmentId = appointmentId, // ensure these IDs match your seeded appointments
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ComboAppointment
                {
                    Id = comboAppointmentId2,
                    ComboId = comboId2,
                    AppointmentId = appointmentId1,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ComboAppointment
                {
                    Id = comboAppointmentId3,
                    ComboId = comboId3,
                    AppointmentId = appointmentId2,
                    CreatedBy = "SeedData",
                    LastUpdatedBy = "SeedData",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                }
            );*/
        }
    }
}