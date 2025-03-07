using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace AutodocTest.Dal.Model;

[Table("file_data")]
[Comment("Файл")]
public class FileData : BaseEntity
{
    [Required]
    public virtual TaskInfo TaskInfo { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;
}
