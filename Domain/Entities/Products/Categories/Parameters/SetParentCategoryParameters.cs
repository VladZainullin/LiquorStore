﻿// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Products.Categories.Parameters;

public sealed class SetParentCategoryParameters
{
    public required Category Category { get; init; }
}