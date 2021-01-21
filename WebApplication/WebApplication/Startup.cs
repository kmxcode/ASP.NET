using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication.Models;
using SignalRChat.Hubs;

namespace WebApplication
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration["Data:SportStoreProducts:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDeveloperExceptionPage(); // informacje szczegó³owe o b³êdach
            app.UseStatusCodePages(); // Wyœwietla strony ze statusem b³êdu
            app.UseStaticFiles(); // obs³uga treœci statycznych css, images, js
            app.UseElapsedTimeMiddleware();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "api";
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(routes => {

                routes.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=List}/{id?}"
                );

                routes.MapControllerRoute(
                    name: null,
                    pattern: "Product/{category}",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List",
                    }
                );

                routes.MapControllerRoute(
                    name: null,
                    pattern: "Admin/{action=Index}",
                    defaults: new
                    {
                        controller = "Admin",
                    }
                );

                routes.MapControllerRoute(
                    name: null,
                    pattern: "Chat/{action=Index}",
                    defaults: new
                    {
                        controller = "Chat",
                    }
                );

                routes.MapHub<ChatHub>("/chathub");
                routes.MapHub<CounterHub>("/counterhub");

            });
            SeedData.EnsurePopulated(app);
        }
    }
}
