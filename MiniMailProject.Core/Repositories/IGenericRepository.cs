using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniMailProject.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        
        IQueryable<T> GetAll();

        // entityRepository.where(x=>x.id).OrderBy.ToListAync();
        IQueryable<T> Where(Expression<Func<T,bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T,bool>> expression);

        Task AddAsync (T entity);

        void Delete(T entity);

    }
}
