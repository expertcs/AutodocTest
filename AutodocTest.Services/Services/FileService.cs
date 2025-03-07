using AutodocTest.Dal.Model;

using Microsoft.EntityFrameworkCore;

namespace AutodocTest.Services;

internal class FileService : IFileService
{
    private readonly DbContext _dbContext;

    public FileService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<FileBody?> GetFile(int id, CancellationToken token)
        => _dbContext.Set<FileBody>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

    public Task<int> AddFile(FileBody file, CancellationToken token)
        => _dbContext.AddEntity(file, token);

    public Task<int> DeleteFile(int id, CancellationToken token)
        => _dbContext.DeleteEntity<FileBody>(id, token);
}
