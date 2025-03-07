using AutodocTest.Dal.Model;

using Microsoft.EntityFrameworkCore;

namespace AutodocTest.Services;

internal class FileService : IFileService
{
    private readonly DbContext _dbContext;
    private readonly ITaskService _taskService;

    public FileService(
        DbContext dbContext,
        ITaskService taskService)
    {
        _dbContext = dbContext;
        _taskService = taskService;
    }

    public Task<FileData?> GetFile(int id, CancellationToken token)
        => _dbContext.Set<FileData>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

    public async Task<int> AddFile(FileData file, CancellationToken token)
    {
        return await _dbContext.AddEntity(file, token);
    }

    public Task<int> DeleteFile(int id, CancellationToken token)
        => _dbContext.DeleteEntity<FileData>(id, token);
}
