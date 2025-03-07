
using AutodocTest.Dal.Model;

namespace AutodocTest.Services
{
    public interface IFileService
    {
        Task<int> AddFile(FileBody file, CancellationToken token);
        Task<int> DeleteFile(int id, CancellationToken token);
        Task<FileBody?> GetFile(int id, CancellationToken token);
    }
}