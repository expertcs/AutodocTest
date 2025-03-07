using AutodocTest.Dal.DataAccess;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutodocTest.Dal;

public static class ServicesExtensions
{
    public static IServiceCollection AddTestDbContext(
        this IServiceCollection services,
        IConfiguration config,
        string name)
        => services.AddDbContext<DbContext, TestDbContext>(options =>
        {
            var cs = config.GetConnectionString(name);
            options.UseSqlServer(cs);
        });
}
