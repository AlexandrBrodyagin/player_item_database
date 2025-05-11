using Microsoft.EntityFrameworkCore;
using NewProject.Data;  
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection")));

var app = builder.Build();

app.MapGet("/db-check", async (IConfiguration config) => {
    var cs = config.GetConnectionString("PostgreSQLConnection");
    try {
        await using var conn = new NpgsqlConnection(cs);
        await conn.OpenAsync();
        return $"Успех! Версия PostgreSQL: {conn.PostgreSqlVersion}";
    } catch (Exception ex) {
        return $"Ошибка: {ex.Message}\nИспользуемая строка: {cs}";
    }
});

app.Run();


