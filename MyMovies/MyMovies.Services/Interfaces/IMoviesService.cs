using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
    public interface IMoviesService
    {
        List<Movie> GetAllMovies();

        List<Movie> GetRecipesByTitle(string title);
        Movie GetMovieById(int id);

        void CreateMovie(Movie movie);

        void Delete(int Id);

        void Update(Movie movie);

        Movie GetMovieDetails(int id);
        List<Movie> GetMostRecentMovies(int count);
        List<Movie> GetTopMovies(int count);
    }
}
