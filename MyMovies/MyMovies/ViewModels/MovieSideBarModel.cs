﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieSideBarModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Views { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
