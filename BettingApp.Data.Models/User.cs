namespace BettingApp.Data.Models
{
	using System.Collections.Generic;
	using Microsoft.AspNetCore.Identity;

	public class User : IdentityUser
	{
		public int AccountId { get; set; }
		public Account Account { get; set; }

		public IList<Bet> Bets { get; set; }
	}
}
