using MiniMailProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMailProject.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MailDbContext _context;

        public UnitOfWork(MailDbContext mailDbContext)
        {
            _context = mailDbContext;
        }

        // Değişikleri kaydedecek SaveChanges için toplu bir işlem gerekirse bu alanda yönetibiliriz.

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
