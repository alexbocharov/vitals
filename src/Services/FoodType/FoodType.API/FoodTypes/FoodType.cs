// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace FoodType.API;

public record FoodType
{
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public Type Type { get; init; } = default!;
    public Benefit Benefit { get; init; } = default!;
    public State State { get; init; } = default!;
    public bool HotMeals { get; init; }
    public int RegionalBudget { get; init; }
    public int MunicipalBudget { get; init; }
    public int Parentpayment { get; init; }
}

public record Type
{
    public int Id { get; init; }
    public string Name { get; init; } = default!;
}

public record Benefit
{
    public int Id { get; init; }
    public string Name { get; init; } = default!;
}

public record State
{
    public int Id { get; init; }
    public string Name { get; init; } = default!;
}
