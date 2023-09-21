// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Vitals.FoodType.API;

public interface IFoodTypeService
{
    ValueTask<IEnumerable<FoodTypeItem>> GetFoodTypesAsync(int providerId, string username, string password, CancellationToken cancellationToken = default);
}
