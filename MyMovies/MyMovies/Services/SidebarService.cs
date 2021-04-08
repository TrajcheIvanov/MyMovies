using MyMovies.Mappings;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Services
{
    public class SidebarService : ISidebarService
    {
        private IMoviesService _service;
        public SidebarService(IMoviesService service)
        {
            _service = service;
        }
        public MovieSidebarDataModel GetSidebarData()
        {
            var sidebarDataModel = new MovieSidebarDataModel();

            var mostRecentRecipes = _service.GetMostRecentMovies(5);
            var topRecipes = _service.GetTopMovies(5);

            sidebarDataModel.MostRecentMovies = mostRecentRecipes.Select(x => x.ToMovieSidebarModel()).ToList();
            sidebarDataModel.TopMovies = topRecipes.Select(x => x.ToMovieSidebarModel()).ToList();

            return sidebarDataModel;
        }
    }
}
