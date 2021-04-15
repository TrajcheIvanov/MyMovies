using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repositories
{
    public class MovieLikeRepository : BaseRepository<MovieLike> , IMovieLikeRepository
    {

        public MovieLikeRepository(MyMoviesDbContext context) : base(context)
        {

        }

        public MovieLike Get(int movieId, int userId)
        {
            return _context.MovieLikes.FirstOrDefault(x => x.MovieId == movieId && x.UserId == userId);
        }
    }
}
