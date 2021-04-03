using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyMovies.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsAdmin { get; set; }

        public List<Comment> Comments {get; set; }
    }
}
