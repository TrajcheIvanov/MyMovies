using MyMovies.Common.Exceptions;
using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace MyMovies.Services
{
    public class MoviesService : IMoviesService
    {
        private IMoviesRepository _moviesRepository { get; set; }

        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public List<Movie> GetAllMovies()
        {
            return _moviesRepository.GetAll();
        }

        public Movie GetMovieById(int id)
        {
            return _moviesRepository.GetById(id);
        }

        public Movie GetMovieDetails(int id)
        {
            var movie = _moviesRepository.GetById(id);

            if (movie == null)
            {
                return movie;
            }

            movie.Views++;
            _moviesRepository.Update(movie);
            return movie;
        }

        public void CreateMovie(Movie movie)
        {
            movie.DateCreated = DateTime.Now;
            _moviesRepository.Add(movie);
        }

        public List<Movie> GetRecipesByTitle(string title)
        {
            if (title == null)
            {
                return _moviesRepository.GetAll();
            }
            else
            {
                return _moviesRepository.GetByTitle(title);
            }
        }

        public void Delete(int Id)
        {
            var movie = _moviesRepository.GetById(Id);

            if (movie == null)
            {
                throw new NotFoundException($"The Movie with Id {Id} was not found");
            }else
            {
                _moviesRepository.Delete(movie);
            }
        }

        public void Update(Movie movie)
        {

            var movieForUpdate = _moviesRepository.GetById( movie.Id);

            if (movieForUpdate != null)
            {
                movieForUpdate.Title = movie.Title;
                movieForUpdate.ImgUrl = movie.ImgUrl;
                movieForUpdate.Stars = movie.Stars;
                movieForUpdate.Storyline = movie.Storyline;
                movieForUpdate.Genre = movie.Genre;
                movieForUpdate.DateModified = DateTime.Now;

                _moviesRepository.Update(movieForUpdate);
            }
            else
            {
                throw new NotFoundException($"The recipe with id {movie.Id} was not found");
            }
                

            
            
        }
    }
}
