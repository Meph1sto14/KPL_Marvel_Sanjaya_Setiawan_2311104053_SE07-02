using Microsoft.AspNetCore.Mvc;
using modul9_2311104053.Models;

namespace modul9_2311104053.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>
        {
            new Movie
            {
                Title = "The Shawshank Redemption",
                Director = "Frank Darabont",
                Stars = new List<string> { "Tim Robbins", "Morgan Freeman" },
                Description = "Two imprisoned men bond over a number of years..."
            },
            new Movie
            {
                Title = "The Godfather",
                Director = "Francis Ford Coppola",
                Stars = new List<string> { "Marlon Brando", "Al Pacino" },
                Description = "The aging patriarch of an organized crime dynasty..."
            },
            new Movie
            {
                Title = "The Dark Knight",
                Director = "Christopher Nolan",
                Stars = new List<string> { "Christian Bale", "Heath Ledger" },
                Description = "When the menace known as the Joker wreaks havoc..."
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAllMovies()
        {
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            if (id < 0 || id >= movies.Count)
                return NotFound("Movie not found.");
            return Ok(movies[id]);
        }

        [HttpPost]
        public ActionResult AddMovie([FromBody] Movie newMovie)
        {
            movies.Add(newMovie);
            return Ok("Movie added.");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            if (id < 0 || id >= movies.Count)
                return NotFound("Movie not found.");
            movies.RemoveAt(id);
            return Ok("Movie deleted.");
        }
    }
}
