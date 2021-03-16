using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyMovies.Repositories
{
    public class MoviesSqlRepository : IMoviesRepository
    {
        public void Add(Movie movie)
        {
            using (var cnn = new SqlConnection("Server=(LocalDb)\\MSSQLLocalDB;Database=MyMoviesSql;Trusted_Connection=True;"))
            {
                cnn.Open();

                var query = @"insert into movies(Title, Genre, ImgUrl, Stars, Storyline) values(@Title, @Genre, @ImgUrl, @Stars, @Storyline)";


                var cmd = new SqlCommand(query, cnn);

                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@Genre", movie.Genre);
                cmd.Parameters.AddWithValue("@ImgUrl", movie.ImgUrl);
                cmd.Parameters.AddWithValue("@Stars", movie.Stars);
                cmd.Parameters.AddWithValue("@Storyline", movie.Storyline);

                cmd.ExecuteNonQuery();
            }

            
        }

        public List<Movie> GetAll()
        {
            var result = new List<Movie>();

            using (var cnn = new SqlConnection("Server=(LocalDb)\\MSSQLLocalDB;Database=MyMoviesSql;Trusted_Connection=True;"))
            {
                cnn.Open();

                var query = "Select * from movies";
                var cmd = new SqlCommand(query, cnn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var movie = new Movie();

                    movie.Id = reader.GetInt32(0);
                    movie.Title = reader.GetString(1);
                    movie.Genre = reader.GetString(2);
                    movie.ImgUrl = reader.GetString(3);
                    movie.Stars = reader.GetString(4);
                    movie.Storyline = reader.GetString(5);

                    result.Add(movie);
                }
            }

                return result;
        }

        public Movie GetById(int id)
        {
            Movie result = null;

            using (var cnn = new SqlConnection("Server=(LocalDb)\\MSSQLLocalDB;Database=MyMoviesSql;Trusted_Connection=True;"))
            {
                cnn.Open();

                var query = $"Select * from movies where id = @Id";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Id", id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = new Movie();

                    result.Id = reader.GetInt32(0);
                    result.Title = reader.GetString(1);
                    result.Genre = reader.GetString(2);
                    result.ImgUrl = reader.GetString(3);
                    result.Stars = reader.GetString(4);
                    result.Storyline = reader.GetString(5);
                }
            }

            return result;
        }
    }
}
