using Azure;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<Movies>
        [HttpGet]
        public  IActionResult Get() 
        {
            var movies = _context.Movies.ToList();
            return Ok(movies);
        }

        // GET api/<Movies>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie !=null)
            {
                return Ok(movie);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<Movies>
        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return StatusCode(201, movie);
        }

        // PUT api/<Movies>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie movie)
        {
            var movieToUpdate = _context.Movies.FirstOrDefault(m => m.id == id);
            movieToUpdate.title = movie.title;
            movieToUpdate.runningTime = movie.runningTime;
            movieToUpdate.genre = movie.genre;
            _context.SaveChanges();
            return Ok(movie);
        }

        // DELETE api/<Movies>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}
