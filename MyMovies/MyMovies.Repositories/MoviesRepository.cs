using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repositories
{
    public class MoviesRepository
    {
        public List<Movie> Movies { get; set; }

        public MoviesRepository()
        {
            var movie3 = new Movie()
            {
                Id = 3,
                Title = "The Godfather",
                ImgUrl = "https://static3.srcdn.com/wordpress/wp-content/uploads/2020/12/The-Godfather-trilogy.jpg",
                Stars = "Marlon Brando, Al Pacino, James Caan",
                Genre = "Crime, Drama",
                Storyline = "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son."
            };

            var movie2 = new Movie()
            {
                Id = 2,
                Title = "Blood Diamond",
                ImgUrl = "https://fc480b5189c535d5b417-91c94059efc677f9d43e33555c730d09.ssl.cf1.rackcdn.com/BDD_03497.jpg",
                Stars = "Leonardo DiCaprio, Djimon Hounsou, Jennifer Connelly",
                Genre = "Adventure, Drama, Thriller",
                Storyline = "A fisherman, a smuggler, and a syndicate of businessmen match wits over the possession of a priceless diamond."
            };

            var movie1 = new Movie()
            {
                Id = 1,
                Title = "City of God",
                ImgUrl = "https://www.slantmagazine.com/wp-content/uploads/2015/07/interviews_fernandomeirelles.jpg",
                Stars = " Alexandre Rodrigues, Leandro Firmino, Matheus Nachtergaele",
                Genre = "Crime, Drama",
                Storyline = "In the slums of Rio, two kids' paths diverge as one struggles to become a photographer and the other a kingpin."
            };

            Movies = new List<Movie> { movie1, movie2, movie3 };
        }

        public List<Movie> GetAll()
        {
            return Movies;
        }

        public Movie GetById(int id)
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }
    }
}
