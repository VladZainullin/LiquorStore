using Domain.ProductPositions;
using Domain.Products.Parameters;

namespace Domain.Products;

public sealed class Product
{
    private Guid _id = Guid.NewGuid();
    private string _title = default!;
    private string _description = default!;
    private readonly List<ProductInstance> _productInstances = [];

    public Product()
    {
    }

    public Product(CreateProductParameters parameters)
    {
        SetTitle(new SetProductTitleParameters
        {
            Title = parameters.Title
        });
        
        SetDescription(new SetProductDescriptionParameters
        {
            Description = parameters.Description
        });
    }

    public Guid Id => _id;

    public string Title => _title;

    public void SetTitle(SetProductTitleParameters parameters)
    {
        _title = parameters.Title;
    }

    public string Description => _description;

    public void SetDescription(SetProductDescriptionParameters parameters)
    {
        _description = parameters.Description;
    }

    public IReadOnlyCollection<ProductInstance> ProductInstances => _productInstances.AsReadOnly();

    public void AddProductInstance(AddProductInstanceToProductParameters parameters)
    {
        foreach (var productInstance in parameters.ProductInstance)
        {
            _productInstances.Add(productInstance);
        }
    }
    
    public void RemoveProductInstance(RemoveProductInstanceToProductParameters parameters)
    {
        foreach (var productInstance in parameters.ProductInstance)
        {
            _productInstances.Remove(productInstance);
        }
    }
}