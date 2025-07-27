using Bazar.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//adding services to the container 
//NOTE :builder.services is the container
builder.Services.AddControllers();

//Registering DbContext

builder.Services.AddDbContext<BazarDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//adding swagger (opne api)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app= builder.Build();

// Configure the HTTP request pipeline
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); 

app.Run();