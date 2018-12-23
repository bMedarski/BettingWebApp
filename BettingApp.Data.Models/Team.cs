﻿namespace BettingApp.Data.Models
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

		public string LogoUrl { get; set; }

		//public int SportsId { get; set; }
	}
}
