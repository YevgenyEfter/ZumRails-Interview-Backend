using RestSharp;
using ZumRails_Interview_Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPokemonService, PokemonService>(service =>
{
    var pokemonApiUrl = builder.Configuration.GetValue<string>("PokemonApiUrl");
    if (pokemonApiUrl is null)
    {
        throw new ArgumentNullException("PokemonApiUrl is not defined.");
    }
    var client = new RestClient(pokemonApiUrl);
    return new PokemonService(client);
});
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IPokemonResultsSorter, PokemonResultsSorter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// The next line is for development purposes only, should not be used in production.
app.UseCors(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
