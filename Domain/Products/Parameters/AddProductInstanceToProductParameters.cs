using Domain.ProductPositions;

namespace Domain.Products.Parameters;

public readonly struct AddProductInstanceToProductParameters
{
    public required IReadOnlyCollection<ProductInstance> ProductInstance { get; init; }
}