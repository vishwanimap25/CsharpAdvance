using EnitityFrameworkCodeFirstApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//<------------------These two lines which i have to add--------------------------------->
var newConnection = builder.Configuration.GetConnectionString("dbcs");  /////////////////
builder.Services.AddDbContext<DBcontextFile>(x => x.UseSqlServer(newConnection));///////////////
//<------------------End of These two lines which i have to add--------------------------------->

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
