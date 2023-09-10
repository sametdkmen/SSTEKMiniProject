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

//UnitOfWork için yazýyoruz.
builder.Services.AddScoped<IUnitOfWork,UnitOfWork> ();

//Diðer hizmet kayýtlarýný ekliyoruz..
builder.Services.AddScoped<ISendMailService, SendMailService>();
builder.Services.AddScoped<ISendMailRepository, SendMailRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));


// AutoMapper ile Maplediðimiz Yapýlarýn Class Adlarýný Veriyoruz
builder.Services.AddAutoMapper(typeof(MapProfile));

// appsettings.json Ýçinde Oluþturduðumuz Email Ayarlarýný Ekliyoruz
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));


// burada connectionString ve Configuration ayarlarýmý tanýtýyorum.
builder.Services.AddDbContext<MailDbContext>(
    x=>{        
        x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
        {
            // tip güvenli þekilde ismini ekledik
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
