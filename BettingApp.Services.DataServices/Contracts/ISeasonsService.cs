namespace BettingApp.Services.DataServices.Contracts
{
	using System.Linq;
	using System.Threading.Tasks;
	using Data.Common;
	using ViewModels.Season;

	public interface ISeasonsService
	{
		Task<int> Create(CreateSeasonInputModel model);
		Season GetSeasonById(int seasonId);
		IQueryable<SeasonListViewModel> GetAllSeasons(int sport);
	}
}
