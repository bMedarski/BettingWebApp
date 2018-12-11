namespace BettingApp.Data.Models
{
	using Common;

	public class Account:BaseModel<int>
	{
		public Account()
		{
			//TODO Constant
			this.MoneyBalance = 100;
		}

		public decimal MoneyBalance { get; set; }

		public decimal MoneyInBets { get; set; }
	}
}
