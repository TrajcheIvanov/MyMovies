using MyMovies.Models;
using MyMovies.ViewModels;

namespace MyMovies.Mappings
{
    public static class ViewModelExtensions
    {
        public static Movie ToModel(this MovieCreateModel viewModel)
        {
            return new Movie
            {
                Title = viewModel.Title,
                ImgUrl = viewModel.ImgUrl,
                Stars = viewModel.Stars,
                Storyline = viewModel.Storyline,
                Genre = viewModel.Genre,
            };

        }

        public static Movie ToModel(this MovieUpdateModel viewModel)
        {
            return new Movie
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                ImgUrl = viewModel.ImgUrl,
                Stars = viewModel.Stars,
                Storyline = viewModel.Storyline,
                Genre = viewModel.Genre,
            };
        }

    }
}
