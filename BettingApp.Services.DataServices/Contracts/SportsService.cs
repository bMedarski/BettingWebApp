namespace BettingApp.Services.DataServices.Contracts
{
	using System.Linq;
	using System.Threading.Tasks;
	using Data.Common;
	using Mapping;
	using ViewModels.Sport;

	public class SportsService:ISportsService
	{
		private readonly IRepository<Sport> sportRepository;

		public SportsService(IRepository<Sport> sportRepository)
		{
			this.sportRepository = sportRepository;
		}
		public async Task<int> CreateAsync(CreateSportInputModel model)
		{
			
			
			//var sportId = this.sportRepository.AddAsync(sport);
			return 0;
		}

		public IQueryable<CreateSportInputModel> GetAll()
		{
			return this.sportRepository.All().To<CreateSportInputModel>();
		}
	}
}
