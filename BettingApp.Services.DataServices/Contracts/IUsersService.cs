namespace BettingApp.Services.DataServices.Contracts
{
	using ViewModels.User;

	public interface IUsersService
	{
		void CreateUser(RegisterUserInputModel model);
		//IList<AdminPanelUsersViewModel> AdminPanelUsers();
		void LogoutUser();
		//void Demote(string id);
		//void Promote(string id);
	}
}
