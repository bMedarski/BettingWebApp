namespace BettingApp.Services.ViewModels.Sport
{
	using System.ComponentModel.DataAnnotations;
	using Data.Common;
	using Mapping;

	public class CreateSportInputModel:IMapTo<Sport>,IMapFrom<Sport>
	{
		[Required]
		public string Name { get; set; }
	}
}
