using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services
{
    public class CommentsService : ICommentsService
    {
        private ICommentsRepository _commentsRepository;

        private IMoviesService _moviesService;
        public CommentsService(ICommentsRepository commentsRepository, IMoviesService moviesService)
        {
            _commentsRepository = commentsRepository;
            _moviesService = moviesService;
        }

        public CommentStatusModel Add(string comment, int movieId, int userId)
        {
            var response = new CommentStatusModel();

            var movie = _moviesService.GetMovieById(movieId);

            if (movie != null)
            {
                var newComment = new Comment()
                {
                    Message = comment,
                    DateCreated = DateTime.Now,
                    MovieId = movieId,
                    UserId = userId,
                };

                _commentsRepository.Add(newComment);
                response.CommentId = newComment.Id;
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"The movie with Id {movieId} was not found";
            }

            
            return response;
        }

        public void Delete(Comment comment)
        {
            _commentsRepository.Delete(comment);
        }

        public Comment GetById(int id)
        {
            return _commentsRepository.GetById(id);
        }
    }
}
