using System.ComponentModel.DataAnnotations.Schema;
using Domain.MeasurementUnitPositions;
using Domain.MeasurementUnitPositions.Parameters;
using Domain.MeasurementUnits.Parameters;

namespace Domain.MeasurementUnits;

public sealed class MeasurementUnit
{
    private Guid _id;
    
    private string _title = default!;

    private readonly List<MeasurementUnitPosition> _measurementUnitPositions = [];
    
    private MeasurementUnit()
    {
    }

    public MeasurementUnit(CreateMeasurementUnitParameters parameters) : this()
    {
        _id = Guid.NewGuid();
        
        SetTitle(new SetMeasurementUnitTitleParameters
        {
            Title = parameters.Title
        });
    }

    public Guid Id => _id;

    public string Title => _title;

    public void SetTitle(SetMeasurementUnitTitleParameters parameters)
    {
        _title = parameters.Title;
    }

    public IReadOnlyCollection<MeasurementUnitPosition> MeasurementUnitPositions =>
        _measurementUnitPositions.AsReadOnly();

    public void AddPositions(AddPositionsToMeasurementUnitParameters parameters)
    {
        var resultMeasurementUnitPositions = parameters.MeasurementUnitPositions
            .ExceptBy(_measurementUnitPositions.Select(m => m.Value), m => m.Value)
            .DistinctBy(mup => mup.Value)
            .Select(m => new MeasurementUnitPosition(new CreateMeasurementUnitPositionParameters
            {
                Value = m.Value,
                MeasurementUnit = this
            }))
            .ToArray();
        
        foreach (var measurementUnitPosition in resultMeasurementUnitPositions)
        {
            _measurementUnitPositions.Add(measurementUnitPosition);
        }
    }

    public void RemovePositions(RemovePositionsFromMeasurementUnitParameters parameters)
    {
        var resultMeasurementUnits = _measurementUnitPositions
            .Intersect(parameters.MeasurementUnitPositions)
            .ToArray();
        
        foreach (var measurementUnitPosition in resultMeasurementUnits)
        {
            _measurementUnitPositions.Remove(measurementUnitPosition);
        }
    }
}