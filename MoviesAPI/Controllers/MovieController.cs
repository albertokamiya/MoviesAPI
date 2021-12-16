using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public MovieController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovieById), new { Id = movie.Id }, movie);
        }

        [HttpGet]
        public IActionResult listMovies()
        {
            return Ok(_context.Movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            Movie movie = getMovieById(id);
            if (movie != null)
            {
                ReadMovieDto movieDto = _mapper.Map<ReadMovieDto>(movie);
                return Ok(movieDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult updateMovie(int id, [FromBody] UpdateAddressDto movieNewDataDto)
        {
            Movie movie = getMovieById(id);
            if(movie == null)
            {
                return NotFound();
            }

            _mapper.Map(movieNewDataDto, movie);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult deleteMovie(int id)
        {
            Movie movie = getMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }

        private Movie getMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(movie => movie.Id == id);
        }
    }
}
