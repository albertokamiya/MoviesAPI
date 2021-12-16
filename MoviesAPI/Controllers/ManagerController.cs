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
    public class ManagerController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ManagerController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddManager(CreateManagerDto createManagerDto)
        {
            Manager manager = _mapper.Map<Manager>(createManagerDto);
            _context.Managers.Add(manager);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetManagerById), new { Id = manager.Id }, manager);
        }

        [HttpGet("{id}")]
        public IActionResult GetManagerById(int id)
        {
            Manager manager = _context.Managers.FirstOrDefault(manager => manager.Id == id);
            if (manager != null)
            {
                ReadManagerDto movieDto = _mapper.Map<ReadManagerDto>(manager);
                return Ok(movieDto);
            }
            return NotFound();
        }
    }
}
