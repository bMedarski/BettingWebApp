namespace BettingApp.Data.Common
{
	using System;
	using System.Collections.Generic;

	public class Season:BaseModel<int>
	{
		public Season()
		{
			this.Competitors = new HashSet<Competitor>();
		}
		public string Name { get; set; }
		public ICollection<Competitor> Competitors { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public virtual Sport Sport { get; set; }
	}
}
