using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Web
{
	using BettingApp.Data;
	using BettingApp.Data.Common;
	using BettingApp.Data.Models;
	using BettingApp.Services.DataServices;
	using BettingApp.Services.DataServices.Contracts;
	using BettingApp.Services.Mapping;
	using BettingApp.Services.ViewModels.Competition;
	using Controllers;

	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			AutoMapperConfig.RegisterMappings(
				typeof(CreateCompetitionInputModel).Assembly
				);
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddDbContext<BettingAppDbContext>(options =>
				options.UseSqlServer(
					this.Configuration.GetConnectionString("DefaultConnection")));

			services.AddDefaultIdentity<User>(
					options =>
					{
						options.Password.RequiredLength = 6;
						options.Password.RequireLowercase = false;
						options.Password.RequireNonAlphanumeric = false;
						options.Password.RequireUppercase = false;
						options.Password.RequireDigit = false;
					}
				)
				.AddEntityFrameworkStores<BettingAppDbContext>();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
			services.AddScoped<ICompetitionsService, CompetitionsService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
