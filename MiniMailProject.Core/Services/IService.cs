using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniMailProject.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<T> TGetByIdAsync(int id);

        Task<IEnumerable<T>> TGetAllAsync();        
        IQueryable<T> TWhere(Expression<Func<T, bool>> expression);

        Task<bool> TAnyAsync(Expression<Func<T, bool>> expression);

        Task<T> TAddAsync(T entity);

        Task TDeleteAsync (T entity);
    }
}
