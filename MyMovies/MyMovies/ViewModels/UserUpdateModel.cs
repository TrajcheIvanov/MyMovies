﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class UserUpdateModel
    {
        
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
