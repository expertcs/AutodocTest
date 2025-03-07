//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace AutodocTest.Dal.Model;

//[Table("file_data")]
//public class FileBody : BaseEntity
//{
//    [ForeignKey(nameof(Id))]
//    public FileData File { get; set; } = null!;

//    //[Required]
//    //public TaskInfo TaskInfo { get; set; } = null!;

//    //[Required]
//    //[StringLength(50)]
//    //public string Name { get; set; } = null!;

//    [Required]
//    [Column(TypeName = "varbinary(MAX)")]
//    public byte[] Body { get; set; } = null!;
//}