using Microsoft.EntityFrameworkCore;
using Practice_Project_with_ASP.Net_Core_with_DDD.Models;

namespace Practice_Project_with_ASP.Net_Core_with_DDD.Persistence
{
	public class MovieDbContext(DbContextOptions<MovieDbContext> options) : DbContext(options)
	{
		public DbSet<Movie> Movies => Set<Movie>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("app");
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieDbContext).Assembly);
			base.OnModelCreating(modelBuilder);
		}
	}
}
