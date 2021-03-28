using MyMovies.Models;
using MyMovies.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
    public interface IUsersService
    {
        User GetDetails(string userId);

        StatusModel Update(User user);
    }
}
