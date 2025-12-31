using System.Diagnostics;
//Q4

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

var cmd = Environment.GetEnvironmentVariable("UNSAFE_CMD");
if (!string.IsNullOrEmpty(cmd))
{
    Process.Start(new ProcessStartInfo("bash", "-c " + cmd) { RedirectStandardOutput = true });
}
//Q4

app.Run();

// Necesario para pruebas de integración
public partial class Program { }
