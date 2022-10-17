using Contacts.API;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IContactDbContext, ContactDbContext>(options =>
            options.UseInMemoryDatabase("contact_db"));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddCors(options => options.AddPolicy("Access-Control-Allow-Origin", builder =>
{
    builder
    .SetIsOriginAllowed((host) => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .Build();
}));

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandling>();

app.UseCors("Access-Control-Allow-Origin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
