using HairSalonBE.API;

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
            builder.Services.AddConfig(builder.Configuration);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add session services
            builder.Services.AddDistributedMemoryCache(); // Required for session management
            builder.Services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
                options.Cookie.HttpOnly = true; // Set cookie as HTTP only
                options.Cookie.IsEssential = true; // Mark cookie as essential
            });

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

            // Use session middleware
            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute("default", "api/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();

                // Redirect root URL to the login page
                endpoints.MapGet("/", context =>
                {
                    context.Response.Redirect("/Login");
                    return Task.CompletedTask;
                });
            });

            app.Run();
		}
	}
}
