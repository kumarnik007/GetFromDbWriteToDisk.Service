using Microsoft.EntityFrameworkCore;
using Service.API.Configuration;
using Service.Infra.DbConnections;
using Service.Models.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add Db context
var connectionString = ConnectionString.Create();
builder.Services.AddDbContext<DocumentContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

AppConfiguration.AddEndpoints(app, builder.Configuration);

app.Run();
