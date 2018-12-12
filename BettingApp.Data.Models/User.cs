namespace BettingApp.Data.Models
{
	using System.Collections.Generic;
	using Microsoft.AspNetCore.Identity;

	public class User : IdentityUser
	{
		public User()
		{
			this.Bets = new HashSet<Bet>();
		}
		public virtual Wallet Wallet { get; set; }
		public virtual ICollection<Bet> Bets { get; set; }
	}
}
