namespace BettingApp.Data
{
	using Common;
	using Enums.Football;

	public class Player:Competitor
	{
		public FootballPosition Position { get; set; }
	}
}
