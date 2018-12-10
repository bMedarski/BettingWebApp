namespace BettingApp.Services.DataServices
{
	using System.Linq;
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using ViewModels.Competition;

	public class CompetitionsService : ICompetitionsService
	{
		private readonly IRepository<Competition> _competitionRepository;

		public CompetitionsService(IRepository<Competition> competitionRepository,IRepository<Sport> sportRepository)
		{
			this._competitionRepository = competitionRepository;
			this.SportRepository = sportRepository;
		}

		public IRepository<Sport> SportRepository { get; }

		public async Task<int> CreateAsync(CreateCompetitionInputModel model)
		{
			var sportId = int.Parse(model.SportId);
			//TODO Check if Id is int
			var sport = this.SportRepository.All().FirstOrDefault(s => s.Id == sportId);
			//TODO If Id is Valid
			//var competition = model.To<Competition>();
			//var competitionResult = this.competitionRepository.AddAsync(competition).GetAwaiter().GetResult();
			//await this.competitionRepository.SaveChangesAsync();
			//var task = new Task(()=
			//{
			//	Console.WriteLine()
			//});
			//return Task.CompletedTask;
			return 0;
		}
	}
}
