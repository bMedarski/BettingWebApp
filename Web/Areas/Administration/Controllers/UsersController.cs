namespace Web.Areas.Administration.Controllers
{
	using System.Threading.Tasks;
	using BettingApp.Data.Models;
	using BettingApp.Services.DataServices.Contracts;
	using BettingApp.Services.ViewModels.User;
	using Filters;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Web.Controllers;

	public class UsersController : BaseController
	{
		private readonly IUsersService _usersService;
		private SignInManager<User> SignInManager { get; }

		public UsersController(IUsersService usersService, SignInManager<User> signInManager)
		{
			this._usersService = usersService;
			this.SignInManager = signInManager;
		}

		[Area("Administration")]
		public IActionResult Login()
		{

			return this.View();
		}

		[HttpPost]
		[ValidateModelState]
		public async Task<IActionResult> Login(LoginUserInputModel model)
		{

			var result = await this.SignInManager.PasswordSignInAsync(model.Username,
				model.Password, model.RememberMe, false);

			if (result.Succeeded)
			{
				return this.RedirectToAction("Index", "Home");
			}


			return this.StatusCode(409);
		}

		public IActionResult Register()
		{
			return this.View();
		}

		[HttpPost]
		[ValidateModelState]
		public IActionResult Register(RegisterUserInputModel model)
		{
			this._usersService.CreateUser(model);
			return this.RedirectToAction("Index", "Home");

		}

		[Area("Administration")]
		public IActionResult Logout()
		{
			this._usersService.LogoutUser();
			return this.RedirectToAction("Index", "Home");
		}

		//[Authorize(Roles = GlobalConstants.AdminRoleText)]
		//   public IActionResult AdminPanel()
		//{
		//	var users = new AdminPanelUsersListViewModel{Users = this.AccountsService.AdminPanelUsers()};
		//	return this.View(users);
		//}
		//   [Authorize(Roles = GlobalConstants.AdminRoleText)]
		//   public IActionResult Demote(string id)
		//   {
		//    this.AccountsService.Demote(id);
		//    return this.RedirectToAction("AdminPanel");
		//   }
		//   [Authorize(Roles = GlobalConstants.AdminRoleText)]
		//   public IActionResult Promote(string id)
		//   {
		//    this.AccountsService.Promote(id);
		//    return this.RedirectToAction("AdminPanel");
		//   }
	}
}