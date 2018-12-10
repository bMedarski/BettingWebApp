namespace BettingApp.Services.DataServices.Contracts
{
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Mvc.Rendering;
	using ViewModels.Sport;

	public interface ISportsService
	{
		Task<int> CreateAsync(CreateSportInputModel model);
		IQueryable<SelectListItem> GetAllAsSelectLisItems();
	}
}
