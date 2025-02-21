using Practice_Project_with_ASP.Net_Core_with_DDD.DTOs;
using System.Collections;

namespace Practice_Project_with_ASP.Net_Core_with_DDD.Services
{
	public interface IMovieService
	{
		Task<MovieDto> GetMovieByIdAsync(Guid id);
		Task<IEnumerable> GetAllMoviesAsync();
		Task<MovieDto> CreateMovieAsync(CreateMovieDto command);
		Task UpdateMovieAsync(Guid id, UpdateMovieDto command);
		Task DeleteMovieAsync(Guid id);
	}
}
