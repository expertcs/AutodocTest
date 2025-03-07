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
        => _dbContext.Set<FileBody>().AsNoTracking().Include(x => x.File).SingleOrDefaultAsync(x => x.Id == id);

    public async Task<int> AddFile(FileBody file, CancellationToken token)
    {
        //var task = await _taskService.GetTask(file.File.TaskInfo.Id, token);
        //if (task == null)
        //    return 0;
        //var x = _dbContext.Attach(task);
        //file.File.TaskInfo = task;
        //_dbContext.Add(file.File);
        return await _dbContext.AddEntity(file, token);
    }

    public Task<int> DeleteFile(int id, CancellationToken token)
        => _dbContext.DeleteEntity<FileBody>(id, token);
}
