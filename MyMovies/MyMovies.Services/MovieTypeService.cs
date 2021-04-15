using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services
{
    public class MovieTypeService : IMovieTypeService
    {
        private IMovieTypeRepository _movieTypeRepository;
        public MovieTypeService(IMovieTypeRepository movieTypeRepository)
        {
            _movieTypeRepository = movieTypeRepository;
        }
        public bool CheckIfExists(int movieTypeId)
        {
            var movieType = _movieTypeRepository.GetById(movieTypeId);

            return movieType != null;
        }

        public List<MovieType> GetAll()
        {
           return  _movieTypeRepository.GetAll();
        }
    }
}
