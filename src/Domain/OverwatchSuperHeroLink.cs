using System.ComponentModel.DataAnnotations;

namespace Domain;

public class OverwatchSuperHeroLink
{
    [Key]
    public int Id { get; set; }
    public string Mp4 { get; set; } = string.Empty;
    public string Webm { get; set; } = string.Empty;
}
