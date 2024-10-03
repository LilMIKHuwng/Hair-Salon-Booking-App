using Microsoft.EntityFrameworkCore;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Repositories.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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
        }
    }
}