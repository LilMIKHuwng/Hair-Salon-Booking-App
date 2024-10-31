using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Repositories.Context;
using HairSalon.Repositories.Entity;
using HairSalon.Repositories.UOW;
using HairSalon.Services.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HairSalon.RazorPage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline
            Configure(app);

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Register HttpClient for dependency injection
            services.AddHttpClient();

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("HairSalonDb"));
            });

            // Config JWT Authentication
            var jwtSettings = configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                x.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                        return Task.CompletedTask;
                    }
                };
            })
            .AddCookie("MyCookieAuth", options =>
            {
                options.LoginPath = "/Login/Login"; // Set the login path
                options.AccessDeniedPath = "/AccessDenied"; // Optional: add access denied page
            });

            // Register Identity services
            services.AddIdentity<ApplicationUsers, ApplicationRoles>()
                .AddEntityFrameworkStores<DatabaseContext>() // Make sure to use the correct DbContext
                .AddDefaultTokenProviders();

            // Register IUnitOfWork and other services
            services.AddScoped<IUnitOfWork, UnitOfWork>(); // Ensure this is added
            services.AddScoped<TokenService>();

            // Add Razor Pages
            services.AddRazorPages();

            // Add logging
            services.AddLogging(config =>
            {
                config.AddDebug();
                config.AddConsole();
            });

            // CORS policy (optional)
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
        }

        private static void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Enable CORS (if configured)
            app.UseCors("AllowAllOrigins");

            // Enable authentication and authorization middleware
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            // Redirect to Login or Index based on authentication status
            app.MapGet("/", async context =>
            {
                if (!context.User.Identity?.IsAuthenticated ?? true) // Check if user is not authenticated
                {
                    context.Response.Redirect("/Login/Login");
                }
                else
                {
                    context.Response.Redirect("/Index"); // Redirect to Index if authenticated
                }
            });
        }
    }
}
