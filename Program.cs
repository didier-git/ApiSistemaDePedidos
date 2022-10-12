using Microsoft.EntityFrameworkCore;
using PruebaTSistemaDePedidos.Context;
using PruebaTSistemaDePedidos.Interfaces;
using PruebaTSistemaDePedidos.Repositorios;


var Cors = "MyCors";

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));
builder.Services.AddScoped<I_RepositorioProducto, RepositorioProducto>();
builder.Services.AddScoped<I_RepositorioPedido, RepositorioPedido>();

//Habilitando cors

builder.Services.AddCors(
    options=> options.AddPolicy(name:Cors,buid => 
    buid.WithOrigins("http://localhost:4200")
    .AllowAnyHeader()
    .AllowAnyMethod()));


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

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(Cors);
app.UseAuthorization();

app.MapControllers();

app.Run();
