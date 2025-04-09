using GodRift.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Adiciona o contexto ao contêiner de injeção de dependência
builder.Services.AddDbContext<GodRiftContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GodRiftDb")));

// 🔧 Serviços do controlador + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🌐 Swagger (apenas em desenvolvimento)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// 🚀 Mapeia os endpoints dos controllers
app.MapControllers();

app.Run();
