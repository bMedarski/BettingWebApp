namespace Web.Middleware.Extensions
{
	using Microsoft.AspNetCore.Builder;

	public static class SeederExtension
	{
		public static IApplicationBuilder UseSeeder(
			this IApplicationBuilder builder) => builder.UseMiddleware<Seeder>();
	}
}
