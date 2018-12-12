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
		public DbSet<Position> Positions { get; set; }
		public DbSet<Wallet> Wallets { get; set; }
		public DbSet<Match> Matches { get; set; }
		public DbSet<Bet> Bets { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<Player>().ToTable("Players");
			builder.Entity<Team>().ToTable("Teams");
		}
	}
}
