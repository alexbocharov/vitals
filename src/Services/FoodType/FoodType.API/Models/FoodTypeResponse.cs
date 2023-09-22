// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Vitals.FoodType.API;

public sealed class FoodTypeResponse
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("createdAt")]
    public required DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("foodTypes")]
    public required ICollection<FoodTypeItem> FoodTypes { get; init; } = new List<FoodTypeItem>();
}
