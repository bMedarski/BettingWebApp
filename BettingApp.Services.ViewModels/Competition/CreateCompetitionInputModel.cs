namespace BettingApp.Services.ViewModels.Competition
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using Data.Common.Enums;
	using Microsoft.AspNetCore.Mvc.Rendering;

	public class CreateCompetitionInputModel
	{
		[Required]
		public string Name { get; set; }

		[Required]
		[EnumDataType(typeof(Country))]		
		public string SportId { get; set; }
		public IList<SelectListItem> Sports { get; set; }
		public string SeasonId { get; set; }
	}
}
