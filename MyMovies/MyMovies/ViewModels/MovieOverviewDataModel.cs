﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieOverviewDataModel
    {
        public List<MovieOverviewModel> OverviewMovies { get; set; }

        public MovieSidebarDataModel SidebarData { get; set; } = new MovieSidebarDataModel();
        
    }
}
