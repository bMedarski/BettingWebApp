namespace BettingApp.Services.DataServices
{
	using System.Linq;
	using AutoMapper;
	using Contracts;
	using Data;
	using Data.Models;
	using Microsoft.AspNetCore.Identity;
	using ViewModels.User;
	using Web.Utilities;

	public class UsersService:IUsersService
	{
		private readonly IMapper _autoMapper;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly BettingAppDbContext _context;

		private SignInManager<User> SignInManager { get; }
		private UserManager<User> UserManager { get; }

		public UsersService(BettingAppDbContext context,RoleManager<IdentityRole>roleManager,SignInManager<User> signInManager, UserManager<User> userManager,IMapper autoMapper)
		{
			this._context = context;
			this._roleManager = roleManager;
			this._autoMapper = autoMapper;
			this.SignInManager = signInManager;
			this.UserManager = userManager;
		}
		public void CreateUser(RegisterUserInputModel model)
		{
			var user = this._autoMapper.Map<User>(model);
			var result = this.UserManager.CreateAsync(user, model.Password).Result;
			if (result.Succeeded)
			{
				//this.UserManager.AddToRoleAsync(user,
				//	GlobalConstants.UserRoleText).Wait();
				this.SignInUser(user, model.Password);
			}
		}

		public async void SignInUser(User user, string password)
		{
			await this.SignInManager.PasswordSignInAsync(user, password, false, false);
		}
		public async void LogoutUser()
		{
			await this.SignInManager.SignOutAsync();
		}

		//public IList<AdminPanelUsersViewModel> AdminPanelUsers()
		//{
		//	var users = new List<AdminPanelUsersViewModel>();
		//	foreach (var u in this.UserManager.Users.ToList())
		//	{
		//		var user = new AdminPanelUsersViewModel
		//		{
		//			Username = u.UserName,
		//			Id = u.Id
		//		};
		//		var roleId = this.context.UserRoles.Where(r => r.UserId == u.Id).FirstOrDefault();
		//		if (roleId != null)
		//		{
		//			user.Role = this.roleManager.Roles.Where(r => r.Id == roleId.RoleId).FirstOrDefault().Name;
		//		}

		//		users.Add(user);
		//	}
		//	return users;
		//}

		//public void Promote(string id)
		//{
		//	var user = this.UserManager.Users.Where(u => u.Id == id).FirstOrDefault();
		//	this.UserManager.AddToRoleAsync(user,GlobalConstants.AdminRoleText).GetAwaiter().GetResult();
		//}

		//public void Demote(string id)
		//{
		//	var user = this.UserManager.Users.Where(u => u.Id == id).FirstOrDefault();
		//	this.UserManager.RemoveFromRoleAsync(user,GlobalConstants.AdminRoleText).GetAwaiter().GetResult();
		//}
	
	}
}
