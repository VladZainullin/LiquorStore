namespace Domain.Entities.Countries.Exceptions;

public sealed class CountryTitleIsEmptyOrNullException(string name)
    : ArgumentOutOfRangeException(name, "Некоректное наименование страны");