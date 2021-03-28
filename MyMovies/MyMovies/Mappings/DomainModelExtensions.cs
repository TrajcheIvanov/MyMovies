using MyMovies.Models;
using MyMovies.ViewModels;

namespace MyMovies.Mappings
{
    public static class DomainModelExtensions
    {

        public static MovieOverviewModel ToOverviewModel(this Movie movie)
        {
            return new MovieOverviewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                ImgUrl = movie.ImgUrl,
                Genre = movie.Genre,

            };
        }

        public static MovieManageMoviesModel ToManageMovieModel(this Movie movie)
        {
            return new MovieManageMoviesModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                
            };
        }

        public static MovieDetailsModel ToDetailsModel(this Movie movie)
        {
            return new MovieDetailsModel()
            {
                Title = movie.Title,
                Genre = movie.Genre,
                Storyline = movie.Storyline,
                Stars = movie.Stars,
                ImgUrl = movie.ImgUrl,
                DateCreated = movie.DateCreated,

            };
        }

        public static MovieUpdateModel ToUpdateModel(this Movie movie)
        {
            return new MovieUpdateModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Storyline = movie.Storyline,
                Stars = movie.Stars,
                ImgUrl = movie.ImgUrl,

            };
        }

        public static UserDetailsModel ToDetailsModel(this User user)
        {
            return new UserDetailsModel()
            {
                Username = user.Username,
                Email = user.Email,
            };
        }

        public static UserUpdateModel ToUpdateModel(this User user)
        {
            return new UserUpdateModel()
            {
               Username = user.Username,
               Email = user.Email,

            };
        }
    }
}
