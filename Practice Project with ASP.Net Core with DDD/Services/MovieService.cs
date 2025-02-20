using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Practice_Project_with_ASP.Net_Core_with_DDD.DTOs;
using Practice_Project_with_ASP.Net_Core_with_DDD.Models;
using Practice_Project_with_ASP.Net_Core_with_DDD.Persistence;
using System.Collections;

namespace Practice_Project_with_ASP.Net_Core_with_DDD.Services
{
	public class MovieService : IMovieServices
	{
		private readonly MovieDbContext _dbContext;
		private readonly ILogger<MovieService> _logger;
		public MovieService(MovieDbContext dbContext, ILogger<MovieService> logger)
		{
			_dbContext = dbContext;
			_logger = logger;
		}
		public async Task<MovieDto> CreateMovieAsync(CreateMovieDto command)
		{
			var movie = Movie.Create(command.Title, command.Genre, command.ReleaseDate, command.Rating);

			await _dbContext.Movies.AddAsync(movie);
			await _dbContext.SaveChangesAsync();

			return new MovieDto(movie.Id, movie.Title, movie.Genre, movie.ReleaseDate, movie.Rating);
		}

		public async Task DeleteMovieAsync(Guid id)
		{
			var movieToDelete = await _dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);

			if (movieToDelete != null)
			{
				_dbContext.Movies.Remove(movieToDelete);
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable> GetAllMoviesAsync()
		{
			return await _dbContext.Movies
				.AsNoTracking()
				.Select(x => new MovieDto(
					x.Id,
					x.Title,
					x.Genre,
					x.ReleaseDate,
					x.Rating			
				))
				.ToListAsync();			
		}

		public async Task<MovieDto> GetMovieByIdAsync(Guid id)
		{
			var movie = await _dbContext.Movies
				.FirstOrDefaultAsync(x => x.Id == id);

			if (movie == null)
				return null;

			return new MovieDto(movie.Id, movie.Title, movie.Genre, movie.ReleaseDate, movie.Rating);
		}

		public async Task UpdateMovieAsync(Guid id, UpdateMovieDto command)
		{
			var movieToUpdate = await _dbContext.Movies.FindAsync(id);

			if (movieToUpdate == null)
				throw new ArgumentNullException("Invalid Movie Id");

			movieToUpdate.Update(command.Title, command.Genre, command.ReleaseDate, command.Rating);

			await _dbContext.SaveChangesAsync();
		}
	}
}
