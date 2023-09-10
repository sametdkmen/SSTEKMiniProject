using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MiniMailProject.Core.Configuration;
using MiniMailProject.Core.Repositories;
using MiniMailProject.Core.Services;
using MiniMailProject.Core.UnitOfWorks;
using MiniMailProject.Repository;
using MiniMailProject.Repository.Repositories;
using MiniMailProject.Repository.UnitOfWorks;
using MiniMailProject.Service.Mapping;
using MiniMailProject.Service.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//UnitOfWork i�in yaz�yoruz.
builder.Services.AddScoped<IUnitOfWork,UnitOfWork> ();

//Di�er hizmet kay�tlar�n� ekliyoruz..
builder.Services.AddScoped<ISendMailService, SendMailService>();
builder.Services.AddScoped<ISendMailRepository, SendMailRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));


// AutoMapper ile Mapledi�imiz Yap�lar�n Class Adlar�n� Veriyoruz
builder.Services.AddAutoMapper(typeof(MapProfile));

// appsettings.json ��inde Olu�turdu�umuz Email Ayarlar�n� Ekliyoruz
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));


// burada connectionString ve Configuration ayarlar�m� tan�t�yorum.
builder.Services.AddDbContext<MailDbContext>(
    x=>{        
        x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
        {
            // tip g�venli �ekilde ismini ekledik
            option.MigrationsAssembly(Assembly.GetAssembly(typeof(MailDbContext)).GetName().Name);
        });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
