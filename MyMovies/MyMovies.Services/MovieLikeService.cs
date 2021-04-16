using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services
{
    public class MovieLikeService : IMovieLikeService
    {
        private IMovieLikeRepository _movieLikeRepository;
        public MovieLikeService(IMovieLikeRepository movieLikeRepository)
        {
            _movieLikeRepository = movieLikeRepository;
        }
        public void Add(int movieId, int userId)
        {
            var like = _movieLikeRepository.Get(movieId, userId);

            if (like == null)
            {
                var newLike = new MovieLike();
                newLike.MovieId = movieId;
                newLike.UserId = userId;

                _movieLikeRepository.Add(newLike);
            }
        }

        public void Remove(int movieId, int userId)
        {
            var like = _movieLikeRepository.Get(movieId, userId);

            if (like != null)
            {
                _movieLikeRepository.Delete(like);
            }
        }
    }
}
