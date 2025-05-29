using AutoMapper;
using ISExam.Data.Entities;
using ISExam.Data.Interfaces;
using ISExam.Service.DTOs;
using ISExam.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISExam.Service.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMapper mapper;
        private readonly IMovieRepository repository;

        public MovieService(IMapper mapper, IMovieRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public MovieDTO AddMovie(MovieDTO movie)
        {
            var newMovie = mapper.Map<Movie>(movie);

            if (repository.GetMovie(movie.Id) == null)
                repository.AddMovie(newMovie);

            return mapper.Map<MovieDTO>(newMovie);
            //throw new NotImplementedException();
        }

        public bool DeleteMovie(int id)
        {
            var movie = repository.GetMovie(id);

            return repository.DeleteMovie(movie);
            //throw new NotImplementedException();
        }

        public MovieDTO? GetMovie(int id)
        {
            var movie = repository.GetMovie(id);

            return mapper.Map<MovieDTO>(movie);
            //throw new NotImplementedException();
        }

        public List<MovieDTO> GetMovies()
        {
            var movies = repository.GetMovies();

            return mapper.Map<List<MovieDTO>>(movies);
            //throw new NotImplementedException();
        }

        public MovieDTO UpdateMovie(MovieDTO movie)
        {
            var newMovie = mapper.Map<Movie>(movie);
            var oldMovie = repository.GetMovie(movie.Id);

            if (oldMovie != null)
                repository.UpdateMovie(oldMovie, newMovie);

            return mapper.Map<MovieDTO>(newMovie);
            //throw new NotImplementedException();
        }
    }
}
