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

        public Task<T> Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
