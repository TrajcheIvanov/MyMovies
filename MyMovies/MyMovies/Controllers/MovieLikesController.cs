using Microsoft.AspNetCore.Mvc;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    public class MovieLikesController : Controller
    {
        private IMovieLikeService _movieLikeService;
        public MovieLikesController(IMovieLikeService movieLikeService)
        {
            _movieLikeService = movieLikeService;
        }
        public IActionResult Add(int movieId)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);

            _movieLikeService.Add(movieId, userId);

            return RedirectToAction("Overview", "Movies");

        }

        public IActionResult Remove(int movieId)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);

            _movieLikeService.Remove(movieId, userId);

            return RedirectToAction("Overview", "Movies");

        }
    }
}
