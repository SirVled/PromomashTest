using Microsoft.EntityFrameworkCore;
using PromomashTest.Infrastructure.Data;
using PromomashTest.Infrastructure.DependencyInjection;
using PromomashTest.Application.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Run migrations and seed
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
    await SeedData.EnsureSeedData(db);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseDefaultFiles();  
app.UseStaticFiles();   


app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();