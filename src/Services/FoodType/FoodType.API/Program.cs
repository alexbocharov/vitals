// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;

using Vitals.FoodType.API;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.Configure<FoodTYpeSettings>(builder.Configuration);

builder.Services.AddHttpClient<IFoodTypeService, FoodTypeService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["FoodProviderBaseUrl"]!);
});

builder.Services.AddDbContext<FoodTypeDbContext>(options => 
{
    var connectionString = builder.Configuration.GetConnectionString("foodtypedb") ?? throw new InvalidOperationException("The foodtypedb connection string is not found");
    options.UseNpgsql(connectionString);
});

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapHealthChecks("/health", new HealthCheckOptions() { Predicate = _ => true });
app.MapHealthChecks("/liveness", new HealthCheckOptions() { Predicate = r => r.Name.Contains("self") });

app.MapFoodTypeApi();

app.Run();
