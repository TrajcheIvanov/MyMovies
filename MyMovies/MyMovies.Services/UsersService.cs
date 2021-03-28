using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services
{
    public class UsersService : IUsersService
    {
        private IUserRepository _userRepository;
        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User GetDetails(string userId)
        {
            return _userRepository.GetById(int.Parse(userId));
        }

        public StatusModel Update(User user)
        {
            var response = new StatusModel();
            var updateUser = _userRepository.GetById(user.Id);

            if (updateUser != null)
            {

                updateUser.Email = user.Email;

                _userRepository.Update(updateUser);

                response.IsSuccessful = true;
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"The User with id {user.Id} was not found";
            }

            return response;
        }
    }
}
