using AutodocTest.Dal.Model;

using Microsoft.EntityFrameworkCore;

namespace AutodocTest.Services;

internal static class DbExtensions
{
    public static Task<bool> IsExists<T>(this DbContext dbContext, int id, CancellationToken token)
        where T : BaseEntity
        => dbContext.Set<T>().AnyAsync(x => x.Id == id, token);

    public static Task<int> AddEntity<T>(this DbContext dbContext, T entity, CancellationToken token)
        where T : BaseEntity
    {
        entity.Id = default;
        dbContext.Add(entity);
        return dbContext.SaveChangesAsync(token);
    }

    public static Task<int> UpdateEntity<T>(this DbContext dbContext, T entity, CancellationToken token)
        where T : BaseEntity
    {
        dbContext.Entry(entity).State = EntityState.Modified;
        return dbContext.SaveChangesAsync(token);
    }

    public static Task<int> DeleteEntity<T>(this DbContext dbContext, int id, CancellationToken token)
        where T : BaseEntity, new()
    {
        var entity = new T { Id = id };
        dbContext.Entry(entity).State = EntityState.Deleted;
        return dbContext.SaveChangesAsync(token);
    }
}
