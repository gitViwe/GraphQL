using System.ComponentModel.DataAnnotations;

namespace Domain;

public class OverwatchSuperHeroVideo
{
    [Key]
    public int Id { get; set; }
    public string Thumbnail { get; set; } = string.Empty;
    public OverwatchSuperHeroLink Link { get; set; } = new();
}
