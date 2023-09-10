using Microsoft.EntityFrameworkCore;
using MiniMailProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MiniMailProject.Repository
{
    public class MailDbContext : DbContext
    {
        public MailDbContext(DbContextOptions<MailDbContext> options) : base(options)
        {
            
        }

        public DbSet<SendMail> SendMail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration kısmında ayrı ayrı entity özelliklerini belirlediğim alanda ki ayarlarımı anlaması için burada IEntityTypeConfiguration sınıfından türeyen tüm sınıflarını anlaması için metodumuzu yazdık.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
