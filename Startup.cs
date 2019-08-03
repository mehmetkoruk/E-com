using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EticaretShoes.Interface;
using EticaretShoes.Models;
using EticaretShoes.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace EticaretShoes
{
    public class Startup
    {
        private IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
            services.AddTransient<IShoes, ShoesRepository>();
            services.AddTransient<ICart, CartRepository>();
            services.AddTransient<ICartItem, CartItemRepository>();
            services.AddTransient<IUser, UserRepository>();
            services.AddTransient<SignInManager<ApplicationUser>, SignInManager<ApplicationUser>>();
            var con = @"Server=WISSEN\SQLEXPRESS;
                        Database=ShopDb22; User Id=sa;
                          Password=123456;
                        MultipleActiveResultSets=true";
            //var con2 = @"Server=.\SQLEXPRESS;
            //            Database=ShopDb2; User Id=sa;
            //              Password=123456;
            //            MultipleActiveResultSets=true";
           
            services.AddDbContext<ApplicationIdentityContext>(x => x.UseSqlServer(Configuration.GetConnectionString("WissenConnection")));
            
            services.AddDbContext<Context>(x => x.UseSqlServer(con));
            services.AddIdentity<ApplicationUser, IdentityRole>(
              options =>
              {
                  //options.User.AllowedUserNameCharacters = "abcdefg";//sadece bu karakterlerinin girişine izin veriyor
                  options.User.RequireUniqueEmail = false;//email uniq olsun mu
                  options.Password.RequireNonAlphanumeric = false;
                  options.Password.RequiredLength = 5;
                  options.Password.RequireLowercase = false;
                  options.Password.RequireUppercase = false;
                  options.Password.RequireDigit = false;

              }).AddEntityFrameworkStores<ApplicationIdentityContext>()
              .AddDefaultTokenProviders();
            services.AddScoped<SignInManager<ApplicationUser>, SignInManager<ApplicationUser>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            SeedData.Seed(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                RequestPath = "/modules"
            });
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                 name: "default",
                 template: "{controller=Home}/{action=Index}/{id?}"
               );
            });
        }
    }
}
