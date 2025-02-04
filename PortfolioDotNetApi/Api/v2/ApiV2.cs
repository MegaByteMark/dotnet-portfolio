using Asp.Versioning.Builder;
using Microsoft.EntityFrameworkCore;
using PortfolioDotNetApi.Models;
using PortfolioDotNetApi.Repos.DbContext;

namespace PortfolioDotNetApi.Api.v2;

public static class ApiV2
{
    public static RouteGroupBuilder MapApiV2(this RouteGroupBuilder routeGroupBuilder, ApiVersionSet apiVersionSet)
    {
        //TODO - This needs to be updated to use intradotnet repositories.

        routeGroupBuilder.MapGet("/developers", async (PortfolioDotNetApiDbContext dbContext) =>
        {
            return await dbContext.Developers.ToListAsync();
        })
        .WithApiVersionSet(apiVersionSet)
        .WithName("GetDevelopers_v2")
        .MapToApiVersion(2, 0)
        .HasDeprecatedApiVersion(1, 0); //example of how to mark an endpoint as deprecated.

        routeGroupBuilder.MapGet("/developers/{id}", async (PortfolioDotNetApiDbContext dbContext, Guid id) =>
        {
            return await dbContext.Developers.FindAsync(id);
        })
        .WithApiVersionSet(apiVersionSet)
        .WithName("GetDeveloper_v2")
        .MapToApiVersion(2, 0);

        routeGroupBuilder.MapPost("/developers", async (PortfolioDotNetApiDbContext dbContext, Developer developer) =>
        {
            dbContext.Developers.Add(developer);
            await dbContext.SaveChangesAsync();
            return developer;
        })
        .WithApiVersionSet(apiVersionSet)
        .WithName("AddDeveloper_v2")
        .MapToApiVersion(2, 0);

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
        .WithName("UpdateDeveloper_v2")
        .MapToApiVersion(2, 0);

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
        .WithName("RemoveDeveloper_v2")
        .MapToApiVersion(2, 0);

        routeGroupBuilder.MapGet("/ratings", async (PortfolioDotNetApiDbContext dbContext) =>
        {
            return await dbContext.Ratings.ToListAsync();
        })
        .WithApiVersionSet(apiVersionSet)
        .WithName("GetRatings_v2")
        .MapToApiVersion(2, 0);

        routeGroupBuilder.MapGet("/ratings/{id}", async (PortfolioDotNetApiDbContext dbContext, Guid id) =>
        {
            return await dbContext.Ratings.FindAsync(id);
        })
        .WithApiVersionSet(apiVersionSet)
        .WithName("GetRating_v2")
        .MapToApiVersion(2, 0);

        routeGroupBuilder.MapPost("/ratings", async (PortfolioDotNetApiDbContext dbContext, Rating rating) =>
        {
            dbContext.Ratings.Add(rating);
            await dbContext.SaveChangesAsync();
            return rating;
        })
        .WithApiVersionSet(apiVersionSet)
        .WithName("AddRating_v2")
        .MapToApiVersion(2, 0);

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
        .WithName("UpdateRating_v2")
        .MapToApiVersion(2, 0);

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
        .WithName("RemoveRating_v2")
        .MapToApiVersion(2, 0);

        return routeGroupBuilder;
    }
}