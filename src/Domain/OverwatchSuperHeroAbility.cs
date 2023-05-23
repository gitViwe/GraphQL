using System.ComponentModel.DataAnnotations;

namespace Domain;

public class OverwatchSuperHeroAbility
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public OverwatchSuperHeroVideo Video { get; set; } = new();
}
