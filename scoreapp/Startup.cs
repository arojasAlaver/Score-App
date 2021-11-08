using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using scoreapp.data;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebMarkupMin.AspNetCore5;
using Microsoft.AspNetCore.Http.Features;
using scoreapp.data.Services.Classes;
using scoreapp.data.Services.Interfaces;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Authorization;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace scoreapp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Enviroment = environment;
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Debug)
                .Enrich.FromLogContext()
                .WriteTo.File(Path.Combine(Enviroment.WebRootPath, Configuration["LogFilePath"], $"{DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss_tt")}.txt"))
                .CreateLogger();
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Enviroment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages().AddMvcOptions(auth => auth.Filters.Add(new AuthorizeFilter()))
                .AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Configs/Configs", "081663df-1745-485f-a8d4-6f9bb39f0042");
                options.Conventions.AddPageRoute("/Users/Users", "cfb24a38-05ba-4155-8727-a1e3301af9f2");
                options.Conventions.AddPageRoute("/Users/UserEdit", "cfb24a38-05ba-4155-8727-a1e3301af9f3/{Id}");
                options.Conventions.AddPageRoute("/Users/UserRole", "f83823e1-081f-46d4-881e-854381d520bd/{Id}");
                options.Conventions.AddPageRoute("/Roles/RolesManagment", "7e793c11-acc7-4cf5-8592-bc2025f529c7");
                options.Conventions.AddPageRoute("/Roles/PermissionManagment", "478d5d45-d8d5-4433-bb8e-451bf62b6d61/{Id}");
                options.Conventions.AddPageRoute("/Dashboard", "75e56f57-3036-460f-b3c4-d3789e0fd5fc");
                options.Conventions.AddPageRoute("/Applications/Index", "6b4ad353-c211-4849-a8ba-a70e4bdfdb0c");
                options.Conventions.AddPageRoute("/Variables/Index", "9e4256db-5990-4151-a88e-e1d490482410");
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Login";
                options.AccessDeniedPath = "/Error";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(Convert.ToInt32(Configuration["ExpireInnactiveSessionTime"]));
                options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddDataProtection();
            services.AddHttpContextAccessor();
            services.AddLogging(Config => Config.AddSerilog(dispose: true));
            ILogger<Startup> _log = new LoggerFactory().CreateLogger<Startup>();

            services.AddEntityFrameworkSqlServer();

            services.AddDbContextPool<Context>((ServiceProvider, Options) =>
            {
                Options.UseSqlServer(Configuration.GetConnectionString("SQLServer1"));
                Options.UseInternalServiceProvider(ServiceProvider);
                Options.ConfigureWarnings(warning => _log.LogError(RelationalEventId.MultipleCollectionIncludeWarning.ToString()));
            });

            services.AddWebMarkupMin(
                options =>
                {
                    options.AllowCompressionInDevelopmentEnvironment = true;
                    options.AllowMinificationInDevelopmentEnvironment = true;
                    
                }).AddHtmlMinification(options =>
                {
                    options.MinificationSettings.RemoveRedundantAttributes = true;
                    options.MinificationSettings.RemoveHttpProtocolFromAttributes = true;
                    options.MinificationSettings.RemoveHttpsProtocolFromAttributes = true;
                });


            services.Configure<FormOptions>(options => 
            {
                options.ValueCountLimit = int.MaxValue;
            });

            services.AddScoped<ISendData, SendDataClass>();
            services.AddScoped<ISettings, SettingsClass>();
            services.AddScoped<IAuthentication, AuthenticationClass>();
            services.AddScoped<IUsers, UsersClass>();
            services.AddScoped<IEmailNotify, EmailNotifyClass>();


            services.AddAuthorization(options => 
            {
                options.AddPolicy("Config",policy => policy.RequireAssertion(context => 
                {
                    
                    return context.User.HasClaim("Permission", "Permission.Config.View") || context.User.IsInRole("Administrator");
                }));

                options.AddPolicy("Users", policy => policy.RequireAssertion(context =>
                {
                    return context.User.HasClaim("Permission", "Permission.User.View") || context.User.IsInRole("Administrator");
                }));

                options.AddPolicy("UsersCreate", policy => policy.RequireAssertion(context =>
                {
                    return context.User.HasClaim("Permission", "Permission.User.Create") || context.User.IsInRole("Administrator");
                }));

                options.AddPolicy("UsersEdit", policy => policy.RequireAssertion(context =>
                {
                    return context.User.HasClaim("Permission", "Permission.User.Edit") || context.User.IsInRole("Administrator");
                }));

                options.AddPolicy("Roles", policy => policy.RequireAssertion(context =>
                {
                    return context.User.HasClaim("Permission", "Permission.Role.View") || context.User.IsInRole("Administrator");
                }));

                options.AddPolicy("RolesCreate", policy => policy.RequireAssertion(context =>
                {
                    return context.User.HasClaim("Permission", "Permission.Role.Create") || context.User.IsInRole("Administrator");
                }));

                options.AddPolicy("RolesEdit", policy => policy.RequireAssertion(context =>
                {
                    return context.User.HasClaim("Permission", "Permission.Role.Edit") || context.User.IsInRole("Administrator");
                }));

                options.AddPolicy("Permissions", policy => policy.RequireAssertion(context =>
                {
                    return context.User.HasClaim("Permission", "Permission.Permission.View") || context.User.IsInRole("Administrator");
                }));

                options.AddPolicy("Application", policy => policy.RequireAssertion(context =>
                {
                    return context.User.HasClaim("Permission", "Permission.Applications.View") || context.User.IsInRole("Administrator");
                }));


                options.AddPolicy("GroupVariables", policy => policy.RequireAssertion(context =>
                {
                    return context.User.HasClaim("Permission", "Permission.GroupVariable.View") || context.User.IsInRole("Administrator");
                }));
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerfactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseWebMarkupMin();
            loggerfactory.AddSerilog();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
