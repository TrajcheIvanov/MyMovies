using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public int MovieId { get; set; }
        public Movie Event { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
