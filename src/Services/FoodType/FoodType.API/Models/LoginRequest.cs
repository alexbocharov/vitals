// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Vitals.FoodType.API;

public sealed class LoginRequest
{
    [JsonPropertyName("username")]
    public required string Username { get; init; }

    [JsonPropertyName("password")]
    public required string Password { get; init; }
}
