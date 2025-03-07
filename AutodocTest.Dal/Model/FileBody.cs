using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutodocTest.Dal.Model;

[Table("file_data")]
public class FileBody : FileData
{
    [Required]
    [Column(TypeName = "varbinary(MAX)")]
    public byte[] Body { get; set; } = null!;
}