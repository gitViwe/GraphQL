using System.ComponentModel.DataAnnotations;

namespace Domain;

public class OverwatchSuperHeroRole
{
    [Key]
    public int Id { get; set; }
    public string Key { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
