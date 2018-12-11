namespace BettingApp.Data.Models
{
	using Common;

	public class Position
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int SportId { get; set; }
		public virtual Sport Sport { get; set; }
	}
}
