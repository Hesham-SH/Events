using Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SiteContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapControllers();

using var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;

var context = service.GetRequiredService<SiteContext>();

try
{
    await context.Database.MigrateAsync();
    await SeedData.Seed(context);
}
catch (Exception ex)
{
    
    var logger = service.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An Error Occured During The Migration !");
}

app.Run();
