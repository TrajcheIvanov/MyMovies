﻿using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyMovies.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private MyMoviesDbContext _context;

        public UsersRepository(MyMoviesDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool CheckIfExists(string username, string email)
        {
            return _context.Users.Any(x => x.Username == username || x.Email == email);
        }

        public List<User> GetAll()
        {
            var result = _context.Users.ToList();
            return result;
        }

        public User GetById(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.Id == userId);
        }

        public User GetUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
