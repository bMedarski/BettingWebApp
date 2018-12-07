namespace BettingApp.Services.ViewModels.Season
{
	using System;
	using Data;
	using Data.Common;
	using Mapping;

	public class CreateSeasonInputModel:IMapTo<Season>
	{
		public string Name { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public Sport Sport { get; set; }
	}
}
