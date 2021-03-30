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

        public StatusModel Delete(int Id)
        {
            var response = new StatusModel();
            var userToDelete = _userRepository.GetById(Id);

            if (userToDelete != null)
            {
                _userRepository.Remove(userToDelete);
            }
            else
            {
                response.IsSuccessful = false;
            }

            return response;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetDetails(string userId)
        {
            return _userRepository.GetById(int.Parse(userId));
        }

        public StatusModel ToggleAdmin(int id)
        {
            var response = new StatusModel();

            var user = _userRepository.GetById(id);

            if (user.IsAdmin)
            {
                user.IsAdmin = false;
                Update(user);
            }
            else
            {
                user.IsAdmin = true;
                Update(user);
            }

            return response;
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
