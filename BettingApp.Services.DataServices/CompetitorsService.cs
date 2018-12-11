namespace BettingApp.Services.DataServices
{
	using Contracts;
	using Data.Common;

	public class CompetitorsService:ICompetitorsService
	{
		private readonly IRepository<Competitor> _competitorsRepository;

		public CompetitorsService(IRepository<Competitor> competitorsRepository)
		{
			this._competitorsRepository = competitorsRepository;
		}

	}
}
