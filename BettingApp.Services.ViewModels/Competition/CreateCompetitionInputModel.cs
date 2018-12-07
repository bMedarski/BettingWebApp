namespace BettingApp.Services.ViewModels.Competition
{
	using System.ComponentModel.DataAnnotations;
	using Data.Common;
	using Data.Common.Enums;
	using Mapping;

	public class CreateCompetitionInputModel : IMapTo<Competition>,IMapFrom<Competition>
	{
		[Required]
		public string Name { get; set; }

		[Required]
		[EnumDataType(typeof(Country))]
		public Country Country { get; set; }
		//public Season Season { get; set; }
	}
}
