using DockerDemo.Data;
using DockerDemo.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();


// swagger service 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// to add all the DI 
builder.Services.AddApplicationServices();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    // Points to the generated JSON file
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");

    // This makes Swagger available at the root URL (e.g., http://localhost:5062/)
    options.RoutePrefix = string.Empty;
});
//}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//   app.MapOpenApi();
//}

//app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast =  Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast");

//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//    db.Database.Migrate(); // creates tables if they don't exist
//}

app.MapControllers();
app.Run();

//record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
