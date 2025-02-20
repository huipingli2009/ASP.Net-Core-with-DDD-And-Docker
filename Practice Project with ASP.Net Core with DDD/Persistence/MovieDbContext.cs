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

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseAsyncSeeding(async (context, _, cancellationToken) =>
				{
					var sampleMovie = await context.Set<Movie>().FirstOrDefaultAsync(b => b.Title == "Sonic the Hedgehog 3");
					if (sampleMovie == null)
					{
						sampleMovie = Movie.Create("Sonic the Hedgehog 3", "Fantasy", new DateTimeOffset(new DateTime(2025, 1, 3), TimeSpan.Zero), 7);
						await context.Set<Movie>().AddAsync(sampleMovie);
						await context.SaveChangesAsync();
					}
				})
				.UseSeeding((context, _) =>
				{
					var sampleMovie = context.Set<Movie>().FirstOrDefault(b => b.Title == "Sonic the Hedgehog 3");
					if (sampleMovie == null)
					{
						sampleMovie = Movie.Create("Sonic the Hedgehog 3", "Fantasy", new DateTimeOffset(new DateTime(2025, 1, 3), TimeSpan.Zero), 7);
						context.Set<Movie>().Add(sampleMovie);
						context.SaveChanges();
					}
				});
		}
	}
}
