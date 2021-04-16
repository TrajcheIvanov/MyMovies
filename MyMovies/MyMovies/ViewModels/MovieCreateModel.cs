
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MyMovies.ViewModels
{
    public class MovieCreateModel
    {
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        [Required]
        public string Stars { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Storyline { get; set; }

        public int MovieTypeId { get; set; }
        public List<MovieTypeModel> MovieTypes { get; set; }
        
    }
}
