namespace BettingApp.Services.DataServices.Contracts
{
	using System.Linq;
	using System.Threading.Tasks;
	using ViewModels.Season;

	public interface ISeasonsService
	{
		Task<int> Create(CreateSeasonInputModel model);
		IQueryable<SeasonListViewModel> GetAllAsSelectLisItems(int sport);
	}
}
