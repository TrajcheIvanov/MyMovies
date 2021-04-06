using MyMovies.Models;
using MyMovies.ViewModels;
using System.Collections.Generic;
using System.Linq;

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
                Views = movie.Views

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
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Storyline = movie.Storyline,
                Stars = movie.Stars,
                ImgUrl = movie.ImgUrl,
                DateCreated = movie.DateCreated,
                Comments = movie.Comments.Select(x=> x.ToCommentModel()).ToList()

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

        public static TopFiveViewedSideBarModel ToTopFiveViewed (this Movie movie)
        {
            return new TopFiveViewedSideBarModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Views = movie.Views,
            };

        }

        public static TopNewFiveSideBarModel ToTopNewFiveModel(this Movie movie)
        {
            return new TopNewFiveSideBarModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                DateCreated = movie.DateCreated,
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

        public static List<ManageUserModel> ToManageUserModels(this List<User> users)
        {
            var manageUsers = new List<ManageUserModel>();

            foreach (var user in users)
            {
                var newManageUserModel = new ManageUserModel();
                newManageUserModel.Id = user.Id;
                newManageUserModel.Username = user.Username;
                newManageUserModel.IsAdministrator = user.IsAdmin;

                manageUsers.Add(newManageUserModel);
            }

            return manageUsers;
        }

        public static MovieCommentModel ToCommentModel(this Comment comment)
        {
            return new MovieCommentModel
            {
                Id = comment.Id,
                Message = comment.Message,
                DateCreated = comment.DateCreated,
                Username = comment.User.Username
            };

        }

       
    }
}
