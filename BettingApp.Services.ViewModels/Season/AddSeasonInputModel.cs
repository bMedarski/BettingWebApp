namespace BettingApp.Services.ViewModels.Season
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using Data.Common;
	using Mapping;
	using Utilities.Constants;

	public class AddSeasonInputModel:IMapTo<Season>
	{
		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		[MinLength(InputModelsConstants.SeasonNameMinimumLength,ErrorMessage = InputModelsConstants.SeasonNameLengthErrorMessage)]
		public string Name { get; set; }
		
		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		[DataType(DataType.Date, ErrorMessage = InputModelsConstants.DateInvalidErrorMessage)]  
		[DisplayFormat(DataFormatString = InputModelsConstants.DateFormat, ApplyFormatInEditMode = true)]
		public DateTime Start { get; set; }
		
		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		[DataType(DataType.Date, ErrorMessage = InputModelsConstants.DateInvalidErrorMessage)]  
		[DisplayFormat(DataFormatString = InputModelsConstants.DateFormat, ApplyFormatInEditMode = true)]
		public DateTime End { get; set; }

		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		public string SportId { get; set; }
	}
}
