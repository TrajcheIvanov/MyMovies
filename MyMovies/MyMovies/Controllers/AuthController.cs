﻿using Microsoft.AspNetCore.Mvc;
using MyMovies.Mappings;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;


namespace MyMovies.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInModel signInModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var response = _authService.SignIn(signInModel.Username, signInModel.Password,signInModel.IsPersistent, HttpContext);

                if (response.IsSuccessful)
                {
                    if (returnUrl == null)
                    {
                        return RedirectToAction("Overview", "Movies");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                    return View(signInModel);
                }
            }
            else
            {
                return View(signInModel);
            }
        }

        public IActionResult SignOut()
        {
            _authService.SignOut(HttpContext);
            return RedirectToAction("Overview", "Movies");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                var user = signUpModel.ToModel();

                var response = _authService.SingUp(user);

                if (response.IsSuccessful)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                    return View(signUpModel);
                }
                
            }
            else
            {
                return View(signUpModel);
            }

        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
