namespace BettingApp.Services.DataServices
{
	using System.Linq;
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using Data.Models;
	using Microsoft.EntityFrameworkCore;
	using ViewModels.Position;

	public class PositionsService:IPositionsService
	{
		private readonly IRepository<Position> _positionRepository;
		private readonly ISportsService _sportsService;

		public PositionsService(IRepository<Position> positionRepository, ISportsService sportsService)
		{
			this._positionRepository = positionRepository;
			this._sportsService = sportsService;
		}

		public async Task<int> Add(AddPositionInputModel model)
		{
			var sport = this._sportsService.GetSportById(int.Parse(model.SportId));
			var position = new Position
			{
				Name = model.Name,
				Sport = sport,
			};
			await this._positionRepository.AddAsync(position);
			await this._positionRepository.SaveChangesAsync();
			return position.Id;
		}
		public IQueryable<PositionListViewModel> GetAllPositions(int sport)
		{
			var positions = this._positionRepository.All().Include(s => s.Sport).Where(s => s.Sport.Id == sport).Select(s => new PositionListViewModel()
			{
				Id = s.Id,
				Name = s.Name
			});
			return positions;
		}
	}
}
