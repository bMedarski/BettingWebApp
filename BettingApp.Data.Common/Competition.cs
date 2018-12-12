namespace BettingApp.Data.Common
{
	using System.Collections.Generic;
	using Enums;

	public class Competition:BaseModel<int>
	{
		public Competition()
		{
			//this.Competitors = new HashSet<Competitor>();
			this.PastSeasons = new HashSet<Season>();
		}

		public string Name { get; set; }
		//public ICollection<Competitor> Competitors { get; set; }
		public Country Country { get; set; }
		public virtual Season CurrentSeason { get; set; }
		public virtual ICollection<Season> PastSeasons { get; set; }
	}
}
