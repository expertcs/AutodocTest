using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace AutodocTest.Dal.Model;

[Table("task_info")]
[Comment("Задача")]
public class TaskInfo : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string State { get; set; } = null!;

    public virtual List<FileData> Files { get; set; } = null!;
}
