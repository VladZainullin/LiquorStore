using Domain.MeasurementUnitPositions;
using Domain.Products;

namespace Domain.ProductPositions.Parameters;

public readonly struct CreateProductInstanceParameters
{
    public required Product Product { get; init; }

    public required MeasurementUnitPosition MeasurementUnitPosition { get; init; }
}