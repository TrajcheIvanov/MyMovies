using Microsoft.EntityFrameworkCore;
using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repositories
{
    public class MoviesRepository : BaseRepository<Movie> , IMoviesRepository
    {
        
        public MoviesRepository(MyMoviesDbContext context) : base(context)
        {
        }

        public List<Movie> GetByTitle(string title)
        {
            var result = _context.Movies.Where(x => x.Title.Contains(title)).ToList();
            return result;
        }

        public override Movie GetById(int entityId)
        {
            var movie = _context.Movies
                .Include(x => x.Comments)
                    .ThenInclude(x => x.User)
                .FirstOrDefault(x => x.Id == entityId);

            return movie;
        }

        public List<Movie> GetMostRecentMovies(int count)
        {
            return _context.Movies.OrderByDescending(x => x.DateCreated).Take(count).ToList();
        }

        public List<Movie> GetTopMovies(int count)
        {
            return _context.Movies.OrderByDescending(x => x.Views).Take(count).ToList();
        }
    }
}
