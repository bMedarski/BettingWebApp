namespace BettingApp.Data.Models
{
	using Common;

	public class Wallet:BaseModel<int>
	{
		public decimal MoneyBalance { get; set; }

		public decimal MoneyInBets { get; set; }
	}
}
