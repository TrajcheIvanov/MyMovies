using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
    public interface IMovieLikeService 
    {
        void Add(int movieId, int userId);
        void Remove(int movieId, int userId);
    }
}
