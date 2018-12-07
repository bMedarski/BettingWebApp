namespace BettingApp.Services.DataServices.Contracts
{
	using System.Threading.Tasks;
	using ViewModels.Season;

	public interface ISeasonsService
	{
		Task<int> Create(CreateSeasonInputModel model);
	}
}
