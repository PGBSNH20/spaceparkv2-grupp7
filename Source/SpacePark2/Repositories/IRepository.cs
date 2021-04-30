using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SpacePark2.Repositories
{
    public interface IRepository
    {
        Task<T> Add<T>(T entity) where T : class;
        Task<T> Delete<T>(T entity) where T : class;
    }
}
