// ReSharper disable ConvertToAutoProperty
// ReSharper disable ConvertToAutoPropertyWithPrivateSetter
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local
using Domain.Entities.Products.Countries;
using Domain.Entities.Products.Manufacturers.Parameters;

namespace Domain.Entities.Products.Manufacturers;

/// <summary>
///     Производитель
/// </summary>
public sealed class Manufacturer
{
    /// <summary>
    ///     Уникальный идентификатор производителя
    /// </summary>
    private Guid _id = default!;
    
    /// <summary>
    ///     Наименование производителя
    /// </summary>
    private string _title = default!;

    /// <summary>
    ///     Страна производителя
    /// </summary>
    private Country _country = default!;

    private Manufacturer()
    {
    }

    public Manufacturer(CreateManufacturerParameters parameters) : this()
    {
        SetTitle(new SetManufacturerTitleParameters
        {
            Title = parameters.Title
        });
    }

    /// <summary>
    ///     Уникальный идентификатор производителя
    /// </summary>
    public Guid Id => _id;

    /// <summary>
    ///     Наименование производителя
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Некоректно указано наименование производителя
    /// </exception>
    public string Title => _title;

    public void SetTitle(SetManufacturerTitleParameters parameters)
    {
        if (string.IsNullOrWhiteSpace(parameters.Title) && string.IsNullOrEmpty(parameters.Title))
            throw new ArgumentOutOfRangeException(parameters.Title, "Некоректное наименование производителя");

        _title = parameters.Title.Trim();
    }

    /// <summary>
    ///     Страна производителя
    /// </summary>
    public Country Country => _country;

    public void SetCountry(SetManufacturerCountryParameters parameters)
    {
        _country = parameters.Country;
    }
}