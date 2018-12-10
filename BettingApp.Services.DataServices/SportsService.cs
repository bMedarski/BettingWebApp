namespace BettingApp.Services.DataServices
{
	using System.Linq;
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using Microsoft.AspNetCore.Mvc.Rendering;
	using ViewModels.Sport;

	public class SportsService:ISportsService
	{
		private readonly IRepository<Sport> _sportRepository;

		public SportsService(IRepository<Sport> sportRepository)
		{
			this._sportRepository = sportRepository;
		}
		public async Task<int> CreateAsync(CreateSportInputModel model)
		{
			var sport = new Sport
			{
				Name = model.Name
			};
			await this._sportRepository.AddAsync(sport);
			//TODO for database errors
			await this._sportRepository.SaveChangesAsync();
			return sport.Id;
		}

		public 
			IQueryable<SportListViewModel> GetAllSports()
		{
			return this._sportRepository.All().Select(s => new SportListViewModel
			{
				Id = s.Id,
				Name = s.Name
			});
		}
	}
}
