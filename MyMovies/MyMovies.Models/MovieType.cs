using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Models
{
    public class MovieType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
