using ISExam.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISExam.Service.Interfaces
{
    public interface IMovieService
    {
        public List<MovieDTO> GetMovies();
        public MovieDTO? GetMovie(int id);
        public MovieDTO UpdateMovie(MovieDTO movie);
        public MovieDTO AddMovie(MovieDTO movie);
        public bool DeleteMovie(int id);
    }
}
