using Microsoft.EntityFrameworkCore;
using OT.Api.DataContext;
using OT.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OTApiSQLContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OTApiConnection")));

builder.Services.AddScoped<IShopRepository, ShopRepository>();
builder.Services.AddScoped<IShopClientRepository, ShopClientRepository>();
builder.Services.AddScoped<IVehicleDetailsRepository, VehicleDetailsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
