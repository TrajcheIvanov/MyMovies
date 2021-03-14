using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace MyMovies.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        
        const string Path = "Movies.txt";
        public MoviesRepository()
        {
            if (!File.Exists(Path))
            {
                File.WriteAllText(Path, "[]");
            }

            var result = File.ReadAllText(Path);
            var deserializedList = JsonConvert.DeserializeObject<List<Movie>>(result);
            Movies = deserializedList;

            
        }

        public List<Movie> Movies { get; set; }

        public List<Movie> GetAll()
        {
            return Movies;
        }

        public Movie GetById(int id)
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Movie movie)
        {
            movie.Id = GenerateId();
            Movies.Add(movie);
            SaveChanges();
        }

        private int GenerateId()
        {
            var maxId = 0;

            if (Movies.Any())
            {
                maxId = Movies.Max(x => x.Id);
            }

            return maxId + 1;
        }

        private void SaveChanges()
        {
            var serialized = JsonConvert.SerializeObject(Movies);
            File.WriteAllText(Path, serialized);
        }
    }
}
