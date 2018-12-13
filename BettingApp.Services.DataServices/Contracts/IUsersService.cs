namespace BettingApp.Services.DataServices.Contracts
{
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Identity;
	using ViewModels.User;

	public interface IUsersService
	{
		Task<IdentityResult> CreateUser(RegisterUserInputModel model);
		//IList<AdminPanelUsersViewModel> AdminPanelUsers();
		void LogoutUser();
		//void Demote(string id);
		//void Promote(string id);
	}
}
