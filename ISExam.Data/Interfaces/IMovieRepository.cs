using ISExam.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISExam.Data.Interfaces
{
    public interface IMovieRepository
    {
        public IEnumerable<Movie> GetMovies();
        public Movie? GetMovie(int id);
        public void AddMovie(Movie Movie);
        public void UpdateMovie(Movie oldMovie, Movie newMovie);
        public bool DeleteMovie(Movie Movie);
    }
}