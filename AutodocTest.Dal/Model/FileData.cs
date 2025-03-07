using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Microsoft.EntityFrameworkCore;

namespace AutodocTest.Dal.Model;

[Table("file_data")]
[Comment("Файл")]
public class FileData : BaseEntity
{
    [Required]
    [JsonIgnore]
    public TaskInfo TaskInfo { get; set; } = null!;

    [JsonIgnore]
    public int TaskInfoId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    [Column(TypeName = "varbinary(MAX)")]
    [JsonIgnore]
    public byte[] Body { get; set; } = null!;
}


