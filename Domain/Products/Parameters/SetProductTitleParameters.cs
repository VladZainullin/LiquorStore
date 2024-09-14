// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Products.Parameters;

public readonly struct SetProductTitleParameters
{
    public required string Title { get; init; }
}