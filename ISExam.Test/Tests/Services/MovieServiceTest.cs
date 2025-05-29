using AutoMapper;
using ISExam.Data.Entities;
using ISExam.Data.Interfaces;
using ISExam.Service.DTOs;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit;

namespace ISExam.Test.Tests.Services
{
    public class MovieServiceTest
    {
        IMovieRepository MovieRepository;
        IMapper mapper;
        Mock<IMovieRepository> MovieRepositoryMock = new Mock<IMovieRepository>();
        Movie Movie;
        MovieDTO MovieDTO;
        Mock<IMapper> mapperMock = new Mock<IMapper>();
        List<MovieDTO> MovieDTOList = new List<MovieDTO>();
        List<Movie> Movies = new List<Movie>();

        private Movie GetMovie()
        {
            return new Movie
            {
                BoxOfficeEarnings = 1000000.00f,
                Director = "Director",
                Genre = "Genre",
                Id = 1,
                Name = "Name",
                Rating = 4.5f,
                Year = 2025
            };
        }

        private MovieDTO GetMovieDTO()
        {
            return new MovieDTO
            {
                BoxOfficeEarnings = 1000000.00f,
                Director = "Director",
                Genre = "Genre",
                Id = 1,
                Name = "Name",
                Rating = 4.5f,
                Year = 2025
            };
        }

        private List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie
            {
                BoxOfficeEarnings = 1000000.00f,
                Director = "Director",
                Genre = "Genre",
                Id = 1,
                Name = "Name",
                Rating = 4.5f,
                Year = 2025
            },
                new Movie
            {
                BoxOfficeEarnings = 10.00f,
                Director = "Director2",
                Genre = "Genre2",
                Id = 2,
                Name = "Name2",
                Rating = 1.5f,
                Year = 1997
            }
            };
        }

        private void SetUpMocks()
        {
            MovieRepository = MovieRepositoryMock.Object;
            mapper = mapperMock.Object;
        }

        private void SetUpMovieDTOListMock()
        {
            MovieDTO = GetMovieDTO();

            var MovieDTO2 = GetMovieDTO();

            MovieDTO2.Id = 2;

            MovieDTOList.Add(MovieDTO);
            MovieDTOList.Add(MovieDTO2);

            Movies = GetMovies();

            mapperMock.Setup(o => o.Map<List<MovieDTO>>(Movies)).Returns(MovieDTOList);
        }

        private void SetUpMovieDTOMock()
        {
            Movie = GetMovie();

            mapperMock.Setup(o => o.Map<MovieDTO>(Movie)).Returns(GetMovieDTO());
        }

        [Fact]
        public void GetAllMoviesTest()
        {
            SetUpMocks();
            SetUpMovieDTOListMock();
            MovieRepositoryMock.Setup(o => o.GetMovies()).Returns(Movies);

            var result = MovieRepository.GetMovies();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetMovieByIdTest()
        {
            SetUpMocks();
            SetUpMovieDTOMock();
            MovieRepositoryMock.Setup(o => o.GetMovie(1)).Returns(Movie);
            var result = MovieRepository.GetMovie(1);
            Assert.NotNull(result);
            Assert.Equal(Movie.Id, result.Id);
        }
    }
}
