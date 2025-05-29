using ISExam.Service.DTOs;
using ISExam.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ISExam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService service;

        public MovieController(IMovieService service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<MovieDTO> Get()
        {
            var movies = service.GetMovies();

            return movies;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var movie = service.GetMovie(id);
            if (movie == null)
                return NotFound();
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult Post([FromBody] MovieDTO movie)
        {
            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var existingMovie = service.GetMovie(movie.Id);

            if (existingMovie != null)
                return Conflict($"Movie with id {movie.Id} already exists.");

            var newMovie = service.AddMovie(movie);

            return Created($"Movie with id {newMovie.Id} created successfully", newMovie);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] MovieDTO movie)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var existingMovie = service.GetMovie(id);
            if (existingMovie == null)
                return NotFound();
            movie.Id = id;
            var updatedMovie = service.UpdateMovie(movie);
            return Ok(updatedMovie);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = service.DeleteMovie(id);

            if(result == false)
                return NotFound($"Movie with id {id} not found.");

            return Ok($"Movie with id {id} deleted successfully.");
        }
    }
}
