using API.ApiServices.JikanService;
using Application.Animes;
using Application.Core;
using Application.Interfaces;
using Infrastructure.Photos;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<JikanService>((serviceProvider, httpClient) =>
{
    httpClient.BaseAddress = new Uri("https://api.jikan.moe/v4/");
})
.ConfigurePrimaryHttpMessageHandler(() => 
{
    return new SocketsHttpHandler
    {
        PooledConnectionLifetime = TimeSpan.FromMinutes(5)
    };
});

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
    });
});

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(List.Handler).Assembly));
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("Cloudinary"));
builder.Services.AddScoped<IPhotoAccessor, PhotoAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    // var context = services.GetRequiredService<DataContext>();
    // await context.Database.MigrateAsync();
    // await Seed.SeedGenres(context);
    // await Seed.SeedAnimes(context);
    // await Seed.SeedAnimeGenres(context);

    var jikan = services.GetRequiredService<JikanService>();
    // await jikan.SeedCharacters();
    await jikan.LoopThroughManga();
    // await jikan.Cleanup();
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred.");
}

app.Run();
