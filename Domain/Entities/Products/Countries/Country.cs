using Domain.Entities.Products.Countries.Exceptions;
using Domain.Entities.Products.Countries.Parameters;
using Domain.Entities.Products.Manufacturers.Parameters;

// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace Domain.Entities.Products.Countries;

/// <summary>
///     Страна
/// </summary>
public sealed class Country
{
    /// <summary>
    ///     Уникальный идентификатор страны
    /// </summary>
    private Guid _id = default!;
    
    /// <summary>
    ///     Наименование страны
    /// </summary>
    private string _title = default!;

    private Country()
    {
    }

    public Country(CreateCountryParameters parameters) : this()
    {
        SetTitle(new SetManufacturerTitleParameters
        {
            Title = parameters.Title
        });
    }

    /// <summary>
    ///     Уникальный идентификатор страны
    /// </summary>
    public Guid Id => _id;

    /// <summary>
    ///     Наименование страны
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Некоректно указано наименование страны
    /// </exception>
    public string Title => _title;
    
    private void SetTitle(SetManufacturerTitleParameters parameters)
    {
        if (string.IsNullOrWhiteSpace(parameters.Title) && string.IsNullOrEmpty(parameters.Title))
            throw new CountryTitleIsEmptyOrNullException(parameters.Title);

        _title = parameters.Title.Trim();
    }
}