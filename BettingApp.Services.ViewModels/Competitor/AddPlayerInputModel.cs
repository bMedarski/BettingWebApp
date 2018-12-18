namespace BettingApp.Services.ViewModels.Competitor
{
	using Data;
	using Data.Common;
	using Data.Common.Enums;
	using Data.Models;

	public class AddPlayerInputModel
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public Position Position{ get; set; }

		public int? Number { get; set; }

		public string ImageUrl { get; set; }

		public Country Country { get; set; }

		public Team Team { get; set; }
	}
}
