namespace BettingApp.Services.ViewModels.Competitor
{
	using System.ComponentModel.DataAnnotations;
	using Data.Common.Enums;
	using Utilities.Constants;

	public class AddTeamInputModel
	{
		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		[MinLength(InputModelsConstants.TeamNameMinimumLength,ErrorMessage = InputModelsConstants.TeamNameLengthErrorMessage)]
		public string Name { get; set; }

		[RegularExpression(InputModelsConstants.ImageUrlRegularExpressionFormat,
			ErrorMessage = InputModelsConstants.ImageUrlInvalidErrorMessage)]
		[Display(Name = InputModelsConstants.TeamUrlDisplayName)]
		public string LogoUrl { get; set; }

		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		public string SportId { get; set; }

		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		[EnumDataType(typeof(Country))]	
		public Country Country { get; set; }
	}
}
