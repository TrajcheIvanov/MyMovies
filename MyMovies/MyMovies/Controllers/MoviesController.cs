using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Common.Exceptions;
using MyMovies.Common.Models;
using MyMovies.Common.Services;
using MyMovies.Mappings;
using MyMovies.Models;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System;
using System.Linq;

namespace MyMovies.Controllers
{
    [Authorize(Policy = "IsAdmin")]
    public class MoviesController : Controller
    {
        private IMoviesService _moviesService { get; set; }

        private ISidebarService _sidebarService { get; set; }

        private ILogService _logService { get; set; }

        private IMovieTypeService _moviesTypesService { get; set; }
        public MoviesController(
            IMoviesService service, 
            ISidebarService sidebarService, 
            ILogService logService,
            IMovieTypeService moviesTypesService)
        {
            _moviesService = service;
            _sidebarService = sidebarService;
            _logService = logService;
            _moviesTypesService = moviesTypesService;
        }

        [AllowAnonymous]
        public IActionResult Overview(string title)
        {
            //throw new Exception("this is test exception");

            var movies = _moviesService.GetMoviesWithFilters(title);

            var overviewDataModel = new MovieOverviewDataModel();

            var moviesOverviewModels = movies.Select(x => x.ToOverviewModel()).ToList();
            overviewDataModel.OverviewMovies = moviesOverviewModels;
            overviewDataModel.SidebarData = _sidebarService.GetSidebarData();


            return View(overviewDataModel);
        }
        
        public IActionResult ManageMovies(string errorMEssage, string successMessage, string updateMessage)
        {
            ViewBag.ErrorMessage = errorMEssage;
            ViewBag.SuccessMessage = successMessage;
            ViewBag.UpdateMEssage = updateMessage;
            var movies = _moviesService.GetAllMovies();

            var manageModels = movies.Select(x => x.ToManageMovieModel()).ToList();
            return View(manageModels);
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            try
            {
                var movie = _moviesService.GetMovieDetails(id);

                if (movie == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }

                var movieDetailsDataModel = new MovieDetailsDataModel();

                movieDetailsDataModel.MovieDetails = movie.ToDetailsModel();
                movieDetailsDataModel.SidebarData = _sidebarService.GetSidebarData();

                return View(movieDetailsDataModel);
            }
            catch (Exception)
            {

                return RedirectToAction("ErrorGeneral","Info");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            var movieTypes = _moviesTypesService.GetAll();
            var viewModels = movieTypes.Select(x => x.ToMovieTypeModel()).ToList();

            var viewModel = new MovieCreateModel();
            viewModel.MovieTypes = viewModels;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(MovieCreateModel movie)
        {
            if (ModelState.IsValid)
            {
                var domainModel = movie.ToModel();
                _moviesService.CreateMovie(domainModel);
                var userId = User.FindFirst("Id");
                var logData = new LogData() { Type = LogType.Info, DateCreated = DateTime.Now, Message = $"User with id {userId} created movie {movie.Title}" };
                _logService.Log(logData);
                
                return RedirectToAction("ManageMovies", new { SuccessMessage = "Movie added sucessfully"});
            }

            return View(movie);
        } 

        public IActionResult Delete(int Id)
        {
            try
            {
                _moviesService.Delete(Id);
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

        [HttpGet]
        public IActionResult Update(int Id)
        {
            try
            {
               var movie = _moviesService.GetMovieById(Id);

                if (movie != null)
                {
                    var viewModel = movie.ToUpdateModel();

                    var movieTypes = _moviesTypesService.GetAll();
                    var viewModels = movieTypes.Select(x => x.ToMovieTypeModel()).ToList();

                    viewModel.MovieTypes = viewModels;

                    return View(viewModel);
                } 
                else
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
        public IActionResult Update(MovieUpdateModel movie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _moviesService.Update(movie.ToModel());
                    return RedirectToAction("ManageMovies", new { UpdateMEssage = "Movie updated sucessfully" });
                }
                catch (NotFoundException ex)
                {

                    return RedirectToAction("ManageMovies", new { ErrorMessage = ex.Message });
                }
                catch (Exception)
                {
                    return RedirectToAction("InternalError", "Info");
                }

                
            }
            else
            {
                return RedirectToAction("InternalError", "Info");
            }
        }
    }
}
