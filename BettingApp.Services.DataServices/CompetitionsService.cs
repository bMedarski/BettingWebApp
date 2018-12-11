namespace BettingApp.Services.DataServices
{
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using ViewModels.Competition;

	public class CompetitionsService : ICompetitionsService
	{
		private readonly IRepository<Competition> _competitionRepository;
		private readonly ISeasonsService _seasonsService;

		public CompetitionsService(IRepository<Competition> competitionRepository,ISeasonsService seasonsService)
		{
			this._competitionRepository = competitionRepository;
			this._seasonsService = seasonsService;
		}

		public async Task<int> CreateAsync(CreateCompetitionInputModel model)
		{
			var season = this._seasonsService.GetSeasonById(int.Parse(model.SeasonId));

			var competition = new Competition()
			{
				CurrentSeason = season,
				Name = model.Name,
				Country = model.Country
			};
			await this._competitionRepository.AddAsync(competition);
			await this._competitionRepository.SaveChangesAsync();
			return competition.Id;
		}
	}
}
