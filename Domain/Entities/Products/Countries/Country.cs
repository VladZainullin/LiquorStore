// ReSharper disable ConvertToAutoPropertyWithPrivateSetter
// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable FieldCanBeMadeReadOnly.Local
using Domain.Entities.Products.Countries.Parameters;
using Domain.Entities.Products.Manufacturers;

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

    /// <summary>
    ///     Производители страны
    /// </summary>
    private readonly List<Manufacturer> _manufacturers = [];

    private Country()
    {
    }

    public Country(CreateCountryParameters parameters) : this()
    {
        SetTitle(new SetCountryTitleParameters
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
    
    private void SetTitle(SetCountryTitleParameters parameters)
    {
        _title = parameters.Title.Trim();
    }

    /// <summary>
    ///     Производители страны
    /// </summary>
    public IReadOnlyCollection<Manufacturer> Manufacturers => _manufacturers.AsReadOnly();
    
    public void AddManufacturers(AddManufacturersParameters parameters)
    {
        _manufacturers.AddRange(parameters.Manufacturers);
    }
}