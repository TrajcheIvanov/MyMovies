
using System.ComponentModel.DataAnnotations;


namespace MyMovies.ViewModels
{
    public class MovieUpdateModel
    {
        public int Id { get; set; }
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
       
    }
}
