namespace BettingApp.Services.ViewModels.Competition
{
	using System.ComponentModel.DataAnnotations;
	using Data.Common.Enums;

	public class AddCompetitionInputModel
	{
		[Required]
		public string Name { get; set; }

		[Required]
		[EnumDataType(typeof(Country))]		
		public Country Country { get; set; }

		[Required]
		public string SportId { get; set; }

		[Required]
		public string SeasonId { get; set; }
	}
}
