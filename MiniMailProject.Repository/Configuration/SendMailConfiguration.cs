using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniMailProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMailProject.Repository.Configuration
{
    internal class SendMailConfiguration : IEntityTypeConfiguration<SendMail>
    {
        public void Configure(EntityTypeBuilder<SendMail> builder)
        {
            // Burası override onmodelcreating metodunu parçaladığımız kısım => Burada kirletmeden temiz şekilde Entitylere özgü Fluent API ile ayarlarımızı yapabiliriz.
            // Burada ki ayarlarımı anlaması için MailDbContext sınıfım içinde ki ana onmodelcreating metoduma, modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); bunu vericem

            // SendMail için Base Entity sınıfımdan aldığım Id sütunu kesin olarak Primary Key diye açık açık belirttim                         
            builder.HasKey(x => x.Id);

            // Id Sütununun Otomatik artan sütun olduğunu belirttim
            builder.Property(x=>x.Id).UseIdentityColumn();
        }
    }
}
