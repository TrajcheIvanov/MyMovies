using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected MyMoviesDbContext _context;
        public BaseRepository(MyMoviesDbContext context)
        {
            _context = context;
        }

        public virtual List<T> GetAll()
        {
            var result = _context.Set<T>().ToList();
            return result;
        }

        public virtual T GetById(int entityId)
        {
            var result = _context.Set<T>().Find(entityId);
            return result;
        }

        public virtual void Add(T newEntity)
        {
            _context.Set<T>().Add(newEntity);
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

    }
}
