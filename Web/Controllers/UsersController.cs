namespace Web.Controllers
{
	using System.Threading.Tasks;
	using BettingApp.Data.Models;
	using BettingApp.Services.DataServices.Contracts;
	using BettingApp.Services.ViewModels.User;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;

	public class UsersController : BaseController
	{
		private readonly IUsersService _usersService;
	    private SignInManager<User> SignInManager { get; }

	    public UsersController(IUsersService usersService, SignInManager<User> signInManager)
	    {
		    this._usersService = usersService;
		    this.SignInManager = signInManager;
	    }

        public IActionResult Login()
        {
            return this.View();
        }

	    [HttpPost]
	    public async Task<IActionResult> Login(LoginUserInputModel model)
	    {
		    if (this.ModelState.IsValid)
		    {
			    var result = await this.SignInManager.PasswordSignInAsync(model.Username,
				    model.Password, false, false);

			    if (result.Succeeded)
			    {
				    return this.RedirectToAction("Index", "Home");
			    }
		    }

		    return this.View(model);
	    }
	    public IActionResult Register()
	    {
		    return this.View();
	    }
	    [HttpPost]
	    public IActionResult Register(RegisterUserInputModel model)
	    {
		    if (this.ModelState.IsValid)
		    {
			    this._usersService.CreateUser(model);
			    return this.RedirectToAction("Index", "Home");
		    }
		    return this.View(model);
	    }
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