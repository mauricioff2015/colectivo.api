using Colectivo.Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

const string CorsPolicy = "AllowFlutterWeb";
builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsPolicy, policy =>
    {
        policy.WithOrigins("http://localhost:8080", "http://127.0.0.1:8080", "http://localhost:52770")
              .AllowAnyHeader()
              .AllowAnyMethod();
        // .AllowCredentials(); // solo si usas cookies/sesión
    });
});

// Add services to the container.
builder.Services.AddDbContext<ColectivoDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("ColectivoDb")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddAuthentication(); // Descomenta si usas autenticación
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(CorsPolicy);
// app.UseAuthentication(); // Descomenta si usas autenticación
app.UseAuthorization();

app.MapControllers();

app.Run();
