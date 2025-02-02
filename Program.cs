using BookStore.Repositories;
using BookStore.Services;
using FluentValidation.AspNetCore;

using Serilog;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Настройка на Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo());
});

builder.Services.AddLogging(configure => configure.AddSerilog());

// Добавяне на зависимости за MongoDB

builder.Services.AddDbContext<ApplicationDbContext>(
                //options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
                options => options.UseSqlServer(builder.Configuration.GetValue<string>("DefaultConnection")));

var asd = builder.Configuration.GetValue<string>("DefaultConnection");
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAutorsService, AuthorsService>();


builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BookStore.Validations.BookValidator>());

var app = builder.Build();
app.MapSwagger();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

// Конфигурация на пътища и контролери
//app.UseSerilogRequestLogging();  // Логиране на заявките

app.MapControllers();
app.Run();

//Здравейте, колеги. В курсовия проект, трябва да имате поне:
// -N tier архитектура
// - 2 модела
// - 2 репоситорита (CRUD операции) към Монго или SQL с 2 сървиса към тях
// - 1 Бизнес сървис с 2 метода в него
// - 1 конторлер върху бизнес сървиса с 2 ендпойнта
// - Валидацаии на всички рекуести FluenValidation
// - хелт чекове
// - юнит тестове на бизнес сървиса - xUnit, Moq
// - логове - Serilog