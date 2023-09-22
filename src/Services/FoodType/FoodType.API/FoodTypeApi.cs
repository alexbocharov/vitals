// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Http.HttpResults;

namespace Vitals.FoodType.API;

public static class FoodTypeApi
{
    public static IEndpointConventionBuilder MapFoodTypeApi(this IEndpointRouteBuilder endpoints)
    {
        var foodTypeService = endpoints.ServiceProvider.GetRequiredService<IFoodTypeService>();

        var routeGroup = endpoints.MapGroup("");

        routeGroup.MapPost("api/v1/providers/{providerId}/food-types", async Task<Results<Ok<FoodTypeResponse>, NotFound>> (FoodTypeDbContext db, int providerId, LoginRequest request) =>
        {
            var foodTypes = await foodTypeService.GetFoodTypesAsync(providerId, request.Username, request.Password);

            if (foodTypes is null)
            {
                return TypedResults.NotFound();
            }

            var foodType = new FoodType
            {
                ProviderId = providerId,
                Processed = true,
                FoodTypes = foodTypes
            };

            db.FoodTypes.Add(foodType);
            await db.SaveChangesAsync();

            var foodTypeResponse = new FoodTypeResponse
            {
                Id = foodType.Id,
                CreatedAt = foodType.CreatedAt,
                FoodTypes = foodType.FoodTypes
            };

            return TypedResults.Ok(foodTypeResponse);
        });

        return new MapFoodTypeEndpointsConventionBuilder(routeGroup);
    }

    private sealed class MapFoodTypeEndpointsConventionBuilder(RouteGroupBuilder inner) : IEndpointConventionBuilder
    {
        private IEndpointConventionBuilder InnerAsConventionBuilder => inner;

        public void Add(Action<EndpointBuilder> convention) => InnerAsConventionBuilder.Add(convention);
        public void Finally(Action<EndpointBuilder> convention) => InnerAsConventionBuilder.Finally(convention);
    }
}
