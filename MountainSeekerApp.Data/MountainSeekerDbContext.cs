namespace MountainSeekerApp.Data
{
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;
	using MountainSeeker.Data.Models;

	public class MountainSeekerDbContext:IdentityDbContext<User>
	{
		public MountainSeekerDbContext(DbContextOptions<MountainSeekerDbContext> options)
			: base(options)
		{
		}
	}
}
