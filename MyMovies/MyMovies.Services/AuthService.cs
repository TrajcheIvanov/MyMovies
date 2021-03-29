using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyMovies.Services
{
    public class AuthService : IAuthService
    {
        private IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public StatusModel SignIn(string username, string password, bool isPersistent, HttpContext httpContext)
        {
            var response = new StatusModel();
            var user = _userRepository.GetUsername(username);

            if (user != null && BCrypt.Net.BCrypt.Verify(password,user.Password))
            {

                var claims = new List<Claim>()
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Username", user.Username),
                    new Claim("Email", user.Email),
                    new Claim("IsAdmin", user.IsAdmin.ToString())
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var authProps = new AuthenticationProperties() { IsPersistent = isPersistent };

                Task.Run(() => httpContext.SignInAsync(principal, authProps)).GetAwaiter().GetResult();


            }
            else
            {
                response.IsSuccessful = false;
                response.Message = "Username or password is incorrect";
            }

            return response;
        }

        public void SignOut(HttpContext httpContext)
        {
            Task.Run(() => httpContext.SignOutAsync()).GetAwaiter().GetResult();
        }

        public StatusModel SingUp(Models.User user)
        {
            var response = new StatusModel();

            var exist = _userRepository.CheckIfExists(user.Username, user.Email);

            if (exist)
            {
                response.IsSuccessful = false;
                response.Message = "UIser with username or email already exists";
            }
            else
            {
                var password = user.Password;
                user.Password = BCrypt.Net.BCrypt.HashPassword(password);
                user.DateCreated = DateTime.Now;
                _userRepository.Add(user);
            }

            return response;
        }
    }
}
