using Microsoft.EntityFrameworkCore;
using Practice_Project_with_ASP.Net_Core_with_DDD.Models;

namespace Practice_Project_with_ASP.Net_Core_with_DDD.Persistence
{
	public class MovieDbContextConfiguration : IEntityTypeConfiguration<Movie>
	{
		public void Configure(EntityTypeBuilder<Movie> builder)
		{
			builder.ToTable("Movies", "app");
			builder.HasKey(m => m.Id);
			builder.Property(m => m.Id).ValueGeneratedNever();
			builder.Property(m => m.Title).IsRequired().HasMaxLength(100);
			builder.Property(m => m.Genre).IsRequired().HasMaxLength(50);
			builder.Property(m => m.ReleaseDate).IsRequired();
			builder.Property(m => m.Rating).IsRequired();
		}

		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Movie> builder)
		{
			builder.ToTable("Movies");
			builder.HasKey(m => m.Id);

			builder.Property(m => m.Title)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(m => m.Genre)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(m => m.ReleaseDate)
				.IsRequired();

			builder.Property(m => m.Rating)
				.IsRequired();

			builder.Property(m => m.Created)
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(m => m.LastModified)
				.IsRequired()
				.ValueGeneratedOnAddOrUpdate();

			// Optional: Add indexes for better query performance
			builder.HasIndex(m => m.Title);
		}
	}
}
	
