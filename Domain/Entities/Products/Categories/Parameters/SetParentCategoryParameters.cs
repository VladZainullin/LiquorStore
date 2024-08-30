// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Products.Categories.Parameters;

public sealed class SetParentCategoryParameters
{
    public required Category? Parent { get; init; }
}