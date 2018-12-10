namespace BettingApp.Services.DataServices.Contracts
{
	using System.Linq;
	using System.Threading.Tasks;
	using ViewModels.Sport;

	public interface ISportsService
	{
		Task<int> CreateAsync(CreateSportInputModel model);
		IQueryable<SportListViewModel> GetAllSports();
	}
}
