using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.DtoModels
{
    public class CommentStatusModel
    {
        public CommentStatusModel()
        {
            IsSuccessful = true;
        }
        public bool IsSuccessful { get; set; }

        public string Message { get; set; }

        public int CommentId { get; set; }
    }
}
