namespace Practice_Project_with_ASP.Net_Core_with_DDD.DTOs
{
		public record CreateMovieDto(string Title, string Genre, DateTimeOffset ReleaseDate, double Rating);

}
