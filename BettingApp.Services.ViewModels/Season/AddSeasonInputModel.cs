namespace BettingApp.Services.ViewModels.Season
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using Data.Common;
	using Mapping;

	public class AddSeasonInputModel:IMapTo<Season>
	{
		[Required]	
		public string Name { get; set; }
		
		[Required(ErrorMessage = "Date Required")]
		[DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]  
		[DisplayFormat(DataFormatString = "{yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = true)]
		public DateTime Start { get; set; }
		
		[Required(ErrorMessage = "Date Required")]
		[DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]  
		[DisplayFormat(DataFormatString = "{yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = true)]
		public DateTime End { get; set; }

		[Required]
		public string SportId { get; set; }
	}
}
