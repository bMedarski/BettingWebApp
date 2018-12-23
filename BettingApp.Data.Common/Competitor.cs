namespace BettingApp.Data.Common
{
	using Enums;

	public abstract class Competitor:BaseModel<int>
	{
		public string Name { get; set; }

		public Country Country { get; set; }

	}
}
