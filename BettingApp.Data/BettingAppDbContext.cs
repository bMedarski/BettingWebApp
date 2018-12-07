namespace BettingApp.Data
{
	using Common;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;
	using Models;

	public class BettingAppDbContext : IdentityDbContext<User>
	{
		public BettingAppDbContext(DbContextOptions<BettingAppDbContext> options)
			: base(options)
		{
		}

		public DbSet<Team> Teams { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<Competition> Competitions { get; set; }
		public DbSet<Season> Seasons { get; set; }
		public DbSet<Sport> Sports { get; set; }
	}
}
