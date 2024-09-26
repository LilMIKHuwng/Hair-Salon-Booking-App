using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Repositories.Entity;

namespace HairSalon.Repositories.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        /*// user
        public virtual DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
        public virtual DbSet<ApplicationRole> ApplicationRoles => Set<ApplicationRole>();
        public virtual DbSet<ApplicationUserClaims> ApplicationUserClaims => Set<ApplicationUserClaims>();
        public virtual DbSet<ApplicationUserRoles> ApplicationUserRoles => Set<ApplicationUserRoles>();
        public virtual DbSet<ApplicationUserLogins> ApplicationUserLogins => Set<ApplicationUserLogins>();
        public virtual DbSet<ApplicationRoleClaims> ApplicationRoleClaims => Set<ApplicationRoleClaims>();
        public virtual DbSet<ApplicationUserTokens> ApplicationUserTokens => Set<ApplicationUserTokens>();

        public virtual DbSet<UserInfo> UserInfos => Set<UserInfo>();*/

		public virtual DbSet<Role> Roles { get; set; }
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Shop> Shops { get; set; }
		public virtual DbSet<Service> Services { get; set; }
		public virtual DbSet<Appointment> Appointments { get; set; }
		public virtual DbSet<SalaryPayment> SalaryPayments { get; set; }
		public virtual DbSet<ServiceAppointment> ServiceAppointments { get; set; }
		public virtual DbSet<Feedback> Feedbacks { get; set; }
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
			// Cấu hình mối quan hệ giữa Appointment và User cho Stylist
			modelBuilder.Entity<Appointment>()
				.HasOne(a => a.Stylist)
				.WithMany() // Stylist không cần danh sách các Appointment
				.HasForeignKey(a => a.StylistId)
				.OnDelete(DeleteBehavior.Restrict); // Hoặc bạn có thể chọn hành vi khác như Cascade hoặc SetNull

			/*// Định nghĩa khóa chính cho ApplicationUserLogins
			modelBuilder.Entity<ApplicationUserLogins>()
				.HasKey(login => new { login.UserId, login.LoginProvider, login.ProviderKey });

			// Định nghĩa khóa chính cho ApplicationUserRoles
			modelBuilder.Entity<ApplicationUserRoles>()
				.HasKey(role => new { role.UserId, role.RoleId });

			// Định nghĩa khóa chính cho ApplicationUserTokens
			modelBuilder.Entity<ApplicationUserTokens>()
				.HasKey(token => new { token.UserId, token.LoginProvider, token.Name });*/
		}


	}
}
