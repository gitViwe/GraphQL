using System.ComponentModel.DataAnnotations;

namespace Domain;

public class OverwatchSuperHero
{
    [Key]
    public int Id { get; set; }
    public string Key { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Portrait { get; set; } = string.Empty;

    public OverwatchSuperHeroDetail Detail { get; set; } = new();
}
