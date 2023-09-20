// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapHealthChecks("/health", new HealthCheckOptions() { Predicate = _ => true });
app.MapHealthChecks("/liveness", new HealthCheckOptions() { Predicate = r => r.Name.Contains("self") });

app.MapGet("/", () => "Vitals FoodType API");

app.Run();
