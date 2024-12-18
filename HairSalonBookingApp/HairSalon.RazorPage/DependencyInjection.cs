using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Services.Interface;
using HairSalon.Repositories.Context;
using HairSalon.Repositories.Entity;
using HairSalon.Services;
using HairSalon.Services.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Net.payOS;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace HairSalonBE.API
{
    public static class DependencyInjection
    {
        public static void AddConfig(this IServiceCollection services, IConfiguration configuration)
        {
            PayOS payOS = new PayOS(configuration["PayOS:PAYOS_CLIENT_ID"] ?? throw new Exception("Cannot find environment"),
                configuration["PayOS:PAYOS_API_KEY"] ?? throw new Exception("Cannot find environment"),
                configuration["PayOS:PAYOS_CHECKSUM_KEY"] ?? throw new Exception("Cannot find environment"));
            services.AddSingleton(payOS);
            services.ConfigRoute();
            services.AddDatabase(configuration);
            services.AddIdentity();
            services.AddInfrastructure(configuration);
            services.AddServices();
            services.ConfigGoogleAuthentication(configuration);
            services.ConfigFacebookAuthentication(configuration);
            services.ConfigJwt(configuration);
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
            });

            services.AddRazorPages();
            services.AddControllers();
        }
        
        public static void AddConfigRazor(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigRoute();
            services.AddServices();
            services.AddRazorPages();
        }

        public static void ConfigRoute(this IServiceCollection services)
        {
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });
        }
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("HairSalonDb"));
            });
        }

        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUsers, ApplicationRoles>(options =>
            {
            })
             .AddEntityFrameworkStores<DatabaseContext>()
             .AddDefaultTokenProviders();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<IRoleService, RoleService>()
                .AddScoped<IShopService, ShopService>()
                .AddScoped<ISalaryPaymentService, SalaryPaymentService>()
                .AddScoped<IServiceService, ServiceService>()
                .AddScoped<IAppointmentService, AppointmentService>()
                .AddScoped<IPaymentService, PaymentService>()
                .AddScoped<IAppUserRoleService, AppUserRoleService>()
                .AddScoped<IAppUserService, AppUserService>()
                .AddScoped<IEmailService, EmailService>()
                .AddScoped<TokenService>()
                .AddScoped<IPasswordHasher<ApplicationUsers>, PasswordHasher<ApplicationUsers>>()
                .AddScoped<IFeedbackService, FeedbackService>()
                .AddScoped<IVnPayService, VnPayService>()
                .AddScoped<IComboService, ComboService>()
                .AddScoped<IDashboardService, DashboardService>()
                .AddScoped<IPromotionService, PromotionService>()
                .AddScoped<IPayOSService, PayOSService>()
                ;
        }

        public static void ConfigGoogleAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication()
                .AddGoogle(GoogleOptions =>
                {
                    var googleAuthNSection = configuration.GetSection("Authentication:Google");
                    GoogleOptions.ClientId = googleAuthNSection["ClientId"];
                    GoogleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
                    GoogleOptions.CallbackPath = "/signin-google"; 
                    GoogleOptions.Events = new OAuthEvents
                    {
                        OnRemoteFailure = context =>
                        {
                            Console.WriteLine("Google OAuth error: " + context.Failure.Message);
                            context.Response.Redirect("/Login?error=" + Uri.EscapeDataString(context.Failure.Message));
                            context.HandleResponse();
                            return Task.CompletedTask;
                        }
                    };
                });
        }
        public static void ConfigFacebookAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication()
                .AddFacebook(facebookOptions =>
                {
                    var facebookAuthNSection = configuration.GetSection("Authentication:Facebook");
                    facebookOptions.AppId = facebookAuthNSection["AppId"];
                    facebookOptions.AppSecret = facebookAuthNSection["AppSecret"];
                    facebookOptions.CallbackPath = "/signin-facebook"; 
                    facebookOptions.Events = new OAuthEvents
                    {
                        OnRemoteFailure = context =>
                        {
                            Console.WriteLine("Facebook OAuth error: " + context.Failure.Message);
                            context.Response.Redirect("/Login?error=" + Uri.EscapeDataString(context.Failure.Message));
                            context.HandleResponse();
                            return Task.CompletedTask;
                        }
                    };
                });
        }
        public static void ConfigJwt(this IServiceCollection services, IConfiguration configuration)
        {
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
            });
        }
    }
}
