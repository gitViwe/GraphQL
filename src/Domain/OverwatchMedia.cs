using System.ComponentModel.DataAnnotations;

namespace Domain;

public class OverwatchMedia
{
    [Key]
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
}
