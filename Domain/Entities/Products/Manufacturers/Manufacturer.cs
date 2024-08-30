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
    ///     Описание производителя
    /// </summary>
    private string _description = default!;

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
        
        SetDescription(new SetManufacturerDescriptionParameters
        {
            Description = parameters.Description
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
        _title = parameters.Title.Trim();
    }

    /// <summary>
    ///     Описание производителя
    /// </summary>
    public string Description => _description;

    public void SetDescription(SetManufacturerDescriptionParameters parameters)
    {
        _description = parameters.Description;
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