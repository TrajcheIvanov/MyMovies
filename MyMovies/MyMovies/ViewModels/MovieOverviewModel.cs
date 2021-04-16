

using System.Collections.Generic;

namespace MyMovies.ViewModels
{
    public class MovieOverviewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string ImgUrl { get; set; }
       
        public string Genre { get; set; }

        public int Views { get; set; }

        public string MovieType { get; set; }

        public List<MovieLikeModel> MovieLikes { get; set; }
    }
}
