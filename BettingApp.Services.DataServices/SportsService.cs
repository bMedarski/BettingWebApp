namespace BettingApp.Services.DataServices
{
	using System.Linq;
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using ViewModels.Sport;

	public class SportsService : ISportsService
	{
		private readonly IRepository<Sport> _sportRepository;

		public SportsService(IRepository<Sport> sportRepository)
		{
			this._sportRepository = sportRepository;
		}
		public async Task<int> Add(AddSportInputModel model)
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

		public IQueryable<SportListViewModel> GetAllSports()
		{
			var sports = this._sportRepository.All().Select(s => new SportListViewModel
			{
				Id = s.Id,
				Name = s.Name
			});
			return sports;
		}

		public Sport GetSportById(int sportId)
		{
			var sport = this._sportRepository.All().FirstOrDefault(s => s.Id == sportId);
			return sport;
		}
	}
}
