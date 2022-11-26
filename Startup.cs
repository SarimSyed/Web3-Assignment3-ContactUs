using AspNetCore.ReCaptcha;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web3_Assignment3_ContactUs.Data;
using Web3_Assignment3_ContactUs.Services;

namespace Web3_Assignment3_ContactUs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddTransient<IEmailSender, SendGridEmailSender>();
            services.Configure<SendGridEmailSenderOptions>(options =>
            {
                options.APIKey = Configuration.GetValue<string>("ExternalProviders:SendGrid:APIKey");
                options.SenderEmail = Configuration.GetValue<string>("ExternalProviders:SendGrid:SenderEmail");
                options.SenderName = Configuration.GetValue<string>("ExternalProviders:SendGrid:SenderName");
            });
            
            services.Configure<ReCAPTCHASettings>(options =>
            {
                options.ReCAPTCHA_Secret_Key = Configuration.GetValue<string>("ExternalProviders:ReCAPTCHA:SiteKey");
                options.ReCAPTCHA_Site_Key = Configuration.GetValue<string>("ExternalProviders:ReCAPTCHA:SecretKey");
                //options.ReCAPTCHA_Secret_Key = "6Lf3jBAjAAAAANds7Nf9fmO_bp-4oCdhndeLz-Er";
                //options.ReCAPTCHA_Site_Key = "6Lf3jBAjAAAAAJ0YqF8u7SCiycnQRThG6pYY1ckL";
            });

            services.AddReCaptcha(Configuration.GetSection("ExternalProviders:ReCAPTCHA"));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
