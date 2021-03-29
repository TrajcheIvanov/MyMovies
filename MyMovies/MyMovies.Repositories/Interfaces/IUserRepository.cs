using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUsername(string username);

        User GetById(int userId);

        void Update(User user);

        bool CheckIfExists(string username, string email);
        void Add(User user);
    }
}
