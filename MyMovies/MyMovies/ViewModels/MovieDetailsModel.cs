using System;
using System.Collections.Generic;

namespace MyMovies.ViewModels
{
    public class MovieDetailsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public string ImgUrl { get; set; }
        
        public string Stars { get; set; }
        
        public string Genre { get; set; }
        
        public string Storyline { get; set; }
        
        public DateTime DateCreated { get; set; }

        public List<MovieCommentModel> Comments { get; set; }
        
    }
}
