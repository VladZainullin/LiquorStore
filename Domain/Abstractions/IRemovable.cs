namespace Domain.Abstractions;

public interface IRemovable<in TParameters> where TParameters : struct
{
    public DateTimeOffset? RemovedAt { get; }

    public bool IsRemove { get; }
    
    void Remove(TParameters parameters);
}