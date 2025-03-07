using Microsoft.Extensions.DependencyInjection;

namespace AutodocTest.Services;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
        => services
        .AddTransient<IFileService, FileService>()
        .AddTransient<ITaskService, TaskService>();
}
