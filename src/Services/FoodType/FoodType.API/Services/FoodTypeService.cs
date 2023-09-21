// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Net.Http.Headers;
using System.Text;

namespace Vitals.FoodType.API;

public sealed class FoodTypeService(HttpClient httpClient) : IFoodTypeService
{
    public async ValueTask<IEnumerable<FoodTypeItem>> GetFoodTypesAsync(int providerId, string username, string password, CancellationToken cancellationToken = default)
    {
        string requestUri = $"api/1/food_providers/{providerId}/food_types";

        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));

        return await httpClient.GetFromJsonAsync<IEnumerable<FoodTypeItem>>(requestUri, cancellationToken) ?? Enumerable.Empty<FoodTypeItem>();
    }
}
