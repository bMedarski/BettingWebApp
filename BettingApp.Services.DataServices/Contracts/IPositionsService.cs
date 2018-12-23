namespace BettingApp.Services.DataServices.Contracts
{
	using System.Linq;
	using System.Threading.Tasks;
	using ViewModels.Position;

	public interface IPositionsService
	{
		Task<int> Add(AddPositionInputModel model);
		IQueryable<PositionListViewModel> GetAllPositions(int sport);
	}
}
