using MyMovies.Models;
using MyMovies.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
    public interface ICommentsService
    {
        CommentStatusModel Add(string comment, int movieId, int userId);
        Comment GetById(int id);

        void Delete(Comment comment);
    }
}
