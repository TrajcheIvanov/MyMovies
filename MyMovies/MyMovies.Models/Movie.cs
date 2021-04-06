using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength (maximumLength: 30, MinimumLength =3)]
        public string Title { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        [Required]
        public string Stars { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Storyline { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public int Views { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
