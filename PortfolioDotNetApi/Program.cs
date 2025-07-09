using Microsoft.EntityFrameworkCore;
using PortfolioDotNetApi.Health;
using PortfolioDotNetApi.Repos.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContextFactory<PortfolioDotNetApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;

    //This approach adds a version number to the URL route e.g. /v1/developers. 
    //The version of the route is definied in the minimal API route group.
    options.ApiVersionReader = new Asp.Versioning.UrlSegmentApiVersionReader();
});

builder.Services.AddHealthChecks().AddCheck<DatabaseHealthCheck>("Database");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseHealthChecks("/_health");

//Set up API versioning using a route group and then map api endpoints from api endpoints classes for that version.
var versionSet = app.NewApiVersionSet()
.HasApiVersion(new Asp.Versioning.ApiVersion(1, 0))
.ReportApiVersions()
.Build();

var groupBuilder = app.MapGroup("/v{version:apiVersion}");
//groupBuilder.MapApiV1(versionSet);
//groupBuilder.MapApiV2(versionSet);

app.Run();