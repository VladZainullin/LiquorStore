namespace Domain.Products.Parameters;

public readonly struct CreateProductParameters
{
    public required Guid Id { get; init; }

    public required string Title { get; init; }

    public required string Description { get; init; }
}