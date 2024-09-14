using Domain.ProductPositions;

namespace Domain.Products.Parameters;

public readonly struct RemoveProductInstanceToProductParameters
{
    public required IReadOnlyCollection<ProductInstance> ProductInstance { get; init; }
}