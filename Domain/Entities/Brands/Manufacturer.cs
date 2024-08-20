using Domain.Entities.Brands.Parameters;

// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace Domain.Entities.Brands;

/// <summary>
///     Производитель
/// </summary>
public sealed class Manufacturer
{
    /// <summary>
    ///     Наименование производителя
    /// </summary>
    private string _title = default!;

    private Manufacturer()
    {
    }

    public Manufacturer(CreateBrandParameters parameters) : this()
    {
        Title = parameters.Title;
    }

    /// <summary>
    ///     Уникальный идентификатор производителя
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    ///     Наименование производителя
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Некоректно указано наименование производителя
    /// </exception>
    public string Title
    {
        get => _title;
        private set
        {
            if (string.IsNullOrWhiteSpace(value) && string.IsNullOrEmpty(value))
                throw new ArgumentOutOfRangeException(value, "Некоректное наименование производителя");

            _title = value.Trim();
        }
    }

    public void SetTitle(SetTitleParameters parameters)
    {
        Title = parameters.Title;
    }
}