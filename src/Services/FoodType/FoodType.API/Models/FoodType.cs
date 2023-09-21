// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Vitals.FoodType.API;

public class FoodType
{
    [JsonPropertyName("id")]
    public string Id { get; private set; }

    [JsonPropertyName("providerId")]
    public int ProviderId { get; init; }

    [JsonPropertyName("processed")]
    public bool Processed { get; init; }

    [JsonPropertyName("createdAt")]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("foodTypes")]
    public ICollection<FoodTypeItem> FoodTypes { get; init; } = new List<FoodTypeItem>();

    public FoodType()
    {
        Id = Guid.NewGuid().ToString();
    }
}

public record FoodTypeItem
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [JsonPropertyName("type")]
    public Type Type { get; init; } = default!;

    [JsonPropertyName("benefit")]
    public Benefit Benefit { get; init; } = default!;

    [JsonPropertyName("state")]
    public State State { get; init; } = default!;

    [JsonPropertyName("hotMeals")]
    public bool HotMeals { get; init; }

    [JsonPropertyName("regionalBudget")]
    public int RegionalBudget { get; init; }

    [JsonPropertyName("municipalBudget")]
    public int MunicipalBudget { get; init; }

    [JsonPropertyName("parentPayment")]
    public int ParentPayment { get; init; }
}

public record Type
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;
}

public record Benefit
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;
}

public record State
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;
}
