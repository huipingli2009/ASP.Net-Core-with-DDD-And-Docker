using Practice_Project_with_ASP.Net_Core_with_DDD.DTOs;
using Practice_Project_with_ASP.Net_Core_with_DDD.Models;
using Practice_Project_with_ASP.Net_Core_with_DDD.Persistence;
using System.Collections;

namespace Practice_Project_with_ASP.Net_Core_with_DDD.Services
{
	public class MovieServicesNew : IMovieServices
	{
		private readonly MovieDbContext _dbContext;
		private readonly ILogger _logger;

		public MovieServicesNew(MovieDbContext dbContext, ILogger logger)
		{
			_dbContext = dbContext;
			_logger = logger;	
		}

		public async Task<MovieDto> CreateMovieAsync(CreateMovieDto command)
		{
			var movie = Movie.Create(command.Title, command.Genre, command.ReleaseDate, command.Rating);

			await _dbContext.Movies.AddAsync(movie);
			await _dbContext.SaveChangesAsync();

			return new MovieDto(
				movie.Id,
				movie.Title, 
				movie.Genre, 
				movie.ReleaseDate,	
				movie.Rating
			);
		}

		public async Task DeleteMovieAsync(Guid id)
		{
			
		}

		public async Task<IEnumerable> GetAllMoviesAsync()
		{
			
		}

		public async Task<MovieDto> GetMovieByIdAsync(Guid id)
		{
			
		}

		public async Task UpdateMovieAsync(Guid id, UpdateMovieDto command)
		{
			
		}
	}
}
