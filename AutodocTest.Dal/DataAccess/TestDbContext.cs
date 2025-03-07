using AutodocTest.Dal.Model;

using Microsoft.EntityFrameworkCore;

namespace AutodocTest.Dal.DataAccess;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<FileBody> Files { get; set; }

    public DbSet<TaskInfo> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<FileBody>(b =>
        //{
        //    b.HasOne(x => x.File).WithOne().HasForeignKey<FileData>(x => x.Id);
        //});
        base.OnModelCreating(modelBuilder);
    }
}
