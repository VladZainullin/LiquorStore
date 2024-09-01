namespace Domain.Entities.Products.Countries.ValueObjects.CountryTitles.Exceptions;

public sealed class CountryTitleIsWhiteSpacesException(string parameterName) : 
    ArgumentOutOfRangeException(parameterName, "Наименование страны не может состоять из пробелов");