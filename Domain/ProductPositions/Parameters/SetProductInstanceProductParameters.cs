using Domain.Products;

namespace Domain.ProductPositions.Parameters;

public readonly struct SetProductInstanceProductParameters
{
    public required Product Product { get; init; }
}