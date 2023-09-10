using Microsoft.EntityFrameworkCore;
using MiniMailProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniMailProject.Repository.Repositories
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {

        protected readonly MailDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(MailDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            // AsNoTracking track etmeden getirsin (memory de yer kaplamasın, AsQueryable Koleksiyonu IQueryable olarak döndürür ve IEnumerable özellikleri de barındırır.
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
