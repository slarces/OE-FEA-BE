using Flag_Explorer_App.Infrastructure;
using Flag_Explorer_App.Infrastructure.Seeders;
using Flag_Explorer_App.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "Flag Explorer API", Version = "v1" });
});

// Configure SQLite Database
builder.Services.AddDbContext<FlagExplorerDbContext>(options =>
    options.UseSqlite("Data Source=flagexplorer.db").EnableSensitiveDataLogging(), ServiceLifetime.Scoped);

// Register HttpClient
builder.Services.AddHttpClient<CountryDataService>();

// Register country data service
builder.Services.AddScoped<CountryDataService>();


var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    IServiceProvider services = scope.ServiceProvider;
    FlagExplorerDbContext dbContext = services.GetRequiredService<FlagExplorerDbContext>();
    CountryDataService countryDataService = services.GetRequiredService<CountryDataService>();

    // Fetch and save data before migrations
    await countryDataService.FetchAndStoreCountriesAsync();

    // Apply migrations automatically
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Flag Explorer API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


