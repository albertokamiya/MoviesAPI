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
        private static int _count = 0;

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            movie.Id = ++_count;
            _movies.Add(movie);
            return CreatedAtAction(nameof(GetMovieById), new { Id = movie.Id }, movie);
        }

        [HttpGet]
        public IActionResult listMovies()
        {
            return Ok(_movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            Movie movie = _movies.FirstOrDefault(movie => movie.Id == id);
            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound();
        }
    }
}
