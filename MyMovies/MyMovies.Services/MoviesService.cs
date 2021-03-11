using MyMovies.Models;
using MyMovies.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services
{
    public class MoviesService
    {
        private MoviesRepository _moviesRepository { get; set; }

        public MoviesService()
        {
            _moviesRepository = new MoviesRepository();
        }

        public List<Movie> GetAllMovies()
        {
            return _moviesRepository.GetAll();
        }

        public Movie GetMovieById(int id)
        {
            return _moviesRepository.GetById(id);
        }
    }
}
