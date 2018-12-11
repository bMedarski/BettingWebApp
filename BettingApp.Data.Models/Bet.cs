namespace BettingApp.Data.Models
{
	using Common;

	public class Bet:BaseModel<int>
	{
		public virtual User User { get; set; }

		public decimal Amount { get; set; }

		public double Coefficient { get; set; }

		public Match Match { get; set; }

	}
}
