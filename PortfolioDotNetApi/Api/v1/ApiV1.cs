using Asp.Versioning.Builder;
using Microsoft.EntityFrameworkCore;
using PortfolioDotNetApi.Models;
using PortfolioDotNetApi.Repos.DbContext;

namespace PortfolioDotNetApi.Api.v1;

public static class ApiV1
{
    public static RouteGroupBuilder MapApiV1(this RouteGroupBuilder routeGroupBuilder, ApiVersionSet apiVersionSet)
    {
        //TODO - This needs to be updated to use intradotnet repositories.

        routeGroupBuilder.MapGet("/developers", async (PortfolioDotNetApiDbContext dbContext) =>
        {
            return await dbContext.Developers.ToListAsync();
        })
        .WithApiVersionSet(apiVersionSet)
        .WithName("GetDevelopers")
        .MapToApiVersion(1, 0)
        .HasDeprecatedApiVersion(1, 0); //example of how to mark an endpoint as deprecated.

        routeGroupBuilder.MapGet("/developers/{id}", async (PortfolioDotNetApiDbContext dbContext, Guid id) =>
        {
            return await dbContext.Developers.FindAsync(id);
        })
        .WithApiVersionSet(apiVersionSet)
        .WithName("GetDeveloper")
        .MapToApiVersion(1, 0);

        routeGroupBuilder.MapPost("/developers", async (PortfolioDotNetApiDbContext dbContext, Developer developer) =>
        {
            dbContext.Developers.Add(developer);
            await dbContext.SaveChangesAsync();
            return developer;
        })
        .WithApiVersionSet(apiVersionSet)
        .WithName("AddDeveloper")
        .MapToApiVersion(1, 0);

        routeGroupBuilder.MapPut("/developers/{id}", async (PortfolioDotNetApiDbContext dbContext, Guid id, Developer developer) =>
        {
            if (id != developer.Id)
            {
                throw new Exception("Id mismatch");
            }

            dbContext.Entry(developer).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return developer;
        })
        .WithApiVersionSet(apiVersionSet)
        .WithName("UpdateDeveloper")
        .MapToApiVersion(1, 0);

        routeGroupBuilder.MapDelete("/developers/{id}", async (PortfolioDotNetApiDbContext dbContext, Guid id) =>
        {
            var developer = await dbContext.Developers.FindAsync(id);
            if (developer == null)
            {
                throw new Exception("Developer not found");
            }

            dbContext.Developers.Remove(developer);
            await dbContext.SaveChangesAsync();
            return developer;
        })
        .WithApiVersionSet(apiVersionSet)
        .WithName("RemoveDeveloper")
        .MapToApiVersion(1, 0);

        routeGroupBuilder.MapGet("/ratings", async (PortfolioDotNetApiDbContext dbContext) =>
        {
            return await dbContext.Ratings.ToListAsync();
        })
        .WithApiVersionSet(apiVersionSet)
        .WithName("GetRatings")
        .MapToApiVersion(1, 0);

        routeGroupBuilder.MapGet("/ratings/{id}", async (PortfolioDotNetApiDbContext dbContext, Guid id) =>
        {
            return await dbContext.Ratings.FindAsync(id);
        })
        .WithApiVersionSet(apiVersionSet)
        .WithName("GetRating")
        .MapToApiVersion(1, 0);

        routeGroupBuilder.MapPost("/ratings", async (PortfolioDotNetApiDbContext dbContext, Rating rating) =>
        {
            dbContext.Ratings.Add(rating);
            await dbContext.SaveChangesAsync();
            return rating;
        })
        .WithApiVersionSet(apiVersionSet)
        .WithName("AddRating")
        .MapToApiVersion(1, 0);

        routeGroupBuilder.MapPut("/ratings/{id}", async (PortfolioDotNetApiDbContext dbContext, Guid id, Rating rating) =>
        {
            if (id != rating.Id)
            {
                throw new Exception("Id mismatch");
            }

            dbContext.Entry(rating).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return rating;
        })
        .WithApiVersionSet(apiVersionSet)
        .WithName("UpdateRating")
        .MapToApiVersion(1, 0);

        routeGroupBuilder.MapDelete("/ratings/{id}", async (PortfolioDotNetApiDbContext dbContext, Guid id) =>
        {
            var rating = await dbContext.Ratings.FindAsync(id);
            if (rating == null)
            {
                throw new Exception("Rating not found");
            }

            dbContext.Ratings.Remove(rating);
            await dbContext.SaveChangesAsync();
            return rating;
        })
        .WithApiVersionSet(apiVersionSet)
        .WithName("RemoveRating")
        .MapToApiVersion(1, 0);

        return routeGroupBuilder;
    }
}