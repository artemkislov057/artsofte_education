using System.ComponentModel.DataAnnotations;
using Education.DataBase.Enums;

namespace Education.DataBase.Entities;

public class LoadedFile
{
    [Key]
    public Guid FileGuid { get; set; }
    public FileType FileType { get; set; }
    public string FileExtension { get; set; } = null!;
    public string ContentType { get; set; } = null!;
}