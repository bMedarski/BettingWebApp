namespace BettingApp.Services.DataServices
{
	using System;
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using ViewModels.Competition;

	public class CompetitionsService : ICompetitionsService
	{
		private readonly IRepository<Competition> competitionRepository;

		public CompetitionsService(IRepository<Competition> competitionRepository)
		{
			this.competitionRepository = competitionRepository;
		}

		public async Task<int> CreateAsync(CreateCompetitionInputModel model)
		{
			
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
