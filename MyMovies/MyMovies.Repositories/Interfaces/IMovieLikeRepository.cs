using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repositories.Interfaces
{
    public interface IMovieLikeRepository : IBaseRepository<MovieLike>
    {
        MovieLike Get(int movieId, int userId);
    }
}
