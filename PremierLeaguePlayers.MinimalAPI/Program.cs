using PremierLeaguePlayers.DataAccess;
using PremierLeaguePlayers.MinimalAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterEndpointDefinitions();
// app.UseAuthorization();

using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
try
{
    AppDbContext context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
    DataInitializer.SeedData(context).Wait();
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    throw;
}

app.Run();