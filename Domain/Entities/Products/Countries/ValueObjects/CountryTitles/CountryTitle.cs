// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local

using Domain.Entities.Products.Countries.ValueObjects.CountryTitles.Exceptions;

namespace Domain.Entities.Products.Countries.ValueObjects.CountryTitles;

public readonly record struct CountryTitle
{
    private CountryTitle(string value)
    {
        if (value.Length == default) throw new CountryTitleIsEmpty(nameof(value));

        var trimmedValue = value.Trim();

        if (trimmedValue.Length == default) throw new CountryTitleIsWhiteSpacesException(nameof(value));
        
        Value = value;
    }
    
    public string Value { get; private init; }
    
    public static implicit operator CountryTitle(string value)
    {
        return new CountryTitle(value);
    }
}