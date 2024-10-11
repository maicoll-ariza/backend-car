using Microsoft.EntityFrameworkCore;
using VehiculosApi.Data; 


var builder = WebApplication.CreateBuilder(args);

// Agrega el contexto de la base de datos
builder.Services.AddDbContext<VehiculosContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("VehiculosContext")));
// Registrar los controladores
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Habilitar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowAllOrigins");
// Configuración del pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();
