using Microsoft.EntityFrameworkCore;
using SimpleBookService.Web.Infra.Context;
using SimpleBookService.Web.Infra.Interfaces;
using SimpleBookService.Web.Infra.Repository;
using SimpleBookService.Web.Services;
using SimpleBookService.Web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("BooksDb")));

//Dependency injection Repo
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

//Dependency injection DTOs
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

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
