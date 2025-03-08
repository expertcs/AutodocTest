using AutodocTest.Dal.Model;

using Microsoft.EntityFrameworkCore;

namespace AutodocTest.Services;

internal class TaskService(DbContext dbContext) : ITaskService
{
    private readonly DbContext _dbContext = dbContext;

    private IQueryable<TaskInfo> GetQuery()
        => _dbContext
        .Set<TaskInfo>()
        .Select(x => new TaskInfo
        {
            Id = x.Id,
            Name = x.Name,
            State = x.State,
            Files = x.Files.Select(f => new FileData
            {
                Id = f.Id,
                Name = f.Name
            }).ToArray()
        })
        ;

    public Task<TaskInfo[]> GetTaskList(PageInfo? page, CancellationToken token)
    {
        var q = GetQuery();
        if (page != null)
            q = q.OrderBy(x => x.Id).Skip(page.Start).Take(page.Count);
        return q.ToArrayAsync(token);
    }

    public Task<TaskInfo?> GetTask(int id, CancellationToken token)
        => GetQuery().SingleOrDefaultAsync(x => x.Id == id, token);

    public Task<int> AddTask(TaskInfo entity, CancellationToken token)
        => _dbContext.AddEntity(entity, token);

    public Task<int> UpdateTask(TaskInfo entity, CancellationToken token)
        => _dbContext.UpdateEntity(entity, token);

    public Task<int> DeleteTask(int id, CancellationToken token)
        => _dbContext.DeleteEntity<TaskInfo>(id, token);
}
