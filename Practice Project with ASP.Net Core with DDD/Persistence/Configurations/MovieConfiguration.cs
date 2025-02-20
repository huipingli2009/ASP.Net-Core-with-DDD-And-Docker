using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practice_Project_with_ASP.Net_Core_with_DDD.Models;

namespace Practice_Project_with_ASP.Net_Core_with_DDD.Persistence.Configurations
{
	public class MovieConfiguration : IEntityTypeConfiguration<Movie>
	{
		public void Configure(EntityTypeBuilder<Movie> builder)
		{
			//define table name
			builder.ToTable("Movies");
		
			//set primary key
			builder.HasKey(x => x.Id);

			//configure properties
			builder.Property(x => x.Title)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(x => x.Genre)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(x => x.ReleaseDate)
				.IsRequired();

			builder.Property(x => x.Rating)
				.IsRequired();

			builder.Property(x => x.Created)
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(x => x.LastModified);
				//.IsRequired()
				//.ValueGeneratedOnAddOrUpdate();

			//optional: configure indexes
			builder.HasIndex(x => x.Title);
		}
	}
}
