namespace BettingApp.Services.ViewModels.Season
{
	using System;
	using System.Collections.Generic;
	using Data.Common;
	using Mapping;
	using Microsoft.AspNetCore.Mvc.Rendering;

	public class AddSeasonInputModel:IMapTo<Season>
	{
		public string Name { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public string SportId { get; set; }
		public IList<SelectListItem> Sports { get; set; }
	}
}
