using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private MyMoviesDbContext _context { get; set; }

        public MoviesRepository(MyMoviesDbContext context)
        {
            _context = context;
        }
        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public List<Movie> GetAll()
        {
            var result = _context.Movies.ToList();
            return result;
        }

        public Movie GetById(int id)
        {
            var result = _context.Movies.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public List<Movie> GetByTitle(string title)
        {
            var result = _context.Movies.Where(x => x.Title.Contains(title)).ToList();
            return result;
        }

        public void Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public void Update(Movie movie)
        {
            var movieForUpdate = _context.Movies.FirstOrDefault(x => x.Id == movie.Id);
            movieForUpdate.Title = movie.Title;
            movieForUpdate.ImgUrl = movie.ImgUrl;
            movieForUpdate.Stars = movie.Stars;
            movieForUpdate.Storyline = movie.Storyline;
            movieForUpdate.Genre = movie.Genre;

            _context.Movies.Update(movieForUpdate);
            _context.SaveChanges();
        }
    }
}
