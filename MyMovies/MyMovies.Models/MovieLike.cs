﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Models
{
    public class MovieLike
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
