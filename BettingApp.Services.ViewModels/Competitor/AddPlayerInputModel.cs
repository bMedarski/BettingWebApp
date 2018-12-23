namespace BettingApp.Services.ViewModels.Competitor
{
	using System.ComponentModel.DataAnnotations;
	using Data.Common.Enums;
	using Data.Models;
	using Utilities.Constants;

	public class AddPlayerInputModel
	{
		[MinLength(InputModelsConstants.PlayerFirstNameMinimumLength,ErrorMessage = InputModelsConstants.PlayerFirstNameLengthErrorMessage)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		[MinLength(InputModelsConstants.PlayerSecondNameMinimumLength,ErrorMessage = InputModelsConstants.PlayerSecondNameLengthErrorMessage)]
		public string LastName { get; set; }


		public Position Position{ get; set; }


		public int? Number { get; set; }

		[RegularExpression(InputModelsConstants.ImageUrlRegularExpressionFormat,
			ErrorMessage = InputModelsConstants.ImageUrlInvalidErrorMessage)]
		[Display(Name = InputModelsConstants.PlayerUrlDisplayName)]
		public string ImageUrl { get; set; }

		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		[EnumDataType(typeof(Country))]		
		public Country Country { get; set; }

		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		public string SportId { get; set; }

		public int TeamId { get; set; }
	}
}
