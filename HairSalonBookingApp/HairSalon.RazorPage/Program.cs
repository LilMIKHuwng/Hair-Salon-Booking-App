using HairSalon.Contract.Services.Interface;
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
            builder.Services.AddDistributedMemoryCache(); 
            builder.Services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30); 
                options.Cookie.HttpOnly = true; 
                options.Cookie.IsEssential = true; 
            });

            var app = builder.Build();

			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

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

			// Run the email and auto-cancel tasks in a background thread
			Task.Run(async () =>
			{
				using var scope = app.Services.CreateScope();
				var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
				var appointmentService = scope.ServiceProvider.GetRequiredService<IAppointmentService>();

				var emailTaskDelay = TimeSpan.FromHours(12); 
				var autoCancelTaskDelay = TimeSpan.FromMinutes(5); 

				var nextEmailRun = DateTime.UtcNow.Add(emailTaskDelay);
				var nextAutoCancelRun = DateTime.UtcNow.Add(autoCancelTaskDelay);

				while (true)
				{
					try
					{
						if (DateTime.UtcNow >= nextEmailRun)
						{
							await emailService.SendEmailToConfirmDateAsync();
							nextEmailRun = DateTime.UtcNow.Add(emailTaskDelay);
						}

						if (DateTime.UtcNow >= nextAutoCancelRun)
						{
							await appointmentService.AutoCheckCancelAppointmentAsync();
							nextAutoCancelRun = DateTime.UtcNow.Add(autoCancelTaskDelay);
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Error during background tasks: {ex.Message}");
					}

					await Task.Delay(TimeSpan.FromMinutes(1));
				}
			});

			app.Run();
		}
	}
}
