using Microsoft.EntityFrameworkCore;
using SalesStock.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// ✅ Registro do DbContext (injeção de dependência)
builder.Services.AddDbContext<SalesStockDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controllers
builder.Services.AddControllers();

// Logs no console (opcional)
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
