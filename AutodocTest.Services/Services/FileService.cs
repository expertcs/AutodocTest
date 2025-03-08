using AutodocTest.Dal.Model;

using Microsoft.EntityFrameworkCore;

namespace AutodocTest.Services;

internal class FileService(DbContext dbContext) : IFileService
{
    private readonly DbContext _dbContext = dbContext;

    public Task<FileData?> GetFile(int id, CancellationToken token)
        => _dbContext.Set<FileData>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

    public Task<int> AddFile(FileData file, CancellationToken token)
        => _dbContext.AddEntity(file, token);

    public Task<int> DeleteFile(int id, CancellationToken token)
        => _dbContext.DeleteEntity<FileData>(id, token);
}
