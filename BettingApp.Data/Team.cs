namespace BettingApp.Data
{
	using System.Collections.Generic;
	using Common;

	public class Team:Competitor
	{
		public Team()
		{
			this.Players = new HashSet<Player>();
		}
		public virtual ICollection<Player> Players { get; set; }
	}
}
