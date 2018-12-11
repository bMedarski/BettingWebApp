namespace BettingApp.Data.Models
{
	using Common;

	public class Player:Competitor
	{

		public virtual Position Position { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public int? Number { get; set; }

		public string ImageUrl { get; set; }

		public virtual Team Team { get; set; }

	}
}
