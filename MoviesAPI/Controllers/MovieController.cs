using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> _movies = new List<Movie>();

        [HttpPost]
        public void AddMovie([FromBody] Movie movie)
        {
            _movies.Add(movie);
            Console.WriteLine(movie.Title);
        }
    }
}
