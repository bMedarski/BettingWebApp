namespace BettingApp.Services.DataServices
{
	using System.Linq;
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using Data.Models;
	using Microsoft.EntityFrameworkCore;
	using ViewModels.Competitor;
	using ViewModels.Season;

	public class CompetitorsService:ICompetitorsService
	{
		private readonly IRepository<Team> _teamsRepository;
		private readonly IRepository<Player> _playersRepository;

		public CompetitorsService(IRepository<Team> teamsRepository,IRepository<Player> playersRepository)
		{
			this._teamsRepository = teamsRepository;
			this._playersRepository = playersRepository;
		}

		public async Task<int> AddTeam(AddTeamInputModel model)
		{

			var team = new Team
			{
				Name = model.Name,
				LogoUrl = model.LogoUrl,
				Country = model.Country
			};
			await this._teamsRepository.AddAsync(team);
			await this._teamsRepository.SaveChangesAsync();
			return team.Id;
		}
		public async Task<int> AddPlayer(AddPlayerInputModel model)
		{
			var team = this._teamsRepository.All().FirstOrDefault(t => t.Id == model.TeamId);
			var player = new Player
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				ImageUrl = model.ImageUrl,
				Position = model.Position,
				Number = model.Number,
				Country = model.Country,
				Team = team
			};
			await this._playersRepository.AddAsync(player);
			await this._playersRepository.SaveChangesAsync();
			return player.Id;
		}

		public IQueryable<TeamListViewModel> GetAllTeams(int sport)
		{
			//var teams = this._teamsRepository.All().Where(s => s.SportsId == sport).Select(s => new TeamListViewModel()
			//{
			//	Id = s.Id,
			//	Name = s.Name
			//});
			return null;
		}
	}
}
