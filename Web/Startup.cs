﻿namespace Web
{
	using System.Reflection;
	using AutoMapper;
	using BettingApp.Data;
	using BettingApp.Data.Common;
	using BettingApp.Data.Models;
	using BettingApp.Services.DataServices;
	using BettingApp.Services.DataServices.Contracts;
	using BettingApp.Services.Mapping;
	using BettingApp.Services.ViewModels.Competition;
	using BettingApp.Services.ViewModels.User;
	using Filters;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Middleware.Extensions;
	using Newtonsoft.Json.Serialization;

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
				typeof(AddCompetitionInputModel).Assembly,
				Assembly.GetExecutingAssembly());

			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddDbContext<BettingAppDbContext>(options =>
				options.UseSqlServer(
					this.Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<User,IdentityRole>(
					options =>
					{
						options.Password.RequireDigit = false;
						options.Password.RequireLowercase = false;
						options.Password.RequireNonAlphanumeric = false;
						options.Password.RequireUppercase = false;
						options.Password.RequiredLength = 3;
						options.Password.RequiredUniqueChars = 1;
					}
				)			
				.AddDefaultTokenProviders()
				.AddEntityFrameworkStores<BettingAppDbContext>();

			services.AddMvc(
					options =>
					{
						options.Filters.Add(typeof(ValidateModelStateAttribute));
					}
				)
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
				.AddJsonOptions(options =>
				options.SerializerSettings.ContractResolver = new DefaultContractResolver());

			services.AddKendo();

			services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
			services.AddScoped<ICompetitionsService, CompetitionsService>();
			services.AddScoped<ICompetitorsService, CompetitorsService>();
			services.AddScoped<ISeasonsService, SeasonsService>();
			services.AddScoped<ISportsService, SportsService>();
			services.AddScoped<IUsersService,UsersService>();

			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = $"/Administration/Users/Login";
				options.LogoutPath = $"/Administration/Users/Logout";
				options.AccessDeniedPath = $"/Administration/Users/AccessDenied";
			});
			services.AddAutoMapper(config =>
			{
				//config.CreateMap<CreateEventViewModel, Season>().ForMember(s=>s.TicketPrice,opt=>opt.MapFrom(d=>d.PricePerTicket));
				config.CreateMap<RegisterUserInputModel, User>();
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env,RoleManager<IdentityRole> roleManager,UserManager<User> userManager)
		{
			if (env.IsDevelopment())
			{
				app.UseStatusCodePagesWithReExecute("/Errors/Status/{0}");
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseStatusCodePagesWithReExecute("/Errors/Status/{0}");
				app.UseHsts();
			}
			app.UseSeeder();
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "areas",
					template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
				);
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
