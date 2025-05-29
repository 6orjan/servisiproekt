using ISExam.Data.Entities;
using ISExam.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISExam.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MainContext context;

        public MovieRepository(MainContext context)
        {
            this.context = context;
        }

        public void AddMovie(Movie Movie)
        {
            context.Movies.Add(Movie);
            context.SaveChanges();
            //throw new NotImplementedException();
        }

        public bool DeleteMovie(Movie Movie)
        {
            try
            {
                context.Movies.Remove(Movie);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            //throw new NotImplementedException();
        }

        public Movie? GetMovie(int id)
        {
            return context.Movies.FirstOrDefault(c => c.Id == id);
            //throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMovies()
        {
            //throw new NotImplementedException();
            return context.Movies;
        }

        public void UpdateMovie(Movie oldMovie, Movie newMovie)
        {
            context.Movies.Entry(oldMovie).CurrentValues.SetValues(newMovie);
            context.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
