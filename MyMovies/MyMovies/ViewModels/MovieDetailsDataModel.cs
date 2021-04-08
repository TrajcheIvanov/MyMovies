using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieDetailsDataModel
    {
        public MovieDetailsModel MovieDetails { get; set; }

        public MovieSidebarDataModel SidebarData { get; set; } = new MovieSidebarDataModel();
    }
}
