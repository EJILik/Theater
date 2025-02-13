using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.Areas.Identity;
using Theater.Data;
using Theater.Data.Interfaces;
using Theater.Data.Models;
using Theater.Data.Repository;

namespace Theater
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
			services.AddDbContext<AppDBContent>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));
			services.AddDatabaseDeveloperPageExceptionFilter();
			services.AddDefaultIdentity<ApplicationIdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<AppDBContent>();
			services.AddRazorPages();

			services.AddTransient<IPerformance, PerformanceRepository>();
			services.AddTransient<IGenre, GenreRepository>();
			services.AddTransient<IScene, SceneRepository>();
			services.AddTransient<IPlace, PlaceRepository>();
			services.AddTransient<ISchedule, ScheduleRepository>();
			services.AddTransient<IPerformanceActor, PerformanceActorRepository>();
			services.AddTransient<IActorsList, ActorsListRepository>();
			services.AddTransient<IScenePart, ScenePartRepository>();
			services.AddTransient<ITicket, TicketRepository>();
			services.AddTransient<IAllOrders, OrderRepository>();
			services.AddTransient<IShopCartItem, ShopCartItemRepository>();

			//services.AddDistributedMemoryCache();

			services.AddMvc(options => options.EnableEndpointRouting = false);


			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped(sp => Schedule.GetSchedule(sp));
			services.AddScoped(sp => ShopCart.GetCart(sp));


			services.AddMvc();
			services.AddDistributedMemoryCache();

			services.AddMemoryCache();
			services.AddSession();
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
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseSession();


			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

            app.UseMvc(routes =>
            {
               routes.MapRoute(
               name: "default",
               template: "{controller=Home}/{action=Index}/{id?}");
            });



            app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
			});
		}
	}
}
