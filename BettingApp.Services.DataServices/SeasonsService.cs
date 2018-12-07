
namespace BettingApp.Services.DataServices
{
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using ViewModels.Season;

	public class SeasonsService:ISeasonsService
	{
		public IRepository<Season> SeasonRepository { get; set; }

		public SeasonsService(IRepository<Season> seasonRepository)
		{
			this.SeasonRepository = seasonRepository;
		}

		public async Task<int> Create(CreateSeasonInputModel model)
		{

			throw new System.NotImplementedException();
		}
	}
}
