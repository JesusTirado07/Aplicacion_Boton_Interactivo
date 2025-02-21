using Examen_Aplicativo.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ExamenAplicativoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowFrontend");

using (var scope = app.Services.CreateScope())
{

    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ExamenAplicativoContext>();

    try
    {
        context.Database.OpenConnection();
        Console.WriteLine("Conexión a la base de datos exitosa.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error de conexión a la base de datos: {ex.Message}");
    }
    finally
    {
        context.Database.CloseConnection();
    }
}

if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/mensaje", async (ExamenAplicativoContext context) =>
{

    var mensaje = await context.Mensajes.OrderByDescending(m => m.Fecha).FirstOrDefaultAsync();

    if (mensaje == null)
    {
        return Results.NotFound(new { mensaje = "No hay mensajes en la base de datos" });
    }

    return Results.Ok(new { mensaje = $"{mensaje.Texto} - {mensaje.Fecha}" });
})
.WithName("GetMensaje")
.WithOpenApi();

app.Run();
