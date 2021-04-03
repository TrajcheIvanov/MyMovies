using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services
{
    public class CommentsService : ICommentsService
    {
        private ICommentsRepository _commentsRepository;
        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public void Add(string comment, int movieId, int userId)
        {
            var newComment = new Comment()
            {
                Message = comment,
                DateCreated = DateTime.Now,
                MovieId = movieId,
                UserId = userId,
            };

            _commentsRepository.Add(newComment);
        }
    }
}
