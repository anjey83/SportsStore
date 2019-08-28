using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;
using Microsoft.AspNetCore.Identity;

namespace SportsStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:SportStoreProducts:ConnectionString"]));
            services.AddDbContext<AppIdentityDbContext>( options => options.UseSqlServer( Configuration["Data:SportStoreIdentity:ConnectionString"] ) );
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();
            services.AddTransient<IProductRepository, EFProductRepository>();
            //specifies that the same object should be used to satisfy related requests for Cart instances
            services.AddScoped<Cart>( sp => SessionCart.GetCart( sp ) );
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddMvc();
            //sets up the in-memory data store
            services.AddMemoryCache();
            //registers the services used to access session data
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //automatically associate requests with sessions when they arrive from the client.
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes => 
            {
                routes.MapRoute(
                    name:null,
                    template: "{category}/Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List" }
                    );
                routes.MapRoute(
                    name:null,
                    template: "Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 }
                    );
                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 }
                    );
                routes.MapRoute( 
                    name: null,
                    template: "",
                    defaults: new { controller = "Product", action = "List", productPage = 1 } );
                routes.MapRoute(
                    name: "pagination",
                    template: "Produkty/Strona{productPage}",
                    defaults: new { Controller = "Product", action = "List" } );

                routes.MapRoute(name: "default", template: "{controller=Product}/{action=List}/{id?}");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
