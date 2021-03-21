using Microsoft.AspNetCore.Mvc;
using MyMovies.Common.Exceptions;
using MyMovies.Models;
using MyMovies.Services.Interfaces;
using System;

namespace MyMovies.Controllers
{
    public class MoviesController : Controller
    {
        private IMoviesService _service { get; set; }

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public IActionResult Overview(string title)
        {
            var movies = _service.GetRecipesByTitle(title);
            return View(movies);
        }
        
        public IActionResult ManageMovies(string errorMEssage, string successMessage, string updateMessage)
        {
            ViewBag.ErrorMessage = errorMEssage;
            ViewBag.SuccessMessage = successMessage;
            ViewBag.UpdateMEssage = updateMessage;
            var movies = _service.GetAllMovies();
            return View(movies);
        }
        public IActionResult Details(int id)
        {
            try
            {
                var movie = _service.GetMovieById(id);

                if (movie == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }

                return View(movie);
            }
            catch (Exception)
            {

                return RedirectToAction("ErrorGeneral","Info");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _service.CreateMovie(movie);
                return RedirectToAction("ManageMovies", new { SuccessMessage = "Movie added sucessfully"});
            }

            return View(movie);
        }

        public IActionResult Delete(int Id)
        {
            try
            {
                _service.Delete(Id);
                return RedirectToAction("ManageMovies", new { SuccessMessage = "Movie deleted sucessfully" });
            }
            catch (NotFoundException ex)
            {

                return RedirectToAction("ManageMovies", new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return RedirectToAction("InternalError", "Info");
            }
        }

        public IActionResult Edit(int Id)
        {
            try
            {
               var movie = _service.GetMovieById(Id);

                if (movie != null)
                {
                    return RedirectToAction("EditMovie", "Movies", movie);
                } else
                {
                    throw new NotFoundException($"The Movie with Id {Id} was not found");
                }
               
            }
            catch (NotFoundException ex)
            {

                return RedirectToAction("ManageMovies", new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return RedirectToAction("InternalError", "Info");
            }
        }

        public IActionResult EditMovie(Movie movie)
        {
            return View(movie);
        }

        [HttpPost]
        public IActionResult Update(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _service.Update(movie);
                return RedirectToAction("ManageMovies", new { UpdateMEssage = "Movie updated sucessfully" });
            }
            else
            {
                return RedirectToAction("InternalError", "Info");
            }

            
        }

    }
}
