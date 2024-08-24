using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Persistence;

internal sealed class DbSetAdapter<T>(DbContext context) : IDbSet<T> where T : class
{
    private readonly DbSet<T> _set = context.Set<T>();
    
    public void Update(T entity)
    {
        _set.Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        _set.UpdateRange(entities);
    }

    public void Add(T entity)
    {
        _set.Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _set.AddRange(entities);
    }

    public void Remove(T entity)
    {
        _set.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _set.RemoveRange(entities);
    }
}