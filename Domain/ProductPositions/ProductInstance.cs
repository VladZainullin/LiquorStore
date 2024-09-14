using Domain.MeasurementUnitPositions;
using Domain.ProductPositions.Parameters;
using Domain.Products;

namespace Domain.ProductPositions;

public sealed class ProductInstance
{
    private Product _product = default!;

    private MeasurementUnitPosition _measurementUnitPosition = default!;
    
    private ProductInstance()
    {
    }

    public ProductInstance(CreateProductInstanceParameters parameters) : this()
    {
        SetProduct(new SetProductInstanceProductParameters
        {
            Product = parameters.Product
        });
        
        SetMeasurementUnitValue(new SetProductInstanceMeasurementUnitValueParameters
        {
            MeasurementUnitPosition = parameters.MeasurementUnitPosition
        });
    }

    public void SetMeasurementUnitValue(SetProductInstanceMeasurementUnitValueParameters parameters)
    {
        _measurementUnitPosition = parameters.MeasurementUnitPosition;
    }

    public void SetProduct(SetProductInstanceProductParameters parameters)
    {
        _product = parameters.Product;
    }
}