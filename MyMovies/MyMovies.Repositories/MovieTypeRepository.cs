using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repositories
{
    public class MovieTypeRepository : BaseRepository<MovieType> , IMovieTypeRepository
    {
        public MovieTypeRepository(MyMoviesDbContext context) : base(context)
        {

        }
    }
}
