namespace BettingApp.Services.DataServices.Contracts
{
	using System.Linq;
	using System.Threading.Tasks;
	using Data.Common;
	using ViewModels.Sport;

	public interface ISportsService
	{
		Task<int> CreateAsync(CreateSportInputModel model);
		Sport GetSportById(int sportId);
		IQueryable<SportListViewModel> GetAllSports();
	}
}
