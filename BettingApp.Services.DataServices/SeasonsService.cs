namespace BettingApp.Services.DataServices
{
	using System.Linq;
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using Microsoft.EntityFrameworkCore;
	using ViewModels.Season;

	public class SeasonsService : ISeasonsService
	{
		private readonly IRepository<Season> _seasonRepository;
		private readonly ISportsService _sportsService;

		public SeasonsService(IRepository<Season> seasonRepository, ISportsService sportsService)
		{
			this._seasonRepository = seasonRepository;
			this._sportsService = sportsService;
		}

		public async Task<int> Add(AddSeasonInputModel model)
		{
			//TODO Check if Id is int
			var sport = this._sportsService.GetSportById(int.Parse(model.SportId));
			//TODO If Id is Valid
			//TODO Mapper Instance
			var season = new Season
			{
				Name = model.Name,
				Sport = sport,
				Start = model.Start,
				End = model.End
			};
			await this._seasonRepository.AddAsync(season);
			//TODO check for database errors
			await this._seasonRepository.SaveChangesAsync();

			//TODO in case of success to return whole model
			//TODO research good way for creating and if-ove
			
			return season.Id;
		}

		public IQueryable<SeasonListViewModel> GetAllSeasons(int sport)
		{
			var seasons = this._seasonRepository.All().Include(s => s.Sport).Where(s => s.Sport.Id == sport).Select(s => new SeasonListViewModel()
			{
				Id = s.Id,
				Name = s.Name
			});
			return seasons;
		}

		public Season GetSeasonById(int seasonId)
		{
			var season = this._seasonRepository.All().FirstOrDefault(s => s.Id == seasonId);
			return season;
		}
	}
}
