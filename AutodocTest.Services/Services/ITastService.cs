
using AutodocTest.Dal.Model;

namespace AutodocTest.Services;

public interface ITaskService
{
    Task<int> AddTask(TaskInfo task, CancellationToken token);
    Task<int> DeleteTask(int id, CancellationToken token);
    Task<TaskInfo?> GetTask(int id, CancellationToken token);
    Task<TaskInfo[]> GetTaskList(PageInfo? page, CancellationToken token);
    Task<int> UpdateTask(TaskInfo task, CancellationToken token);
}