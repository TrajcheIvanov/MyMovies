using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Mappings;
using MyMovies.Models;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System;

namespace MyMovies.Controllers
{
    public class UsersController : Controller
    {
        private IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [Authorize]
        public IActionResult Details(string errorMessage, string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;
            var userId = User.FindFirst("Id").Value;
            var user = _usersService.GetDetails(userId);

            if (user == null)
            {
                return RedirectToAction("ErrorNotFound", "Info");

            }

            return View(user.ToDetailsModel());
           
        }

        [Authorize]
        [HttpGet]
        public IActionResult Update()
        {
            var userId = User.FindFirst("Id").Value;
            var user = _usersService.GetDetails(userId);

            if (user == null)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
            return View(user.ToUpdateModel());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(UserUpdateModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userModel = user.ToModel();
                    userModel.Id = int.Parse(User.FindFirst("Id").Value);
                    var response = _usersService.Update(userModel);

                    if (response.IsSuccessful)
                    {
                        return RedirectToAction("Details", new { SuccessMessage = "User udpated sucessfully" });
                    }
                    else
                    {
                        return RedirectToAction("Details", new { ErrorMessage = response.Message });
                    }
                }
                catch (Exception)
                {

                    return RedirectToAction("ErrorNotFound", "Info");
                }
                
            }
            else
            {
                return View(user);
            }
        }

        public IActionResult ManageUsers()
        {
            var domainUsers = _usersService.GetAllUsers();

            return View(domainUsers.ToManageUserModels());
        }

        public IActionResult ToggleAdmin(int Id)
        {
            var response = _usersService.ToggleAdmin(Id);

            if (response.IsSuccessful)
            {
                return RedirectToAction("ManageUsers");
            }
            else
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }

        }

        public IActionResult Delete(int Id)
        {
            var response = _usersService.Delete(Id);

            if (response.IsSuccessful)
            {
                return RedirectToAction("ManageUsers");
            }
            else
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
        }

    }
}
