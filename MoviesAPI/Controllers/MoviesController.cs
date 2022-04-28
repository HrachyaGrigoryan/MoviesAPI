#nullable disable
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    public class SelectController : Controller
    {
        private readonly MovieDatabaseContext _context;

        public SelectController(MovieDatabaseContext context)
        {
            _context = context;
        }
        //GET: api/Select/(Actors Name)
        [HttpGet("{ActorName}")]
        public List<string> GetMoviebyActor(string ActorName)
        {
            return _context.Movies.Where(a => a.Actor == ActorName).Select(n => n.Name).ToList();
        }
    }
    //[Route("api/[controller]")]
    //public class VoteController : Controller
    //{
    //    private readonly MovieDatabaseContext _context;

    //    public VoteController(MovieDatabaseContext context)
    //    {
    //        _context = context;
    //    }
    //    //GET: api/Vote/(Movie name)
    //    [HttpGet("{MovieName}")]
    //    public List<string> GetMoviebyActor(string MovieName)
    //    {

    //    }
    //}

    [Route("api/[controller]")]
    public class SorterController : Controller
    {
        private readonly MovieDatabaseContext _context;

        public SorterController(MovieDatabaseContext context)
        {
            _context = context;
        }
        // GET: api/Sorter/(Name,Year,Rating,ActorRating)
        [HttpGet("{SortedBy}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesSorted(string SortedBy)
        {
            var movies = from m in _context.Movies select m;
            switch (SortedBy)
            {
                case "Name":
                    movies = _context.Movies.OrderBy(ob => ob.Name);
                    return await movies.ToListAsync();
                case "Year":
                    movies = _context.Movies.OrderBy(ob => ob.Year);
                    return await movies.ToListAsync();
                case "Rating":
                    movies = _context.Movies.OrderBy(ob => ob.Rating);
                    return await movies.ToListAsync();
                case "ActorRating":
                    movies = _context.Movies.OrderBy(ob => ob.ActorRating);
                    return await movies.ToListAsync();
                default:
                    return NotFound();
            }
        }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDatabaseContext _context;

        public MoviesController(MovieDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
