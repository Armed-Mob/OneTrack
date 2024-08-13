using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using OT.Api.DataContext;
using OT.Api.Repositories;
using OT.Shared;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Cors for OT.Blazor Connection
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOTBlazor",
        policy => policy.WithOrigins("https://localhost:7112") // The url of the OT.Blazor Frontend
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials() // Send credentials like cookies or auth headers.
        //.WithExposedHeaders("X-Custom-Header") // If custom header need exposed.
        .SetPreflightMaxAge(TimeSpan.FromSeconds(2520)));  // Cache pre-flight response.
});

// Add Db Context
builder.Services.AddDbContext<OTApiSQLContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OTApiConnection")));

// Add Repositories
builder.Services.AddScoped<IShopRepository, ShopRepository>();
builder.Services.AddScoped<IShopClientRepository, ShopClientRepository>();
builder.Services.AddScoped<IVehicleDetailsRepository, VehicleDetailsRepository>();
builder.Services.AddScoped<IVehicleColorRepository, VehicleColorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            // Log the error detail
            ILogger logger = context.RequestServices.GetRequiredService<ILogger<StartupBase>>();
            logger.LogError(contextFeature.Error, "Unhandled exception occurred.");

            await context.Response.WriteAsync(new ErrorDetail()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error. Please try again later."
            }.ToString());
        }
    });
});

app.UseCors("AllowOTBlazor");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
