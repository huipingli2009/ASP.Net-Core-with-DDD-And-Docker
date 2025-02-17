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

			///Applies all entity configurations from the assembly containing the `MovieDbContext` class. This is useful for applying configurations defined in separate configuration classes.
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieDbContext).Assembly);

			//Calls the base class implementation to ensure any additional configuration in the base class is applied.
			base.OnModelCreating(modelBuilder);
		}
	}
}
