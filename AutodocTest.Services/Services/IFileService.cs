
using AutodocTest.Dal.Model;

namespace AutodocTest.Services
{
    public interface IFileService
    {
        Task<int> AddFile(FileData file, CancellationToken token);
        Task<int> DeleteFile(int id, CancellationToken token);
        Task<FileData?> GetFile(int id, CancellationToken token);
    }
}