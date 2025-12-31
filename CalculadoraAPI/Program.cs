var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Q4

var userInput = Environment.GetEnvironmentVariable("UNSAFE_INPUT");

// DEMO Q4: ejecución insegura de comandos
if (!string.IsNullOrEmpty(userInput))
{
    System.Diagnostics.Process.Start(userInput);
}
//Q4

app.Run();

// Necesario para pruebas de integración
public partial class Program { }
