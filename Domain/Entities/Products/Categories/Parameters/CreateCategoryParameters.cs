// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Products.Categories.Parameters;

public sealed class CreateCategoryParameters
{
    public required string Title { get; init; }

    public required Category? Parent { get; init; }
}