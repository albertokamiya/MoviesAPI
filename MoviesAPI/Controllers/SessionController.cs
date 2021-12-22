using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessionController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddSession([FromBody] CreateSessionDto sessionDto)
        {
            Session session = _mapper.Map<Session>(sessionDto);
            _context.Sessions.Add(session);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSessionById), new { Id = session.Id }, session);
        }

        [HttpGet]
        public IEnumerable<Session> ListSession()
        {
            return _context.Sessions;
        }

        [HttpGet("{id}")]
        public IActionResult GetSessionById(int id)
        {
            Session session = _context.Sessions.FirstOrDefault(session => session.Id == id);
            if (session != null)
            {
                ReadSessionDto addressDto = _mapper.Map<ReadSessionDto>(session);
                return Ok(addressDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSession(int id, [FromBody] UpdateSessionDto sessionDto)
        {
            Session session = _context.Sessions.FirstOrDefault(session => session.Id == id);
            if (session == null)
            {
                return NotFound();
            }
            _mapper.Map(sessionDto, session);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaSession(int id)
        {
            Session session = _context.Sessions.FirstOrDefault(session => session.Id == id);
            if (session == null)
            {
                return NotFound();
            }
            _context.Remove(session);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
