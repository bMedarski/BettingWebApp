namespace Web.Middleware
{
	using System.Threading.Tasks;
	using BettingApp.Data;
	using BettingApp.Data.Models;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Identity;
	using Utilities;

	public class Seeder
	{
		private readonly RequestDelegate _next;
		private RoleManager<IdentityRole> _roleManager;
		private UserManager<User> _userManager;

		public Seeder(RequestDelegate next)
		{
			this._next = next;
		}
		public async Task InvokeAsync(HttpContext httpContext, BettingAppDbContext dbContext,RoleManager<IdentityRole> roleManager,UserManager<User> userManager)
		{
			this._roleManager = roleManager;
			this._userManager = userManager;
			this.SeedRoles(roleManager,userManager);
			
			await this._next(httpContext);
		}
		public void SeedRoles(RoleManager<IdentityRole> rm,UserManager<User> um)
		{
			if (!rm.RoleExistsAsync
				(GlobalConstants.UserRoleText).Result)
			{
				IdentityRole role = new IdentityRole(GlobalConstants.UserRoleText);
				IdentityResult roleResult = rm.CreateAsync(role).Result;
			}			
			if (!rm.RoleExistsAsync
				(GlobalConstants.ModeratorRoleText).Result)
			{
				IdentityRole role = new IdentityRole {Name = GlobalConstants.ModeratorRoleText};
				IdentityResult roleResult = rm.CreateAsync(role).Result;
			}
			if (!rm.RoleExistsAsync
				(GlobalConstants.AdminRoleText).Result)
			{
				IdentityRole role = new IdentityRole {Name = GlobalConstants.AdminRoleText};
				IdentityResult roleResult = rm.CreateAsync(role).Result;
			}
		}
	}
}
