using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Repositories.Context;
using HairSalon.Repositories.UOW;
using HairSalon.Services.Service;
using HairSalonBE.API;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.RazorPage
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			var configuration = builder.Configuration;
			builder.Services.AddHttpContextAccessor();
			// Add services to the container.
			builder.Services.AddRazorPages();
			builder.Services.AddDbContext<DatabaseContext>(options =>
			{
				options.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("HairSalonDb"));
			});
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
			builder.Services.AddScoped<IRoleService, RoleService>();
			builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapRazorPages();

			app.Run();
		}
	}
}
