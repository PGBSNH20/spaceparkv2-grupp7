using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Repositories
{
    public class Repository : IRepository
    {
        protected readonly SpaceParkContext _context;

        public Repository(SpaceParkContext context)
        {
            _context = context;
        }

        public async Task<T> Add<T>(T entity) where T : class
        {
            await _context.Set<T>().AddAsync(entity);
            await Save();
            return entity;
        }

        public async Task<T> Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
            await Save();
            return entity;
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
