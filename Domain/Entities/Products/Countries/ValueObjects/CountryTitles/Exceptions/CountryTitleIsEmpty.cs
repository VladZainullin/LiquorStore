namespace Domain.Entities.Products.Countries.ValueObjects.CountryTitles.Exceptions;

public sealed class CountryTitleIsEmpty(string parameterName) : 
    ArgumentOutOfRangeException(parameterName, "Наименование страны не может быть пустым");