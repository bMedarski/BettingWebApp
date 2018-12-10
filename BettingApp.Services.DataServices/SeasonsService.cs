
namespace BettingApp.Services.DataServices
{
	using System.Linq;
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using Microsoft.AspNetCore.Mvc.Rendering;
	using Microsoft.EntityFrameworkCore;
	using ViewModels.Season;

	public class SeasonsService:ISeasonsService
	{
		public IRepository<Season> SeasonRepository { get; }
		public IRepository<Sport> SportRepository { get; }

		public SeasonsService(IRepository<Season> seasonRepository,IRepository<Sport> sportRepository)
		{
			this.SeasonRepository = seasonRepository;
			this.SportRepository = sportRepository;
		}

		public async Task<int> Create(CreateSeasonInputModel model)
		{
			var sportId = int.Parse(model.SportId);
			//TODO Check if Id is int
			var sport = this.SportRepository.All().FirstOrDefault(s => s.Id == sportId);
			//TODO If Id is Valid
			var season = new Season
			{
				Name = model.Name,
				Sport = sport,
				Start = model.Start,
				End = model.End
			};
			await this.SeasonRepository.AddAsync(season);
			//TODO check for database errors
			await this.SeasonRepository.SaveChangesAsync();
			return season.Id;
		}

		public IQueryable<SeasonListViewModel> GetAllAsSelectLisItems(int sport)
		{
			//TODO everywhere PROPERTIES OR FIELDS
			var seasons = this.SeasonRepository.All().Include(s=>s.Sport).Where(s => s.Sport.Id == sport).Select(s => new SeasonListViewModel()
			{
				Id = s.Id,
				Name = s.Name
			});
			return seasons;
		}
	}
}
