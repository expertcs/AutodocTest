using AutodocTest.Dal.Model;

using Microsoft.EntityFrameworkCore;

namespace AutodocTest.Dal.DataAccess;

public class TestDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<FileData> Files { get; set; }

    public DbSet<TaskInfo> Tasks { get; set; }
}
