namespace BettingApp.Services.DataServices.Contracts
{
	using System.Linq;
	using System.Threading.Tasks;
	using ViewModels.Competitor;
	using ViewModels.Season;

	public interface ICompetitorsService
	{
		Task<int> AddPlayer(AddPlayerInputModel model);
		Task<int> AddTeam(AddTeamInputModel model);
		IQueryable<TeamListViewModel> GetAllTeams(int sport);
	}
}
