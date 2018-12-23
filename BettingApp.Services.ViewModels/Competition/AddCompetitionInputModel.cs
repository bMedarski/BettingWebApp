namespace BettingApp.Services.ViewModels.Competition
{
	using System.ComponentModel.DataAnnotations;
	using Data.Common.Enums;
	using Utilities.Constants;

	public class AddCompetitionInputModel
	{
		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		[MinLength(InputModelsConstants.CompetitionNameMinimumLength,ErrorMessage = InputModelsConstants.CompetitionNameLengthErrorMessage)]
		public string Name { get; set; }

		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		[EnumDataType(typeof(Country))]		
		public Country Country { get; set; }

		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		public string SportId { get; set; }

		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		public string SeasonId { get; set; }
	}
}
