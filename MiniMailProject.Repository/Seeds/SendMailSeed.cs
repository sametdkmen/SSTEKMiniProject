using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniMailProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMailProject.Repository.Seeds
{
    internal class SendMailSeed : IEntityTypeConfiguration<SendMail>
    {
        public void Configure(EntityTypeBuilder<SendMail> builder)
        {
            // Migration öncesi tablolarımıza örnek veriler eklemek amacı ile tıpki configuration dosyasında oluşturduğumuz gibi Entity'e özel ayarları ayrı bir sınıfta vermek daha tatlı, temiz.

            builder.HasData(new SendMail { Id = 1,To = "sametdikmendev@gmail.com", Body = "Seed özelliği denemek için oluşturduğum örnek verinin açıklaması", Subject = "Seed Özelliği", CreatedDate = DateTime.Now });
        }
    }
}
